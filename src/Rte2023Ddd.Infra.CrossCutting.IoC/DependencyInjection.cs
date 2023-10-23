using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rte2023Ddd.Application.Commands;
using Rte2023Ddd.Application.Events;
using Rte2023Ddd.Application.Queries;
using Rte2023Ddd.Application.Services;
using Rte2023Ddd.Domain.Core.Messages.CommonMessages.Notifications;
using Rte2023Ddd.Domain.Core.Options;
using Rte2023Ddd.Domain.TmsContext.Validators;
using Rte2023Ddd.Infra.Data.Contexts.TmsDb;

namespace Rte2023Ddd.Infra.CrossCutting.IoC;

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