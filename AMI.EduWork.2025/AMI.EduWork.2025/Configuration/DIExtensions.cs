using AMI.EduWork._2025.Data.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Repository;
using AMI.EduWork._2025.Domain.Interfaces.Service;
using AMI.EduWork._2025.Domain.Services;

namespace AMI.EduWork._2025.Configuration;
public static class DIExtensions
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IWorkDayRepository, WorkDayRepository>();
        services.AddScoped<IVacationRepository, VacationRepository>();
        services.AddScoped<IUserOnVacationRepository, UserOnVacationRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<ITimeSliceRepository, TimeSliceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IWorkDayService, WorkDayService>();
        services.AddScoped<IVacationService, VacationService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<ITimeSliceService, TimeSliceService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
