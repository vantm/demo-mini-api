namespace DemoMiniApi;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddModules(this WebApplicationBuilder builder)
    {
        builder.Services.RegisterModules(builder.Configuration, builder.Environment, new[]
        {
            typeof(Program).Assembly
        });

        return builder;
    }
}
