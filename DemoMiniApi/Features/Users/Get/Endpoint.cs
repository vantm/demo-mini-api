using DemoMiniApi.Domain;

namespace DemoMiniApi.Features.Users.Get;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUnitOfWork uow, IMapper mapper, CancellationToken ct)
    {
        var user = await uow.Users.FindAsync(req.Id);

        if (user == null)
        {
            return Results.NotFound(req.Id);
        }

        var response = mapper.Map<Response>(user);

        return Results.Ok(response);
    }
}
