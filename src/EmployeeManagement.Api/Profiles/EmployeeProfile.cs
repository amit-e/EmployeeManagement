namespace EmployeeManagement.Api.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, EmployeeListItemDto>();
        CreateMap<NewEmployeeDto, Employee>();
        //.ForMember(
        //    dest => dest.FirstName,
        //    opt => opt.MapFrom(src => $"{src.FirstName}")
        //)
    }
}