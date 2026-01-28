// Infrastructure/Persistence/Configurations/AttendanceConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("attendance");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.AttendanceDate)
                .HasColumnName("attendance_date")
                .IsRequired();

            builder.Property(a => a.CheckIn)
                .HasColumnName("check_in");

            builder.Property(a => a.CheckOut)
                .HasColumnName("check_out");

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasMaxLength(20);

            builder.Property(a => a.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Foreign key
            builder.Property(a => a.EmployeeId)
                .HasColumnName("employee_id")
                .IsRequired();

            // Relationships
            builder.HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(a => a.EmployeeId);
            builder.HasIndex(a => a.AttendanceDate);
            builder.HasIndex(a => a.Status);

            // Composite unique constraint
            builder.HasIndex(a => new { a.EmployeeId, a.AttendanceDate })
                .IsUnique();
        }
    }
}