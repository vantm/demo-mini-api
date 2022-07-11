using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiniApi;

namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseModules(this IApplicationBuilder app)
    {
        var modules = app.ApplicationServices.GetRequiredService<IEnumerable<Module>>();
        var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger(typeof(Module).Namespace!);

        foreach (var module in modules.OrderBy(x => x.Priority))
        {
            module.Configure(app);

            logger.LogDebug("Configured module {name}.", module.GetType().FullName);
        }

        return app;
    }
}
