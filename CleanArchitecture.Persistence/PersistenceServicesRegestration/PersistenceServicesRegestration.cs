using CleanArchitecture.Application.Contracts.Persistence.IBaseRepository;
using CleanArchitecture.Application.Contracts.Persistence.IRepository;
using CleanArchitecture.Application.Contracts.Persistence.IUnitOfWork;
using CleanArchitecture.Persistence.BaseRepository;
using CleanArchitecture.Persistence.Data;
using CleanArchitecture.Persistence.Persistence.UnitOfWork;
using CleanArchitecture.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.PersistenceServicesRegestration
{
    public static class PersistenceServicesRegestration
    {
        public static IServiceCollection ConfigurPersistenceServicesRegestration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
