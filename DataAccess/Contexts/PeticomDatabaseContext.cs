using System.Reflection;
using Core.Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class PeticomDatabaseContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<SomeFeatureEntity> SomeFeatureEntities { get; set; }
    
    public PeticomDatabaseContext(DbContextOptions<PeticomDatabaseContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        var currentDate = DateTime.UtcNow;

        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = currentDate;
                        break;
                    case EntityState.Modified:
                        entity.UpdatedDate = currentDate;
                        break;
                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(a => a.GetForeignKeys()))
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
    }
}
