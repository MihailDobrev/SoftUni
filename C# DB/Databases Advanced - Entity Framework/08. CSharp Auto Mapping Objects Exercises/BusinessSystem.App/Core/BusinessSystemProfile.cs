namespace BusinessSystem.App.Core
{
    using AutoMapper;
    using BusinessSystem.App.Core.Dtos;
    using BusinessSystem.Models;

    public class BusinessSystemProfile : Profile
    {
        public BusinessSystemProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest=>dest.Manager, from=>from.MapFrom(e=>e.Manager))
                .ReverseMap();
            CreateMap<Employee, ManagerDto>()
                .ForMember(dest => dest.EmployeeDtos, from => from.MapFrom(x => x.EmployeesOfManager))
                .ReverseMap();
            CreateMap<Employee, EmployeeInfoDto>().ReverseMap();
        }
    }
}
