using DemoMiniApi.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace DemoMiniApi.Features.Users.Edit;

public record Parameters
{
    [FromRoute]
    public long Id { get; init; }

    [FromBody]
    public Request Request { get; init; } = new();
}

public class Request
{
    public string UserName { get; init; } = string.Empty;

    public string? Name { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x!.UserName)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(30)
            .Matches("^[a-z][a-z0-9_\\.]+$", RegexOptions.IgnoreCase | RegexOptions.Multiline).WithMessage("The format of field '{PropertyName}' is invalid. It must contain only alphabet, numeric, or underscore and the first character must be an alphabet.");

        RuleFor(x => x!.Name)
            .MaximumLength(50);
    }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Request, User>();
    }
}