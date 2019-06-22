using Assassins.DataModels.AdAccounts;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories.AdAccounts
{
    public interface IAdAccountRepository
    {
        BaseRepository Base { get; }

        ICollection<AdAccount> GetAdAccountsByOwnerId(long owner_id);
        ICollection<AdAccount> GetAdAccountsByUserId(int appUserId);
        AdAccount GetAdAccountById(long account_id);
        ICollection<AdAccount> GetAdAccountsByUserEmail(string email);
        void AddAdAccounts(ICollection<AdAccount> accounts);

        void UpdateAdAccounts(List<AdAccount> toUpdate);
        ICollection<long> GetAccountIdsByOwnerId(long owner_id);
    }
}
