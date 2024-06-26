using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;
using Web.Middleware;


namespace Web;

public static class ConfigureService
{
    public static IServiceCollection AddWebConfigureService(this WebApplicationBuilder builder, IConfiguration configuration)
    {


        builder.Services.AddControllers();
        //ApiBehaviorOptions(builder);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocumentation();
        //CORS Policy
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    //.WithOrigins(configuration["CorsAddress:AddressHttp"] ?? string.Empty,
                    //    configuration["CorsAddress:AddressHttp"] ?? string.Empty);
                });
            opt.AddPolicy("CorsPolicyadmin",
                policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    //.WithOrigins(configuration["CorsAddressadmin:AddressHttp"] ?? string.Empty,
                    //    configuration["CorsAddressadmin:AddressHttp"] ?? string.Empty);
                });
        });
        //IHttpContext Accessor
        //builder.Services.AddSingleton<ICurrentUserService, CurrentUserUserService>();
        builder.Services.AddHttpContextAccessor();
        //cache memory
        builder.Services.AddDistributedMemoryCache();
        return builder.Services;
    }
    public static async Task<IApplicationBuilder> AddWebAppService(this WebApplication app)
    {
        app.UseMiddleware<MiddlewareExceptionHandler>();

        //create scope
        var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        //get service
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var context = services.GetRequiredService<ApplicationDbContext>();
        //auto migrations
        try
        {
            await context.Database.MigrateAsync();
            await GenerateFakeData.SeedDataAsync(context, loggerFactory);
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(e, "error exception for migrations");
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerDocumentation();
        }

        //access to wwwroot
        app.UseStaticFiles();

        app.UseRouting();
        //CORS
        app.UseCors("CorsPolicy");
        app.UseCors("CorsPolicyadmin");


        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
        return app;
    }
}

