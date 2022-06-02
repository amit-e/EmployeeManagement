namespace EmployeeManagement.Application.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _reportRepository;

    public ReportService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<Report?> GetReportAsync(int reportId)
        => await GetReportAsync(reportId);

    public async Task<Report?> AddReportAsync(Report report)
        => await _reportRepository.AddAsync(report);

    public async Task<Report?> UpdateReportAsync(Report report)
        => await _reportRepository.UpdateAsync(report);

    public async Task DeleteReportAsync(int reportId)
        => await _reportRepository.DeleteAsync(reportId);

    public async Task<IEnumerable<Report>> GetManagerReportsAsync(int employeeId)
        => await _reportRepository.GetByManagerIdAsync(employeeId);
}
