using Microsoft.Extensions.DependencyInjection;
using Oracle2023Ddd.Domain.TmsContext.Interfaces.Validators;

namespace Oracle2023Ddd.Domain.TmsContext.Validators;

public static class ValidatorIoC
{
    public static void AddTmsValidators(this IServiceCollection services)
    {
        services.AddScoped<IAddressValidator, AddressValidator>();
        services.AddScoped<ICnaeValidator, CnaeValidator>();
        services.AddScoped<IPersonValidator, PersonValidator>();
    }
}
