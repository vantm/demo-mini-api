﻿using DemoMiniApi.Users.Models;

namespace DemoMiniApi.Users.GetUsers;

public class Request : PageParams
{
    public string? Filter { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Filter).MaximumLength(50);
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PerPage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(500);
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
