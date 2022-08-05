using System.Text.Json;

namespace DemoMiniApi.Users.EditUser;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Request req, IValidator<Request> validator, ILogger<UserModule> logger, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        logger.LogDebug("User {id} had been updated to {data}", req.Id, JsonSerializer.Serialize(req.Data));

        return Results.NoContent();
    }
}
