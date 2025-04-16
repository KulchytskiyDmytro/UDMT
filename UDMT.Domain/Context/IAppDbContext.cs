using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace UDMT.Domain.Context;

public interface IAppDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    
    Task<int> SaveChangesAsync(CancellationToken cancel = default);
    
    EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
    
    void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
}