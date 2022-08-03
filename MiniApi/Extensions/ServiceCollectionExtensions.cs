using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MiniApi;
using System.Reflection;
using Module = MiniApi.Module;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterEntryModule<T>(this IServiceCollection services,
                                                            IConfiguration configuration,
                                                            IHostEnvironment environment) where T : Module
    {
        var queue = new Queue<Type>();
        var moduleTypes = new HashSet<Type>();

        queue.Enqueue(typeof(T));

        while (queue.Count > 0)
        {
            var currentModuleType = queue.Dequeue();

            moduleTypes.Add(currentModuleType);

            var dependedModuleTypes = GetDependModuleTypes(currentModuleType);

            foreach (var dependedModule in dependedModuleTypes)
            {
                if (!queue.Contains(dependedModule) &&
                    !moduleTypes.Contains(dependedModule))
                {
                    queue.Enqueue(dependedModule);
                }
            }
        }

        var modules = new List<Module>();

        foreach (var moduleType in moduleTypes.Reverse())
        {
            var module = (Module)Activator.CreateInstance(moduleType)!;

            module.Configuration = configuration;
            module.Environment = environment;

            module.RegisterServices(services);

            modules.Add(module);
        }

        services.AddSingleton(new ModuleLocator(modules.ToArray()));

        return services;
    }

    private static Type[] GetDependModuleTypes(Type currentModuleType)
    {
        var dependsOnAttribute = currentModuleType.GetCustomAttribute<DependsOnAttribute>();

        if (dependsOnAttribute == null)
        {
            return Array.Empty<Type>();
        }

        return dependsOnAttribute.Types;
    }
}
