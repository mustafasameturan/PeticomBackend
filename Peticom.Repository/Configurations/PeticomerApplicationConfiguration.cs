using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class PeticomerApplicationConfiguration : IEntityTypeConfiguration<PeticomerApplication>
{
    public void Configure(EntityTypeBuilder<PeticomerApplication> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
        builder.Property(p => p.City).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Address).IsRequired().HasMaxLength(400);
        builder.Property(p => p.Status).HasDefaultValue(false);
        builder.Property(p => p.RejectStatus).HasDefaultValue(true);

        builder.ToTable("PeticomerApplications");
    }
}