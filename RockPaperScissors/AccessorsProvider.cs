using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public class AccessorsProvider : IAccessorsProvider
    {
        public IEnumerable<IAccessor> GetAccessors<T>(T item)
        {
            var objectType = item.GetType();

            foreach (var property in objectType.GetProperties())
            {
                var propertyType = property.PropertyType;

                if (!(property.CanRead && property.CanWrite))
                {
                    throw new InvalidOperationException();
                }

                var accessorType = typeof(Accessor<,>).MakeGenericType(objectType, propertyType);

                var accessor = (IAccessor) Activator.CreateInstance(accessorType, property.GetGetMethod(), property.GetSetMethod());

                yield return accessor;
            }
        }
    }
}
