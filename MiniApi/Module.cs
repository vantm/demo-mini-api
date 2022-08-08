#nullable disable

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiniApi;

public abstract class Module
{
    public IConfiguration Configuration { get; internal set; }
    public IHostEnvironment Environment { get; internal set; }

    public virtual void RegisterServices(IServiceCollection services) { }
    public virtual void PreConfigure(WebApplication app) { }
    public virtual void Configure(WebApplication app) { }
    public virtual void PostConfigure(WebApplication app) { }
}
