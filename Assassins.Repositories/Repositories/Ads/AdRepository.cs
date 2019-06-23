using System.Collections.Generic;
using System.Linq;
using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.Ads;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assassins.DataAccess.Repositories
{
    public class AdRepository : BaseRepository, IAdRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        //private readonly string key = "ads";
        public AdRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<Ad> GetAdsByUserId(int appUserId)
        {
            var items = _context.Campaigns
                            .AsNoTracking()
                            .Where(k => k.AppUserId == appUserId)
                            .SelectMany(k => k.adsets.SelectMany(m => m.Ads))
                            .ToList();
            return items;
        }

        public ICollection<long> GetAdIdsByOwnerId(long owner_id)
        {
            var items = _context.AdAccounts
                .Where(k => k.owner == owner_id)
                .SelectMany(k => k.adsets.SelectMany(m => m.Ads))
                .Select(k => k.id)
                .ToList();
            return items;
        }

        public void AddAds(ICollection<Ad> toAdd)
        {
            _context.Ads.AddRange(toAdd);
        }

        public void UpdateAds(ICollection<Ad> toUpdate)
        {
            _context.Ads.UpdateRange(toUpdate);
        }

        public void AddAdHistoryItems(List<_AdHistoryItem> historyItems)
        {
            _context._AdHistory.AddRange(historyItems);
        }
    }
}
