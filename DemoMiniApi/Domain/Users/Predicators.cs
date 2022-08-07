using System.Linq.Expressions;

namespace DemoMiniApi.Domain.Users;

using UserPredicator = Expression<Func<User, bool>>;

public static class Predicators
{
    public static UserPredicator UserNameStartsWith(string filter) => x => x.UserName.StartsWith(filter);

    public static UserPredicator NameStartsWith(string filter) => x => x.Name.StartsWith(filter);

    public static UserPredicator PasswordMatched(string password) => x => x.ClearTextPasswordForDemoOnlyPleaseDontUseInProduction == password;
}
