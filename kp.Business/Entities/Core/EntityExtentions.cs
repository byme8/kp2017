using System.Linq;
using kp.Entities.Data;

namespace kp.Business.Entities
{
    public static class EntityExtentions
    {
        public static void MarkAsDeleted(this Entity entity)
        {
            entity.Deleted = true;
        }

        public static IQueryable<TEntity> NotDeleted<TEntity>(this IQueryable<TEntity> entities)
            where TEntity : Entity
        {
            return entities.Where(o => !o.Deleted);
        }
    }
}