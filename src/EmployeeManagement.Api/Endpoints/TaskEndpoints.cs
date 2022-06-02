namespace EmployeeManagement.Api.Endpoints;

public static class TaskEndpoints
{
    private const string Tag = "Tasks";
    private const string ContentType = "application/json";

    public static void UseTaskEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet($"/employees/{{employeeId}}/tasks", GetEmployeeTasksAsync)
            .WithName("GetEmployeeTasks")
            .Produces<IEnumerable<WorkTaskListItemDto>>(200)
            .WithTags(Tag);

        app.MapPost($"/employees/{{employeeId}}/tasks", CreateWorkTaskAsync)
            .WithName("CreateTask")
            .Accepts<NewWorkTaskDto>(ContentType)
            .Produces<WorkTaskDto>(200).Produces(400)
            .WithTags(Tag);
    }

    internal static async Task<IResult> GetEmployeeTasksAsync(int employeeId, IWorkTaskService workTaskService, IMapper mapper)
    {
        var tasks = await workTaskService.GetEmployeeTasksAsync(employeeId);

        var tasksDto = mapper.Map<IEnumerable<WorkTaskListItemDto>>(tasks);

        return Results.Ok(tasksDto);
    }

    internal static async Task<IResult> CreateWorkTaskAsync(NewWorkTaskDto newWorkTaskDto, IWorkTaskService workTaskService, IMapper mapper)
    {
        var task = mapper.Map<WorkTask>(newWorkTaskDto);
        task.AssignDate = DateTime.Now;
        
        var result = await workTaskService.AddTaskAsync(task);
        return Results.Ok(result);
    }
}