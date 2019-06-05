using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Assassins.Configuration;
using Assassins.DataAccess.Contexts;
using Assassins.DataModels.Interfaces;
using Assassins.Helpers;
using System;
using System.Linq;
using System.Security.Claims;

namespace Assassins.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        internal MainContext _context;
        internal readonly IOptions<AppValueConfig> _appValConfig;
        public BaseRepository(MainContext context, IOptions<AppValueConfig> appValConfig)
        {
            _context = context;
            _appValConfig = appValConfig;
        }
        public bool SaveAll(ClaimsPrincipal user)
        {
            var email = UserClaimHelpers.Email(user.Identity);
            return SaveAll(email);
        }

        public bool SaveAll(string email)
        {
            foreach (var history in _context.ChangeTracker.Entries()
                            .Where(e => e.Entity is IModificationHistory &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified))
                            .Select(e => e.Entity as IModificationHistory))
            {
                history.ModifiedBy = email;
                if (string.IsNullOrEmpty(history.CreatedBy))
                {
                    history.CreatedBy = email;
                }

                history.ModifiedOn = DateTime.UtcNow;
                if (history.CreatedOn == DateTime.MinValue)
                {
                    history.CreatedOn = DateTime.UtcNow;
                }
            }

            return _context.SaveChanges() > 0;
        }
    }
}
