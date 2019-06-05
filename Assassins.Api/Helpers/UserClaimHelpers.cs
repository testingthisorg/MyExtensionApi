using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Assassins.Api.Helpers
{
    public static class UserClaimHelpers
    {
        public static List<string> Roles(IIdentity Identity)
        {
            var cId = (ClaimsIdentity)Identity;
            var roles = cId.Claims.Where(k => k.Type == "roles").Select(k => k.Value).ToList();
            return roles;
        }
        public static string Email(IIdentity Identity)
        {
            var cId = (ClaimsIdentity)Identity;
            //var claimEmail = cId.Claims.FirstOrDefault(k => k.Type.ToLower() == "email");
            var claimEmail = cId.Claims.FirstOrDefault(k => k.Type.ToLower().Contains("email"));
            if (claimEmail != null)
                return claimEmail.Value;
            else
                return null;
        }
    }
}
