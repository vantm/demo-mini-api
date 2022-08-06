#nullable disable


namespace DemoMiniApi.Users.Domain;

public class User
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string UserName { get; set; }

    public string ClearTextPasswordForDemoOnlyPleaseDontUseInProduction { get; set; }
}
