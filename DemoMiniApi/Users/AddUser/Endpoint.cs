using DemoMiniApi.Users.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.AddUser;

public static class Endpoint
{
    public static async Task<IResult> Handle([FromBody] Request req, IValidator<Request> validator, IMapper mapper, IUserRepo repo, IUow uow, LinkGenerator linker, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var user = mapper.Map<User>(req);

        // random new password
        user.ClearTextPasswordForDemoOnlyPleaseDontUseInProduction = Guid.NewGuid().ToString("N")[^10..];

        await repo.InsertAsync(user, ct);

        var response = mapper.Map<Response>(user);

        var link = linker.GetPathByName(nameof(GetUser), new { id = user.Id })!;

        await uow.SaveChangesAsync(ct);

        if (link == null)
        {
            return Results.StatusCode(StatusCodes.Status201Created);
        }

        return Results.Created(link, response);
    }
}
