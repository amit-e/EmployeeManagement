namespace EmployeeManagement.Domain.Entities;

public record WorkTask
{
    public int? Id { get; set; }
    
    public int? EmployeeId { get; set; }

    public string? TaskText { get; set; }

    public DateTime AssignDate { get; set; }

    public DateTime DueDate { get; set; }
}