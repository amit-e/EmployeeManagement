namespace EmployeeManagement.Infrastructure.Repositories.Sql;

public class EmployeeRepoSql : IEmployeeRepository
{
    private readonly ISqlDataAccess _db;

    public EmployeeRepoSql(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<Employee?> AddAsync(Employee employee)
    {
        int id = await _db.InsertDataAndGetKeyAsync("dbo.spEmployee_Insert", new
        {
            employee.FirstName,
            employee.LastName,
            employee.TypeId,
            employee.PositionId,
            employee.ManagerId
        });

        var result = await _db.LoadDataAsync<Employee, dynamic>("dbo.spEmployee_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task DeleteAsync(int id)
    {
        await _db.SaveDataAsync("dbo.spEmployee_Delete", new { Id = id });
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await _db.LoadDataAsync<Employee, dynamic>("dbo.spEmployee_GetAll", new { });
    }

    public async Task<Employee?> GetAsync(int id)
    {
        var result = await _db.LoadDataAsync<Employee, dynamic>("dbo.spEmployee_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Employee>> GetByManagerIdAsync(int managerId)
    {
        return await _db.LoadDataAsync<Employee, dynamic>("dbo.spEmployee_GetByManagerId", new { ManagerId = managerId });
    }

    public async Task<Employee?> UpdateAsync(Employee employee)
    {
        await _db.SaveDataAsync("dbo.spEmployee_Update", new
        {
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.TypeId,
            employee.PositionId,
            employee.ManagerId
        });
        return await Task.FromResult(employee);
    }
}