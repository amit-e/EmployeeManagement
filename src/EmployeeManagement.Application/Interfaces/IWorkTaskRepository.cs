namespace EmployeeManagement.Application.Interfaces;

public interface IWorkTaskRepository : IRepository<WorkTask>
{
    Task<IEnumerable<WorkTask>> GetByEmployeeIdAsync(int employeeId);
}
