namespace DemoMiniApi.Users;

public class UserModule : Module
{
    public override void Configure(WebApplication app)
    {
        app.MapGet("/users", GetUsers.Endpoint.Handle)
            .WithName("getUsers")
            .WithSummary("Get users");

        app.MapGet("/users/{id:long}", GetUser.Endpoint.Handle)
            .WithName("getUser")
            .WithSummary("Get a user");

        app.MapPost("/users", AddUser.Endpoint.Handle)
            .WithSummary("Add a user");

        app.MapPut("/users/{id:long}", EditUser.Endpoint.Handle)
            .WithSummary("Edit a user");
    }
}
