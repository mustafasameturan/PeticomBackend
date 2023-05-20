using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class PeticomerHomeConfiguration : IEntityTypeConfiguration<PeticomerHome>
{
    public void Configure(EntityTypeBuilder<PeticomerHome> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Type).IsRequired();
        builder.Property(p => p.Garden).IsRequired();
        builder.Property(p => p.Cigaret).IsRequired();
        builder.Property(p => p.Kid).IsRequired();

        builder.ToTable("PeticomerHomes");
    }
}