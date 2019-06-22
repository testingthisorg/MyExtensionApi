using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.LeadForms
{

    public class LeadForm : IDataModel, IHistoryData
    {
        public DateTime DateRecorded { get; set; }
        public long AppUserDataSyncId { get; set; }
        public virtual AppUserDataSync AppUserDataSync { get; set; }


        public long id { get; set; }
        public override IDataViewModel ToViewModel()
        {
            throw new NotImplementedException();
        }
    }
    public class LeadFormViewModel : IDataViewModel
    {
        public long id { get; set; }
        public IDataModel ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
