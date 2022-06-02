namespace EmployeeManagement.Infrastructure.Repositories.Sql;

public class WorkTaskRepoSql : IWorkTaskRepository
{
    private readonly ISqlDataAccess _db;

    public WorkTaskRepoSql(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<WorkTask?> AddAsync(WorkTask task)
    {
        int id = await _db.InsertDataAndGetKeyAsync("dbo.spTask_Insert", new
        {
            task.EmployeeId,
            task.TaskText,
            task.AssignDate,
            task.DueDate
        });

        var result = await _db.LoadDataAsync<WorkTask, dynamic>("dbo.spTask_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task DeleteAsync(int id)
    {
        await _db.SaveDataAsync("dbo.spTask_Delete", new { Id = id });
    }

    public async Task<WorkTask?> GetAsync(int id)
    {
        var result = await _db.LoadDataAsync<WorkTask, dynamic>("dbo.spTask_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<WorkTask>> GetByEmployeeIdAsync(int employeeId)
    {
        return await _db.LoadDataAsync<WorkTask, dynamic>("dbo.spTask_GetByEmployeeId", new { EmployeeId = employeeId });
    }

    public async Task<WorkTask?> UpdateAsync(WorkTask task)
    {
        await _db.SaveDataAsync("dbo.spTask_Update", new
        {
            task.Id,
            task.TaskText,
            task.DueDate
        });
        return await Task.FromResult(task);
    }
}