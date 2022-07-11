namespace MiniApi;

public abstract class PageParams
{
    public long Page { get; init; } = 1;
    public int PerPage { get; init; } = 20;
}
