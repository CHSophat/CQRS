
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace HRManagement.Application.DTOs.Products
{
    public class DepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<Position> Positions { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}