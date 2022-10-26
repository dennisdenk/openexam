using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Infrastructure.Persistence;
using OpenExam.WebUI.Filters;
using OpenExam.WebUI.Services;

namespace OpenExam.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
                .AddJsonOptions(
                    opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddRazorPages();
        services.AddSignalR();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddSwaggerGen();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "OpenExam API",
                Description = "Prüfungsmanagement und Durchführung",
                /* TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }*/
            });
            options.UseInlineDefinitionsForEnums();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
            });
            
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    Array.Empty<string>()
                }
            });
            
            /* options.AddSecurityDefinition("OpenId" ,new OpenIdConnectConfiguration
            {
                AuthorizationEndpoint = "localhost:8080/auth",
                TokenEndpoint = "localhost:8080/auth/realms/master/protocol/openid-connect/token",
                EndSessionEndpoint = "localhost:8080/auth/realms/master/protocol/openid-connect/logout"
            }; */
        });

        return services;
    }
}
