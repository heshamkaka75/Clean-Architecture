using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Options;
using CleanArchitecture.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Infrastructure.InfrastructureServicesRegestration
{
    public static class InfrastructureServicesRegestration
    {
        public static IServiceCollection ConfigurInfrastructureServicesRegestration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpOptions>(configuration.GetSection(nameof(SmtpOptions)));
            services.AddTransient<IMessagerService, MessagerService>();

            return services;
        }
    }
}
