#nullable disable

using DemoMiniApi.Domain.Products;
using DemoMiniApi.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoMiniApi.DataAccess;

public class MasterDbContext : DbContext
{
    public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; private set; }

    public DbSet<Product> Products { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildProductModel(modelBuilder.Entity<Product>());
        BuildUserModel(modelBuilder.Entity<User>());
    }

    private static void BuildProductModel(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Price).IsRequired();
    }

    private static void BuildUserModel(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Name).HasMaxLength(200);
        builder.Property(x => x.ClearTextPasswordForDemoOnlyPleaseDontUseInProduction).HasMaxLength(100).HasColumnName("ClearTextPassword");

        builder.HasIndex(x => x.UserName).IncludeProperties(x => x.ClearTextPasswordForDemoOnlyPleaseDontUseInProduction);
    }
}
