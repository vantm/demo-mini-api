using DemoMiniApi.Domain;
using DemoMiniApi.Domain.Products;
using DemoMiniApi.Domain.Users;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoMiniApi.DataAccess;

public class MasterUnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MasterDbContext _context;
    private IDbContextTransaction? _transaction;

    public IProductRepository Products { get; }
    public IUserRepository Users { get; set; }

    public MasterUnitOfWork(MasterDbContext context)
    {
        _context = context;
        Products = new ProductRepository(context);
        Users = new UserRepository(context);
    }

    public void Begin()
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("Begin UOW is called too many times");
        }

        _transaction = _context.Database.BeginTransaction();
    }

    public void Complete()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Begin UOW must be called before completing it");
        }

        _transaction.Commit();
    }

    public void Rollback()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Begin UOW must be called before rollback it");
        }

        _transaction.Rollback();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }

    public Task SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
