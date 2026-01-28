namespace Domain.Entities;

public class EmployeeAsset : BaseEntities.BaseEntity
{
    public DateTime AssignedDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    // Foreign keys
    public int EmployeeId { get; set; }
    public int AssetId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
    public Asset Asset { get; set; }
}