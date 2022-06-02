namespace EmployeeManagement.Api.DTOs.Task
{
    public class NewWorkTaskDto
    {
        public int EmployeeId { get; set; }
        public string? TaskText { get; set; }
        public DateTime DueDate { get; set; }
    }
}