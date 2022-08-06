#nullable disable

namespace DemoMiniApi.Users;

public record User
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string UserName { get; set; }
}
