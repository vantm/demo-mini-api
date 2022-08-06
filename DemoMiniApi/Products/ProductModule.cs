namespace DemoMiniApi.Products;

public class ProductModule : Module
{
    public override void Configure(WebApplication app)
    {
        app.MapGet("/products", GetProducts.Endpoint.Handle)
           .WithName(nameof(GetProducts))
           .WithTags(nameof(Products));

        app.MapGet("/products/{id:long:min(1)}", GetProduct.Endpoint.Handle)
           .WithName(nameof(GetProduct))
           .WithTags(nameof(Products));
    }
}
