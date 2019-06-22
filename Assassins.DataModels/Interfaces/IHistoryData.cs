using Assassins.DataModels.AppUsers;
using System;

namespace Assassins.DataModels.Interfaces
{
    public interface IHistoryData
    {
        long AppUserDataSyncId { get; set; } 
        AppUserDataSync AppUserDataSync { get; set; }
        DateTime DateRecorded { get; set; }
    }
}
