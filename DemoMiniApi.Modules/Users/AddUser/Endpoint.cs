using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DemoMiniApi.Modules.Users.AddUser;

public class Endpoint : EndpointBaseAsync
    .WithRequest<Request>
    .WithResult<Response>
{
    private readonly IValidator<Request> _validator;
    private readonly IMapper _mapper;

    public Endpoint(IValidator<Request> validator, IMapper mapper)
    {
        _validator = validator;
        _mapper = mapper;
    }

    [HttpPost("users")]
    [SwaggerOperation(Summary = "Add an user")]
    public override async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken = default)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var response = _mapper.Map<Response>(request);
        response.Id = 4;

        return response;
    }
}
