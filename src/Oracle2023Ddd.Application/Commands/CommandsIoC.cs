﻿using Microsoft.Extensions.DependencyInjection;

namespace Oracle2023Ddd.Application.Commands;

public static class CommandsIoC
{
    public static void AddCommands(this IServiceCollection services)
    {
        //services.AddScoped<IRequestHandler<SomeCommand, SomeEntiyModel?>, SomeCommandHandler>();
    }
}