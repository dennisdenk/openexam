using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OpenExam.Application.Common.Interfaces;
using OpenExam.Infrastructure.Files;
using OpenExam.Infrastructure.Identity;
using OpenExam.Infrastructure.Persistence;
using OpenExam.Infrastructure.Persistence.Interceptors;
using OpenExam.Infrastructure.Services;

namespace OpenExam.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    builder =>
                    {
                        builder.UseNodaTime();
                        builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                    }));
            NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
            // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            // builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        // services.AddIdentityServer()
        //    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
        
        services.AddScoped<IBlobStorageContext, BlobStorageContext>();

        /* services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"))); */
        
        // Authentication and Authorization stuff
        // TODO: Nach erfolgreichem Einbau auf Configuration-Datei ändern
        var authenticationOptions = new KeycloakAuthenticationOptions
        {
            AuthServerUrl = "https://login.sysadapt.com/auth",
            
            Realm = "openExam",
            Resource = "testclient2",
            VerifyTokenAudience = false,
            // Credentials = { Secret = "3h0EhED2UOgQzN6YUCLuynL4yedIglkj" },
            SslRequired = "external",
            
        };

        services.AddKeycloakAuthentication(authenticationOptions);
        services.AddAuthorization(o => o.AddPolicy("IsAdmin", b =>
        {
            b.RequireRealmRoles("admin");
            b.RequireResourceRoles("r-admin"); // stands for "resource admin"
            // resource roles are mapped to ASP.NET Core Identity roles
            b.RequireRole("r-admin"); 
        }));
        services.AddKeycloakAuthorization(configuration);

        return services;
    }
}
