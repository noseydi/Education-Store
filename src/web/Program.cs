using Application;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureService(builder.Configuration);
//object value = builder.Services.ConfigureAutoMappers();
var app = builder.Build();
app.UseStaticFiles();
await app.AddWebAppService().ConfigureAwait(false);


//await app.AddWebAppService().ConfigureAwait(false);
