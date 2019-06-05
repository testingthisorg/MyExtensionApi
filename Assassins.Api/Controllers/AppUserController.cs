using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : Controller
    {
        private IAppUserRepository _userRepo;
        private IAuthAdapter _authAdapter;
        public UserController(IAppUserRepository userRepo, IAuthAdapter authAdapter)
        {
            _userRepo = userRepo;
            _authAdapter = authAdapter;
        }
        [HttpGet("")]
        public JsonResult GetUsers()
        {
            try
            {
                var models = _userRepo.GetUsers();
                var vms = models.Select(k => k.ToViewModel());
                return Json(vms);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(MsgFactory.Error(ex));
            }
        }

        [HttpGet("{id}")]
        public JsonResult GetUser(int id)
        {
            var model = _userRepo.GetUserById(id);
            var vm = model.ToViewModel();
            return Json(vm);
        }

        [HttpPost("")]
        public async Task<JsonResult> AddUser([FromBody] SignUpViewModel vm)
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
                        UserRoles = new List<AppUserRole> { new AppUserRole { RoleId = vm.RoleId } }
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
        [HttpPatch("")]
        public JsonResult UpdateUser([FromBody] AppUserViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userRepo.UpdateUser(vm.AppUserId, vm.FirstName, vm.LastName, vm.AdAssassinId);

                    if (_userRepo.Base.SaveAll(User))
                    {
                        Response.StatusCode = (int)HttpStatusCode.OK;
                        var newVm = user.ToViewModel();
                        return Json(newVm);
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        return Json(MsgFactory.Error("Unable to save user!"));
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
