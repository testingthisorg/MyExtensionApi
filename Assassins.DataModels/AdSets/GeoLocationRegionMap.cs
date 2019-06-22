using Assassins.DataModels.Interfaces;

namespace Assassins.DataModels.AdSets
{
    public class GeolocationRegionMap : IDataModel
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
    public class GeolocationRegionMapViewModel : IDataViewModel
    {
        public long adset_id { get; set; }
        public virtual Geolocation GeoLocation { get; set; }
        public int key { get; set; }
        public virtual Region Region { get; set; }

        public IDataModel ToModel()
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
