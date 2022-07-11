using System.Text.RegularExpressions;

namespace DemoMiniApi.Modules.Users.EditUser;

public class Request : RequestBase.Mutate<long, UserChanges>
{
}

public class UserChanges
{
    public string? UserName { get; set; }

    public string? Name { get; set; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Data).NotNull().SetValidator(new DataValidator());
    }
}

public class DataValidator : AbstractValidator<UserChanges?>
{
    public DataValidator()
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