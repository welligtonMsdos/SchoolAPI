using SchoolAPI.Business.Services;
using SchoolAPI.Data.EFCore;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Repository;

namespace SchoolAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressEF>();
        services.AddScoped<IAddressService, AddressService>();

        return services;
    }
}
