using Microsoft.Extensions.DependencyInjection;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public static class ValidatorIoC
{
    public static void AddTmsValidators(this IServiceCollection services)
    {
        //services.AddScoped<ISomeEntityValidator, SomeEntityValidator>();
    }
}
