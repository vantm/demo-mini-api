using DemoMiniApi.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace DemoMiniApi.DataAccess;

public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
{
    private readonly MasterDbContext _context;

    public ProductRepository(MasterDbContext context)
    {
        _context = context;
    }

    protected override DbSet<Product> Set()
    {
        return _context.Products;
    }
}
