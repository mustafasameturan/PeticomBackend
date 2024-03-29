using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class UserAppConfiguration : IEntityTypeConfiguration<UserApp>
{
    public void Configure(EntityTypeBuilder<UserApp> builder)
    {
        builder.Property(p => p.FullName).HasMaxLength(100);
        builder.Property(p => p.City).HasMaxLength(50);
        builder.HasMany(u => u.PetIdentities)
            .WithOne(p => p.UserApp)
            .HasForeignKey(p => p.UserId);
        builder.HasMany(u => u.Ads)
            .WithOne(p => p.UserApp)
            .HasForeignKey(p => p.UserId);
    }
}