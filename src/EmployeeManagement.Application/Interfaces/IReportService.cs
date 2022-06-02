namespace EmployeeManagement.Application.Interfaces;

public interface IReportService
{
    Task<IEnumerable<Report>> GetManagerReportsAsync(int employeeId);

    Task<Report?> GetReportAsync(int id);

    Task<Report?> AddReportAsync(Report report);

    Task<Report?> UpdateReportAsync(Report report);

    Task DeleteReportAsync(int reportId);
}
