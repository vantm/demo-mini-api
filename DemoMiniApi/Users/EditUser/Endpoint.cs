using System.Text.Json;

namespace DemoMiniApi.Modules.Users.EditUser;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Put("users/{Id}");
        AllowAnonymous();

        Description(b =>
        {
            b.Produces(StatusCodes.Status204NoContent);
            b.ProducesProblem(StatusCodes.Status404NotFound, "application/json+problem");
            b.ProducesValidationProblem();
        });

        Summary(s =>
        {
            s.Summary = "Edit an user";
            s.ExampleRequest = new Request { Id = 1, UserName = "john.doe", Name = "John Doe" };
            s.Responses[200] = "The user is found";
            s.Responses[400] = "The request is invalidate";
            s.Responses[404] = "The user is not found";
        });
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        Logger.LogDebug("User {id} had been updated to {data}", req.Id, JsonSerializer.Serialize(req));

        return SendNoContentAsync(ct);
    }
}
