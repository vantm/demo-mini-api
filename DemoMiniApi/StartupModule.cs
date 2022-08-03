using DemoMiniApi.Users;
using FastEndpoints.Swagger;

namespace DemoMiniApi
{
    [DependsOn(
        typeof(UserModule)
    )]
    public class StartupModule : Module
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddFastEndpoints(o =>
            {
                o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All;
            });

            services.AddSwaggerDoc(s =>
            {
                s.Title = "My API";
                s.Description = "Demo MiniAPI";
                s.Version = "v1";
            });
        }

        public override void PreConfigure(IApplicationBuilder app)
        {
            app.UseDefaultExceptionHandler();
            app.UseAuthorization();
        }

        public override void PostConfigure(IApplicationBuilder app)
        {
            ((WebApplication)app).UseFastEndpoints();
            app.UseOpenApi();
            app.UseSwaggerUi3(c => c.ConfigureDefaults());
        }
    }
}
