using AdminSchool.Application;
using AdminSchool.Infrastructure;

namespace AdminSchool.Api
{
    public static class DependecyInjection
    {
        public static IServiceCollection ConfiguraAdminSchoolService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAplicationServices(configuration);
            services.AddinfrastrucutreServices(configuration);
            return services;
        }

    }
}