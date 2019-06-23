using Assassins.DataModels.AppUsers;
using System;

namespace Assassins.DataModels.Interfaces
{
    public abstract class HistoryItem : DataModel
    {
        public long AppUserDataSyncId { get; set; }
        public AppUserDataSync AppUserDataSync { get; set; }
        public DateTime DateRecorded { get; set; }

    }
}
