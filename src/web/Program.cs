using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServiceCollection();
var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var loggerfactory = services.GetRequiredService<ILoggerFactory>();
//auto migration

try
{
    var context = services.GetRequiredService<ApplicationDbContext>();
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

app.MapRazorPages();

app.Run();
