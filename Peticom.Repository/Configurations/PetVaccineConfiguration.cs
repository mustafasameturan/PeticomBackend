using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class PetVaccineConfiguration : IEntityTypeConfiguration<PetVaccine>
{
    public void Configure(EntityTypeBuilder<PetVaccine> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.VaccineDate).IsRequired();
        builder.Property(p => p.Period).IsRequired();
        builder.HasOne(p => p.PetIdentity).WithMany(p => p.PetVaccines).HasForeignKey(p => p.PetId);

        builder.ToTable("PetVaccines");
    }
}