using Domain.Entities;

namespace Application.DTOs.Products
{
    public class BenfitsDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();
    }
}