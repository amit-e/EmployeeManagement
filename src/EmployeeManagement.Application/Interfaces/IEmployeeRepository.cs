namespace EmployeeManagement.Application.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<IEnumerable<Employee>> GetAllAsync();

    Task<IEnumerable<Employee>> GetByManagerIdAsync(int managerId);
}
