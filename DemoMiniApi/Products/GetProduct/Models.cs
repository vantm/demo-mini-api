using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Products.GetProduct;

public record Request
{
    [FromRoute]
    public int Id { get; init; }
}

public record Response
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public decimal Price { get; init; }
}

