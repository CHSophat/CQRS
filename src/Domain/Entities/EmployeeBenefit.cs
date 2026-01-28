namespace Domain.Entities;

public class EmployeeBenefit : BaseEntities.BaseEntity
{
    public DateTime AssignedDate { get; set; }

    // Foreign keys
    public int EmployeeId { get; set; }
    public int BenefitId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public Benefit Benefit { get; set; }
}