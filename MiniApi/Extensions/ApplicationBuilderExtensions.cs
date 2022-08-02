using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniApi;

namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseModules(this IApplicationBuilder app,
        Action? preConfigure = null,
        Action? postConfigure = null)
    {
        var moduleLocator = app.ApplicationServices.GetRequiredService<ModuleLocator>();
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(Module).Namespace!);

        preConfigure?.Invoke();

        foreach (var module in moduleLocator.Items)
        {
            module.PreConfigure(app);
            logger.LogDebug("Completed to configure for module {Name}", module.GetType().Name);
        }

        foreach (var module in moduleLocator.Items)
        {
            module.Configure(app);
            logger.LogDebug("Completed to configure for module {Name}", module.GetType().Name);
        }

        foreach (var module in moduleLocator.Items)
        {
            module.PostConfigure(app);
            logger.LogDebug("Completed to configure for module {Name}", module.GetType().Name);
        }

        postConfigure?.Invoke();

        return app;
    }
}
