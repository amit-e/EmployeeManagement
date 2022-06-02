namespace EmployeeManagement.Infrastructure.Repositories.InMemory;

public class WorkTaskRepoInMemory : IWorkTaskRepository
{
    List<WorkTask> _tasks = new List<WorkTask>();

    public async Task<WorkTask?> AddAsync(WorkTask task)
    {
        task.Id = !_tasks.Any() ? 1 : _tasks.Max(t => t.Id) + 1;
        _tasks.Add(task);
        return await Task.FromResult(task);
    }

    public async Task DeleteAsync(int id)
    {
        _tasks.RemoveAll(t => t.Id == id);
        await Task.CompletedTask;
    }

    public async Task<WorkTask?> GetAsync(int id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task<IEnumerable<WorkTask>> GetByEmployeeIdAsync(int employeeId)
    {
        return await Task.FromResult(_tasks.Where(t => t.EmployeeId == t.EmployeeId));
    }

    public async Task<WorkTask?> UpdateAsync(WorkTask task)
    {
        _tasks.RemoveAll(t => t.Id == task.Id);
        _tasks.Add(task);
        return await Task.FromResult(task);
    }
}
