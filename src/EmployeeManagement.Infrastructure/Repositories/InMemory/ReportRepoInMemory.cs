namespace EmployeeManagement.Infrastructure.Repositories.InMemory;

public class ReportRepoInMemory : IReportRepository
{
    List<Report> _reports = new List<Report>();

    public async Task<Report?> AddAsync(Report report)
    {
        report.Id = !_reports.Any() ? 1 : _reports.Max(e => e.Id) + 1;
        _reports.Add(report);
        return await Task.FromResult(report);
    }

    public async Task DeleteAsync(int id)
    {
        _reports.RemoveAll(r => r.Id == id);
        await Task.CompletedTask;
    }

    public async Task<Report?> GetAsync(int id)
    {
        return await Task.FromResult(_reports.FirstOrDefault(r => r.Id == id));
    }

    public async Task<IEnumerable<Report>> GetByManagerIdAsync(int managerId)
    {
        return await Task.FromResult(_reports.Where(r => r.ManagerId == managerId));
    }

    public async Task<Report?> UpdateAsync(Report report)
    {
        _reports.RemoveAll(r => r.Id == report.Id);
        _reports.Add(report);
        return await Task.FromResult(report);
    }
}
