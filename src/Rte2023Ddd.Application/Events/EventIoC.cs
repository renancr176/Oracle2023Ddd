using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Rte2023Ddd.Application.Events;

public static class EventIoC
{
    public static void AddEvents(this IServiceCollection services)
    {
        //services.AddScoped<INotificationHandler<SomeEvent>, SomeEventHandler>();
    }
}

