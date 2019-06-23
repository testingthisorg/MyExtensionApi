using Assassins.DataModels.Interfaces;

namespace Assassins.DataModels.AdSets
{
    public class GeolocationRegionMap : HistoryItem
    {
        public long adset_id { get; set; }
        public virtual Geolocation GeoLocation { get; set; }
        public int key { get; set; }
        public virtual Region Region { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationRegionMapViewModel()
            {
                adset_id = adset_id,
                key = key
            };
            return vm;
        }
    }
    public class _GeolocationRegionMapHistoryItem : HistoryItem
    {
        public long adset_id { get; set; }
        //public virtual _GeolocationHistoryItem GeoLocation { get; set; }
        public int key { get; set; }
        //public virtual Region Region { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationRegionMapViewModel()
            {
                adset_id = adset_id,
                key = key
            };
            return vm;
        }
    }
    public class GeolocationRegionMapViewModel : IDataViewModel
    {
        public long adset_id { get; set; }
        public virtual Geolocation GeoLocation { get; set; }
        public int key { get; set; }
        public virtual Region Region { get; set; }

        public DataModel ToModel()
        {
            var model = new GeolocationRegionMap()
            {
                adset_id = adset_id,
                key = key
            };
            return model;
        }
    }
}
