using DemoMiniApi.Modules;
using MiniApi.ApiEndpoints;

namespace DemoMiniApi;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddModules(this WebApplicationBuilder builder)
    {
        ApiEndpointModule.ModuleAssemblies.AddRange(new[]
        {
            typeof(ApiEndpointModule).Assembly,
            typeof(DemoModules).Assembly
        });

        builder.Services.RegisterModules(builder.Configuration, builder.Environment, ApiEndpointModule.ModuleAssemblies);

        return builder;
    }
}
