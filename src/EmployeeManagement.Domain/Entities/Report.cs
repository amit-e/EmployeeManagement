namespace EmployeeManagement.Domain.Entities;

public record Report
{
    public int Id { get; set; }

    public string? ReportText { get; set; }

    public DateTime ReportDate { get; set; }

    public int EmployeeId { get; set; }
    
    public int ManagerId { get; set; }
}
