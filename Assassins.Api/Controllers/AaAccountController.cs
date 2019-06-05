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
using Assassins.DataAccess.Repositories.AaAccounts;
using Assassins.DataModels.AdAccounts;

namespace Assassins.Api.Controllers
{
    [Authorize]
    [Route("api/v1/aa-accounts")]
    [ApiController]
    public class AaAccountController : Controller
    {
        private IAaAccountRepository _repo;
        public AaAccountController(IAaAccountRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("")]
        public JsonResult GetAaAccounts()
        {
            try
            {
                var email = UserClaimHelpers.Email(User.Identity);
                var models = _repo.GetAdAccountsByUserEmail(email);
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
        public JsonResult GetAaAccount(int id)
        {
            var model = _repo.GetAdAccountById(id);
            var vm = model.ToViewModel();
            return Json(vm);
        }

        [HttpPost("")]
        public JsonResult ProcessAccountData([FromBody]List<object> accounts)
        {
            try
            {
                var parsedAccounts = AdAccount.ParseCollection(accounts);

                _repo.AddAdAccounts(parsedAccounts);
                if (_repo.Base.SaveAll(User))
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(MsgFactory.Success());
                }
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(MsgFactory.Error("Unable to process!"));
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(MsgFactory.Error(ex));
            }
        }
    }

}
