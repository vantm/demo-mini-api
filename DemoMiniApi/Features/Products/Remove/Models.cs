using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Products.Remove;

public class Request
{
    [FromRoute]
    public long Id { get; set; }
}
