using Assassins.DataModels.Interfaces;
using System.Collections.Generic;

namespace Assassins.DataModels.AdSets
{
    public class Targeting : HistoryItem
    {
        //    public int AaId { get; set; }
        public int age_max { get; set; }
        public int age_min { get; set; }
        public long adset_id { get; set; }
        public virtual AdSet AdSet { get; set; }

        public Geolocation geo_locations { get; set; }
        public ICollection<string> publisher_platforms { get; set; }
        public ICollection<string> facebook_positions { get; set; }
        public ICollection<string> instagram_positions { get; set; }
        public ICollection<string> device_platforms { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new TargetingViewModel()
            {
                //  AaId = AaId,
                age_max = age_max,
                age_min = age_min,
                device_platforms = device_platforms,
                facebook_positions = facebook_positions,
                instagram_positions = instagram_positions,
                publisher_platforms = publisher_platforms,
            };
            if (geo_locations != null)
            {
                vm.geo_locations = (GeolocationViewModel)geo_locations.ToViewModel();
            }
            return vm;
        }
    }
    public class _TargetingHistoryItem : HistoryItem
    {
        //    public int AaId { get; set; }
        public int age_max { get; set; }
        public int age_min { get; set; }
        public long adset_id { get; set; }
        //public virtual AdSet AdSet { get; set; }

        //public Geolocation geo_locations { get; set; }
        public ICollection<string> publisher_platforms { get; set; }
        public ICollection<string> facebook_positions { get; set; }
        public ICollection<string> instagram_positions { get; set; }
        public ICollection<string> device_platforms { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new TargetingViewModel()
            {
                //  AaId = AaId,
                age_max = age_max,
                age_min = age_min,
                device_platforms = device_platforms,
                facebook_positions = facebook_positions,
                instagram_positions = instagram_positions,
                publisher_platforms = publisher_platforms,
            };
            //if (geo_locations != null)
            //{
            //    vm.geo_locations = (GeoLocationViewModel)geo_locations.ToViewModel();
            //}
            return vm;
        }
    }

    public class TargetingViewModel : IDataViewModel
    {
        //   public int AaId { get; set; }
        public long adset_id { get; set; }
        public int age_max { get; set; }
        public int age_min { get; set; }
        public GeolocationViewModel geo_locations { get; set; }
        public ICollection<string> publisher_platforms { get; set; }
        public ICollection<string> facebook_positions { get; set; }
        public ICollection<string> instagram_positions { get; set; }
        public ICollection<string> device_platforms { get; set; }

        public DataModel ToModel()
        {
            var model = new Targeting()
            {
                // AaId = AaId,
                adset_id = adset_id,
                age_max = age_max,
                age_min = age_min,
                device_platforms = device_platforms,
                facebook_positions = facebook_positions,
                instagram_positions = instagram_positions,
                publisher_platforms = publisher_platforms,
            };
            if (geo_locations != null)
            {
                model.geo_locations = (Geolocation)geo_locations.ToModel();
            }
            return model;
        }
    }
}
