using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using Assassins.DataModels.Users;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataModels.AdAccounts
{
    public class AdAccount : IDataModel
    {
        public static ICollection<AdAccount> ParseCollection(List<object> accounts)
        {
            foreach (var item in accounts)
            {
                var jObj = item as JObject;
                var props = jObj.Properties().ToDictionary(k => k.Name, m => m.Value);
                var accnt = jObj.ToObject<AdAccount>();
            }
            return null;
        }

        public int AaId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RecordDate { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Campaign> campaigns { get; set; }

        #region // FB Properties ===========================
        public uint amount_spent { get; set; }
        public int account_status { get; set; }
        public double age { get; set; }
        public double balance { get; set; }
        public string name { get; set; }
        public ulong account_id { get; set; }
        public ICollection<AttributionSpec> attribution_spec { get; set; }
        public int BusinessId { get; set; }
        public virtual Business business { get; set; }
        public string business_city { get; set; }
        public string business_country_code { get; set; }
        public string business_name { get; set; }
        public string business_street { get; set; }
        public string business_street2 { get; set; }
        public DateTime created_time { get; set; }
        public string currency { get; set; }
        public int disable_reason { get; set; }
        public ulong end_advertiser { get; set; }
        public string end_advertiser_name { get; set; }
        public int fb_entity { get; set; }
        public int min_campaign_group_spend_cap { get; set; }
        public int min_daily_budget { get; set; }
        public ulong owner { get; set; }
        public int spend_cap { get; set; }
        public int timezone_id { get; set; }
        public string timezone_name { get; set; }
        public int timezone_offset_hours_utc { get; set; }

        #endregion  // FB Properties ===========================

        public IDataViewModel ToViewModel()
        {
            var vm = new AdAccountViewModel()
            {
                AaId = AaId,
                AppUserId = AppUserId,

                account_id = account_id,
                account_status = account_status,
                age = age,
                amount_spent = amount_spent,
                //attribution_spec
                balance = balance,
                //business = business,
                business_city = business_city,
                business_country_code = business_country_code,
                business_name = business_name,
                business_street = business_street,
                business_street2 = business_street2,
                created_time = created_time,
                currency = currency,
                disable_reason = disable_reason,
                end_advertiser = end_advertiser,
                end_advertiser_name = end_advertiser_name,
                fb_entity = fb_entity,
                min_campaign_group_spend_cap = min_campaign_group_spend_cap,
                min_daily_budget = min_daily_budget,
                name = name,
                owner = owner,
                spend_cap = spend_cap,
                timezone_id = timezone_id,
                timezone_name = timezone_name,
                timezone_offset_hours_utc = timezone_offset_hours_utc
            };

            if (attribution_spec != null)
            {
                vm.attribution_spec = new List<AttributionSpecViewModel>();
                foreach (var item in attribution_spec)
                {
                    vm.attribution_spec.Add((AttributionSpecViewModel)item.ToViewModel());
                }
            }
            if (business != null)
            {
                vm.business = (BusinessViewModel)business.ToViewModel();
            }
            if (campaigns != null)
            {
                vm.campaigns = new List<CampaignViewModel>();
                foreach (var item in campaigns)
                {
                    vm.campaigns.Add((CampaignViewModel)item.ToViewModel());
                }
            }
            return vm;
        }
    }
    public class AdAccountViewModel : IDataViewModel
    {
        public int AaId { get; set; }
        public int AppUserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RecordDate { get; set; }
        public AppUserViewModel AppUser { get; set; }

        #region // FB Properties ===========================
        public List<CampaignViewModel> campaigns { get; set; }
        public uint amount_spent { get; set; }
        public int account_status { get; set; }
        public double age { get; set; }
        public double balance { get; set; }
        public string name { get; set; }
        public ulong account_id { get; set; }
        public ICollection<AttributionSpecViewModel> attribution_spec { get; set; }
        public BusinessViewModel business { get; set; }
        public string business_city { get; set; }
        public string business_country_code { get; set; }
        public string business_name { get; set; }
        public string business_street { get; set; }
        public string business_street2 { get; set; }
        public DateTime created_time { get; set; }
        public string currency { get; set; }
        public int disable_reason { get; set; }
        public ulong end_advertiser { get; set; }
        public string end_advertiser_name { get; set; }
        public int fb_entity { get; set; }
        public int min_campaign_group_spend_cap { get; set; }
        public int min_daily_budget { get; set; }
        public ulong owner { get; set; }
        public int spend_cap { get; set; }
        public int timezone_id { get; set; }
        public string timezone_name { get; set; }
        public int timezone_offset_hours_utc { get; set; }

        #endregion // FB Properties ===========================
        public IDataModel ToModel()
        {
            var model = new AdAccount()
            {
                AaId = AaId,
                AppUserId = AppUserId,
                CreatedOn = CreatedOn,                
                RecordDate = RecordDate,

                account_id = account_id,
                account_status = account_status,
                age = age,
                amount_spent = amount_spent,
                //attribution_spec
                balance = balance,
                //business = business,
                business_city = business_city,
                business_country_code = business_country_code,
                business_name = business_name,
                business_street = business_street,
                business_street2 = business_street2,
                created_time = created_time,
                currency = currency,
                disable_reason = disable_reason,
                end_advertiser = end_advertiser,
                end_advertiser_name = end_advertiser_name,
                fb_entity = fb_entity,
                min_campaign_group_spend_cap = min_campaign_group_spend_cap,
                min_daily_budget = min_daily_budget,
                name = name,
                owner = owner,
                spend_cap = spend_cap,
                timezone_id = timezone_id,
                timezone_name = timezone_name,
                timezone_offset_hours_utc = timezone_offset_hours_utc                
            };
   
            if(attribution_spec != null)
            {
                model.attribution_spec = new List<AttributionSpec>();
                foreach (var item in attribution_spec)
                {
                    model.attribution_spec.Add((AttributionSpec)item.ToModel());
                }
            }
            if(business != null)
            {
                model.business = (Business)business.ToModel();
            }
            if(campaigns != null)
            {
                model.campaigns = new List<Campaign>();
                foreach (var item in campaigns)
                {
                    model.campaigns.Add((Campaign)item.ToModel());
                }
            }
            return model;
        }

    }

}
