using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Povio.FlowerSpot.Api.Handlers;
using Povio.FlowerSpot.Api.Middlewares;
using Povio.FlowerSpot.Application;
using Povio.FlowerSpot.Infrastructure;
using Povio.FlowerSpot.Persistence;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Povio.FlowerSpot.Api.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddConfigurations(builder.Configuration);

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            var serviceProvider = builder.Services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<FlowerSpotDbContext>();
            dbContext.Database.Migrate();

            builder.Services.AddControllers().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<IApplicationMarker>();
            });

            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", config => { });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(SetupSwagger);

            builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("FlowerSpotConnectionString"));

            return builder.Build();
        }

        private static void SetupSwagger(SwaggerGenOptions config)
        {
            config.AddSecurityDefinition("basic", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization"
            });
            config.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseHealthChecks("/healthz");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
