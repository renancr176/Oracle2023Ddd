using Microsoft.Extensions.DependencyInjection;

namespace Oracle2023Ddd.Application.Events;

public static class EventIoC
{
    public static void AddEvents(this IServiceCollection services)
    {
        //services.AddScoped<INotificationHandler<SomeEvent>, SomeEventHandler>();
    }
}

