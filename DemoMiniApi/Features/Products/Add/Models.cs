using DemoMiniApi.Domain.Products;

namespace DemoMiniApi.Features.Products.Add;

public class Request
{
    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
}

public class Response
{
    public long Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(200);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).LessThan(100_000_000);
    }
}

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Request, Product>();
        CreateMap<Product, Response>();
    }
}