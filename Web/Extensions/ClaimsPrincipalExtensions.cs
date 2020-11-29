using Application.Structs;
using System;
using System.Linq;
using System.Security.Claims;

namespace Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Role).Value == Role.Administrator;
        }

        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt32(claimsPrincipal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
