using DemoMiniApi.Products.Domain;

namespace DemoMiniApi.Products.GetProducts;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Request req, IValidator<Request> validator)
    {
        validator.ValidateAndThrow(req);

        var items = new Product[]
        {
            new() { Id = 1, Name = "Product 1", Price = 100 },
            new() { Id = 2, Name = "Product 2", Price = 120 },
            new() { Id = 3, Name = "Product 3", Price = 40 },
            new() { Id = 4, Name = "Product 4", Price = 20 },
            new() { Id = 5, Name = "Product 5", Price = 30 },
        };

        var response = new Response();

        response.SetParams(req);
        response.SetResult(items, items.Length);

        return Results.Ok(response);
    }
}
