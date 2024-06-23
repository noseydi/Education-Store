using Application.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection"));
            });
           // services.AddScoped(typeof (GenericRepository<>), typeof(IGenericRepository<>));
           services.AddScoped<IUnitOfWork , UnitOfWorks>();
            return services;

        }
    }
}
