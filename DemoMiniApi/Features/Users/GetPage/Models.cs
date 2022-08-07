using DemoMiniApi.Domain.Users;

namespace DemoMiniApi.Features.Users.GetPage;

public class Request : PageParams
{
    public string? UserName { get; init; }

    public string? Name { get; init; }
}

public class Response : PageResult<ResponseItem, Request>
{
    public string? Filter { get; private set; }

    protected override void SetMoreParams(Request pageParams)
    {
        Filter = pageParams.UserName;
    }
}

public class ResponseItem
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserName).MaximumLength(50);
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PerPage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(500);
    }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, ResponseItem>();
    }
}