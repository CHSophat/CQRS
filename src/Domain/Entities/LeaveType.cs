namespace Domain.Entities;

public class LeaveType : BaseEntities.BaseEntity
{
    public string Name { get; set; }
    public int MaxDays { get; set; }

    // Navigation properties
    public ICollection<Leave> Leaves { get; set; }

}