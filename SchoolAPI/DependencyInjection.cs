using SchoolAPI.Business.Services;
using SchoolAPI.Data.EFCore;
using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Repository;
using SchoolAPI.Profiles;

namespace SchoolAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAddressRepository, AddressEF>();
        services.AddScoped<IAddressService, AddressService>();

        services.AddScoped<IGradesRepository, GradesEF>();
        services.AddScoped<IGradesService, GradesService>();

        services.AddScoped<IStudentRepository, StudentEF>();
        services.AddScoped<IStudentService, StudentService>();

        services.AddScoped<IMatterRepository, MatterEF>();
        services.AddScoped<IMatterService, MatterService>();

        services.AddScoped<IProfessorRepository, ProfessorEF>();
        services.AddScoped<IProfessorService, ProfessorService>();

        services.AddScoped<IMatterProfessorRepository, MatterProfessorEF>();
        services.AddScoped<IMatterProfessorService, MatterProfessorService>();

        return services;
    }
}
