using DemoMiniApi.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Products.Edit;

public class Parameters
{
    [FromRoute]
    public long Id { get; init; }

    [FromBody]
    public Request Request { get; init; } = new();
}

public class Request
{
    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
}

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).LessThan(100_000_000);
    }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Request, Product>();
    }
}

