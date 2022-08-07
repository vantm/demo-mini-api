using System.Linq.Expressions;

namespace DemoMiniApi.Common;

public interface IRepository<TId, TModel> where TModel : class
{
    Task<TModel?> FindAsync(TId id, CancellationToken ct = default);

    Task<long> CountAsync(Expression<Func<TModel, bool>>? predicator = null, CancellationToken ct = default);

    Task<IEnumerable<TModel>> SelectAllAsync(SelectParams<TModel>? selectParams = null, CancellationToken ct = default);
    Task<Page<TModel>> SelectPageAsync(SelectParams<TModel>? selectParams = null, PageParams? pageParams = null, CancellationToken ct = default);
    Task<TModel?> SelectFirstAsync(SelectParams<TModel>? selectParams = null, CancellationToken ct = default);

    Task InsertAsync(TModel model, CancellationToken ct = default);
    Task UpdateAsync(TModel model, CancellationToken ct = default);
    Task DeleteAsync(TModel model, CancellationToken ct = default);
}

public record SelectParams<T>(
    Expression<Func<T, bool>>? Predicator,
    Expression<Func<T, object>>? SortBy,
    bool SortDesc = false
);