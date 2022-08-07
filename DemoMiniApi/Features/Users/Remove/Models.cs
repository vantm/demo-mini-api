using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Users.Remove;

public class Request
{
    [FromRoute]
    public long Id { get; init; }
}
