// Application/DTOs/Attendance/AttendanceDto.cs
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace HRManagement.Application.DTOs.Attendance
{
    public class AttendanceDto
    {
        public DateTime AttendanceDate { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign keys
        public int EmployeeId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }

    }
}