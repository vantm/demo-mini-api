using Microsoft.EntityFrameworkCore.Storage;

namespace DemoMiniApi.DataAccess;

public class MasterDbUow : IUow, IDisposable
{
    private readonly MasterDbContext _context;
    private IDbContextTransaction? _transaction;

    public MasterDbUow(MasterDbContext context)
    {
        _context = context;
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
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
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
