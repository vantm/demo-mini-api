namespace DemoMiniApi.Modules.Users.AddUser;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("users");
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        ThrowIfAnyErrors();

        return SendCreatedAtAsync("users", 4, new()
        {
            Id = 4,
            Name = req.Name,
            UserName = req.UserName
        }, cancellation: ct);
    }
}
