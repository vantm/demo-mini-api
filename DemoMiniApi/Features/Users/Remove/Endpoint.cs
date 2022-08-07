namespace DemoMiniApi.Features.Users.Remove;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IUnitOfWork uow, CancellationToken ct)
    {
        var user = await uow.Users.FindAsync(req.Id, ct);

        if (user == null)
        {
            return Results.NotFound(req.Id);
        }

        await uow.Users.DeleteAsync(user);

        return Results.NoContent();
    }
}
