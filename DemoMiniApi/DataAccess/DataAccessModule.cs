﻿using DemoMiniApi.Products;
using DemoMiniApi.Users;
using DemoMiniApi.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoMiniApi.DataAccess;

[DependsOn(
    typeof(UserModule),
    typeof(ProductModule)
)]
public class DataAccessModule : Module
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddDbContextPool<MasterDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString(nameof(DemoMiniApi))!);

            if (Environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddScoped<IUow, MasterDbUow>();
        services.AddScoped<IUserRepo, UserRepo>();
    }

    public override void PreConfigure(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var migrator = scope.ServiceProvider.GetRequiredService<MasterDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<DataAccessModule>>();

        logger.LogInformation("Starting to migrate the database");

        migrator.Database.Migrate();

        logger.LogInformation("Migrating the database had been completed");
    }
}
