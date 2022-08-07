namespace DemoMiniApi.Features.Users;

public class UserModule : Module
{
    public override void Configure(WebApplication app)
    {
        const string tag = nameof(Users);

        app.MapGet("/users", GetPage.Endpoint.Handle)
           .WithTags(tag);

        app.MapGet("/users/{id:long:min(1)}", Get.Endpoint.Handle)
           .WithName("GetUser")
           .WithTags(tag);

        app.MapPost("/users", Add.Endpoint.Handle)
           .WithTags(tag);

        app.MapPut("/users/{id:long:min(1)}", Edit.Endpoint.Handle)
           .WithTags(tag);

        app.MapDelete("/users/{id:long:min(1)}", Remove.Endpoint.Handle)
           .WithTags(tag);
    }
}
