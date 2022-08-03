using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniApi;

namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseModules(this IApplicationBuilder app)
    {
        var moduleLocator = app.ApplicationServices.GetRequiredService<ModuleLocator>();
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(Module).Namespace!);

        foreach (var module in moduleLocator.Items)
        {
            module.PreConfigure(app);
            logger.LogDebug("Pre-configure for the module '{Name}'", module.GetType().Name);
        }

        foreach (var module in moduleLocator.Items)
        {
            module.Configure(app);
            logger.LogDebug("Configure for the module '{Name}'", module.GetType().Name);
        }

        foreach (var module in moduleLocator.Items)
        {
            module.PostConfigure(app);
            logger.LogDebug("Post-configure for the module '{Name}'", module.GetType().Name);
        }

        return app;
    }
}
