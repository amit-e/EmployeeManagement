namespace EmployeeManagement.Api.DTOs.Report
{
    public class NewReportDto
    {
        public string? ReportText { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
    }
}
