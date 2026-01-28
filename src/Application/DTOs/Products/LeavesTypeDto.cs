using Domain.Entities;

namespace Application.DTOs.Products
{
    public class LeavesTypeDto
    {
        public string Name { get; set; }
        public int MaxDays { get; set; }

        // Navigation properties
        public ICollection<Leave> Leaves { get; set; }
    }
}

