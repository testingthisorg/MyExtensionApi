using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.AdImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataAccess.Repositories
{
    public class AdImageRepository : BaseRepository, IAdImageRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        //private readonly string key = "ad-creatives";
        public AdImageRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<long> GetAdImageIdsByOwnerId(long owner_id)
        {
            var items = _context.AdAccounts.Where(k => k.owner == owner_id)
                                .SelectMany(k => k.adcreatives.Select(m => m.id))
                                .ToList();
            return items;

        }
        public ICollection<AdImage> GetAdImagesByUserId(int appUserId)
        {
            var items = _context.AdAccounts.Where(k => k.AppUserId == appUserId)
                        .AsNoTracking()
                      .SelectMany(k => k.adimages)
                      .ToList();
            return items;
        }

        public void AddAdImages(ICollection<AdImage> toAdd)
        {
            _context.AdImages.AddRange(toAdd);
        }

        public void UpdateAdImages(ICollection<AdImage> toUpdate)
        {
            _context.AdImages.UpdateRange(toUpdate);
        }

        public void AddAdImageHistoryItems(List<_AdImageHistoryItem> historyItems)
        {
            _context._AdImageHistory.AddRange(historyItems);
        }
    }
}
