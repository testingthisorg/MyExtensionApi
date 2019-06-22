using Assassins.DataModels.Interfaces;
using System.Collections.Generic;

namespace Assassins.DataModels.AdSets
{
    public class Region : IDataModel
    {
        public int key { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public virtual ICollection<GeolocationRegionMap> GeoLocationRegionMaps { get; set; }
        public override IDataViewModel ToViewModel()
        {
            var vm = new RegionViewModel()
            {
                key = key,
                name = name,
                country = country
            };
            return vm;
        }
    }

    public class RegionViewModel : IDataViewModel
    {
        public int key { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        public IDataModel ToModel()
        {
            var model = new Region()
            {
                key = key,
                name = name,
                country = country
            };
            return model;
        }
    }
}
