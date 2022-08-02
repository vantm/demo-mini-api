using System.Text.RegularExpressions;

namespace DemoMiniApi.Users.EditUser;

public class Request
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
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
