namespace EmployeeManagement.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee?> GetEmployeeAsync(int employeeId)
        => await _employeeRepository.GetAsync(employeeId);

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        => await _employeeRepository.GetAllAsync();

    public async Task<Employee?> AddEmployeeAsync(Employee employee)
        => await _employeeRepository.AddAsync(employee);

    public async Task<Employee?> UpdateEmployeeAsync(Employee employee)
        => await _employeeRepository.UpdateAsync(employee);

    public async Task DeleteEmployeeAsync(int employeeId)
        => await _employeeRepository.DeleteAsync(employeeId);

    public async Task<IEnumerable<Employee>> GetSubordinatesAsync(int managerId)
        => await _employeeRepository.GetByManagerIdAsync(managerId);
}