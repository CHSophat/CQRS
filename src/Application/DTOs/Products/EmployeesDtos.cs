using Domain.Entities;

namespace Application.DTOs.Products
{
    public class EmployeesDto
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; }

        // Foreign keys
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public int? SupervisorId { get; set; }

        // Navigation properties
        public Department Department { get; set; }
        public Position Position { get; set; }
        public Employee Supervisor { get; set; }
        public ICollection<Employee> Subordinates { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; }
        public ICollection<PerformanceReview> ReviewsReceived { get; set; }
        public ICollection<PerformanceReview> ReviewsGiven { get; set; }
        public ICollection<EmployeeAsset> EmployeeAssets { get; set; }
    }

}
