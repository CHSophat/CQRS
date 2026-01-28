
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.ToTable("payroll");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.SalaryMonth)
                .HasColumnName("salary_month")
                .HasMaxLength(7); // Format: YYYY-MM

            builder.Property(p => p.BaseSalary)
                .HasColumnName("base_salary")
                .HasPrecision(10, 2);

            builder.Property(p => p.Allowance)
                .HasColumnName("allowance")
                .HasPrecision(10, 2)
                .HasDefaultValue(0);

            builder.Property(p => p.Deduction)
                .HasColumnName("deduction")
                .HasPrecision(10, 2)
                .HasDefaultValue(0);

            builder.Property(p => p.NetSalary)
                .HasColumnName("net_salary")
                .HasPrecision(10, 2)
                .HasComputedColumnSql("base_salary + allowance - deduction", stored: true);

            builder.Property(p => p.PaidDate)
                .HasColumnName("paid_date");

            // Foreign key
            builder.Property(p => p.EmployeeId)
                .HasColumnName("employee_id");

            // Relationships
            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(p => p.EmployeeId);
            builder.HasIndex(p => p.SalaryMonth);
            builder.HasIndex(p => p.PaidDate);

            // Composite unique constraint
            builder.HasIndex(p => new { p.EmployeeId, p.SalaryMonth })
                .IsUnique();
        }
    }
}