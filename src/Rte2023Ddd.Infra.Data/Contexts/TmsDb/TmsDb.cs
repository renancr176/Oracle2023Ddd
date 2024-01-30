using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Repositories;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Repositories;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Seeders;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb.Seeders.Interfaces;

namespace Oracle2023Ddd.Infra.Data.Contexts.TmsDb;

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
        services.AddScoped<ICnaeRepository, CnaeRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();

        #endregion

        #region Seeders

        services.AddScoped<ICaneSeeder, CaneSeeder>();

        #endregion
    }

    public static void TmsDbMigrate(this IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetService<TmsDbContext>();
        dbContext.Database.Migrate();

        #region Seeders

        Task.Run(async () =>
        {
            await serviceProvider.GetService<ICaneSeeder>().SeedAsync();
        }).Wait();

        #endregion
    }
}