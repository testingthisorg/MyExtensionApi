using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using System;

namespace Assassins.DataModels.AdSets
{
    public class AdSet : IDataModel
    {
        public int AaId { get; set; }
        public long campaign_id { get; set; }
        public virtual Campaign Campaign { get; set; }
        public IDataViewModel ToViewModel()
        {
            throw new NotImplementedException();
        }
    }
    public class AdSetViewModel : IDataViewModel
    {
        public IDataModel ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
