using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NeerCore.DependencyInjection;
using UDMT.Domain.Entity;
using UDMT.Domain.Entity.Shared;

namespace UDMT.Domain.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();

    public new Task<int> SaveChangesAsync(CancellationToken cancel = default) => base.SaveChangesAsync(cancel);

    public new EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class => base.Remove(entity);
    
    public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class => base.RemoveRange(entities);
    
    public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken ct = default)
        where TEntity : class
    {
        await base.AddRangeAsync(entities, ct);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}