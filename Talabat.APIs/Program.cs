using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.APIs.Extensions;
using Talabat.APIs.MiddleWare;
using Talabat.Repository.Data;
using Talabat.Repository.Identity;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<TalabatContext>(o =>
        {
            o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddDbContext<AppIdentityContext>(o =>
        {
            o.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
        });

        builder.Services.AddSingleton<IConnectionMultiplexer>(Options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Redis");
            return ConnectionMultiplexer.Connect(connectionString);
        });

        builder.Services.AddApplicationServices();
        builder.Services.AddIdentityServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        #region Update-DataBase
        //await app.AddDatabaseServices();
        #endregion

        app.UseStatusCodePagesWithReExecute("/errors/{0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}