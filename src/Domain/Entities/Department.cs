namespace Domain.Entities;

public class Department : BaseEntities.BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public ICollection<Position> Positions { get; set; }
    public ICollection<Employee> Employees { get; set; }
}