using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.Campaigns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataAccess.Repositories.Campaigns
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        //private readonly string key = "campaigns";
        public CampaignRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<Campaign> GetCampaignsByUserEmail(string email)
        {
            var items = _context.AdAccounts.Where(k => k.AppUser.Email == email)
                                .SelectMany(k => k.campaigns).ToList();
            return items;
        }
        public ICollection<long> GetCampaignIdsByUserEmail(string email)
        {
            var items = _context.AdAccounts.Where(k => k.AppUser.Email == email)
                                .SelectMany(k => k.campaigns.Select(m => m.id)).ToList();
            return items;
        }
        public Campaign GetCampaignById(long campaign_id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Campaign> GetCampaigns(int? appUserId = null)
        {
            List<Campaign> campaigns = null;
            if (appUserId.HasValue)
            {
                campaigns = _context.Campaigns
                                    .AsNoTracking()
                                    .Where(k => k.AppUserId == appUserId.Value)
                                    .ToList();
            }
            else
            {
                campaigns = _context.Campaigns.AsNoTracking().ToList();
            }
            return campaigns;
        }

        public void UpdateCampaigns(ICollection<Campaign> toUpdate)
        {
            _context.Campaigns.UpdateRange(toUpdate);
        }

        public void AddCampaigns(ICollection<Campaign> toAdd)
        {
            _context.Campaigns.AddRange(toAdd);
        }

        public ICollection<long> GetCampaignIdsByOwnerId(long owner_id)
        {
            var cmps = _context.Campaigns.Where(k => k.AppUser.id == owner_id)
                                .Select(k => k.id).ToList();
            return cmps;
        }

        public void AddCampaignHistoryItems(List<_CampaignHistoryItem> historyItems)
        {
            _context._CampaignHistory.AddRange(historyItems);
        }
    }
}
