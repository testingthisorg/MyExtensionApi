using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.Creatives;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataAccess.Repositories
{
    public class AdCreativeRepository : BaseRepository, IAdCreativeRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        private readonly string key = "ad-creatives";
        public AdCreativeRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<long> GetAdCreativeIdsByOwnerId(long owner_id)
        {
            var items = _context.AdAccounts.Where(k => k.owner == owner_id)
                                .SelectMany(k => k.adcreatives.Select(m => m.id))
                                .ToList();
            return items;

        }
        public ICollection<AdCreative> GetAdCreativesByUserId(int appUserId)
        {
            var items = _context.AdAccounts.Where(k => k.AppUserId == appUserId)
                        .AsNoTracking()
                      .SelectMany(k => k.adcreatives)
                      .ToList();
            return items;
        }

        public void AddAdCreatives(ICollection<AdCreative> toAdd)
        {
            _context.AdCreatives.AddRange(toAdd);
        }

        public void UpdateAdCreatives(ICollection<AdCreative> toUpdate)
        {
            _context.AdCreatives.UpdateRange(toUpdate);
        }


    }
}
