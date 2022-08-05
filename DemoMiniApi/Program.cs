var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterEntryModule<StartupModule>(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseModules();
app.Run();
