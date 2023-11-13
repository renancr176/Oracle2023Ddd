using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Rte2023Ddd.Infra.Data.Contexts.TmsDb.Repositories;

namespace Rte2023Ddd.Infra.Data.Contexts.TmsDb;

public static class TmsDb
{
    public static void AddTmsDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TmsDbContext>(dbContextOptions =>
            dbContextOptions.UseOracle(configuration.GetConnectionString("TMS"), op => {
                op.UseOracleSQLCompatibility("11");
            }));

        //OracleConfiguration.TnsAdmin = @"J:\TNSNAMES";

        #region Repositories

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();

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