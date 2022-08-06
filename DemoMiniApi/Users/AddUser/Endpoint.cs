using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.AddUser;

public static class Endpoint
{
    public static IResult Handle([FromBody] Request req, IValidator<Request> validator, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var response = new Response
        {
            Id = 4,
            Name = req.Name,
            UserName = req.UserName
        };

        return Results.CreatedAtRoute(nameof(GetUser), new { Id = 4 }, response);
    }
}
