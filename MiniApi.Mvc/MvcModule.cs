using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace MiniApi.Mvc;

public class MvcModule : Module
{
    public static List<Assembly> ModuleAssemblies { get; } = new();

    public override ModulePriority Priority => ModulePriority.Common;

    public override void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(ModuleAssemblies);
        services.AddValidatorsFromAssemblies(ModuleAssemblies);

        services.AddSwaggerGen(opt =>
        {
            opt.CustomSchemaIds(t => t.FullName);
        });

        var mvcBuilder = services.AddControllers(opt =>
        {
            opt.Filters.Add(typeof(ValidationExceptionFilter));
        });

        foreach (var assembly in ModuleAssemblies)
        {
            mvcBuilder.AddApplicationPart(assembly);
        }

        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
            });

            opt.DefaultPolicyName = "AllowAll";
        });
    }

    public override void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(builder =>
        {
            builder.MapControllers();
        });
    }
}
