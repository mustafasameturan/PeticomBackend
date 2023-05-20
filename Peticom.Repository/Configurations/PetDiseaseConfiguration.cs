using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class PetDiseaseConfiguration : IEntityTypeConfiguration<PetDisease>
{
    public void Configure(EntityTypeBuilder<PetDisease> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(400);
        builder.HasOne(p => p.PetIdentity).WithMany(p => p.PetDiseases).HasForeignKey(p => p.PetId);

        builder.ToTable("PetDiseases");
    }
}