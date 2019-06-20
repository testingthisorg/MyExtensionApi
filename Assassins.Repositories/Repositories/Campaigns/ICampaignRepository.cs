using Assassins.DataModels.Campaigns;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories.Campaigns
{
    public interface ICampaignRepository
    {

        BaseRepository Base { get; }

        ICollection<Campaign> GetCampaignsByUserEmail(string email);
        Campaign GetCampaignById(long campaign_id);
        ICollection<Campaign> GetCampaigns(int? appUserId = null);
        void UpdateCampaigns(ICollection<Campaign> toUpdate);
        void AddCampaigns(ICollection<Campaign> toAdd);
    }
}
