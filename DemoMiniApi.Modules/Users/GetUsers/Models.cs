using DemoMiniApi.Modules.Users.Models;

namespace DemoMiniApi.Modules.Users.GetUsers;

public class Request : PageParams
{
    public string? Filter { get; init; }
}

public class Validator : PageParamsValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Filter).MaximumLength(50);
    }
}

public class Response : PageResult<User>
{
    public string? Filter { get; init; }

    public Response(IEnumerable<User> items, long total, Request @params) : base(items, total, @params)
    {
        Filter = @params.Filter;
    }
}
