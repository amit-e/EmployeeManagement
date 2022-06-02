namespace EmployeeManagement.Api.DTOs.Report
{
    public class ReportListItemDto
    {
        public int Id { get; set; }
        public DateTime ReportDate { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
    }
}
