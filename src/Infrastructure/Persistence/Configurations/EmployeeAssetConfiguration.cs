// Infrastructure/Persistence/Configurations/EmployeeAssetConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class EmployeeAssetConfiguration : IEntityTypeConfiguration<EmployeeAsset>
    {
        public void Configure(EntityTypeBuilder<EmployeeAsset> builder)
        {
            builder.ToTable("employee_assets");

            // Composite primary key
            builder.HasKey(ea => new { ea.EmployeeId, ea.AssetId });

            builder.Property(ea => ea.AssignedDate)
                .HasColumnName("assigned_date")
                .HasDefaultValueSql("CURRENT_DATE");

            builder.Property(ea => ea.ReturnDate)
                .HasColumnName("return_date");

            // Foreign keys
            builder.Property(ea => ea.EmployeeId)
                .HasColumnName("employee_id");

            builder.Property(ea => ea.AssetId)
                .HasColumnName("asset_id");

            // Relationships
            builder.HasOne(ea => ea.Employee)
                .WithMany(e => e.EmployeeAssets)
                .HasForeignKey(ea => ea.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ea => ea.Asset)
                .WithMany(a => a.EmployeeAssets)
                .HasForeignKey(ea => ea.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(ea => ea.EmployeeId);
            builder.HasIndex(ea => ea.AssetId);
            builder.HasIndex(ea => ea.AssignedDate);
            builder.HasIndex(ea => ea.ReturnDate);
        }
    }
}