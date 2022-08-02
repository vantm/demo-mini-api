namespace DemoMiniApi.Users.AddUser;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("users");
        AllowAnonymous();

        Description(b =>
        {
            b.Produces(StatusCodes.Status201Created, typeof(Response), "application/json+custom");
            b.ProducesValidationProblem();
        });

        Summary(s =>
        {
            s.Summary = "Add an new user";
            s.ExampleRequest = new Request { UserName = "john.doe", Name = "John Doe" };
            s.Responses[204] = "The user had been created";
            s.Responses[400] = "The request is invalidate";
        });
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        return SendCreatedAtAsync("getUser", new { Id = 4 }, new()
        {
            Id = 4,
            Name = req.Name,
            UserName = req.UserName
        }, cancellation: ct);
    }
}
