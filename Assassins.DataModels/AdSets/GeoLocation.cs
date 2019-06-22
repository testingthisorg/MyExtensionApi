using Assassins.DataModels.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assassins.DataModels.AdSets
{
    public class Geolocation : IDataModel
    {
      //  public int AaId { get; set; }
        public long adset_id { get; set; }
        public virtual Targeting Targeting { get; set; }
        [NotMapped]
        public ICollection<Region> regions { get; set; }
        public ICollection<GeolocationRegionMap> region_maps { get; set; }
        public ICollection<string> location_types { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new GeoLocationViewModel()
            {
                adset_id = adset_id,
             //   AaId = AaId,
                region_maps = new List<GeolocationRegionMapViewModel>(),
                location_types = location_types
            };
            if (region_maps != null)
            {
                foreach (var item in region_maps)
                {
                    vm.region_maps.Add((GeolocationRegionMapViewModel)item.ToViewModel());
                }
            }
            return vm;
        }
    }
    public class GeoLocationViewModel : IDataViewModel
    {
        public long adset_id { get; set; }
        // public int AaId { get; set; }
        //public ICollection<Region> regions { get; set; }
        public ICollection<GeolocationRegionMapViewModel> region_maps { get; set; }
        public ICollection<string> location_types { get; set; }

        public IDataModel ToModel()
        {
            var vm = new Geolocation()
            {
                //AaId = AaId,
                adset_id = adset_id,
                region_maps = new List<GeolocationRegionMap>(),
                location_types = location_types
            };
            if (region_maps != null)
            {
                foreach (var item in region_maps)
                {
                    vm.region_maps.Add((GeolocationRegionMap)item.ToModel());
                }
            }
            return vm;
        }
    }
}
