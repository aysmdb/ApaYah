using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApaYah.Helper
{
    public static class ClaimExtension
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x => x.Type == "username")?.Value ?? string.Empty;
            }

            return string.Empty;
        }

        public static string GetRole(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(x => x.Type == "role")?.Value ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
