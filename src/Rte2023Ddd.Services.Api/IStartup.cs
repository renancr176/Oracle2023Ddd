namespace Rte2023Ddd.Services.Api;

public interface IStartup
{
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }
    void Configure(WebApplication app, IWebHostEnvironment env);
    void ConfigureServices(IServiceCollection services);
}