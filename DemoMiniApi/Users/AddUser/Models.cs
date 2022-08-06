using System.Text.RegularExpressions;

namespace DemoMiniApi.Users.AddUser;

public record Request
{
    public string? UserName { get; init; }

    public string? Name { get; init; }
}

public record Response
{
    public long Id { get; init; }

    public string? UserName { get; init; }

    public string? Name { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(30)
            .Matches("^[a-z][a-z0-9_\\.]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline).WithMessage("The format of field '{PropertyName}' is invalid. It must contain only alphabet, numeric, or underscore and the first character must be an alphabet.");

        RuleFor(x => x.Name)
            .MaximumLength(50);
    }
}