using DemoMiniApi.Common;

namespace DemoMiniApi.Users.Domain;

public interface IUserRepo : IRepo<long, User>
{
}
