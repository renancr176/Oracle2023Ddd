using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oracle2023Ddd.Application.Commands;
using Oracle2023Ddd.Application.Events;
using Oracle2023Ddd.Application.Queries;
using Oracle2023Ddd.Application.Services;
using Oracle2023Ddd.Domain.Core.Messages.CommonMessages.Notifications;
using Oracle2023Ddd.Domain.TmsContext.Validators;
using Oracle2023Ddd.Infra.Data.Contexts.TmsDb;

namespace Oracle2023Ddd.Infra.CrossCutting.IoC;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        //services.AddAutoMapperProfiles();

        #region Options

        //services.Configure<JwtTokenOptions>(configuration.GetSection(JwtTokenOptions.sectionKey));

        #endregion

        #region DbContexts

        services.AddTmsDb(configuration);

        #endregion

        services.AddCommands();
        services.AddEvents();
        services.AddQueries();
        services.AddServices();

        services.AddTmsValidators();

        #region External Services

        #endregion
    }
}