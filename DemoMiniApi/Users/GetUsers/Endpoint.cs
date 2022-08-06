using DemoMiniApi.Common;
using DemoMiniApi.Users.Domain;

namespace DemoMiniApi.Users.GetUsers;

public static class Endpoint
{
    public static async Task<IResult> Handle([AsParameters] Request req, IValidator<Request> validator, IUserRepo repo, IMapper mapper, CancellationToken ct)
    {
        validator.ValidateAndThrow(req);

        var predicator = PredicatorBuilder.True<User>();

        if (req.Name != null)
        {
            predicator = predicator.And(Predicators.NameStartsWith(req.Name));
        }

        if (req.UserName != null)
        {
            predicator = predicator.And(Predicators.UserNameStartsWith(req.UserName));
        }

        var page = await repo.SelectPageAsync(new(predicator, null), req, ct);
        var responseItems = mapper.Map<ResponseItem[]>(page.Items);

        var response = new Response();

        response.SetParams(req);
        response.SetResult(responseItems, page.Total);

        return Results.Ok(response);
    }
}
