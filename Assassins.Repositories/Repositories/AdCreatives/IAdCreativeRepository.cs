using Assassins.DataModels.Creatives;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories
{
    public interface IAdCreativeRepository
    {

        BaseRepository Base { get; }

        ICollection<long> GetAdCreativeIdsByOwnerId(long owner_id);
        ICollection<AdCreative> GetAdCreativesByUserId(int appUserId);
        void AddAdCreatives(ICollection<AdCreative> toAdd);
        void UpdateAdCreatives(ICollection<AdCreative> toUpdate);
    }
}
