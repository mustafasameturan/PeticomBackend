using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Entities
{

    public abstract class BaseEntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.CreatedDate)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(m => m.UpdatedDate)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}