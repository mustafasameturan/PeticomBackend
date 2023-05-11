using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class PetIdentityConfiguration : IEntityTypeConfiguration<PetIdentity>
{
    public void Configure(EntityTypeBuilder<PetIdentity> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Type).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Color).HasMaxLength(100);
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.Gender).IsRequired();
        builder.Property(p => p.Food).HasMaxLength(200);
        builder.Property(p => p.PetLitter).HasMaxLength(200);
        builder.Property(p => p.LastInsDate).IsRequired();

        builder.ToTable("PetIdentities");
    }
}