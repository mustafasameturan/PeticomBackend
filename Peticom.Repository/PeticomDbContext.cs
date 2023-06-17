using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;

namespace Peticom.Repository;

public class PeticomDbContext : IdentityDbContext<UserApp, IdentityRole, string>
{
    public PeticomDbContext(DbContextOptions<PeticomDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<PetIdentity> PetIdentities { get; set; }
    public DbSet<PetDisease> PetDiseases { get; set; }
    public DbSet<PetVaccine> PetVaccines { get; set; }
    public DbSet<PeticomerBadge> PeticomerBadges { get; set; }
    public DbSet<PeticomerHome> PeticomerHomes { get; set; }
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<SubComment> SubComments { get; set; }
    public DbSet<Star> Stars { get; set; }
    public DbSet<PeticomerApplication> PeticomerApplications { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    
    /// <summary>
    /// This method is used to set the CreatedDate and UpdatedDate properties of the entities. For sync operations.
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is BaseEntity entityReference)
            {
                switch (item.Entity)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreatedDate = DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }
            }
        }
        return base.SaveChanges();
    }
    
    /// <summary>
    /// This method is used to set the CreatedDate and UpdatedDate properties of the entities. For async operations.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if(item.Entity is BaseEntity  entityReference)
            {
                switch(item.State)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreatedDate=DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;

                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// This method is used to configure the entities.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This code is used to configure the entities by using the Fluent API approach.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}