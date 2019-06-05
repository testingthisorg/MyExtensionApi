using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataModels.Ads
{
    public class Ad : IDataModel
    {
        public IDataViewModel ToViewModel()
        {
            throw new NotImplementedException();
        }
    }
    public class AdViewModel : IDataViewModel
    {
        public IDataModel ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
