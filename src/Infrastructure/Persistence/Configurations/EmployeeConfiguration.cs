
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.EmployeeCode)
                .HasColumnName("employee_code")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100);

            builder.Property(e => e.Gender)
                .HasColumnName("gender")
                .HasMaxLength(10);

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("dob");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(150);

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);

            builder.Property(e => e.Address)
                .HasColumnName("address");

            builder.Property(e => e.HireDate)
                .HasColumnName("hire_date");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Foreign keys
            builder.Property(e => e.DepartmentId)
                .HasColumnName("department_id");

            builder.Property(e => e.PositionId)
                .HasColumnName("position_id");

            builder.Property(e => e.SupervisorId)
                .HasColumnName("supervisor_id");

            // Relationships
            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Supervisor)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Self-referencing relationship
            builder.HasMany(e => e.Subordinates)
                .WithOne(e => e.Supervisor)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(e => e.EmployeeCode)
                .IsUnique();

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.HasIndex(e => e.DepartmentId);
            builder.HasIndex(e => e.PositionId);
            builder.HasIndex(e => e.SupervisorId);
            builder.HasIndex(e => e.Status);

            // Composite indexes
            builder.HasIndex(e => new { e.FirstName, e.LastName });
        }
    }
}