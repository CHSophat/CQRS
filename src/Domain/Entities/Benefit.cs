namespace Domain.Entities;

public class Benefit : BaseEntities.BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; }
}