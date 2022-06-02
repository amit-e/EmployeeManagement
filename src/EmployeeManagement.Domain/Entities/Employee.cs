using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Domain.Entities;

public record Employee
{
    public int Id { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public EmployeeType? TypeId { get; set; }

    public Position PositionId { get; set; }
    
    public string? Position { get; set; }

    public int ManagerId { get; set; }
}
