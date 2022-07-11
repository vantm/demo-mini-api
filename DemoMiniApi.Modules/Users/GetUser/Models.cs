using DemoMiniApi.Modules.Users.Models;

namespace DemoMiniApi.Modules.Users.GetUser;

public class Request : RequestBase.Single<long>
{
}

[AutoMap(typeof(User))]
public class Response
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }
}