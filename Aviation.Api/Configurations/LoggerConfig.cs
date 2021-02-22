using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AviationManagementApi.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "775b1a6b41e44168aa4f1d7ded0c4a29";
                o.LogId = new Guid("ea02a15a-2559-42ac-905b-7c6a2ba712fb");
            });

            // Loga também os logs injetados manualmente no Asp Net Core
            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "775b1a6b41e44168aa4f1d7ded0c4a29";
                    o.LogId = new Guid("ea02a15a-2559-42ac-905b-7c6a2ba712fb");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            // ERRO NA MIGRAÇÃO!!! SqlServerHealthCheck dando erro
            services.AddHealthChecks()
                .AddElmahIoPublisher(options =>
                {
                    options.ApiKey = "775b1a6b41e44168aa4f1d7ded0c4a29";
                    options.LogId = new Guid("ea02a15a-2559-42ac-905b-7c6a2ba712fb");
                    options.HeartbeatId = "Aviation Management System - API";
                })
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}