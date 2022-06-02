using EmployeeManagement.Api.DTOs.Task;

namespace EmployeeManagement.Api.DTOs.Employee;

public record EmployeeDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Position { get; set; }
    public int PositionId { get; set; }
    public int TypeId { get; set; }
    public int ManagerId { get; set; }
    public string? ManagerFirstName { get; set; }
    public string? ManagerLastName { get; set; }
    public IEnumerable<WorkTaskListItemDto> Tasks { get; set; } = new List<WorkTaskListItemDto>();
}
