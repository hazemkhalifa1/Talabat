using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities.Identity;
using Talabat.Repository.Data;
using Talabat.Repository.Identity;

namespace Talabat.APIs.Extensions
{
    public static class DatabaseServicesExtensions
    {
        public static async Task AddDatabaseServices(this WebApplication app)
        {
            using var Services = app.Services.CreateScope();
            var Service = Services.ServiceProvider;
            var LoggerFactory = Service.GetRequiredService<ILoggerFactory>();
            try
            {
                var DbContext = Service.GetRequiredService<TalabatContext>();
                var IdentityDbContext = Service.GetRequiredService<AppIdentityContext>();
                var userManger = Service.GetRequiredService<UserManager<AppUser>>();
                await DbContext.Database.MigrateAsync();
                await IdentityDbContext.Database.MigrateAsync();
                await TalabatContextSeeding.DataSeedingAsync(DbContext);
                await AppIdentityContextSeed.AddIdentitySeeding(userManger);
            }
            catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "This Error Appeared During Update-DataBase");
            }

        }
    }
}
