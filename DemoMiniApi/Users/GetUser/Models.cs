using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.GetUser;

public record Request
{
    [FromRoute]
    public long Id { get; set; }
}

public record Response
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }
}
