using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class PerformanceReviewConfiguration : IEntityTypeConfiguration<PerformanceReview>
    {
        public void Configure(EntityTypeBuilder<PerformanceReview> builder)
        {
            builder.ToTable("performance_reviews");

            builder.HasKey(pr => pr.Id);

            builder.Property(pr => pr.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(pr => pr.ReviewDate)
                .HasColumnName("review_date");

            builder.Property(pr => pr.Rating)
                .HasColumnName("rating");

            builder.Property(pr => pr.Comments)
                .HasColumnName("comments");

            // Foreign keys
            builder.Property(pr => pr.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(pr => pr.ReviewerId)
                .HasColumnName("reviewer_id");

            // Relationships
            builder.HasOne(pr => pr.Employee)
                .WithMany(e => e.ReviewsReceived)
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pr => pr.Reviewer)
                .WithMany(e => e.ReviewsGiven)
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(pr => pr.EmployeeId);
            builder.HasIndex(pr => pr.ReviewerId);
            builder.HasIndex(pr => pr.ReviewDate);
            builder.HasIndex(pr => pr.Rating);
        }
    }
}