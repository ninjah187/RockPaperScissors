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

        public IReadAccessor<TType, TProperty> GetReadAccessor<TType, TProperty>(MethodInfo getMethod)
        {
            var accessor = new ReadAccessor<TType, TProperty>(getMethod);

            return accessor;
        }

        public IReadAccessor GetReadAccessor(Type objectType, Type propertyType, MethodInfo getMethod)
        {
            var accessorType = typeof(ReadAccessor<,>).MakeGenericType(objectType, propertyType);

            var accessor = (IReadAccessor) Activator.CreateInstance(accessorType, getMethod);

            return accessor;
        }

        public IWriteAccessor<TType, TProperty> GetWriteAccessor<TType, TProperty>(MethodInfo setMethod)
        {
            var accessor = new WriteAccessor<TType, TProperty>(setMethod);

            return accessor;
        }

        public IWriteAccessor GetWriteAccessor(Type objectType, Type propertyType, MethodInfo setMethod)
        {
            var accessorType = typeof(WriteAccessor<,>).MakeGenericType(objectType, propertyType);

            var accessor = (IWriteAccessor) Activator.CreateInstance(accessorType, setMethod);

            return accessor;
        }

        public IAccessor<TType, TProperty> GetAccessor<TType, TProperty>(MethodInfo getMethod, MethodInfo setMethod)
        {
            return new Accessor<TType, TProperty>(
                    GetReadAccessor<TType, TProperty>(getMethod),
                    GetWriteAccessor<TType, TProperty>(setMethod)
                );
        }

        public IAccessor GetAccessor(Type objectType, Type propertyType, MethodInfo getMethod, MethodInfo setMethod)
        {
            var accessorType = typeof(Accessor<,>).MakeGenericType(objectType, propertyType);

            var accessor = (IAccessor) Activator.CreateInstance(accessorType, getMethod, setMethod);

            return accessor;
        }
    }
}
