namespace EmployeeManagement.Infrastructure.Repositories.InMemory;

public class EmployeeRepoInMemory : IEmployeeRepository
{
    List<Employee> _employees = new() 
    { 
        new Employee { Id = 1, FirstName = "Roger", LastName = "Carter", TypeId = EmployeeType.Manager, PositionId = Position.CEO, ManagerId = 1 },
        new Employee { Id = 2, FirstName = "Debra", LastName = "Miller", TypeId = EmployeeType.Manager, PositionId = Position.CTO, ManagerId = 1 },
        new Employee { Id = 3, FirstName = "Jimmy", LastName = "Coleman", TypeId = EmployeeType.Manager, PositionId = Position.CFO, ManagerId = 1 },
        new Employee { Id = 4, FirstName = "Scott", LastName = "Weidler", TypeId = EmployeeType.Employee, PositionId = Position.Accountant, ManagerId = 3 },
        new Employee { Id = 5, FirstName = "Carol", LastName = "Robertson", TypeId = EmployeeType.Manager, PositionId = Position.ProductManager, ManagerId = 1 },
        new Employee { Id = 6, FirstName = "Vickie", LastName = "Moser", TypeId = EmployeeType.Employee, PositionId = Position.Accountant, ManagerId = 3 },
        new Employee { Id = 7, FirstName = "Robert", LastName = "Smith", TypeId = EmployeeType.Manager, PositionId = Position.DevelopmentTeamLeader, ManagerId = 2 },
        new Employee { Id = 8, FirstName = "Patricia", LastName = "Wood", TypeId = EmployeeType.Employee, PositionId = Position.SoftwareDeveloper, ManagerId = 7 },
        new Employee { Id = 9, FirstName = "Steve", LastName = "Garlock", TypeId = EmployeeType.Employee, PositionId = Position.SoftwareDeveloper, ManagerId = 7 },
        new Employee { Id = 10, FirstName = "Amber", LastName = "Reeves", TypeId = EmployeeType.Employee, PositionId = Position.SoftwareDeveloper, ManagerId = 7 },
    };

    public async Task<Employee?> AddAsync(Employee employee)
    {
        employee.Id = !_employees.Any() ? 1 : _employees.Max(e => e.Id) + 1;
        _employees.Add(employee);
        return await Task.FromResult(employee);
    }

    public async Task DeleteAsync(int id)
    {
        _employees.RemoveAll(e => e.Id == id);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await Task.FromResult(_employees as IEnumerable<Employee>);
    }

    public async Task<Employee?> GetAsync(int id)
    {
        return await Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
    }

    public async Task<IEnumerable<Employee>> GetByManagerIdAsync(int managerId)
    {
        return await Task.FromResult(_employees.Where(e => e.ManagerId == managerId));
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        _employees.RemoveAll(e => e.Id == employee.Id);
        _employees.Add(employee);
        return await Task.FromResult(employee);
    }
}
