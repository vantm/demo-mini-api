using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoMiniApi.DataAccess;

public class MasterDbDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MasterDbContext>
{
    public MasterDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<MasterDbDesignTimeDbContextFactory>()
            .Build();

        var options = new DbContextOptionsBuilder<MasterDbContext>()
            .UseSqlServer(config.GetConnectionString(nameof(DemoMiniApi))!)
            .Options;

        return new(options);
    }
}
