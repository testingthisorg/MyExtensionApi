using Assassins.Api.AuthAdapters;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataAccess.Repositories.Campaigns;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using Assassins.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assassins.Api.Controllers
{
    [Authorize]
    [Route("api/v1/aa-campaigns")]
    [ApiController]
    public class CampaignController : Controller
    {
        private readonly ICampaignRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public CampaignController(ICampaignRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        [HttpGet("")]
        public JsonResult GetCampaigns()
        {
            try
            {
                var email = UserClaimHelpers.Email(User.Identity);
                var models = _repo.GetCampaignsByUserEmail(email);
                var vms = models.Select(k => k.ToViewModel());
                return Json(vms);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(MsgFactory.Error(ex));
            }
        }

        [HttpGet("{campaign_id}")]
        public JsonResult GetCampaign(long campaign_id)
        {
            var model = _repo.GetCampaignById(campaign_id);
            var vm = model.ToViewModel();
            return Json(vm);
        }
        [HttpGet("{owner_id}/campaign-ids")]
        public JsonResult GetCampaignIds(long owner_id)
        {
          //  var email = UserClaimHelpers.Email(User.Identity);
          //  var ids = _repo.GetCampaignIdsByUserEmail(email);
            var ids = _repo.GetCampaignIdsByOwnerId(owner_id);
            return Json(ids);
        }
        [HttpPost("")]
        public JsonResult ProcessCampaigns([FromBody]List<object> campaigns)
        {
            try
            {
                // get sync entity
                var email = UserClaimHelpers.Email(User.Identity);
                var user = _userRepo.GetAppUserByEmail(email);
                var dataSyncEntity = _userRepo.GetCurrentDataSync(user.AppUserId);
                var newCampaigns = DataModel.ParseCollection<Campaign>(campaigns);
                if (user == null)
                    throw new Exception("We don't seem to be able to locate your account.  Please contact support for assistance.");

                var dateRecorded = DateTime.UtcNow;
                foreach (var item in newCampaigns)
                {
                    item.AppUserId = user.AppUserId;
                    item.AppUserDataSyncId = dataSyncEntity.Id;
                    item.DateRecorded = dateRecorded;
                }

                // reconcile accounts

                var currentItems = _repo.GetCampaigns(user.AppUserId);

                var currIds = currentItems.Select(k => k.id).ToList();
                var newIds = newCampaigns.Select(k => k.id).ToList();

                var toAddIds = newIds.Except(currIds).ToList();
                var toUpdateIds = newIds.Intersect(currIds).ToList();
                var toDeleteIds = currIds.Except(newIds).ToList();


                var toAdd = newCampaigns.Where(k => toAddIds.Contains(k.id)).ToList();
                var toUpdate = newCampaigns.Where(k => toUpdateIds.Contains(k.id)).ToList();
                var toDelete = currentItems.Where(k => toDeleteIds.Contains(k.id)).ToList();


                // create a copy for the history
                var historyItems = new List<_CampaignHistoryItem>(newCampaigns.Count);
                foreach (var item in newCampaigns)
                    historyItems.Add((_CampaignHistoryItem)item.CreateHistoryItem<_CampaignHistoryItem>());
                _repo.AddCampaignHistoryItems(historyItems);

                dataSyncEntity.CampaignsCompleted = true;

                _repo.AddCampaigns(toAdd);
                _repo.UpdateCampaigns(toUpdate);
                _userRepo.UpdateDataSync(dataSyncEntity);

                if (_repo.Base.SaveAll(User))
                {
                    // send back account ids for campaign syncing
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(newIds);
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
