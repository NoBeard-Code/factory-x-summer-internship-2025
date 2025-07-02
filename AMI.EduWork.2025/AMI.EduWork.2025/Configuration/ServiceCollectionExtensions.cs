using AMI.EduWork._2025.Components.Account;
using AMI.EduWork._2025.Data;
using AMI.EduWork._2025.Data.Migrations;
using AMI.EduWork._2025.Domain;
using AMI.EduWork._2025.Domain.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

namespace AMI.EduWork._2025.Configuration;
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

        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
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
