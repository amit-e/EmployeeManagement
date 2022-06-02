namespace EmployeeManagement.Application.Interfaces;

public interface IReportRepository : IRepository<Report>
{
    Task<IEnumerable<Report>> GetByManagerIdAsync(int managerId);
}
