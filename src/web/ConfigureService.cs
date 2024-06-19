using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace web;

public static class ConfigureService
{
    public static IServiceCollection AddWebServiceCollection(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<ApplicationDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection"));
    });
        return builder.Services;
    }
}

