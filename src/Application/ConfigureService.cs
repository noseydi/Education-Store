using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
namespace Application
{
    public static class ConfigureService
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //  services.AddMediatR(cfg =>   cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper( Assembly.GetExecutingAssembly());
              services.AddMediatR(cfg2 => cfg2.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        }
    }
}
