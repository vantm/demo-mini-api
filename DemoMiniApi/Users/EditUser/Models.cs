using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.EditUser;

public class Request
{
    [FromRoute]
    public long Id { get; set; }

    [FromBody]
    public Body Data { get; set; }
}


public class Body
{
    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Data).SetValidator(new BodyValidator());
    }
}

public class BodyValidator : AbstractValidator<Body>
{
    public BodyValidator()
    {
        RuleFor(x => x!.UserName)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30)
            .Matches("^[a-z][a-z0-9_\\.]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline).WithMessage("The format of {PropertyName} is invalid.");

        RuleFor(x => x!.Name)
            .MaximumLength(50);
    }
}
