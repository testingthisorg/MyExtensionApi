using Assassins.DataModels.Interfaces;
using GeoAPI.Geometries;
using System;

namespace Assassins.DataModels.AdSets
{
    public class CustomLocation : HistoryItem
    {
        public string name { get; set; }
        public string address_string { get; set; }
        public string distance_unit { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public float radius { get; set; }
        public int primary_city_id { get; set; }
        public int region_id { get; set; }
        public string country { get; set; }

        public IPoint LatLongPoint { get; set; }
        public override IDataViewModel ToViewModel()
        {
            var vm = new CustomLocationViewModel()
            {
                name = name,
                address_string = address_string,
                distance_unit = distance_unit,
                latitude = latitude,
                longitude = longitude,
                radius = radius,
                primary_city_id = primary_city_id,
                region_id = region_id,
                country = country
            };
            return vm;
        }
    }
    public class _CustomLocationHistoryItem : HistoryItem
    {
        public string name { get; set; }
        public string address_string { get; set; }
        public string distance_unit { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public float radius { get; set; }
        public int primary_city_id { get; set; }
        public int region_id { get; set; }
        public string country { get; set; }

        public IPoint LatLongPoint { get; set; }
        public override IDataViewModel ToViewModel()
        {
            var vm = new CustomLocationViewModel()
            {
                name = name,
                address_string = address_string,
                distance_unit = distance_unit,
                latitude = latitude,
                longitude = longitude,
                radius = radius,
                primary_city_id = primary_city_id,
                region_id = region_id,
                country = country
            };
            return vm;
        }
    }
    public class CustomLocationViewModel : IDataViewModel
    {
        public string name { get; set; }
        public string address_string { get; set; }
        public string distance_unit { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public float radius { get; set; }
        public int primary_city_id { get; set; }
        public int region_id { get; set; }
        public string country { get; set; }

        public IPoint LatLongPoint { get; set; }
        public DataModel ToModel()
        {
            var model = new CustomLocation()
            {
                name = name,
                address_string = address_string,
                distance_unit = distance_unit,
                latitude = latitude,
                longitude = longitude,
                radius = radius,
                primary_city_id = primary_city_id,
                region_id = region_id,
                country = country
            };
            return model;
        }
    }
}
