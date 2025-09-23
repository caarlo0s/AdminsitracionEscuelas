using AdminSchool.Domain.Interfaces;
using AdminSchool.Infrastructure.Interfaces;
using AdminSchool.Infrastructure.Persistence;
using AdminSchool.Infrastructure.Repositories;
using AdminSchool.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminSchool.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddinfrastrucutreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdminDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAuth, AuthRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<IPermission, PermissionRepository>();
            services.AddScoped<IEducationLevel, EducationLevelRepository>();
            services.AddScoped<IStudent, StudentRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }

    }
}
