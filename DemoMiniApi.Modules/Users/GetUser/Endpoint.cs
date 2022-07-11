using DemoMiniApi.Modules.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoMiniApi.Modules.Users.GetUser;

public class Endpoint : EndpointBaseAsync
    .WithRequest<Request>
    .WithResult<Response>
{
    private readonly IMapper _mapper;

    public Endpoint(IMapper mapper)
    {
        _mapper = mapper;
    }


    [HttpGet("users/{id:long:min(1)}")]
    [SwaggerOperation(Summary = "Get an user")]
    public override Task<Response> HandleAsync([FromRoute] Request request, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Id = request.Id,
            Name = "John Doe",
            UserName = "john.d"
        };

        return Task.FromResult(_mapper.Map<Response>(user));
    }
}
