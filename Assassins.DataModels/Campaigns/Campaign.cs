using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.Ads;
using Assassins.DataModels.AdSets;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Assassins.DataModels.Campaigns
{
    public class Campaign : HistoryItem
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }


        public virtual AdAccount AdAccount { get; set; }

        public virtual ICollection<CampaignInsight> CampaignInsights { get; set; }
        public virtual ICollection<AdSet> adsets { get; set; }
        public virtual ICollection<Ad> ads { get; set; }

        #region // FB Properties ===========================
        public long id { get; set; }
        public long account_id { get; set; }
        public bool budget_rebalance_flag { get; set; }
        public int budget_remaining { get; set; }
        public string buying_type { get; set; }
        public bool can_create_brand_lift_study { get; set; }
        public bool can_use_spend_cap { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public string effective_status { get; set; }
        public string name { get; set; }
        public string objective { get; set; }
        public long? source_campaign_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? stop_time { get; set; }
        public DateTime? updated_time { get; set; }
        public string status { get; set; }

        #endregion  // FB Properties ===========================

        public override IDataViewModel ToViewModel()
        {
            var vm = new CampaignViewModel()
            {
                AppUserId = AppUserId,

                account_id = account_id,
                budget_rebalance_flag = budget_rebalance_flag,
                budget_remaining = budget_remaining,
                buying_type = buying_type,
                can_create_brand_lift_study = can_create_brand_lift_study,
                can_use_spend_cap = can_use_spend_cap,
                configured_status = configured_status,
                created_time = created_time,
                effective_status = effective_status,
                id = id,
                name = name,
                objective = objective,
                source_campaign_id = source_campaign_id,
                start_time = start_time,
                stop_time = stop_time,
                updated_time = updated_time,
                status = status
            };

            if (adsets != null)
            {
                vm.adsets = new List<AdSetViewModel>();
                foreach (var item in adsets)
                {
                    vm.adsets.Add((AdSetViewModel)item.ToViewModel());
                }
            }
            return vm;
        }


    }
    public class _CampaignHistoryItem : HistoryItem
    {
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }


        //public virtual AdAccount AdAccount { get; set; }

        //public virtual ICollection<CampaignInsight> CampaignInsights { get; set; }
        //public virtual ICollection<AdSet> adsets { get; set; }
        //public virtual ICollection<Ad> ads { get; set; }

        #region // FB Properties ===========================
        public long id { get; set; }
        public long account_id { get; set; }
        public bool budget_rebalance_flag { get; set; }
        public int budget_remaining { get; set; }
        public string buying_type { get; set; }
        public bool can_create_brand_lift_study { get; set; }
        public bool can_use_spend_cap { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public string effective_status { get; set; }
        public string name { get; set; }
        public string objective { get; set; }
        public long? source_campaign_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? stop_time { get; set; }
        public DateTime? updated_time { get; set; }
        public string status { get; set; }

        #endregion  // FB Properties ===========================

        public override IDataViewModel ToViewModel()
        {
            var vm = new CampaignViewModel()
            {
                AppUserId = AppUserId,

                account_id = account_id,
                budget_rebalance_flag = budget_rebalance_flag,
                budget_remaining = budget_remaining,
                buying_type = buying_type,
                can_create_brand_lift_study = can_create_brand_lift_study,
                can_use_spend_cap = can_use_spend_cap,
                configured_status = configured_status,
                created_time = created_time,
                effective_status = effective_status,
                id = id,
                name = name,
                objective = objective,
                source_campaign_id = source_campaign_id,
                start_time = start_time,
                stop_time = stop_time,
                updated_time = updated_time,
                status = status
            };

            //if (adsets != null)
            //{
            //    vm.adsets = new List<AdSetViewModel>();
            //    foreach (var item in adsets)
            //    {
            //        vm.adsets.Add((AdSetViewModel)item.ToViewModel());
            //    }
            //}
            return vm;
        }


    }

    public class CampaignViewModel : IDataViewModel
    {

        public int AppUserId { get; set; }
        public virtual AppUserViewModel AppUser { get; set; }

        public long account_id { get; set; }
        public virtual AdAccountViewModel AdAccount { get; set; }

        public ICollection<AdSetViewModel> adsets { get; set; }
        #region // FB Properties ===========================
        public long id { get; set; }
        public bool budget_rebalance_flag { get; set; }
        public int budget_remaining { get; set; }
        public string buying_type { get; set; }
        public bool can_create_brand_lift_study { get; set; }
        public bool can_use_spend_cap { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public string effective_status { get; set; }
        public string name { get; set; }
        public string objective { get; set; }
        public long? source_campaign_id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime? stop_time { get; set; }
        public DateTime? updated_time { get; set; }
        public string status { get; set; }

        #endregion  // FB Properties ===========================
        public DataModel ToModel()
        {
            var model = new Campaign()
            {
                id = id,
                AppUserId = AppUserId,

                account_id = account_id,
                budget_rebalance_flag = budget_rebalance_flag,
                budget_remaining = budget_remaining,
                buying_type = buying_type,
                can_create_brand_lift_study = can_create_brand_lift_study,
                can_use_spend_cap = can_use_spend_cap,
                configured_status = configured_status,
                created_time = created_time,
                effective_status = effective_status,
                name = name,
                objective = objective,
                source_campaign_id = source_campaign_id,
                start_time = start_time,
                stop_time = stop_time,
                updated_time = updated_time,
                status = status
            };

            if (adsets != null)
            {
                model.adsets = new List<AdSet>();
                foreach (var item in adsets)
                {
                    model.adsets.Add((AdSet)item.ToModel());
                }
            }
            return model;
        }
    }
}
