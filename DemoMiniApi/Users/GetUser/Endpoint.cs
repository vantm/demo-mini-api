using DemoMiniApi.Users.Domain;

namespace DemoMiniApi.Users.GetUser;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUserRepo repo, IMapper mapper, CancellationToken ct)
    {
        var user = await repo.FindAsync(req.Id);

        if (user == null)
        {
            return Results.NotFound(req.Id);
        }

        var response = mapper.Map<Response>(user);

        return Results.Ok(response);
    }
}
