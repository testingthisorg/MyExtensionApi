using Assassins.DataModels.AppUsers;
using System.Collections.Generic;
using System.Linq;

namespace Assassins.DataAccess.Repositories.AppUsers
{
    public interface IAppUserRepository
    {
        BaseRepository Base { get; }
        ICollection<AppUser> GetUsers(bool includeDeleted = false);
        AppUser GetUserById(int id);
        AppUser GetUserByExternalId(string externalId);
        AppUser GetAppUserByEmail(string email);
        void AddUser(AppUser user);
        void SuspendUser(int id);
        void DeleteUser(int id);
        void UpdateUser(AppUser user);
        IQueryable<AppRole> GetUserRoles();
        AppUser UpdateUser(int userId, string firstName, string lastName, string adAssassinId);
        ICollection<AppUserDataSync> GetUserDataSyncStatus(int id);
        void AddDataSyncStatus(AppUserDataSync newDs);
        AppUserDataSync GetCurrentDataSync(int appUserId);
        void UpdateDataSync(AppUserDataSync dataSyncEntity);
    }
}
