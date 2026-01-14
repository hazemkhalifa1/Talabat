using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Core.Entities.Identity;

namespace Talabat.APIs.Extensions
{
    public static class UserMangerExtenstion
    {
        public static async Task<AppUser> GetUserWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User)
        => await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == User.FindFirstValue(ClaimTypes.Email));


    }
}
