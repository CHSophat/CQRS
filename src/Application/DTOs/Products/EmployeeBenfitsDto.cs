using Domain.Entities;

namespace Application.DTOs.Products
{
    public class EmployeeBenfitsDto {
        public DateTime AssignedDate { get; set; }

        // Foreign keys
        public int EmployeeId { get; set; }
        public int BenefitId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public Benefit Benefit { get; set; }
    }

}
