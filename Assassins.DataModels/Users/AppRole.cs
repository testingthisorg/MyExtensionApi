using Assassins.DataModels.Interfaces;
using System.Collections.Generic;

namespace Assassins.DataModels.Users
{
    public class AppRole : IDataModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        // public List<AppUserRole> RoleUsers { get; set; }

        public IDataViewModel ToViewModel()
        {
            var item = new RoleViewModel()
            {
                RoleId = RoleId,
                Name = Name
            };

            //if (RoleUsers != null)
            //{
            //    item.RoleUsers = new List<AppUserViewModel>(RoleUsers.Select(k => (AppUserViewModel)k.User.ToViewModel()));
            //}
            return item;
        }
    }

    public class RoleViewModel : IDataViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<AppUserViewModel> RoleUsers { get; set; }

        public IDataModel ToModel()
        {
            var item = new AppRole()
            {
                RoleId = RoleId,
                Name = Name
            };

            return item;
        }
    }
}
