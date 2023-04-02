using Core.Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class SomeFeatureEntityConfiguration :BaseEntityTypeConfiguration<SomeFeatureEntity, Guid>
{
    public override void Configure(EntityTypeBuilder<SomeFeatureEntity> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("SomeFeatureEntities").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.Price).HasColumnName("Price");
    }
}