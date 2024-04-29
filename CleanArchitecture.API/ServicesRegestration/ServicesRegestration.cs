using CleanArchitecture.Application.ServiesRegestration;
using CleanArchitecture.Infrastructure.InfrastructureServicesRegestration;
using CleanArchitecture.Persistence.PersistenceServicesRegestration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace CleanArchitecture.API.ServicesRegestration
{
    public static class ServicesRegestration
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.ConfigureApplicationServies();
            builder.Services.ConfigurPersistenceServicesRegestration(builder.Configuration);
            builder.Services.ConfigurInfrastructureServicesRegestration(builder.Configuration);


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }
    }
}

