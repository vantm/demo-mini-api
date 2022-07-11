#nullable disable

using Microsoft.AspNetCore.Mvc;

namespace MiniApi;

public static class RequestBase
{
    public class Mutate<TId, TChanges> : Single<TId>
    {
        [FromBody]
        public TChanges Data { get; set; }
    }

    public class Single<T>
    {
        [FromRoute(Name = "id")]
        public T Id { get; set; }
    }
}
