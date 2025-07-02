using AMI.EduWork.Components.Account;
using AMI.EduWork.Data;
using AMI.EduWork.Data.Migrations;
using AMI.EduWork.Domain;
using AMI.EduWork.Domain.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace AMI.EduWork.Configuration;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
    {
        services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddAuthenticationStateSerialization();
        //.AddInteractiveWebAssemblyComponents();

        services.AddMudServices();
        services.AddCascadingAuthenticationState();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

<<<<<<< HEAD:AMI.EduWork.2025/AMI.EduWork.2025/Configuration/ServiceCollectionExtensions.cs
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
=======
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
>>>>>>> main:AMI.EduWork/AMI.EduWork/Configuration/ServiceCollectionExtensions.cs
        if (builder.Environment.IsProduction()) {

            connectionString = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");

        }

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
        services.AddAuthorization();

        //AutoMapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        services.AddTransient<DataSeeder>();

        services.AddProjectDependencies();

        return services;
    }
}
