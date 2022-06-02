namespace EmployeeManagement.Api.DTOs.Employee
{
    public class NewEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int TypeId { get; set; }
        public int PositionId { get; set; }
        public int ManagerId { get; set; }
    }
}
