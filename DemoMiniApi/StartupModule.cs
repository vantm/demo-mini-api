﻿using DemoMiniApi.DataAccess;
using System.Reflection;

namespace DemoMiniApi
{
    [DependsOn(
        typeof(DataAccessModule)
    )]
    public class StartupModule : Module
    {
        public override void RegisterServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(t => t.FullName);
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public override void PreConfigure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(exceptionHandlerAppBuilder =>
            {
                var logger = exceptionHandlerAppBuilder.ApplicationServices.GetRequiredService<ILogger<StartupModule>>();

                exceptionHandlerAppBuilder.Run(ctx => ExceptionMiddleware.Handle(ctx, logger));
            });
        }
    }
}
