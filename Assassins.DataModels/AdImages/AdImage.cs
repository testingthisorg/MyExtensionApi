using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Creatives;
using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Assassins.DataModels.AdImages
{
    public class AdImage : HistoryItem
    {
        public string id { get; set; }
        public string url_128 { get; set; }
        public long account_id { get; set; }
        public AdAccount AdAccount { get; set; }
        public DateTime created_time { get; set; }
        public virtual ICollection<AdCreative> AdCreatives { get; set; }
        public string hash { get; set; }
        public int height { get; set; }
        public bool is_associated_creatives_in_adgroups { get; set; }
        public string name { get; set; }
        public int original_height { get; set; }
        public int original_width { get; set; }
        public string permalink_url { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public DateTime? update_time { get; set; }
        public int width { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new AdImageViewModel()
            {
                id = id,
                url_128 = url_128,
                account_id = account_id,
                created_time = created_time,
                hash = hash,
                height = height,
                is_associated_creatives_in_adgroups = is_associated_creatives_in_adgroups,
                name = name,
                original_height = original_height,
                original_width = original_width,
                permalink_url = permalink_url,
                status = status,
                update_time = update_time,
                width = width
            };

            return vm;
        }
    }
    public class _AdImageHistoryItem : HistoryItem
    {
        public string id { get; set; }
        public string url_128 { get; set; }
        public long account_id { get; set; }
        public DateTime created_time { get; set; }
        //public virtual ICollection<AdCreative> AdCreatives { get; set; }
        public string hash { get; set; }
        public int height { get; set; }
        public bool is_associated_creatives_in_adgroups { get; set; }
        public string name { get; set; }
        public int original_height { get; set; }
        public int original_width { get; set; }
        public string permalink_url { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public DateTime? update_time { get; set; }
        public int width { get; set; }

        public override IDataViewModel ToViewModel()
        {
            var vm = new AdImageViewModel()
            {
                id = id,
                url_128 = url_128,
                account_id = account_id,
                created_time = created_time,
                hash = hash,
                height = height,
                is_associated_creatives_in_adgroups = is_associated_creatives_in_adgroups,
                name = name,
                original_height = original_height,
                original_width = original_width,
                permalink_url = permalink_url,
                status = status,
                update_time = update_time,
                width = width
            };

            return vm;
        }
    }
    public class AdImageViewModel : IDataViewModel
    {
        public string id { get; set; }
        public string url_128 { get; set; }
        public long account_id { get; set; }
        public DateTime created_time { get; set; }
        public virtual ICollection<AdCreative> AdCreatives { get; set; }
        public string hash { get; set; }
        public int height { get; set; }
        public bool is_associated_creatives_in_adgroups { get; set; }
        public string name { get; set; }
        public int original_height { get; set; }
        public int original_width { get; set; }
        public string permalink_url { get; set; }
        public string status { get; set; }
        public string url { get; set; }
        public DateTime? update_time { get; set; }
        public int width { get; set; }
        public DataModel ToModel()
        {
            var model = new AdImage()
            {
                id = id,
                url_128 = url_128,
                account_id = account_id,
                created_time = created_time,
                hash = hash,
                height = height,
                is_associated_creatives_in_adgroups = is_associated_creatives_in_adgroups,
                name = name,
                original_height = original_height,
                original_width = original_width,
                permalink_url = permalink_url,
                status = status,
                update_time = update_time,
                width = width
            };

            return model;
        }
    }
}
