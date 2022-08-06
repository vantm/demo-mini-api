namespace MiniApi;

public class Page<T>
{
    public long Total { get; init; }

    public T[] Items { get; init; } = Array.Empty<T>();
}
