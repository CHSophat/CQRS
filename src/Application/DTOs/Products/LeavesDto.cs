using Domain.Entities;

namespace Application.DTOs.Products
{
    public class LeavesDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime AppliedAt { get; set; }

        // Foreign keys
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
    }

}
