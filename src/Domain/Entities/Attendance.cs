using Domain.Entities.BaseEntities;

namespace Domain.Entities;

public class Attendance : BaseEntities.BaseEntity
{
    public DateTime AttendanceDate { get; set; }
    public TimeSpan? CheckIn { get; set; }
    public TimeSpan? CheckOut { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign keys
    public int EmployeeId { get; set; }

    // Navigation properties
    public Employee Employee { get; set; }
}