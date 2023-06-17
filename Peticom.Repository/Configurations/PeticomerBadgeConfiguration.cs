using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class PeticomerBadgeConfiguration : IEntityTypeConfiguration<PeticomerBadge>
{
    public void Configure(EntityTypeBuilder<PeticomerBadge> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Cigaret).IsRequired();
        builder.Property(p => p.Car).IsRequired();
        builder.Property(p => p.CarDistance);
        builder.Property(p => p.Pet).IsRequired();
        builder.Property(p => p.Garden).IsRequired();
        builder.HasOne(p => p.UserApp)
            .WithOne(u => u.PeticomerBadge)
            .HasForeignKey<PeticomerBadge>(p => p.UserId)
            .IsRequired();
        builder.ToTable("PeticomerBadges");
    }
}