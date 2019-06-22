using Assassins.DataAccess.Repositories;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataModels.Ads;
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
    [Route("api/v1/aa-ads")]
    [ApiController]
    public class AdController : Controller
    {
        private readonly IAdRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public AdController(IAdRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        [HttpGet("{owner_id}/ad-ids")]
        public JsonResult GetAdAccountIds(long owner_id)
        {
            var ids = _repo.GetAdIdsByOwnerId(owner_id);
            return Json(ids);
        }
        [HttpPost("")]
        public JsonResult ProcessAds([FromBody]List<object> ads)
        {
            try
            {
                var email = UserClaimHelpers.Email(User.Identity);
                var user = _userRepo.GetAppUserByEmail(email);
                var dataSyncEntity = _userRepo.GetCurrentDataSync(user.AppUserId);
                var newAds = IDataModel.ParseCollection<Ad>(ads);
                if (user == null)
                    throw new Exception("We don't seem to be able to locate your account.  Please contact support for assistance.");

                var dateRecorded = DateTime.UtcNow;
                foreach (var item in newAds)
                {
                    item.AppUserDataSyncId = dataSyncEntity.Id;
                    item.DateRecorded = dateRecorded;

                }
                var currentItems = _repo.GetAdsByUserId(user.AppUserId);

                var currIds = currentItems.Select(k => k.id).ToList();
                var newIds = newAds.Select(k => k.id).ToList();

                var toAddIds = newIds.Except(currIds).ToList();
                var toUpdateIds = newIds.Intersect(currIds).ToList();
                var toDeleteIds = currIds.Except(newIds).ToList();


                var toAdd = newAds.Where(k => toAddIds.Contains(k.id)).ToList();
                var toUpdate = newAds.Where(k => toUpdateIds.Contains(k.id)).ToList();
                var toDelete = currentItems.Where(k => toDeleteIds.Contains(k.id)).ToList();


                dataSyncEntity.AdsCompleted = true;

                _repo.AddAds(toAdd);
                _repo.UpdateAds(toUpdate);
                _userRepo.UpdateDataSync(dataSyncEntity);

                if (_repo.Base.SaveAll(User))
                {
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
