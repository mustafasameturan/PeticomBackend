using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.About).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Slogan).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasMany(a => a.Stars)
            .WithOne(s => s.Ad)
            .HasForeignKey(s => s.AdId);

    }
}