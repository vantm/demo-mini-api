namespace DemoMiniApi.Products.GetProduct;

public static class Endpoint
{
    public static IResult Handle([AsParameters] Request req)
    {
        if (req.Id < 1 || req.Id > 100)
        {
            return Results.NotFound(req.Id);
        }

        var response = new Response
        {
            Id = req.Id,
            Name = $"Product {req.Id}",
            Price = 100
        };

        return Results.Ok(response);
    }
}
