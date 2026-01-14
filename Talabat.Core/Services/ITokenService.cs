using Microsoft.AspNetCore.Identity;
using Talabat.Core.Entities.Identity;

namespace Talabat.Core.Services
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
