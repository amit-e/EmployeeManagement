namespace EmployeeManagement.Application.Services;

public class WorkTaskService : IWorkTaskService
{
    private readonly IWorkTaskRepository _workTaskRepository;

    public WorkTaskService(IWorkTaskRepository workTaskRepository)
    {
        _workTaskRepository = workTaskRepository;
    }

    public async Task<WorkTask?> GetTaskAsync(int id)
        => await _workTaskRepository.GetAsync(id);

    public async Task<WorkTask?> AddTaskAsync(WorkTask workTask)
        => await _workTaskRepository.AddAsync(workTask);

    public async Task<WorkTask?> UpdateTaskAsync(WorkTask workTask)
    => await _workTaskRepository.UpdateAsync(workTask);

    public async Task DeleteTaskAsync(int taskId)
        => await _workTaskRepository.DeleteAsync(taskId);

    public async Task<IEnumerable<WorkTask>> GetEmployeeTasksAsync(int employeeId)
        => await _workTaskRepository.GetByEmployeeIdAsync(employeeId);
}
