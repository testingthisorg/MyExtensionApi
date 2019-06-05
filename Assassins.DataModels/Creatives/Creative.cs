using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assassins.DataModels.Creatives
{
    public class Creative : IDataModel
    {
        public IDataViewModel ToViewModel()
        {
            throw new NotImplementedException();
        }
    }
    public class CreativeViewModel : IDataViewModel
    {
        public IDataModel ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
