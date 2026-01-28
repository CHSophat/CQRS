using Domain.Entities.BaseEntities;

namespace Domain.Entities;


    public class PerformanceReview : BaseEntities.BaseEntity
{
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        // Foreign keys
        public int EmployeeId { get; set; }
        public int ReviewerId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }
        public Employee Reviewer { get; set; }
    }