using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DemoMiniApi.DataAccess;

public abstract class RepositoryBase<TId, TModel> : IRepository<TId, TModel> where TModel : class
{
    protected abstract DbSet<TModel> Set();

    public Task<long> CountAsync(Expression<Func<TModel, bool>>? predicator = null, CancellationToken ct = default)
    {
        var query = Set().AsNoTracking();

        if (predicator != null)
        {
            query = query.Where(predicator);
        }

        return query.LongCountAsync(ct);
    }

    public Task<IEnumerable<TModel>> SelectAllAsync(SelectParams<TModel>? selectParams = null, CancellationToken ct = default)
    {
        var query = Set().AsNoTracking();

        if (selectParams?.Predicator != null)
        {
            query = query.Where(selectParams.Predicator);
        }

        if (selectParams?.SortBy != null)
        {
            if (selectParams.SortDesc)
            {
                query = query.OrderByDescending(selectParams.SortBy);
            }
            else
            {
                query = query.OrderBy(selectParams.SortBy);
            }
        }

        return query.ToArrayAsync(ct).ContinueWith(t => t.Result.AsEnumerable());
    }

    public Task<TModel?> SelectFirstAsync(SelectParams<TModel>? selectParams = null, CancellationToken ct = default)
    {
        var query = Set().AsNoTracking();

        if (selectParams?.Predicator != null)
        {
            query = query.Where(selectParams.Predicator);
        }

        if (selectParams?.SortBy != null)
        {
            if (selectParams.SortDesc)
            {
                query = query.OrderByDescending(selectParams.SortBy);
            }
            else
            {
                query = query.OrderBy(selectParams.SortBy);
            }
        }

        return query.FirstOrDefaultAsync(ct);
    }

    public async Task<Page<TModel>> SelectPageAsync(SelectParams<TModel>? selectParams = null, PageParams? @params = null, CancellationToken ct = default)
    {
        var query = Set().AsNoTracking();

        if (selectParams?.Predicator != null)
        {
            query = query.Where(selectParams.Predicator);
        }

        var total = await query.LongCountAsync(ct);

        if (total == 0)
        {
            return new();
        }

        if (selectParams?.SortBy != null)
        {
            if (selectParams.SortDesc)
            {
                query = query.OrderByDescending(selectParams.SortBy);
            }
            else
            {
                query = query.OrderBy(selectParams.SortBy);
            }
        }

        var items = await query.ToArrayAsync(ct);

        return new()
        {
            Items = items,
            Total = total
        };
    }

    public Task<TModel?> FindAsync(TId id, CancellationToken ct = default)
    {
        if (id == null)
        {
            return Task.FromResult<TModel?>(null);
        }

        return Set().FindAsync(new object[] { id }, ct).AsTask();
    }

    public Task DeleteAsync(TModel model, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        Set().Remove(model);
        return Task.CompletedTask;
    }

    public Task InsertAsync(TModel model, CancellationToken ct = default)
    {
        return Set().AddAsync(model, ct).AsTask();
    }

    public Task UpdateAsync(TModel model, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        Set().Update(model);
        return Task.CompletedTask;
    }
}
