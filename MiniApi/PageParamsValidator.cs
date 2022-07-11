using FluentValidation;

namespace MiniApi;

public abstract class PageParamsValidator<T> : Validator<T> where T : PageParams
{
    protected PageParamsValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PerPage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(500);
    }
}
