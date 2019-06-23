using Assassins.DataModels.Interfaces;
using Assassins.DataModels.Actions;
using System.Collections.Generic;
using System;
using Action = Assassins.DataModels.Actions.Action;

namespace Assassins.DataModels.Campaigns
{
    public class CampaignInsight : DataModel
    {
        //public int AaId { get; set; }

        public virtual ICollection<Action> actions { get; set; }
        public long campaign_id { get; set; }
        public virtual Campaign Campaign { get; set; }

        #region // FB Properties ===========================
        public long id { get; set; }
        public string buying_type { get; set; }
        public int clicks { get; set; }
        public double cost_per_inline_link_click { get; set; }
        public double cost_per_inline_post_engagement { get; set; }
        public double cost_per_unique_click { get; set; }
        public double cost_per_unique_inline_link_click { get; set; }
        public double cpc { get; set; }
        public double cpp { get; set; }
        public double ctr { get; set; }
        public DateTime date_start { get; set; }
        public double cpm { get; set; }
        public DateTime date_stop { get; set; }
        public double frequency { get; set; }
        public uint impressions { get; set; }
        public double inline_link_click_ctr { get; set; }
        public uint inline_link_clicks { get; set; }
        public uint inline_post_engagement { get; set; }
        public uint instant_experience_clicks_to_open { get; set; }
        public uint instant_experience_clicks_to_start { get; set; }
        public uint instant_experience_outbound_clicks { get; set; }
        public uint reach { get; set; }
        public double social_spend { get; set; }
        public string objective { get; set; }
        public uint unique_clicks { get; set; }
        public double spend { get; set; }
        public double unique_ctr { get; set; }
        public double unique_inline_link_click_ctr { get; set; }
        public uint unique_inline_link_clicks { get; set; }
        public double unique_link_clicks_ctr { get; set; }

        #endregion // FB Properties ===========================

        public override IDataViewModel ToViewModel()
        {
            var vm = new CampaignInsightViewModel()
            {
                id = id,
                //AaId = AaId,
                //actions = actions,
                buying_type = buying_type,
                //Campaign = Campaign,
                campaign_id = campaign_id,
                clicks = clicks,
                cost_per_inline_link_click = cost_per_inline_link_click,
                cost_per_inline_post_engagement = cost_per_inline_post_engagement,
                cost_per_unique_click = cost_per_unique_click,
                cost_per_unique_inline_link_click = cost_per_unique_inline_link_click,
                cpc = cpc,
                cpm = cpm,
                cpp = cpp,
                ctr = ctr,
                date_start = date_start,
                date_stop = date_stop,
                frequency = frequency,
                impressions = impressions,
                inline_link_clicks = inline_link_clicks,
                inline_link_click_ctr = inline_link_click_ctr,
                inline_post_engagement = inline_post_engagement,
                instant_experience_clicks_to_open = instant_experience_clicks_to_open,
                instant_experience_clicks_to_start = instant_experience_clicks_to_start,
                instant_experience_outbound_clicks = instant_experience_outbound_clicks,
                unique_inline_link_clicks = unique_inline_link_clicks,
                unique_clicks = unique_clicks,
                unique_ctr = unique_ctr,
                unique_inline_link_click_ctr = unique_inline_link_click_ctr,
                unique_link_clicks_ctr = unique_link_clicks_ctr,
                objective = objective,
                reach = reach,
                social_spend = social_spend,
                spend = spend
            };

            if (actions != null)
            {
                vm.actions = new List<ActionViewModel>(actions.Count);
                foreach (var item in actions)
                {
                    vm.actions.Add((ActionViewModel)item.ToViewModel());
                }
            }
            return vm;
        }
    }

    public class CampaignInsightViewModel : IDataViewModel
    {
        //public int AaId { get; set; }

        public ICollection<ActionViewModel> actions { get; set; }
        public long campaign_id { get; set; }
        public CampaignViewModel Campaign { get; set; }

        #region // FB Properties ===========================
        public long id { get; set; }
        public string buying_type { get; set; }
        public int clicks { get; set; }
        public double cost_per_inline_link_click { get; set; }
        public double cost_per_inline_post_engagement { get; set; }
        public double cost_per_unique_click { get; set; }
        public double cost_per_unique_inline_link_click { get; set; }
        public double cpc { get; set; }
        public double cpp { get; set; }
        public double ctr { get; set; }
        public DateTime date_start { get; set; }
        public double cpm { get; set; }
        public DateTime date_stop { get; set; }
        public double frequency { get; set; }
        public uint impressions { get; set; }
        public double inline_link_click_ctr { get; set; }
        public uint inline_link_clicks { get; set; }
        public uint inline_post_engagement { get; set; }
        public uint instant_experience_clicks_to_open { get; set; }
        public uint instant_experience_clicks_to_start { get; set; }
        public uint instant_experience_outbound_clicks { get; set; }
        public uint reach { get; set; }
        public double social_spend { get; set; }
        public string objective { get; set; }
        public uint unique_clicks { get; set; }
        public double spend { get; set; }
        public double unique_ctr { get; set; }
        public double unique_inline_link_click_ctr { get; set; }
        public uint unique_inline_link_clicks { get; set; }
        public double unique_link_clicks_ctr { get; set; }

        #endregion // FB Properties ===========================
        public DataModel ToModel()
        {
            var model = new CampaignInsight()
            {
                id = id,
                //AaId = AaId,
                //actions = actions,
                buying_type = buying_type,
                //Campaign = Campaign,
                campaign_id = campaign_id,
                clicks = clicks,
                cost_per_inline_link_click = cost_per_inline_link_click,
                cost_per_inline_post_engagement = cost_per_inline_post_engagement,
                cost_per_unique_click = cost_per_unique_click,
                cost_per_unique_inline_link_click = cost_per_unique_inline_link_click,
                cpc = cpc,
                cpm = cpm,
                cpp = cpp,
                ctr = ctr,
                date_start = date_start,
                date_stop = date_stop,
                frequency = frequency,
                impressions = impressions,
                inline_link_clicks = inline_link_clicks,
                inline_link_click_ctr = inline_link_click_ctr,
                inline_post_engagement = inline_post_engagement,
                instant_experience_clicks_to_open = instant_experience_clicks_to_open,
                instant_experience_clicks_to_start = instant_experience_clicks_to_start,
                instant_experience_outbound_clicks = instant_experience_outbound_clicks,
                unique_inline_link_clicks = unique_inline_link_clicks,
                unique_clicks = unique_clicks,
                unique_ctr = unique_ctr,
                unique_inline_link_click_ctr = unique_inline_link_click_ctr,
                unique_link_clicks_ctr = unique_link_clicks_ctr,
                objective = objective,
                reach = reach,
                social_spend = social_spend,
                spend = spend
            };

            if (actions != null)
            {
                model.actions = new List<Action>(actions.Count);
                foreach (var item in actions)
                {
                    model.actions.Add((Action)item.ToModel());
                }
            }
            return model;
        }

    }
}
