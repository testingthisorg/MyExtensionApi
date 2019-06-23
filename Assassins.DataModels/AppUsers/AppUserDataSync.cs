using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.AdImages;
using Assassins.DataModels.Ads;
using Assassins.DataModels.AdSets;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Creatives;
using Assassins.DataModels.Interfaces;
using Assassins.DataModels.LeadForms;
using System;
using System.Collections.Generic;

namespace Assassins.DataModels.AppUsers
{
    public class AppUserDataSync : DataModel
    {
        public long Id { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool AdAccountsCompleted { get; set; }
        public bool CampaignsCompleted { get; set; }
        public bool AdSetsCompleted { get; set; }
        public bool AdsCompleted { get; set; }
        public bool CreativesCompleted { get; set; }
        public bool LeadFormsCompleted { get; set; }
        public bool AdImagesCompleted { get; set; }
        public bool AdInsightsCompleted { get; set; }

        public virtual ICollection<AdAccount> AdAccounts { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<AdSet> AdSets { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<AdCreative> AdCreatives { get; set; }
        public virtual ICollection<AdImage> AdImages { get; set; }
        public virtual ICollection<LeadForm> LeadForms { get; set; }

        public bool AllCompleted
        {
            get
            {
                return AdAccountsCompleted &&
                        CampaignsCompleted &&
                        AdSetsCompleted &&
                        AdsCompleted &&
                        CreativesCompleted &&
                        LeadFormsCompleted && 
                        AdImagesCompleted;
            }
        }



        public override IDataViewModel ToViewModel()
        {
            var vm = new AppUserDataSyncViewModel()
            {
                Id = Id,
                AppUserId = AppUserId,
                StartTime = StartTime,
                EndTime = EndTime,
                AdAccountsCompleted = AdAccountsCompleted,
                CampaignsCompleted = CampaignsCompleted,
                AdSetsCompleted = AdSetsCompleted,
                AdsCompleted = AdsCompleted,
                CreativesCompleted = CreativesCompleted,
                LeadFormsCompleted = LeadFormsCompleted,
                AdImagesCompleted =    AdImagesCompleted,
                AdInsightsCompleted = AdInsightsCompleted
            };
            return vm;
        }
    }

    public class AppUserDataSyncViewModel : IDataViewModel
    {
        public long Id { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool AdAccountsCompleted { get; set; }
        public bool CampaignsCompleted { get; set; }
        public bool AdSetsCompleted { get; set; }
        public bool AdsCompleted { get; set; }
        public bool CreativesCompleted { get; set; }
        public bool LeadFormsCompleted { get; set; }
        public bool AdImagesCompleted { get; set; }
        public bool AdInsightsCompleted { get; set; }

        public DataModel ToModel()
        {
            var model = new AppUserDataSync()
            {
                Id = Id,
                AppUserId = AppUserId,
                StartTime = StartTime,
                EndTime = EndTime,
                AdAccountsCompleted = AdAccountsCompleted,
                CampaignsCompleted = CampaignsCompleted,
                AdSetsCompleted = AdSetsCompleted,
                AdsCompleted = AdsCompleted,
                CreativesCompleted = CreativesCompleted,
                LeadFormsCompleted = LeadFormsCompleted
            };
            return model;
        }
    }
}
