namespace EmployeeManagement.Application.Interfaces;

public interface IWorkTaskService
{
    Task<WorkTask?> GetTaskAsync(int id);

    Task<WorkTask?> AddTaskAsync(WorkTask task);

    Task<WorkTask?> UpdateTaskAsync(WorkTask task);

    Task DeleteTaskAsync(int taskId);

    Task<IEnumerable<WorkTask>> GetEmployeeTasksAsync(int employeeId);
}
