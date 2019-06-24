using Assassins.DataModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assassins.DataModels.AdSets
{
    public class Geolocation : HistoryItem
    {
        public long adset_id { get; set; }
        public virtual Targeting Targeting { get; set; }
        [NotMapped]
        public ICollection<Region> regions { get; set; }
        [NotMapped]
        public ICollection<City> cities { get; set; }

        public ICollection<GeolocationCityMap> city_maps { get; set; }
        public ICollection<GeolocationRegionMap> region_maps { get; set; }

        public ICollection<CustomLocation> custom_locations { get; set; }
        public ICollection<string> location_types { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationViewModel()
            {
                adset_id = adset_id,
                region_maps = new List<GeolocationRegionMapViewModel>(),
                city_maps = new List<GeolocationCityMapViewModel>(),
                custom_locations = new List<CustomLocationViewModel>(),
                location_types = location_types
            };
            if (region_maps != null)
            {
                foreach (var item in region_maps)
                {
                    vm.region_maps.Add((GeolocationRegionMapViewModel)item.ToViewModel());
                }
            }
            if (city_maps != null)
            {
                foreach (var item in city_maps)
                {
                    vm.city_maps.Add((GeolocationCityMapViewModel)item.ToViewModel());
                }
            }
            if (custom_locations != null)
            {
                foreach (var item in custom_locations)
                {
                    vm.custom_locations.Add((CustomLocationViewModel)item.ToViewModel());
                }
            }
            return vm;
        }
    }
    public class _GeolocationHistoryItem : HistoryItem
    {
        public long adset_id { get; set; }
        //public virtual Targeting Targeting { get; set; }
        //[NotMapped]
        //public ICollection<Region> regions { get; set; }
        //public ICollection<GeolocationRegionMap> region_maps { get; set; }
        public ICollection<string> location_types { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeolocationViewModel()
            {
                adset_id = adset_id,
                region_maps = new List<GeolocationRegionMapViewModel>(),
                location_types = location_types
            };
            //if (region_maps != null)
            //{
            //    foreach (var item in region_maps)
            //    {
            //        vm.region_maps.Add((GeolocationRegionMapViewModel)item.ToViewModel());
            //    }
            //}
            return vm;
        }
    }
    public class GeolocationViewModel : IDataViewModel
    {
        public long adset_id { get; set; }

        public ICollection<GeolocationCityMapViewModel> city_maps { get; set; }
        public ICollection<GeolocationRegionMapViewModel> region_maps { get; set; }

        public ICollection<CustomLocationViewModel> custom_locations { get; set; }
        public ICollection<string> location_types { get; set; }

        public DataModel ToModel()
        {
            var model = new Geolocation()
            {
                adset_id = adset_id,
                region_maps = new List<GeolocationRegionMap>(),
                city_maps = new List<GeolocationCityMap>(),
                custom_locations = new List<CustomLocation>(),
                location_types = location_types
            };
            if (region_maps != null)
            {
                foreach (var item in region_maps)
                {
                    model.region_maps.Add((GeolocationRegionMap)item.ToModel());
                }
            }
            if (city_maps != null)
            {
                foreach (var item in city_maps)
                {
                    model.city_maps.Add((GeolocationCityMap)item.ToModel());
                }
            }
            if (custom_locations != null)
            {
                foreach (var item in custom_locations)
                {
                    model.custom_locations.Add((CustomLocation)item.ToModel());
                }
            }
            return model;
        }
    }
}
