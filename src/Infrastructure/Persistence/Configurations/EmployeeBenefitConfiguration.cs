// Infrastructure/Persistence/Configurations/EmployeeBenefitConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class EmployeeBenefitConfiguration : IEntityTypeConfiguration<EmployeeBenefit>
    {
        public void Configure(EntityTypeBuilder<EmployeeBenefit> builder)
        {
            builder.ToTable("employee_benefits");

            // Composite primary key
            builder.HasKey(eb => new { eb.EmployeeId, eb.BenefitId });

            builder.Property(eb => eb.AssignedDate)
                .HasColumnName("assigned_date")
                .HasDefaultValueSql("CURRENT_DATE");

            // Foreign keys
            builder.Property(eb => eb.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(eb => eb.BenefitId)
                .HasColumnName("benefit_id");

            // Relationships
            builder.HasOne(eb => eb.Employee)
                .WithMany(e => e.EmployeeBenefits)
                .HasForeignKey(eb => eb.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(eb => eb.Benefit)
                .WithMany(b => b.EmployeeBenefits)
                .HasForeignKey(eb => eb.BenefitId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(eb => eb.EmployeeId);
            builder.HasIndex(eb => eb.BenefitId);
            builder.HasIndex(eb => eb.AssignedDate);
        }
    }
}