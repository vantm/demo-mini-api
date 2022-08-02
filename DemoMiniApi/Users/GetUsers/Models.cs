using DemoMiniApi.Users.Models;

namespace DemoMiniApi.Users.GetUsers;

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

public class Response : PageResult<User, Request>
{
    public string? Filter { get; private set; }

    protected override void SetMoreParams(Request pageParams)
    {
        Filter = pageParams.Filter;
    }
}
