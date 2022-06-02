namespace EmployeeManagement.Api.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<WorkTask, WorkTaskDto>().ReverseMap();
        CreateMap<WorkTask, WorkTaskListItemDto>();
        CreateMap<NewWorkTaskDto, WorkTask>();
    }
}
