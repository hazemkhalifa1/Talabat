using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public static class AppIdentityContextSeed
    {
        public static async Task AddIdentitySeeding(UserManager<AppUser> userManager)
        {
            if (!await userManager.Users.AnyAsync())
            {
                var User = new AppUser()
                {
                    DisplayName = "HazemKhalifa",
                    UserName = "hazemkhalifa1250",
                    Email = "hazemkhalifa1250@gmail.com",
                    PhoneNumber = "01554532035"
                };
                await userManager.CreateAsync(User, "Pa$$w0rd");
            }
        }
    }
}
