using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.ServiesRegestration
{
    public static class RegisterDependentServices
    {
        public static IServiceCollection ConfigureApplicationServies(this IServiceCollection services)
        {
            #region Data dependencies

            var assembly = typeof(RegisterDependentServices).Assembly;

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(m => m.RegisterServicesFromAssembly(assembly));

            #endregion

            return services;
        }

    }
}