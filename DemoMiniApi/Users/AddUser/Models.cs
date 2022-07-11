using System.Text.RegularExpressions;

namespace DemoMiniApi.Modules.Users.AddUser;

public class Request
{
    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Response
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30)
            .Matches("^[a-z][a-z0-9_\\.]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline).WithMessage("The format of field '{PropertyName}' is invalid. It must contain only alphabet, numeric, or underscore. The first character must be an alphabet.");

        RuleFor(x => x.Name)
            .MaximumLength(50);
    }
}