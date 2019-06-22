using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.AdSets;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.Ads
{
    public class Ad : IDataModel, IHistoryData
    {
        public DateTime DateRecorded { get; set; }
        public long AppUserDataSyncId { get; set; }
        public virtual AppUserDataSync AppUserDataSync { get; set; }

        public long id { get; set; }

        public long account_id { get; set; }
        public virtual AdAccount AdAccount { get; set; }

        public long campaign_id { get; set; }
        public virtual Campaign Campaign { get; set; }

        public long adset_id { get; set; }
        public virtual AdSet AdSet { get; set; }


        public string bid_type { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public string effective_status { get; set; }
        public long last_updated_by_app_id { get; set; }
        public string name { get; set; }
        public long source_ad_id { get; set; }
        public string status { get; set; }
        public DateTime updated_time { get; set; }




        public override IDataViewModel ToViewModel()
        {
            var vm = new AdViewModel()
            {
                id = id,
                account_id = account_id,
                campaign_id = campaign_id,
                adset_id = adset_id,
                bid_type = bid_type,
                configured_status = configured_status,
                effective_status = effective_status,
                status = status,
                created_time = created_time,
                last_updated_by_app_id = last_updated_by_app_id,
                source_ad_id = source_ad_id,
                name = name,
                updated_time = updated_time
            };
            return vm;
        }
    }
    public class AdViewModel : IDataViewModel
    {
        public long id { get; set; }

        public long account_id { get; set; }

        public long campaign_id { get; set; }

        public long adset_id { get; set; }

        public string bid_type { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public string effective_status { get; set; }
        public long last_updated_by_app_id { get; set; }
        public string name { get; set; }
        public long source_ad_id { get; set; }
        public string status { get; set; }
        public DateTime updated_time { get; set; }

        public IDataModel ToModel()
        {
            var model = new Ad()
            {
                id = id,
                account_id = account_id,
                campaign_id = campaign_id,
                adset_id = adset_id,
                bid_type = bid_type,
                configured_status = configured_status,
                effective_status = effective_status,
                status = status,
                created_time = created_time,
                last_updated_by_app_id = last_updated_by_app_id,
                source_ad_id = source_ad_id,
                name = name,
                updated_time = updated_time
            };
            return model;
        }
    }
}
