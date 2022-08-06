using DemoMiniApi.Products.Domain;

namespace DemoMiniApi.Products.GetProducts;

public class Request : PageParams
{
}

public class Response : PageResult<Product, Request>
{
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PerPage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(500);
    }
}