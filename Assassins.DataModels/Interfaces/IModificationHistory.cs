using System;

namespace Assassins.DataModels.Interfaces
{
    public interface IModificationHistory
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
