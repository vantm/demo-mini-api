using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.AddModules();

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

//////////////////////////////

var app = builder.Build();

app.UseDefaultExceptionHandler();
app.UseAuthorization();
app.UseModules();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

//////////////////////////////

app.Run();
