﻿using AMI.EduWork.Domain.Entities;
using AMI.EduWork.Domain.Models.ContractModel;
using AMI.EduWork.Domain.Models.Project;
using AMI.EduWork.Domain.Models.TimeSlice;
using AMI.EduWork.Domain.Models.User;
using AMI.EduWork.Domain.Models.UserOnVacationModel;
using AMI.EduWork.Domain.Models.VacationModel;
using AMI.EduWork.Domain.Models.WorkDay;
using AutoMapper;

namespace AMI.EduWork.Domain.Helpers;

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

        //WorkDayModel to WorkDay
        CreateMap<WorkDayModel, WorkDay>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Date));

        //Vacation
        CreateMap<VacationGetModel, Vacation>();
        CreateMap<VacationCreateModel, Vacation>();
        CreateMap<VacationUpdateModel, Vacation>();
        CreateMap<VacationGetModels, Vacation>();

        //Annual Vacation
        CreateMap<AnnualVacationGetModel, AnnualVacation>();
        CreateMap<AnnualVacationCreateModel, AnnualVacation>();
        CreateMap<AnnualVacationUpdateModel, AnnualVacation>();
        //Contract to ContractGetModel
        CreateMap<Contract, ContractGetModel>()
            .ForMember(dest => dest._GetUserModel, opt => opt.MapFrom(src => src.User));

    }
}
