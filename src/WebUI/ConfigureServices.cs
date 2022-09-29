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
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

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
        });

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddJwtBearer()
            .AddOpenIdConnect(options =>
            {
                // options.Authority = Configuration["Oidc:Authority"]; configuration
                options.Authority = configuration.GetSection("Identity").GetSection("Authority").Value;
                options.ClientId = configuration.GetSection("Identity").GetSection("ClientId").Value;
                options.ClientSecret = configuration.GetSection("Identity").GetSection("ClientSecret").Value;
                options.SaveTokens = true;
                // TODO: Schauen was da am meisten Sinn ergibt
                options.ResponseType = OpenIdConnectResponseType.Code; //Configuration["Oidc:ResponseType"];
                options.RequireHttpsMetadata = false; // dev only
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("claims");
                options.SaveTokens = true;
                //options.Events = new OpenIdConnectEvents
                //{
                //    OnTokenResponseReceived = async ctx =>
                //    {
                //        var a = ctx.Principal;
                //    },
                //    OnAuthorizationCodeReceived = async ctx =>
                //    {
                //        var a = ctx.Principal;
                //    }
                //};

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name", RoleClaimType = "groups", ValidateIssuer = true
                };
            });

        /* services.AddOpenApiDocument(configure =>
        {
            configure.Title = "OpenExam API";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        }); */
        
        services.AddAuthorization();

        return services;
    }
}
