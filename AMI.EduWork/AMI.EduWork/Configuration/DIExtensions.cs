using AMI.EduWork.Data.Repository;
using AMI.EduWork.Domain.Interfaces.Repository;
using AMI.EduWork.Domain.Interfaces.Service;
using AMI.EduWork.Domain.Services;

namespace AMI.EduWork.Configuration;
public static class DIExtensions
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IWorkDayRepository, WorkDayRepository>();
        services.AddScoped<IAnnualVacationRepository, AnnualVacationRepository>();
        services.AddScoped<IVacationRepository, VacationRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<ITimeSliceRepository, TimeSliceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUserOnProjectRepository, UserOnProjectRepository>();
        services.AddScoped<ISickLeaveRepository, SickLeaveRepository>();

        // Services
        services.AddScoped<IWorkDayService, WorkDayService>();
        services.AddScoped<IAnnualVacationService, AnnualVacationService>();
        services.AddScoped<IVacationService, VacationService>();
        services.AddScoped<IContractService, ContractService>();
        services.AddScoped<ITimeSliceService, TimeSliceService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IUserOnProjectService, UserOnProjectService>();
        services.AddScoped<ISickLeaveService, SickLeaveService>();

        return services;
    }
}
