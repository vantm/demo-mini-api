using DemoMiniApi.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Users.Add;

public static class Endpoint
{
    public static async Task<IResult> Handle([FromBody] Request req, IValidator<Request> validator, IMapper mapper, IUnitOfWork uow, LinkGenerator linker, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var user = mapper.Map<User>(req);

        // random new password
        user.ClearTextPasswordForDemoOnlyPleaseDontUseInProduction = Guid.NewGuid().ToString("N")[^10..];

        await uow.Users.InsertAsync(user, ct);

        var link = linker.GetPathByName("GetUser", new { id = user.Id })!;
        var response = mapper.Map<Response>(user);

        await uow.SaveChangesAsync(ct);

        if (link == null)
        {
            return Results.Json(response, statusCode: StatusCodes.Status201Created);
        }

        return Results.Created(link, response);
    }
}
