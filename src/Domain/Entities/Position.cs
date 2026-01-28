namespace Domain.Entities;

public class Position : BaseEntities.BaseEntity
{
    public string Title { get; set; }
    public decimal BaseSalary { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign keys
    public int DepartmentId { get; set; }

    // Navigation properties
    public Department Department { get; set; }
    public ICollection<Employee> Employees { get; set; }
}