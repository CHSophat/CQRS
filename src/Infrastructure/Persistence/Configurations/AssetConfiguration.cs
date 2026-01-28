// Infrastructure/Persistence/Configurations/AssetConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRManagement.Infrastructure.Persistence.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("assets");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.AssetName)
                .HasColumnName("asset_name")
                .HasMaxLength(100);

            builder.Property(a => a.AssetCode)
                .HasColumnName("asset_code")
                .HasMaxLength(50);

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasMaxLength(20)
                .HasDefaultValue("Available");

            // Relationships
            builder.HasMany(a => a.EmployeeAssets)
                .WithOne(ea => ea.Asset)
                .HasForeignKey(ea => ea.AssetId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(a => a.AssetCode)
                .IsUnique();

            builder.HasIndex(a => a.Status);
        }
    }
}