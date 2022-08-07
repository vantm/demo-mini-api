namespace DemoMiniApi.Features.Products;

public class ProductModule : Module
{
    public override void Configure(WebApplication app)
    {
        const string tag = nameof(Products);

        app.MapGet("/products", GetPage.Endpoint.Handle)
           .WithTags(tag);

        app.MapGet("/products/{id:long:min(1)}", Get.Endpoint.Handle)
           .WithName("GetProduct")
           .WithTags(tag);

        app.MapPost("/products", Add.Endpoint.Handle)
           .WithTags(tag);

        app.MapPut("/products/{id:long:min(1)}", Edit.Endpoint.Handle)
           .WithTags(tag);

        app.MapDelete("/products/{id:long:min(1)}", Remove.Endpoint.Handle)
           .WithTags(tag);
    }
}
