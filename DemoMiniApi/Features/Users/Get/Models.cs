using DemoMiniApi.Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Features.Users.Get;

public class Request
{
    [FromRoute]
    public long Id { get; init; }
}

public class Response
{
    public long Id { get; init; }

    public string UserName { get; init; } = string.Empty;

    public string? Name { get; init; }
}

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<User, Response>();
    }
}