#nullable disable

namespace DemoMiniApi.Products;

public record Product
{
    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}
