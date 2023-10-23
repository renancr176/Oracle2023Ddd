using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Rte2023Ddd.Domain.Core.Enums;
using Rte2023Ddd.Services.Api.Middlewares;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text.Json.Serialization;
using Rte2023Ddd.Infra.Data.Contexts.TmsDb;
using Microsoft.EntityFrameworkCore;
using Rte2023Ddd.Infra.CrossCutting.IoC;
using Rte2023Ddd.Domain.Core.Extensions;

namespace Rte2023Ddd.Services.Api;

public class StartupTests
{
    public StartupTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile($"appsettings.Testing.json", true, true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
        services.AddEndpointsApiExplorer();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(StartupTests).Assembly));
        services.AddAutoMapper(typeof(StartupTests).GetTypeInfo().Assembly);
        services.AddHttpContextAccessor();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        //services.Configure<RequestLocalizationOptions>(options =>
        //{
        //    var supportedCultures = new[]
        //    {
        //        new CultureInfo(LanguageEnum.Portugues.GetAttributeOfType<DescriptionAttribute>().Description),
        //        new CultureInfo(LanguageEnum.English.GetAttributeOfType<DescriptionAttribute>().Description)
        //    };
        //    options.DefaultRequestCulture = new RequestCulture(
        //        culture: LanguageEnum.English.GetAttributeOfType<DescriptionAttribute>().Description,
        //        uiCulture: LanguageEnum.English.GetAttributeOfType<DescriptionAttribute>().Description);
        //    options.SupportedCultures = supportedCultures;
        //    options.SupportedUICultures = supportedCultures;

        //    options.RequestCultureProviders.Clear();

        //    options.RequestCultureProviders.Insert(0,
        //        new AcceptLanguageHeaderRequestCultureProvider()
        //        {
        //            Options = options
        //        });
        //});

        services.RegisterServices(Configuration);

        Init(services.BuildServiceProvider());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

        app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseGlobalExceptionHandler();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void Init(IServiceProvider serviceProvider)
    {
        var scriptClearDataBase = @"
BEGIN
   FOR cur_rec IN (SELECT object_name, object_type
                   FROM user_objects
                   WHERE object_type IN
                             ('TABLE',
                              'VIEW',
                              'MATERIALIZED VIEW',
                              'PACKAGE',
                              'PROCEDURE',
                              'FUNCTION',
                              'SEQUENCE',
                              'SYNONYM',
                              'PACKAGE BODY'
                             ))
   LOOP
      BEGIN
         IF cur_rec.object_type = 'TABLE'
         THEN
            EXECUTE IMMEDIATE 'DROP '
                              || cur_rec.object_type
                              || ' ""'
                              || cur_rec.object_name
                              || '"" CASCADE CONSTRAINTS';
         ELSE
            EXECUTE IMMEDIATE 'DROP '
                              || cur_rec.object_type
                              || ' ""'
                              || cur_rec.object_name
                              || '""';
         END IF;
      EXCEPTION
         WHEN OTHERS
         THEN
            DBMS_OUTPUT.put_line ('FAILED: DROP '
                                  || cur_rec.object_type
                                  || ' ""'
                                  || cur_rec.object_name
                                  || '""'
                                 );
      END;
   END LOOP;
   FOR cur_rec IN (SELECT * 
                   FROM all_synonyms 
                   WHERE table_owner IN (SELECT USER FROM dual))
   LOOP
      BEGIN
         EXECUTE IMMEDIATE 'DROP PUBLIC SYNONYM ' || cur_rec.synonym_name;
      END;
   END LOOP;
END;";

        #region DigaXDbContext

        var defaultDbContext = serviceProvider.GetService<TmsDbContext>();

        //Delete all tables before run migrations
        defaultDbContext.Database.ExecuteSqlRaw(scriptClearDataBase);

        serviceProvider.TmsDbMigrate();

        #endregion
    }
}
