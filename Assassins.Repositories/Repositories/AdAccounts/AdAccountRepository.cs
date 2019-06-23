using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataAccess.Repositories.AdAccounts
{
    public class AdAccountRepository : BaseRepository, IAdAccountRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        //private readonly string key = "aa-accounts";
        public AdAccountRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<AdAccount> GetAdAccountsByOwnerId(long owner_id)
        {
            List<AdAccount> accounts = null;
            accounts = _context.AdAccounts
                                .AsNoTracking()
                                .Where(k => k.owner == owner_id)
                                .ToList();

            return accounts;
        }
        public ICollection<AdAccount> GetAdAccountsByUserId(int appUserId)
        {
            List<AdAccount> accounts = null;
            accounts = _context.AdAccounts
                                .AsNoTracking()
                                .Where(k => k.AppUserId == appUserId)
                                .ToList();

            return accounts;
        }
        public AdAccount GetAdAccountById(long account_id)
        {
            var item = _context.AdAccounts.FirstOrDefault(k => k.account_id == account_id);
            return item;
        }


        public ICollection<AdAccount> GetAdAccountsByUserEmail(string email)
        {
            var user = _context.AppUsers
                                .Include(k => k.AdAccounts)
                                .FirstOrDefault(k => k.Email == email);
            var accounts = user.AdAccounts.ToList();
            return accounts;
        }

        public void AddAdAccounts(ICollection<AdAccount> accounts)
        {
            _context.AddRange(accounts);
        }

        public void UpdateAdAccounts(List<AdAccount> toUpdate)
        {
            _context.UpdateRange(toUpdate);
        }

        public ICollection<long> GetAccountIdsByOwnerId(long owner_id)
        {
            var ids = _context
                        .AdAccounts.Where(k => k.owner == owner_id)
                        .Select(k => k.account_id);
            return ids.ToList();
        }

        public void AddAdAccountHistoryItems(List<_AdAccountHistoryItem> historyItems)
        {
            _context._AdAccountHistory.AddRange(historyItems);
        }
    }
}
