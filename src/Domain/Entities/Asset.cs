using Domain.Entities.BaseEntities;

namespace Domain.Entities;

public class Asset : BaseEntities.BaseEntity
{
    public string AssetName { get; set; }
    public string AssetCode { get; set; }
    public string Status { get; set; }

    // Navigation properties
    public ICollection<EmployeeAsset> EmployeeAssets { get; set; }
}