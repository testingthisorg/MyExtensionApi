using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.AdAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataAccess.Repositories.AaAccounts
{
    public class AaAccountRepository : BaseRepository, IAaAccountRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
        private readonly string key = "aa-accounts";
        public AaAccountRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public ICollection<AdAccount> GetAdAccounts(int? appUserId = null)
        {
            List<AdAccount> accounts = null;
            if (appUserId.HasValue)
            {
                accounts = _context.AdAccounts
                                    .Where(k => k.AppUserId == appUserId.Value)
                                    .ToList();
            }
            else
            {
                accounts = _context.AdAccounts.ToList();
            }
            return accounts;
        }

        public AdAccount GetAdAccountById(int id)
        {
            var item = _context.AdAccounts.FirstOrDefault(k => k.AaId == id);
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
    }
}
