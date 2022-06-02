namespace EmployeeManagement.Application.Interfaces;

public interface IEmployeeService
{
    Task<Employee?> GetEmployeeAsync(int id);

    Task<IEnumerable<Employee>> GetAllEmployeesAsync();

    Task<IEnumerable<Employee>> GetSubordinatesAsync(int managerId);

    Task<Employee?> AddEmployeeAsync(Employee employee);

    Task<Employee?> UpdateEmployeeAsync(Employee employee);

    Task DeleteEmployeeAsync(int employeeId);
}
