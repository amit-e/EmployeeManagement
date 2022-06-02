namespace EmployeeManagement.Api.Endpoints;

public static class ReportEndpoints
{
    private const string Tag = "Reports";
    private const string ContentType = "application/json";

    public static void UseReportEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet($"/employees/{{managerId}}/reports", GetManagerReportsAsync)
            .WithName("GetManagerReports")
            .Produces<IEnumerable<ReportListItemDto>>(200)
            .WithTags(Tag);

        app.MapPost($"/employees/{{managerId}}/reports", CreateReportAsync)
            .WithName("CreateReport")
            .Accepts<NewReportDto>(ContentType)
            .Produces<ReportDto>(200).Produces(400)
            .WithTags(Tag);
    }

    internal static async Task<IResult> GetManagerReportsAsync(int managerId, IReportService reportService, IEmployeeService employeeService, IMapper mapper)
    {
        var reports = await reportService.GetManagerReportsAsync(managerId);
        var reportsDto = mapper.Map<IEnumerable<ReportListItemDto>>(reports);

        foreach (var report in reportsDto)
        {
            var employee = await employeeService.GetEmployeeAsync(report.EmployeeId);
            report.EmployeeFirstName = employee?.FirstName ?? string.Empty;
            report.EmployeeLastName = employee?.LastName ?? string.Empty;
        }
        
        return Results.Ok(reportsDto);
    }

    internal static async Task<IResult> CreateReportAsync(NewReportDto newReportDto, IReportService reportService, IMapper mapper)
    {
        var report = mapper.Map<Report>(newReportDto);
        report.ReportDate = DateTime.Now;

        var result = await reportService.AddReportAsync(report);
        return Results.Ok(result);
    }
}
