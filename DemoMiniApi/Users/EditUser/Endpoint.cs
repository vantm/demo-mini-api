using System.Text.Json;

namespace DemoMiniApi.Users.EditUser;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Parameters parameters, IValidator<Request> validator, ILogger<UserModule> logger, CancellationToken ct)
    {
        validator.ValidateAndThrow(parameters.Request);

        logger.LogDebug("User {id} had been updated to {data}", parameters.Id, JsonSerializer.Serialize(parameters.Request));

        return Results.NoContent();
    }
}
