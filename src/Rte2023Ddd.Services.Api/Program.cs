using Rte2023Ddd.Services.Api.Extensions;
using Rte2023Ddd.Services.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureSerilog();
builder.UseStartup<Startup>();