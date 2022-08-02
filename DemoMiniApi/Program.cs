using DemoMiniApi.Users;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints(o =>
{
    o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All;
});

builder.Services.AddSwaggerDoc(s =>
{
    s.Title = "My API";
    s.Description = "Demo MiniAPI";
    s.Version = "v1";
});

builder.Services.RegisterApplicationModule<UserModule>(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseModules(preConfigure: () =>
{
    app.UseDefaultExceptionHandler();
    app.UseAuthorization();
}, postConfigure: () =>
{
    app.UseFastEndpoints();
    app.UseOpenApi();
    app.UseSwaggerUi3(c => c.ConfigureDefaults());
});


app.Run();
