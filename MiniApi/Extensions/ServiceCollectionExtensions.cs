using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MiniApi;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterModules(this IServiceCollection services,
                                                     IConfiguration configuration,
                                                     IHostEnvironment environment,
                                                     IEnumerable<System.Reflection.Assembly> assembliesToScan)
    {
        var modules = new List<Module>();

        foreach (var assembly in assembliesToScan)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || type.IsGenericType || !type.IsAssignableTo(typeof(Module)))
                {
                    continue;
                }

                var module = (Module)Activator.CreateInstance(type)!;

                module.Configuration = configuration;
                module.Environment = environment;

                module.RegisterServices(services);

                modules.Add(module);
            }
        }

        services.AddSingleton<IEnumerable<Module>>(modules.ToArray());

        return services;
    }
}
