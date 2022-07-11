namespace MiniApi;

public class PageResult<T, TParams> where TParams : PageParams
{
    public long Page { get; private set; }

    public int PerPage { get; private set; }

    public long Total { get; private set; }

    public T[] Items { get; private set; } = Array.Empty<T>();

    public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();

    public void SetParams(TParams? pageParams)
    {
        if (pageParams == null)
        {
            return;
        }

        Page = pageParams.Page;
        PerPage = pageParams.PerPage;

        SetMoreParams(pageParams);
    }

    protected virtual void SetMoreParams(TParams pageParams)
    {
    }

    public void SetResult(IEnumerable<T> items, long total)
    {
        if (items != null)
        {
            Items = items.ToArray();
            Total = total;
        }
    }
}
