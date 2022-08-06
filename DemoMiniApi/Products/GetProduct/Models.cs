using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Products.GetProduct;

public class Request
{
    [FromRoute]
    public int Id { get; init; }
}

public class Response
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public decimal Price { get; init; }
}

