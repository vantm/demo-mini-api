using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace DemoMiniApi.Modules.Users.EditUser;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Put("users/{Id}");
    }

    public override Task HandleAsync(Request req, CancellationToken ct)
    {
        ThrowIfAnyErrors();

        Logger.LogDebug("User {id} had been updated to {data}", req.Id, JsonSerializer.Serialize(req));

        return SendNoContentAsync(ct);
    }
}
