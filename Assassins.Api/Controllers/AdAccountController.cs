using Assassins.DataAccess.Repositories.AdAccounts;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.Interfaces;
using Assassins.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Assassins.Api.Controllers
{
    [Authorize]
    [Route("api/v1/aa-accounts")]
    [ApiController]
    public class AdAccountController : Controller
    {
        private readonly IAdAccountRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public AdAccountController(IAdAccountRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        [HttpGet("")]
        public JsonResult GetAdAccounts()
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

        [HttpGet("{account_id}")]
        public JsonResult GetAdAccount(long account_id)
        {
            var model = _repo.GetAdAccountById(account_id);
            var vm = model.ToViewModel();
            return Json(vm);
        }
        [HttpGet("{owner_id}/account-ids")]
        public JsonResult GetAdAccountIds(long owner_id)
        {
            var ids = _repo.GetAccountIdsByOwnerId(owner_id);
            return Json(ids);
        }
        [HttpPost("")]
        public JsonResult ProcessAccountData([FromBody]List<object> accounts)
        {
            try
            {
                var newAccounts = DataModel.ParseCollection<AdAccount>(accounts);
                var email = UserClaimHelpers.Email(User.Identity);
                var user = _userRepo.GetAppUserByEmail(email);

                if (user == null)
                    throw new Exception("We don't seem to be able to locate your account.  Please contact support for assistance.");

                var userOwnedAccounts = newAccounts; // newAccounts.Where(k => k.owner == user.id).ToList();
                var dataSyncEntity = _userRepo.GetCurrentDataSync(user.AppUserId);
                var dateRecorded = DateTime.UtcNow;
                foreach (var item in userOwnedAccounts)
                {
                    item.DateRecorded = dateRecorded;
                    item.AppUserDataSyncId = dataSyncEntity.Id;
                }

                  var currentAccounts = _repo.GetAdAccountsByUserId(user.AppUserId);
               // var currentAccounts = _repo.GetAdAccountsByOwnerId(user.id.Value);

                var currAccntIds = currentAccounts.Select(k => k.account_id).ToList();
                var newAccntIds = userOwnedAccounts.Select(k => k.account_id).ToList();

                var toAddIds = newAccntIds.Except(currAccntIds).ToList();
                var toUpdateIds = newAccntIds.Intersect(currAccntIds).ToList();
                var toDeleteIds = currAccntIds.Except(newAccntIds).ToList();


                var toAdd = userOwnedAccounts.Where(k => toAddIds.Contains(k.account_id)).ToList();
                var toUpdate = userOwnedAccounts.Where(k => toUpdateIds.Contains(k.account_id)).ToList();
                var toDelete = currentAccounts.Where(k => toDeleteIds.Contains(k.account_id)).ToList();

                dataSyncEntity.AdAccountsCompleted = true;

                foreach (var item in toAdd)
                    item.AppUserId = user.AppUserId;
                foreach (var item in toUpdate)
                    item.AppUserId = user.AppUserId;

                // create a copy for the history
                var historyItems = new List<_AdAccountHistoryItem>(userOwnedAccounts.Count);
                foreach (var item in userOwnedAccounts)
                    historyItems.Add((_AdAccountHistoryItem)item.CreateHistoryItem<_AdAccountHistoryItem>());
                _repo.AddAdAccountHistoryItems(historyItems);

                _repo.AddAdAccounts(toAdd);
                _repo.UpdateAdAccounts(toUpdate);
                _userRepo.UpdateDataSync(dataSyncEntity);


                if (_repo.Base.SaveAll(User))
                {
                    // send back account ids for campaign syncing
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(newAccntIds);
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
