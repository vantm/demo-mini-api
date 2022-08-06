namespace MiniApi;

public abstract record PageParams
{
    public long Page { get; init; } = 1;
    public int PerPage { get; init; } = 20;
}
