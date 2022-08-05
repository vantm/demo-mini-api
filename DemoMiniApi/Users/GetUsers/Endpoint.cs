using DemoMiniApi.Users.Models;

namespace DemoMiniApi.Users.GetUsers;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Request req, IValidator<Request> validator, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var users = new List<User>
        {
            new() { Id = 1, Name = "John", UserName = "john.1" },
            new() { Id = 2, Name = "bob", UserName = "bob.2" },
            new() { Id = 3, Name = "alice", UserName = "alice.3" }
        };

        var response = new Response();

        response.SetParams(req);
        response.SetResult(users, users.Count);

        return Results.Ok(response);
    }
}
