#nullable disable

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiniApi;

public abstract class Module
{
    public virtual ModulePriority Priority => ModulePriority.Feature;

    public IConfiguration Configuration { get; internal set; }
    public IHostEnvironment Environment { get; internal set; }

    public virtual void RegisterServices(IServiceCollection services) { }
    public virtual void Configure(IApplicationBuilder app) { }
}
