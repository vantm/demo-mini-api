using DemoMiniApi.Modules.Users.Models;

namespace DemoMiniApi.Modules.Users.GetUser;

public class Request
{
    public long Id { get; set; }
}

public class Response
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }
}

public class Mapper : Mapper<Request, Response, User>
{
    public override Task<Response> FromEntityAsync(User e)
    {
        return Task.FromResult(FromEntity(e));
    }

    public override Response FromEntity(User e)
    {
        return new Response()
        {
            Id = e.Id,
            Name = e.Name,
            UserName = e.UserName
        };
    }
}