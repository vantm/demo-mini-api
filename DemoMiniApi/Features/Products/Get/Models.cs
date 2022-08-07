using DemoMiniApi.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Products.Get;

public class Request
{
    [FromRoute]
    public int Id { get; init; }
}

public class Response
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public decimal Price { get; init; }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Product, Response>();
    }
}
