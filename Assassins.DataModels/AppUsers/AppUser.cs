using Assassins.DataModels.AdAccounts;
using Assassins.DataModels.Campaigns;
using Assassins.DataModels.Interfaces;
using System;
using System.Collections.Generic;

namespace Assassins.DataModels.AppUsers
{
    public class AppUser : IDataModel, IModificationHistory
    {
        public int AppUserId { get; set; }
        public long? id { get; set; }
        public string AvatarUrl { get; set; }
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AppUserDataSync> DataSyncs { get; set; }
        public virtual ICollection<AdAccount> AdAccounts { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }

        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public string AdAssassinId { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public IDataViewModel ToViewModel()
        {
            var item = new AppUserViewModel()
            {
                id = id,
                AppUserId = AppUserId,
                ExternalId = ExternalId,
                AvatarUrl = AvatarUrl,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                IsSuspended = IsSuspended,
                IsDeleted = IsDeleted,
                CreatedBy = CreatedBy,
                CreatedOn = CreatedOn,
                ModifiedBy = ModifiedBy,
                ModifiedOn = ModifiedOn,
                AdAssassinId = AdAssassinId
            };

            if (UserRoles != null)
            {
                item.UserRoles = new List<RoleViewModel>();
                foreach (var ur in UserRoles)
                {
                    if (ur.Role != null)
                        item.UserRoles.Add((RoleViewModel)ur.Role.ToViewModel());
                }
            }

            return item;
        }
    }

    public class AppUserViewModel : IDataViewModel
    {
        public long? id { get; set; }
        public int AppUserId { get; set; }
        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<RoleViewModel> UserRoles { get; set; }
        public string AvatarUrl { get; set; }
        public string AdAssassinId { get; set; }

        public IDataModel ToModel()
        {
            var item = new AppUser()
            {
                id = id,
                AppUserId = AppUserId,
                AvatarUrl = AvatarUrl,
                ExternalId = ExternalId,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                IsSuspended = IsSuspended,
                IsDeleted = IsDeleted,
                AdAssassinId = AdAssassinId,
            };
            return item;
        }
    }

}
