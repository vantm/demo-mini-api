using DemoMiniApi.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DemoMiniApi.DataAccess;

public class UserRepository : RepositoryBase<long, User>, IUserRepository
{
	private readonly MasterDbContext _context;

	public UserRepository(MasterDbContext context)
	{
		_context = context;
	}

	protected override DbSet<User> Set() => _context.Users;
}
