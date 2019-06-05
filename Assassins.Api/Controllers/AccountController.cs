using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assassins.Api.AuthAdapters;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataModels.Users;
using Assassins.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace Assassins.Api.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAppUserRepository _userRepo;

        private ILogger<AccountController> _logger;
        private IAuthAdapter _authAdapter;
        public AccountController(IAppUserRepository userRepo, ILogger<AccountController> logger, IAuthAdapter authAdapter)
        {
            _logger = logger;
            _authAdapter = authAdapter;
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<JsonResult> Login([FromBody] LoginViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // check if any values tracked in Auth0 have changed
                    LoginResponseViewModel responseVM = await _authAdapter.Authenticate(vm);
                    var user = _userRepo.GetUserByExternalId(responseVM.ExternalId);
                    if (user == null)
                    {
                        user = _userRepo.GetUserByEmail(vm.Email);
                        if (user == null)
                        {
                            throw new Exception("Unable to locate user");
                        }
                        else
                        {
                            //update with externalId
                            user.ExternalId = responseVM.ExternalId;
                            _userRepo.Base.SaveAll(User);
                        }
                    }
                    responseVM.AppUserId = user.AppUserId;
                    responseVM.AvatarUrl = user.AvatarUrl;
                    responseVM.Email = user.Email;
                    responseVM.FullName = user.FirstName + " " + user.LastName;
                    responseVM.AdAssassinId = user.AdAssassinId;
                    responseVM.Roles = user.UserRoles.Select(k => k.Role.Name).ToArray();
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(responseVM);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(MsgFactory.Error(ModelState));
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(MsgFactory.Error(ex));
            }
        }
        [HttpGet("refresh/{refreshToken}")]
        public async Task<JsonResult> Refresh(string refreshToken)
        {
            try
            {
                LoginRefreshViewModel responseVM = await _authAdapter.RefreshAuth(refreshToken);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(responseVM);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(MsgFactory.Error(ex));
            }
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<JsonResult> SignUp([FromBody] SignUpViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // check if any values tracked in Auth0 have changed
                    var extId = await _authAdapter.SignUpUser(vm);

                    // save to our db now
                    var user = new AppUser()
                    {
                        FirstName = vm.FirstName,
                        LastName = vm.LastName,
                        Email = vm.Email,
                        ExternalId = extId,
                        AvatarUrl = Avatars.GetAvatarUrl(vm.FirstName, vm.LastName, vm.Email),
                        IsDeleted = false,
                        IsSuspended = false,
                        UserRoles = new List<AppUserRole> { new AppUserRole { RoleId = 2 } } // default to free user
                    };

                    _userRepo.AddUser(user);
                    if (_userRepo.Base.SaveAll(User))
                    {
                        var newVm = user.ToViewModel();
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        return Json(newVm);
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(MsgFactory.Error("Unable to save new user"));
                    }

                }

                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(MsgFactory.Error(ModelState));
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(MsgFactory.Error(ex));
            }
        }
    }

}
