
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.ToTable("leave_types");

            builder.HasKey(lt => lt.Id);

            builder.Property(lt => lt.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(lt => lt.Name)
                .HasColumnName("name")
                .HasMaxLength(50);

            builder.Property(lt => lt.MaxDays)
                .HasColumnName("max_days");

            // Relationships
            builder.HasMany(lt => lt.Leaves)
                .WithOne(l => l.LeaveType)
                .HasForeignKey(l => l.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(lt => lt.Name)
                .IsUnique();
        }
    }
}