using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.AdSets
{
    public class City: DataModel
    {
        public int key { get; set; }
        public int region_id { get; set; }
        public string distance_unit { get; set; }
        public string name { get; set; }
        public float radius { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new CityViewModel()
            {
                key = key,
                region_id = region_id,
                distance_unit = distance_unit,
                radius = radius,
                name = name
            };

            return vm;
        }
    }
    public class CityViewModel : IDataViewModel
    {
        public int key { get; set; }
        public int region_id { get; set; }
        public string distance_unit { get; set; }
        public string name { get; set; }
        public float radius { get; set; }

        public DataModel ToModel()
        {
            var model = new City()
            {
                key = key,
                region_id = region_id,
                distance_unit = distance_unit,
                name = name
            };

            return model;
        }
    }
}
