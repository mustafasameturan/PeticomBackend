using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class PeticomerBadgeConfiguration : IEntityTypeConfiguration<PeticomerBadge>
{
    public void Configure(EntityTypeBuilder<PeticomerBadge> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Cigaret).IsRequired();
        builder.Property(p => p.Car).IsRequired();
        builder.Property(p => p.CarDistance).IsRequired();
        builder.Property(p => p.Pet).IsRequired();
        builder.Property(p => p.Garden).IsRequired();

        builder.ToTable("PeticomerBadges");
    }
}