#nullable disable


using DemoMiniApi;

namespace DemoMiniApi.Domain.Products;

public class Product
{
    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}
