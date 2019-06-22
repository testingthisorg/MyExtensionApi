using Assassins.DataModels.AdSets;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories
{
    public interface IAdSetRepository
    {

        BaseRepository Base { get; }

        ICollection<AdSet> GetAdSetByCampaignId(long campaign_id);
        ICollection<AdSet> GetAdSetByUserId(int appUserId);
        void AddAdSets(ICollection<AdSet> toAdd);
        void UpdateAdSets(ICollection<AdSet> toUpdate);
        Dictionary<int, Region> GetRegions();
        void AddRegions(ICollection<Region> newRegions);
        ICollection<long> GetAdsetIdsByOwnerId(long owner_id);
        ICollection<Targeting> GetTargetings(ICollection<long> adSetIds);
        ICollection<Geolocation> GetGeolocations(ICollection<long> adSetIds);
        void RemoveGelocationRegionMaps(ICollection<GeolocationRegionMap> toRemoveMaps);
    }
}
