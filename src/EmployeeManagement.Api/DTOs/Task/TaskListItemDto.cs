﻿namespace EmployeeManagement.Api.DTOs.Task
{
    public record WorkTaskListItemDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? TaskText { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
