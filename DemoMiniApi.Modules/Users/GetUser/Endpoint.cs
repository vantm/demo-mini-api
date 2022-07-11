﻿using DemoMiniApi.Modules.Users.Models;
using Microsoft.AspNetCore.Http;

namespace DemoMiniApi.Modules.Users.GetUser;

public class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Get("users/{Id}");

        Description(b => b
            .Accepts<Request>("application/json+custom")
            .Produces<Response>(StatusCodes.Status200OK, "application/json+custom")
            .ProducesValidationProblem());

        Summary(s =>
        {
            s.Summary = "Get an user";
            s.ExampleRequest = new Request { Id = 1 };
            s.Responses[200] = "The user is found.";
            s.Responses[404] = "The user is not found";
        });
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        ThrowIfAnyErrors();

        if (req.Id > 10)
        {
            await SendNotFoundAsync(ct);
        }

        var entity = new User
        {
            Id = req.Id,
            Name = "John Doe",
            UserName = "john.d"
        };

        var response = await Map.FromEntityAsync(entity);

        await SendOkAsync(response, ct);
    }
}
