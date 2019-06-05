using Assassins.DataModels.AdAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataAccess.Repositories.AaAccounts
{
    public interface IAaAccountRepository
    {
        BaseRepository Base { get; }

        ICollection<AdAccount> GetAdAccounts(int? appUserId = null);
        AdAccount GetAdAccountById(int id);
        ICollection<AdAccount> GetAdAccountsByUserEmail(string email);
        void AddAdAccounts(ICollection<AdAccount> accounts);
    }
}
