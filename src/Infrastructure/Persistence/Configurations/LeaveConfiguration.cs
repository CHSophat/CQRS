// Infrastructure/Persistence/Configurations/LeaveConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("leaves");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(l => l.StartDate)
                .HasColumnName("start_date");

            builder.Property(l => l.EndDate)
                .HasColumnName("end_date");

            builder.Property(l => l.Reason)
                .HasColumnName("reason");

            builder.Property(l => l.Status)
                .HasColumnName("status")
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            builder.Property(l => l.AppliedAt)
                .HasColumnName("applied_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Foreign keys
            builder.Property(l => l.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(l => l.LeaveTypeId)
                .HasColumnName("leave_type_id");

            // Relationships
            builder.HasOne(l => l.Employee)
                .WithMany(e => e.Leaves)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.LeaveType)
                .WithMany(lt => lt.Leaves)
                .HasForeignKey(l => l.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(l => l.EmployeeId);
            builder.HasIndex(l => l.LeaveTypeId);
            builder.HasIndex(l => l.StartDate);
            builder.HasIndex(l => l.EndDate);
            builder.HasIndex(l => l.Status);
        }
    }
}