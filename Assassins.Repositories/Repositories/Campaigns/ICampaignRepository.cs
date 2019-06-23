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
        ICollection<long> GetCampaignIdsByUserEmail(string email);
        void UpdateCampaigns(ICollection<Campaign> toUpdate);
        void AddCampaigns(ICollection<Campaign> toAdd);
        ICollection<long> GetCampaignIdsByOwnerId(long owner_id);
        void AddCampaignHistoryItems(List<_CampaignHistoryItem> historyItems);
    }
}
