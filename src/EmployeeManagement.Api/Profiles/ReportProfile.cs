namespace EmployeeManagement.Api.Profiles;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        CreateMap<Report, ReportDto>().ReverseMap();
        CreateMap<Report, ReportListItemDto>();
        CreateMap<NewReportDto, Report>();
    }
}
