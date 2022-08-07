using DemoMiniApi.Domain.Products;

namespace DemoMiniApi.Features.Products.GetPage;

public class Request : PageParams
{
}

public class Response : PageResult<ResponseItem, Request>
{
}

public class ResponseItem
{
    public long Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PerPage).GreaterThanOrEqualTo(0).LessThanOrEqualTo(500);
    }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Product, ResponseItem>();
    }
}
