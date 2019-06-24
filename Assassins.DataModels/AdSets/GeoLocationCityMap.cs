using Assassins.DataModels.Interfaces;

namespace Assassins.DataModels.AdSets
{
    public class GeolocationCityMap : HistoryItem
    {
        public long adset_id { get; set; }
        public virtual Geolocation GeoLocation { get; set; }
        public int key { get; set; }
        public virtual City City { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationCityMapViewModel()
            {
                adset_id = adset_id,
                key = key
            };
            return vm;
        }
    }
    public class _GeolocationCityMapHistoryItem : HistoryItem
    {
        public long adset_id { get; set; }
        public int key { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationCityMapViewModel()
            {
                adset_id = adset_id,
                key = key
            };
            return vm;
        }
    }
    public class GeolocationCityMapViewModel : IDataViewModel
    {
        public long adset_id { get; set; }
        public virtual GeolocationViewModel GeoLocation { get; set; }
        public int key { get; set; }
        public virtual CityViewModel Region { get; set; }

        public DataModel ToModel()
        {
            var model = new GeolocationCityMap()
            {
                adset_id = adset_id,
                key = key
            };
            return model;
        }
    }
}
