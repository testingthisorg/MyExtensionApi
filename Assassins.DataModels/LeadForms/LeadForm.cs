using Assassins.DataModels.AppUsers;
using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.LeadForms
{

    public class LeadForm : HistoryItem
    {
        public long id { get; set; }
        public override IDataViewModel ToViewModel()
        {
            throw new NotImplementedException();
        }
    }
    public class LeadFormViewModel : IDataViewModel
    {
        public long id { get; set; }
        public DataModel ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
