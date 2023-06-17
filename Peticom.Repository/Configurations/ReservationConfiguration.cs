using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Peticom.Core.Entities;

namespace Peticom.Repository.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
        builder.Property(p => p.BeginTime).IsRequired();
        builder.Property(p => p.EndTime).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.TotalPrice).IsRequired();
        builder.ToTable("Reservations");
    } 
}