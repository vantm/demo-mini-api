using System.Text.RegularExpressions;

namespace DemoMiniApi.Modules.Users.AddUser;

public class Request
{
    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30)
            .Matches("^[a-z][a-z0-9_\\.]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline).WithMessage("The format of {PropertyName} is invalid. It must contain only alphabet, numeric, or underscore. The first character must be an alphabet.");

        RuleFor(x => x.Name)
            .MaximumLength(50);
    }
}

public class Response : Request
{
    public long Id { get; set; }
}
