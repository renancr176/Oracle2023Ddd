using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb;

public static class TmsDb
{
    public static void AddTmsDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TmsDbContext>(dbContextOptions =>
            dbContextOptions.UseOracle(configuration.GetConnectionString("TMS")));

        //OracleConfiguration.TnsAdmin = @"J:\TNSNAMES";

        #region Repositories

        //services.AddScoped<ISomeEntityRepository, SomeEntityRepository>();

        #endregion

        #region Seeders

        //services.AddScoped<ISomeSeed, SomeSeed>();

        #endregion
    }

    public static void TmsDbMigrate(this IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetService<TmsDbContext>();
        dbContext.Database.Migrate();

        #region Seeders

        Task.Run(async () =>
        {
            //await serviceProvider.GetService<ISomeSeed>().SeedAsync();
        }).Wait();

        #endregion
    }
}