using DemoMiniApi.Modules.Users.Models;

namespace DemoMiniApi.Modules.Users.GetUsers;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("users");
        AllowAnonymous();

        Description(b =>
        {
            b.Produces<Response>(StatusCodes.Status200OK, "application/json+custom");
            b.ProducesValidationProblem();
        });

        Summary(s =>
        {
            s.Summary = "Get an user";
            s.ExampleRequest = new Request { Filter = "john", Page = 1, PerPage = 20 };
            s.Responses[400] = "The request is invalidate";
        });
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        var users = new List<User>
        {
            new() { Id = 1, Name = "John", UserName = "john.1" },
            new() { Id = 2, Name = "bob", UserName = "bob.2" },
            new() { Id = 3, Name = "alice", UserName = "alice.3" }
        };

        var response = new Response();

        response.SetParams(req);
        response.SetResult(users, users.Count);

        return SendOkAsync(response, ct);
    }
}
