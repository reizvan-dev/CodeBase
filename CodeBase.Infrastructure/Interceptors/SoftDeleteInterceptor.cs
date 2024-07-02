using CodeBase.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CodeBase.Infrastructure.Interceptors
{
    public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(
                    eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<SoftDeletableEntity>> entries =
                eventData
                    .Context
                    .ChangeTracker
                    .Entries<SoftDeletableEntity>()
                    .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<SoftDeletableEntity> softDeletable in entries)
            {
                softDeletable.Entity.DeleteTimeUTC = DateTime.UtcNow;
                softDeletable.State = EntityState.Modified;
                softDeletable.Entity.IsDeleted = true;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}