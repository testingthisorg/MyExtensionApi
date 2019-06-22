using Assassins.DataAccess.Repositories;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataModels.Creatives;
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
    [Route("api/v1/aa-ad-creatives")]
    [ApiController]
    public class AdCreativeController : Controller
    {
        private readonly IAdCreativeRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public AdCreativeController(IAdCreativeRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        [HttpGet("{owner_id}/ad-creative-ids")]
        public JsonResult GetAdCreativeIds(long owner_id)
        {
            var ids = _repo.GetAdCreativeIdsByOwnerId(owner_id);
            return Json(ids);
        }
        [HttpPost("")]
        public JsonResult ProcessAdCreatives([FromBody]List<object> adcreatives)
        {
            try
            {
                var email = UserClaimHelpers.Email(User.Identity);
                var user = _userRepo.GetAppUserByEmail(email);
                var dataSyncEntity = _userRepo.GetCurrentDataSync(user.AppUserId);
                var newAds = IDataModel.ParseCollection<AdCreative>(adcreatives);
                var dateRecorded = DateTime.UtcNow;
                if (user == null)
                    throw new Exception("We don't seem to be able to locate your account.  Please contact support for assistance.");

                foreach (var item in newAds)
                {
                    item.AppUserDataSyncId = dataSyncEntity.Id;
                    item.DateRecorded = dateRecorded;
                }

                var currentItems = _repo.GetAdCreativesByUserId(user.AppUserId);

                var currIds = currentItems.Select(k => k.id).ToList();
                var newIds = newAds.Select(k => k.id).ToList();

                var toAddIds = newIds.Except(currIds).ToList();
                var toUpdateIds = newIds.Intersect(currIds).ToList();
                var toDeleteIds = currIds.Except(newIds).ToList();


                var toAdd = newAds.Where(k => toAddIds.Contains(k.id)).ToList();
                var toUpdate = newAds.Where(k => toUpdateIds.Contains(k.id)).ToList();
                var toDelete = currentItems.Where(k => toDeleteIds.Contains(k.id)).ToList();


                dataSyncEntity.CreativesCompleted = true;

                _repo.AddAdCreatives(toAdd);
                _repo.UpdateAdCreatives(toUpdate);
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
