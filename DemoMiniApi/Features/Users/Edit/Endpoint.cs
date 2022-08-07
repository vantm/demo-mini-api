using DemoMiniApi.Domain;

namespace DemoMiniApi.Features.Users.Edit;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Parameters param, IValidator<Request> validator, IMapper mapper, IUnitOfWork uow, CancellationToken ct)
    {
        validator.ValidateAndThrow(param.Request);

        var user = await uow.Users.FindAsync(param.Id);

        if (user == null)
        {
            return Results.NotFound(param.Id);
        }

        mapper.Map(param.Request, user);

        await uow.Users.UpdateAsync(user);

        await uow.SaveChangesAsync(ct);

        return Results.NoContent();
    }
}
