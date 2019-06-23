using Assassins.DataModels.AdImages;
using System.Collections.Generic;

namespace Assassins.DataAccess.Repositories
{
    public interface IAdImageRepository
    {

        BaseRepository Base { get; }

        ICollection<long> GetAdImageIdsByOwnerId(long owner_id);
        ICollection<AdImage> GetAdImagesByUserId(int appUserId);
        void AddAdImages(ICollection<AdImage> toAdd);
        void UpdateAdImages(ICollection<AdImage> toUpdate);
        void AddAdImageHistoryItems(List<_AdImageHistoryItem> historyItems);
    }
}
