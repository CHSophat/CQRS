using Domain.Entities;

namespace Application.DTOs.Products
{
     public class EmployeeAssetDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<Position> Positions { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}