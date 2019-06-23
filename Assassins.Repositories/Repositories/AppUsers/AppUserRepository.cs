using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.AppUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataAccess.Repositories.AppUsers
{
    public class AppUserRepository : BaseRepository, IAppUserRepository
    {
        public BaseRepository Base { get { return this as BaseRepository; } }
       
        public AppUserRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
            : base(context, appValConfig) { }

        public void AddUser(AppUser user)
        {
            // add to context
            _context.Add(user);

            // add to cache as well
            var users = GetUsers();
            users.Add(user);
            //AppValueCache.Set(key, users.OrderBy(k => k.Email).ToList());

        }

        public void DeleteUser(int id)
        {
            var user = GetUsers().FirstOrDefault(k => k.AppUserId == id);
            user.IsDeleted = true;
        }

        public AppUser GetUserByExternalId(string externalId)
        {
            var user = _context.AppUsers
                                    .AsNoTracking()
                                    .Include(k => k.UserRoles)
                                        .ThenInclude(k => k.Role)
                                        .FirstOrDefault(k => k.ExternalId == externalId);
            return user;
        }

        public AppUser GetUserById(int id)
        {
            var user = GetUsers().FirstOrDefault(k => k.AppUserId == id);
            return user;
        }
        public AppUser GetAppUserByEmail(string email)
        {
            var lwrEmail = email.ToLower();
            var user = GetUsers().FirstOrDefault(k => k.Email.ToLower() == lwrEmail);
            return user;
        }
        public ICollection<AppUser> GetUsers(bool includeDeleted = false)
        {
            List<AppUser> users = null;
            //if (AppValueCache.Contains(key))
            //{
            //    return (List<AppUser>)AppValueCache.Get(key);
            //}
            //else
            //{
                users = _context.AppUsers
                                    .AsNoTracking()
                                    .Include(k => k.UserRoles)
                                        .ThenInclude(k => k.Role)
                                    .OrderBy(k => k.Email)
                                    .ToList();
            //    AppValueCache.Set(key, users);
            //}
            if (!includeDeleted)
            {
                users = users.Where(k => k.IsDeleted == false).ToList();
            }
            return users;
        }



        public void SuspendUser(int id)
        {
            var user = GetUsers().FirstOrDefault(k => k.AppUserId == id);
            user.IsSuspended = true;
        }

        public void UpdateUser(AppUser user)
        {
            _context.Update(user);
        }

        public IQueryable<AppRole> GetUserRoles()
        {
            return _context.AppRoles;
        }

        public AppUser UpdateUser(int userId, string firstName, string lastName, string adAssassinId)
        {
            var user = _context.AppUsers.FirstOrDefault(k => k.AppUserId == userId);
            user.FirstName = firstName;
            user.LastName = lastName;
            user.AdAssassinId = adAssassinId;
            return user;
        }

        public ICollection<AppUserDataSync> GetUserDataSyncStatus(int id)
        {
            var items = _context.AppUserDataSyncs
                                .Where(k => k.AppUserId == id && 
                                            !(k.AdAccountsCompleted &&
                                            k.CampaignsCompleted &&
                                            k.AdSetsCompleted &&
                                            k.AdsCompleted &&
                                            k.CreativesCompleted &&
                                            k.LeadFormsCompleted &&
                                            k.AdImagesCompleted))
                                    .ToList();
            return items;
        }

        public void AddDataSyncStatus(AppUserDataSync newDs)
        {
            _context.AppUserDataSyncs.Add(newDs);
        }

        public AppUserDataSync GetCurrentDataSync(int appUserId)
        {
            var maxTime = _context.AppUserDataSyncs
                             .Where(k => k.AppUserId == appUserId)
                             .Max(k => k.StartTime);
            var item = _context.AppUserDataSyncs
                                .FirstOrDefault(k => k.AppUserId == appUserId && k.StartTime == maxTime);
            return item;
        }

        public void UpdateDataSync(AppUserDataSync dataSyncEntity)
        {
            _context.AppUserDataSyncs.Update(dataSyncEntity);
        }
    }
}
