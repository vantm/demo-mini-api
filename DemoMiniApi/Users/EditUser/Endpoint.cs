using DemoMiniApi.Users.Domain;

namespace DemoMiniApi.Users.EditUser;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Parameters param, IValidator<Request> validator, IMapper mapper, IUserRepo repo, IUow uow, CancellationToken ct)
    {
        validator.ValidateAndThrow(param.Request);

        var user = await repo.FindAsync(param.Id);

        if (user == null)
        {
            return Results.NotFound(param.Id);
        }

        mapper.Map(param.Request, user);

        await repo.UpdateAsync(user);

        await uow.SaveChangesAsync(ct);

        return Results.NoContent();
    }
}
