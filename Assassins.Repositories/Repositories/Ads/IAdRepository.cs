using Assassins.DataModels.Ads;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories
{
    public interface IAdRepository
    {

        BaseRepository Base { get; }

        ICollection<Ad> GetAdsByUserId(int appUserId);
        ICollection<long> GetAdIdsByOwnerId(long owner_id);
        void AddAds(ICollection<Ad> toAdd);
        void UpdateAds(ICollection<Ad> toUpdate);
    }
}
