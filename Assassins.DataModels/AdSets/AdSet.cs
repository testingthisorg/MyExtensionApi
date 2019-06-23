using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.Ads;
using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Assassins.DataModels.AdSets
{
    public class AdSet : HistoryItem
    {
        public long id { get; set; }
        public long campaign_id { get; set; }
        public virtual Campaign Campaign { get; set; }
        public long account_id { get; set; }
        public virtual AdAccount AdAccount { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }

        #region // FB Properties ===========================
        public string bid_strategy { get; set; }
        public string billing_event { get; set; }
        public int budget_remaining { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public int daily_budget { get; set; }
        public string destination_type { get; set; }
        public string effective_status { get; set; }
        public DateTime end_time { get; set; }
        public int lifetime_budget { get; set; }
        public int lifetime_imps { get; set; }
        public string name { get; set; }
        public string optimization_goal { get; set; }
        public string optimization_sub_event { get; set; }
        public bool recurring_budget_semantics { get; set; }
        public long source_adset_id { get; set; }
        public DateTime start_time { get; set; }
        public string status { get; set; }
        public DateTime updated_time { get; set; }
        public bool use_new_app_click { get; set; }
        public bool is_dynamic_creative { get; set; }
        public virtual Targeting targeting { get; set; }

        #endregion // FB Properties ===========================

        public override IDataViewModel ToViewModel()
        {
            var vm = new AdSetViewModel()
            {
                id = id,
                campaign_id = campaign_id,
                account_id = account_id,
                bid_strategy = bid_strategy,
                billing_event = billing_event,
                budget_remaining = budget_remaining,
                configured_status = configured_status,
                created_time = created_time,
                daily_budget = daily_budget,
                destination_type = destination_type,
                effective_status = effective_status,
                end_time = end_time,
                lifetime_budget = lifetime_budget,
                lifetime_imps = lifetime_imps,
                name = name,
                optimization_goal = optimization_goal,
                optimization_sub_event = optimization_sub_event,
                recurring_budget_semantics = recurring_budget_semantics,
                source_adset_id = source_adset_id,
                start_time = start_time,
                status = status,
                updated_time = updated_time,
                use_new_app_click = use_new_app_click,
                is_dynamic_creative = is_dynamic_creative
            };
            if (targeting != null)
            {
                vm.targeting = (TargetingViewModel)targeting.ToViewModel();
            }
            return vm;
        }
    }
    public class _AdSetHistoryItem : HistoryItem
    {
        public long id { get; set; }
        public long campaign_id { get; set; }
        //public virtual Campaign Campaign { get; set; }
        public long account_id { get; set; }
        //public virtual AdAccount AdAccount { get; set; }
        //public virtual ICollection<Ad> Ads { get; set; }

        #region // FB Properties ===========================
        public string bid_strategy { get; set; }
        public string billing_event { get; set; }
        public int budget_remaining { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public int daily_budget { get; set; }
        public string destination_type { get; set; }
        public string effective_status { get; set; }
        public DateTime end_time { get; set; }
        public int lifetime_budget { get; set; }
        public int lifetime_imps { get; set; }
        public string name { get; set; }
        public string optimization_goal { get; set; }
        public string optimization_sub_event { get; set; }
        public bool recurring_budget_semantics { get; set; }
        public long source_adset_id { get; set; }
        public DateTime start_time { get; set; }
        public string status { get; set; }
        public DateTime updated_time { get; set; }
        public bool use_new_app_click { get; set; }
        public bool is_dynamic_creative { get; set; }
        //public virtual Targeting targeting { get; set; }

        #endregion // FB Properties ===========================

        public override IDataViewModel ToViewModel()
        {
            var vm = new AdSetViewModel()
            {
                id = id,
                campaign_id = campaign_id,
                account_id = account_id,
                bid_strategy = bid_strategy,
                billing_event = billing_event,
                budget_remaining = budget_remaining,
                configured_status = configured_status,
                created_time = created_time,
                daily_budget = daily_budget,
                destination_type = destination_type,
                effective_status = effective_status,
                end_time = end_time,
                lifetime_budget = lifetime_budget,
                lifetime_imps = lifetime_imps,
                name = name,
                optimization_goal = optimization_goal,
                optimization_sub_event = optimization_sub_event,
                recurring_budget_semantics = recurring_budget_semantics,
                source_adset_id = source_adset_id,
                start_time = start_time,
                status = status,
                updated_time = updated_time,
                use_new_app_click = use_new_app_click,
                is_dynamic_creative = is_dynamic_creative
            };
            //if (targeting != null)
            //{
            //    vm.targeting = (TargetingViewModel)targeting.ToViewModel();
            //}
            return vm;
        }
    }

    public class AdSetViewModel : IDataViewModel
    {
        public long id { get; set; }
        public long campaign_id { get; set; }
        public virtual CampaignViewModel Campaign { get; set; }
        public long account_id { get; set; }

        #region // FB Properties ===========================
        public string bid_strategy { get; set; }
        public string billing_event { get; set; }
        public int budget_remaining { get; set; }
        public string configured_status { get; set; }
        public DateTime created_time { get; set; }
        public int daily_budget { get; set; }
        public string destination_type { get; set; }
        public string effective_status { get; set; }
        public DateTime end_time { get; set; }
        public int lifetime_budget { get; set; }
        public int lifetime_imps { get; set; }
        public string name { get; set; }
        public string optimization_goal { get; set; }
        public string optimization_sub_event { get; set; }
        public bool recurring_budget_semantics { get; set; }
        public long source_adset_id { get; set; }
        public DateTime start_time { get; set; }
        public string status { get; set; }
        public DateTime updated_time { get; set; }
        public bool use_new_app_click { get; set; }
        public bool is_dynamic_creative { get; set; }
        public TargetingViewModel targeting { get; set; }
        #endregion // FB Properties ===========================

        public DataModel ToModel()
        {
            var model = new AdSet()
            {
                id = id,
                campaign_id = campaign_id,
                account_id = account_id,
                bid_strategy = bid_strategy,
                billing_event = billing_event,
                budget_remaining = budget_remaining,
                configured_status = configured_status,
                created_time = created_time,
                daily_budget = daily_budget,
                destination_type = destination_type,
                effective_status = effective_status,
                end_time = end_time,
                lifetime_budget = lifetime_budget,
                lifetime_imps = lifetime_imps,
                name = name,
                optimization_goal = optimization_goal,
                optimization_sub_event = optimization_sub_event,
                recurring_budget_semantics = recurring_budget_semantics,
                source_adset_id = source_adset_id,
                start_time = start_time,
                status = status,
                updated_time = updated_time,
                use_new_app_click = use_new_app_click,
                is_dynamic_creative = is_dynamic_creative
            };
            if (targeting != null)
            {
                model.targeting = (Targeting)targeting.ToModel();
            }
            return model;
        }
    }
}
