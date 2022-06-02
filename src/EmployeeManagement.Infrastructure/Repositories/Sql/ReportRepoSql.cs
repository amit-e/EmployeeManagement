namespace EmployeeManagement.Infrastructure.Repositories.Sql;

public class ReportRepoSql : IReportRepository
{
    private readonly ISqlDataAccess _db;

    public ReportRepoSql(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<Report?> AddAsync(Report report)
    {
        int id = await _db.InsertDataAndGetKeyAsync("dbo.spReport_Insert", new
        {
            report.ReportText,
            report.ReportDate,
            report.EmployeeId,
            report.ManagerId
        });

        var result = await _db.LoadDataAsync<Report, dynamic>("dbo.spReport_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task DeleteAsync(int id)
    {
        await _db.SaveDataAsync("dbo.spReport_Delete", new { Id = id });
    }

    public async Task<Report?> GetAsync(int id)
    {
        var result = await _db.LoadDataAsync<Report, dynamic>("dbo.spReport_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Report>> GetByManagerIdAsync(int managerId)
    {
        return await _db.LoadDataAsync<Report, dynamic>("dbo.spReport_GetByManagerId", new { ManagerId = managerId });
    }

    public async Task<Report?> UpdateAsync(Report report)
    {
        await _db.SaveDataAsync("dbo.spReport_Update", new
        {
            report.Id,
            report.ReportText,
            report.ReportDate
        });
        return await Task.FromResult(report);
    }
}