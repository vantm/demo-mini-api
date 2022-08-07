#nullable disable


using DemoMiniApi;

namespace DemoMiniApi.Domain.Users;

public class User
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string UserName { get; set; }

    public string ClearTextPasswordForDemoOnlyPleaseDontUseInProduction { get; set; }
}
