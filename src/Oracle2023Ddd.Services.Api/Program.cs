using Oracle2023Ddd.Services.Api;
using Oracle2023Ddd.Services.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureSerilog();
builder.UseStartup<Startup>();