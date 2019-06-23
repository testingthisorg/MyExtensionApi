using Assassins.DataAccess.Repositories;
using Assassins.DataAccess.Repositories.AppUsers;
using Assassins.DataModels.AdSets;
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
    [Route("api/v1/aa-adsets")]
    [ApiController]
    public class AdSetController : Controller
    {
        private readonly IAdSetRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public AdSetController(IAdSetRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        [HttpGet("{owner_id}/adset-ids")]
        public JsonResult GetAdAccountIds(long owner_id)
        {
            var ids = _repo.GetAdsetIdsByOwnerId(owner_id);
            return Json(ids);
        }
        [HttpPost("")]
        public JsonResult ProcessAdSets([FromBody]List<object> adsets)
        {
            try
            {
                // get sync entity
                var email = UserClaimHelpers.Email(User.Identity);
                var user = _userRepo.GetAppUserByEmail(email);
                var dataSyncEntity = _userRepo.GetCurrentDataSync(user.AppUserId);
                var newAdsets = DataModel.ParseCollection<AdSet>(adsets);
                var dateRecorded = DateTime.UtcNow;
                if (user == null)
                    throw new Exception("We don't seem to be able to locate your account.  Please contact support for assistance.");


                // create new regions if they do not exist in our system
                var newRegions = new Dictionary<int, Region>();
                var currentItems = _repo.GetAdSetByUserId(user.AppUserId);
                //  var targetings = currentItems.Select(k => k.targeting).ToDictionary(k => k.adset_id, m => m);
                //var newTargets = new Dictionary<long, Targeting>();
                //    var geolocations = targetings.Values.Select(k => k.geo_locations).ToDictionary(k => k.adset_id, m => m);
                var regions = _repo.GetRegions();
                var toRemoveMaps = new List<GeolocationRegionMap>(10);
                foreach (var item in newAdsets)
                {
                    item.AppUserDataSyncId = dataSyncEntity.Id;
                    item.DateRecorded = dateRecorded;
                    //if (!targetings.ContainsKey(item.id) && !newTargets.ContainsKey(item.id))
                    //    newTargets.Add(item.id, item.targeting);
                    item.targeting.adset_id = item.id;
                    item.targeting.AppUserDataSyncId = dataSyncEntity.Id;
                    item.targeting.DateRecorded = dateRecorded;

                    item.targeting.geo_locations.adset_id = item.id;
                    item.targeting.geo_locations.AppUserDataSyncId = dataSyncEntity.Id;
                    item.targeting.geo_locations.DateRecorded = dateRecorded;
                    //if (geolocations.ContainsKey(item.targeting.adset_id))
                    //    item.targeting.geo_locations.adset_id = geolocations[item.targeting.adset_id].adset_id;

                    item.targeting.geo_locations.region_maps = new List<GeolocationRegionMap>(10);
                    foreach (var region in item.targeting.geo_locations.regions)
                    {
                        if (!regions.ContainsKey(region.key) && !newRegions.ContainsKey(region.key))
                            newRegions.Add(region.key, region);

                        var currentItem = currentItems.FirstOrDefault(k => k.id == item.id);
                        if (currentItem != null)
                        {
                            var currentRegions = currentItem.targeting.geo_locations.region_maps;
                            var incomingRegions = item.targeting.geo_locations.regions;

                            var curRegionKeys = currentRegions.Select(k => k.key).ToList();
                            var incomingRegKeys = incomingRegions.Select(k => k.key).ToList();

                            var toAddRegKeyMaps = incomingRegKeys.Except(curRegionKeys);
                            var toRemoveRegKeyMaps = curRegionKeys.Except(incomingRegKeys);

                            foreach (var keyMap in toAddRegKeyMaps)
                            {
                                item.targeting.geo_locations.region_maps.Add(
                                            new GeolocationRegionMap() { key = keyMap, AppUserDataSyncId = dataSyncEntity.Id, DateRecorded = dateRecorded });
                            }
                            foreach (var keyMap in toRemoveRegKeyMaps)
                            {
                                var map = item.targeting.geo_locations.region_maps.FirstOrDefault(k => k.key == keyMap);
                                if (map != null)
                                    toRemoveMaps.Add(map);
                            }
                        }
                        else
                            item.targeting.geo_locations.region_maps.Add(
                                new GeolocationRegionMap() { key = region.key, AppUserDataSyncId = dataSyncEntity.Id, DateRecorded = dateRecorded });
                    }
                }




                var currIds = currentItems.Select(k => k.id).ToList();
                var newIds = newAdsets.Select(k => k.id).ToList();

                var toAddIds = newIds.Except(currIds).ToList();
                var toUpdateIds = newIds.Intersect(currIds).ToList();
                var toDeleteIds = currIds.Except(newIds).ToList();


                var toAdd = newAdsets.Where(k => toAddIds.Contains(k.id)).ToList();
                var toUpdate = newAdsets.Where(k => toUpdateIds.Contains(k.id)).ToList();
                var toDelete = currentItems.Where(k => toDeleteIds.Contains(k.id)).ToList();

                var historyItems = new List<_AdSetHistoryItem>(newAdsets.Count);
                var tgtHistoryItems = new List<_TargetingHistoryItem>(newAdsets.Count);
                var geolocHistoryItems = new List<_GeolocationHistoryItem>(newAdsets.Count);
                var geolocMapHistoryItems = new List<_GeolocationRegionMapHistoryItem>(newAdsets.Count);
                foreach (var item in newAdsets)
                {
                    var newAsHi = (_AdSetHistoryItem)item.CreateHistoryItem<_AdSetHistoryItem>();
                    newAsHi.AppUserDataSyncId = dataSyncEntity.Id;
                    newAsHi.DateRecorded = dateRecorded;
                    historyItems.Add(newAsHi);

                    var newTgtHi = (_TargetingHistoryItem)item.targeting.CreateHistoryItem<_TargetingHistoryItem>();
                    newTgtHi.AppUserDataSyncId = dataSyncEntity.Id;
                    newTgtHi.DateRecorded = dateRecorded;
                    tgtHistoryItems.Add(newTgtHi);

                    var glocHi = (_GeolocationHistoryItem)item.targeting.geo_locations.CreateHistoryItem<_GeolocationHistoryItem>();
                    glocHi.AppUserDataSyncId = dataSyncEntity.Id;
                    glocHi.DateRecorded = dateRecorded;
                    geolocHistoryItems.Add(glocHi);

                    foreach (var regMap in item.targeting.geo_locations.region_maps)
                    {
                        var geolocRegMapHi = (_GeolocationRegionMapHistoryItem)regMap.CreateHistoryItem<_GeolocationRegionMapHistoryItem>();
                        geolocRegMapHi.AppUserDataSyncId = dataSyncEntity.Id;
                        geolocRegMapHi.DateRecorded = dateRecorded;
                        geolocRegMapHi.adset_id = item.id;
                        geolocMapHistoryItems.Add(geolocRegMapHi);
                    }
                }
                _repo.AddSetHistoryItems(historyItems);
                _repo.AddTargetHistoryItems(tgtHistoryItems);
                _repo.AddGeolocationHistoryItems(geolocHistoryItems);
                _repo.AddGeolocationRegionMapHistoryItems(geolocMapHistoryItems);

                dataSyncEntity.AdSetsCompleted = true;

                _repo.RemoveGelocationRegionMaps(toRemoveMaps);
                _repo.AddRegions(newRegions.Values);
                _repo.AddAdSets(toAdd);
                _repo.UpdateAdSets(toUpdate);
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
