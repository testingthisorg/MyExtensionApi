using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Assassins.DataModels.Interfaces
{
    public abstract class DataModel
    {
        public abstract IDataViewModel ToViewModel();
        public static ICollection<T> ParseCollection<T>(List<object> items)
        {
            var parsedItems = new List<T>();
            foreach (var item in items)
            {
                var jObj = item as JObject;
                var accnt = jObj.ToObject<T>();
                parsedItems.Add(accnt);
            }
            return parsedItems;
        }
    }
}
