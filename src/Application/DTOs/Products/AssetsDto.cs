using Domain.Entities;

namespace Application.DTOs.Products
{
    public class AttendenceDto
    {
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public ICollection<EmployeeAsset> EmployeeAssets { get; set; }
    }
}