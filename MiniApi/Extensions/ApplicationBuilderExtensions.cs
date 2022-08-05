using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static WebApplication UseModules(this WebApplication app)
    {
        var moduleLocator = app.Services.GetRequiredService<ModuleLocator>();
        var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(Module).Namespace!);

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

        return app;
    }
}
