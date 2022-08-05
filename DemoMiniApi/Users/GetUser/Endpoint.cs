using DemoMiniApi.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.GetUser;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Request req, CancellationToken ct)
    {
        if (req.Id > 10)
        {
            return Results.NotFound();
        }

        var entity = new User
        {
            Id = req.Id,
            Name = "John Doe",
            UserName = "john.d"
        };

        var response = new Response
        {
            Id = entity.Id,
            Name = entity.Name,
            UserName = entity.UserName
        };

        return Results.Ok(response);
    }
}
