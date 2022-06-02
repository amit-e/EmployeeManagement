namespace EmployeeManagement.Api.Endpoints;

public static class EmployeeEndpoints
{
    private const string ContentType = "application/json";
    private const string BaseRoute = "employees";
    private const string Tag = "Employees";

    public static void UseEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute, GetAllEmployeesAsync)
            .WithName("GetEmployees")
            .Produces<IEnumerable<EmployeeListItemDto>>(200)
            .WithTags(Tag);

        app.MapGet($"{BaseRoute}/{{id}}", GetEmployeeByIdAsync)
            .WithName("GetEmployee")
            .Produces<EmployeeDto>(200).Produces(404)
            .WithTags(Tag);

        app.MapPost(BaseRoute, AddEmployeeAsync)
            .WithName("AddEmployee")
            .Accepts<NewEmployeeDto>(ContentType)
            .Produces<EmployeeDto>(201).Produces(400)
            .WithTags(Tag);

        app.MapPut($"{BaseRoute}/{{id}}", UpdateEmployeeAsync)
            .WithName("UpdateEmployee")
            .Accepts<EmployeeDto>(ContentType)
            .Produces<EmployeeDto>(200).Produces(400)
            .WithTags(Tag);

        app.MapDelete($"{BaseRoute}/{{id}}", DeleteEmployeeAsync)
            .WithName("DeleteEmployee")
            .Produces(200).Produces(400)
            .WithTags(Tag);

        app.MapGet($"{BaseRoute}/{{id}}/subordinates", GetSubordinatesAsync)
            .WithName("GetSubordinates")
            .Produces<IEnumerable<EmployeeListItemDto>>(200)
            .WithTags(Tag);

        app.MapGet($"{BaseRoute}/managers", GetAllManagersAsync)
            .WithName("GetManagers")
            .Produces<IEnumerable<EmployeeListItemDto>>(200)
            .WithTags(Tag);
    }

    internal static async Task<IResult> GetAllEmployeesAsync(IEmployeeService employeeService, IMapper mapper)
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        var employeesDto = mapper.Map<IEnumerable<EmployeeListItemDto>>(employees);
        return Results.Ok(employeesDto);
    }

    internal static async Task<IResult> GetEmployeeByIdAsync(int id, IEmployeeService employeeService, IWorkTaskService taskService, IMapper mapper)
    {
        var employee = await employeeService.GetEmployeeAsync(id);

        if (employee is null) return Results.NotFound();
        
        var employeeDto = mapper.Map<EmployeeDto>(employee);

        var manager = await employeeService.GetEmployeeAsync(employee.ManagerId);
        employeeDto.ManagerFirstName = manager?.FirstName ?? string.Empty;
        employeeDto.ManagerLastName = manager?.LastName ?? string.Empty;
        
        var tasks = await taskService.GetEmployeeTasksAsync(employee.Id);
        employeeDto.Tasks = mapper.Map<IEnumerable<WorkTaskListItemDto>>(tasks);

        return Results.Ok(employeeDto);
    }

    internal static async Task<IResult> AddEmployeeAsync(NewEmployeeDto newEmployeeDto, IEmployeeService employeeService, IMapper mapper)
    {
        var employee = await employeeService.AddEmployeeAsync(mapper.Map<Employee>(newEmployeeDto));

        if (employee is null) return Results.StatusCode(500);

        return Results.Created($"api/employees/{employee.Id}", employee);
    }

    internal static async Task<IResult> UpdateEmployeeAsync(EmployeeDto employeeDto, IEmployeeService employeeService, IMapper mapper)
    {
        var employee = await employeeService.UpdateEmployeeAsync(mapper.Map<Employee>(employeeDto));
        var result = mapper.Map<EmployeeDto>(employee);
        return Results.Ok(result);
    }

    internal static async Task<IResult> DeleteEmployeeAsync(int id, IEmployeeService employeeService)
    {
        await employeeService.DeleteEmployeeAsync(id);
        return Results.Ok();
    }

    internal static async Task<IResult> GetAllManagersAsync(IEmployeeService employeeService, IMapper mapper)
    {
        var employees = await employeeService.GetAllEmployeesAsync();
        
        var managers = employees.Where(e => e.TypeId == EmployeeType.Manager);
        var managersDto = mapper.Map<IEnumerable<EmployeeListItemDto>>(managers);
        
        return Results.Ok(managersDto);
    }

    internal static async Task<IResult> GetSubordinatesAsync(int id, IEmployeeService employeeService, IMapper mapper)
    {
        var subordinates = await employeeService.GetSubordinatesAsync(id);

        var subordinatesDto = mapper.Map<IEnumerable<EmployeeListItemDto>>(subordinates);

        return Results.Ok(subordinatesDto);
    }  
}