using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;

namespace web;

public static class ConfigureService
{
    public static IServiceCollection AddWebConfigureService(this WebApplicationBuilder builder)
    {

    
        return builder.Services;
    }
    public static async Task<IApplicationBuilder>  AddWebAppService(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var loggerfactory = services.GetRequiredService<ILoggerFactory>();
        var context = services.GetRequiredService<ApplicationDbContext>();

        //auto migration

        try
        {
            await context.Database.MigrateAsync();
            await GenerateFakeData.SeedDataAsync(context, loggerfactory);
            //await GenerateFakeData.SeedDataAsync(context, loggerfactory);
        }
        catch (Exception ex)
        {

            var logger = loggerfactory.CreateLogger<Program>();
            logger.LogError(ex, message: ex.Message);
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

       // app.MapRazorPages();

        await app.RunAsync();
        return app;
    }
}

