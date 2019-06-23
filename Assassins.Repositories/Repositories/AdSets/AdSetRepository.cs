using System.Collections.Generic;
using System.Linq;
using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.AdSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assassins.DataAccess.Repositories
{
    public class AdSetRepository : BaseRepository, IAdSetRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        //private readonly string key = "ad-sets";
        public AdSetRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<AdSet> GetAdSetByCampaignId(long campaign_id)
        {
            var items = _context.AdSets
                                .AsNoTracking()
                                .Where(k => k.campaign_id == campaign_id)
                                 .ToList();
            return items;
        }

        public ICollection<AdSet> GetAdSetByUserId(int appUserId)
        {
            var items = _context
                        .Campaigns.Where(k => k.AppUserId == appUserId)
                        .AsNoTracking()
                        .SelectMany(k => k.adsets)
                            .Include(k => k.targeting)
                                .ThenInclude(k => k.geo_locations)
                                    .ThenInclude(k => k.region_maps)
                        .ToList();
            return items;
        }

        public void AddAdSets(ICollection<AdSet> toAdd)
        {
            _context.AdSets.AddRange(toAdd);
        }

        public void UpdateAdSets(ICollection<AdSet> toUpdate)
        {
            _context.AdSets.UpdateRange(toUpdate);
        }

        public Dictionary<int, Region> GetRegions()
        {
            var regions = _context.Regions.ToDictionary(k => k.key, m => m);
            return regions;
        }

        public void AddRegions(ICollection<Region> newRegions)
        {
            _context.Regions.AddRange(newRegions);
        }

        public ICollection<long> GetAdsetIdsByOwnerId(long owner_id)
        {
            var items = _context.Campaigns.Where(k => k.AppUser.id == owner_id)
                                .SelectMany(k => k.adsets.Select(m => m.id))
                                .ToList();
            return items;
        }

        public ICollection<Targeting> GetTargetings(ICollection<long> adSetIds)
        {
            var items = _context.Targeting.Where(k => adSetIds.Contains(k.adset_id))
                                .ToList();
            return items;
        }

        public ICollection<Geolocation> GetGeolocations(ICollection<long> adSetIds)
        {
            var items = _context.Geolocations.Where(k => adSetIds.Contains(k.adset_id))
                    .ToList();
            return items;
        }

        public void RemoveGelocationRegionMaps(ICollection<GeolocationRegionMap> toRemoveMaps)
        {
            _context.GeolocationRegionMaps.RemoveRange(toRemoveMaps);
        }

        public void AddGeolocationHistoryItems(List<_GeolocationHistoryItem> geolocHistoryItems)
        {
            _context._GeolocationHistory.AddRange(geolocHistoryItems);
        }

        public void AddSetHistoryItems(List<_AdSetHistoryItem> historyItems)
        {
            _context._AdSetHistory.AddRange(historyItems);
        }

        public void AddTargetHistoryItems(List<_TargetingHistoryItem> tgtHistoryItems)
        {
            _context._TargetingHistory.AddRange(tgtHistoryItems);
        }

        public void AddGeolocationRegionMapHistoryItems(List<_GeolocationRegionMapHistoryItem> geolocMapHistoryItems)
        {
            _context._GeolocationRegionMapHistory.AddRange(geolocMapHistoryItems);
        }
    }
}
