using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace DemoMiniApi.Modules.Users.EditUser;

public class Endpoint : EndpointBaseAsync
    .WithRequest<Request>
    .WithoutResult
{
    private readonly IValidator<Request> _validator;
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(IValidator<Request> validator, ILogger<Endpoint> logger)
    {
        _validator = validator;
        _logger = logger;
    }

    [HttpPut("users/{id:long:min(1)}")]
    [SwaggerOperation(Summary = "Update an user")]
    public override async Task HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        _logger.LogDebug("User {id} had been updated to {data}", request.Id, JsonSerializer.Serialize(request.Data));
    }
}
