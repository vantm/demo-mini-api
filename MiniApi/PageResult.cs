namespace MiniApi;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> items, long total, PageParams @params)
    {
        Items = items.ToArray();
        Total = total;
        Page = @params.Page;
        PerPage = @params.PerPage;
    }

    public long Page { get; init; }

    public int PerPage { get; init; }

    public long Total { get; init; }

    public T[] Items { get; init; }

    public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();
}
