﻿using Microsoft.AspNetCore.Mvc;

namespace DemoMiniApi.Users.GetUser;

public class Request
{
    [FromRoute]
    public long Id { get; set; }
}

public class Response
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }
}
