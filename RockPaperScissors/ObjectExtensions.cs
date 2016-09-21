using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public static class ObjectExtensions
    {
        public static IEnumerable<Accessor> GetAccessors(this object o)
        {
            var objectType = o.GetType();
            
            foreach (var property in objectType.GetProperties())
            {
                var propertyType = property.PropertyType;

                if (!(property.CanRead && property.CanWrite))
                {
                    throw new InvalidOperationException();
                }

                var accessorType = typeof(Accessor<,>).MakeGenericType(objectType, propertyType);

                var accessor = (Accessor) Activator.CreateInstance(accessorType, property.GetGetMethod(), property.GetSetMethod());

                yield return accessor;
            }
        }
    }
}
