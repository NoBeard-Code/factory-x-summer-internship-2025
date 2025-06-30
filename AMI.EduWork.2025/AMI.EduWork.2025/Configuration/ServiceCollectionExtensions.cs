using AMI.EduWork._2025.Components.Account;
using AMI.EduWork._2025.Data;
using AMI.EduWork._2025.Data.Migrations;
using AMI.EduWork._2025.Domain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace AMI.EduWork._2025.Configuration;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
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

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

        services.AddTransient<DataSeeder>();

        services.AddProjectDependencies();

        return services;
    }
}
