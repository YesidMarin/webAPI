using System;
namespace Entities.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }
    }
}
