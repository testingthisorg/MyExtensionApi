using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.AppUsers
{
    public class AppUserDataSync : IDataModel
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
        public bool AllCompleted
        {
            get
            {
                return AdAccountsCompleted &&
                        CampaignsCompleted &&
                        AdSetsCompleted &&
                        AdsCompleted &&
                        CreativesCompleted &&
                        LeadFormsCompleted;
            }
        }
        public IDataViewModel ToViewModel()
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
                LeadFormsCompleted = LeadFormsCompleted
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

        public IDataModel ToModel()
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
