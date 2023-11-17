using Microsoft.Extensions.DependencyInjection;
using Rte2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Rte2023Ddd.Domain.TmsContext.Validators;

public static class ValidatorIoC
{
    public static void AddTmsValidators(this IServiceCollection services)
    {
        services.AddScoped<IAddressValidator, AddressValidator>();
        services.AddScoped<IPersonValidator, PersonValidator>();
    }
}
