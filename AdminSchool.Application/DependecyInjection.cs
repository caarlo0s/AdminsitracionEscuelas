using AdminSchool.Application.Common.Validators.Users;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AdminSchool.Application
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly));

            services.AddValidatorsFromAssemblyContaining<AddUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateUserCommandValidator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;        
        }
    }
}
