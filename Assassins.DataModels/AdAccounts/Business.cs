using Assassins.DataModels.Interfaces;
using System.Collections.Generic;

namespace Assassins.DataModels.AdAccounts
{
    public class Business : IDataModel
    {
        //public int AaId { get; set; }
        public long id { get; set; }
        public string name { get; set; }
        public virtual ICollection<AdAccount> AdAccounts { get; set; }
        public IDataViewModel ToViewModel()
        {
            var vm = new BusinessViewModel()
            {
                //AaId = AaId,
                id = id,
                name = name
            };
            return vm;
        }
    }
    public class BusinessViewModel : IDataViewModel
    {
        //public int AaId { get; set; }
        public long id { get; set; }
        public string name { get; set; }

        public IDataModel ToModel()
        {
            var model = new Business()
            {
                //AaId = AaId,
                id = id,
                name = name
            };
            return model;
        }
    }
}
