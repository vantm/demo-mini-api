using DemoMiniApi.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoMiniApi.DataAccess;

public class UserRepo : RepoBase<long, User>, IUserRepo
{
	private readonly MasterDbContext _context;

	public UserRepo(MasterDbContext context)
	{
		_context = context;
	}

	protected override DbSet<User> Set() => _context.Users;
}
