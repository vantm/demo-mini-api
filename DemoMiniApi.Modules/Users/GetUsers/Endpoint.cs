using DemoMiniApi.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoMiniApi.Modules.Users.GetUsers;

public class Endpoint : EndpointBaseAsync
    .WithRequest<Request>
    .WithResult<Response>
{
    private readonly IValidator<Request> _validator;

    public Endpoint(IValidator<Request> validator)
    {
        _validator = validator;
    }

    [HttpGet("users")]
    [SwaggerOperation(Summary = "List users page by page")]
    public override async Task<Response> HandleAsync([FromQuery] Request request, CancellationToken cancellationToken = default)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var users = new List<User>
        {
            new() { Id = 1, Name = "John", UserName = "john.1" },
            new() { Id = 2, Name = "bob", UserName = "bob.2" },
            new() { Id = 3, Name = "alice", UserName = "alice.3" }
        };

        return new Response(users, users.Count, request);
    }
}
