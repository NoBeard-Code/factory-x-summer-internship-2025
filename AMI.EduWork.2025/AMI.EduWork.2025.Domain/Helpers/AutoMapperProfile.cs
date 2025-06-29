using AMI.EduWork._2025.Domain.Entities;
using AMI.EduWork._2025.Domain.Models.Project;
using AMI.EduWork._2025.Domain.Models.TimeSlice;
using AMI.EduWork._2025.Domain.Models.User;
using AMI.EduWork._2025.Domain.Models.WorkDay;
using AutoMapper;

namespace AMI.EduWork._2025.Domain.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // Entity to Model mappings
        CreateMap<TimeSlice, GetTimeSliceModel>()
            .ForMember(dest => dest.WorkDay, opt => opt.MapFrom(src => src.WorkDay))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

        CreateMap<WorkDay, GetWorkDayModel>();
        CreateMap<ApplicationUser, GetUserModel>();
        CreateMap<Project, GetProjectModelNoRefrences>();


        // Model to Entity mappings
        CreateMap<WorkDayModel, WorkDay>();

        CreateMap<TimeSliceModel, TimeSlice>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.WorkDayId, opt => opt.Ignore());

        // Project to GetProjectModel
        CreateMap<Project, GetProjectModel>()
            .ForMember(dest => dest.TimeSlices, opt => opt.MapFrom(src => src.TimeSlices))
            .ForMember(dest => dest.UsersOnProjects, opt => opt.MapFrom(src => src.UsersOnProjects));

        // Project to GetProjectModelNoRefrences
        CreateMap<Project, GetProjectModelNoRefrences>();
    }
}
