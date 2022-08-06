namespace DemoMiniApi.Users;

public class UserModule : Module
{
    public override void Configure(WebApplication app)
    {
        app.MapGet("/users", GetUsers.Endpoint.Handle)
           .WithName(nameof(GetUsers))
           .WithTags(nameof(Users));

        app.MapGet("/users/{id:long:min(1)}", GetUser.Endpoint.Handle)
           .WithName(nameof(GetUser))
           .WithTags(nameof(Users));

        app.MapPost("/users", AddUser.Endpoint.Handle)
           .WithName(nameof(AddUser))
           .WithTags(nameof(Users));

        app.MapPut("/users/{id:long:min(1)}", EditUser.Endpoint.Handle)
           .WithName(nameof(EditUser))
           .WithTags(nameof(Users));
    }
}
