using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public interface IAccessorsProvider
    {
        IEnumerable<IAccessor> GetAccessors(Type objectType);

        IReadAccessor<TType, TProperty> GetReadAccessor<TType, TProperty>(MethodInfo getMethod);
        IReadAccessor GetReadAccessor(Type objectType, Type propertyType, MethodInfo getMethod);

        IWriteAccessor<TType, TProperty> GetWriteAccessor<TType, TProperty>(MethodInfo setMethod);
        IWriteAccessor GetWriteAccessor(Type objectType, Type propertyType, MethodInfo setMethod);

        IAccessor<TType, TProperty> GetAccessor<TType, TProperty>(MethodInfo getMethod, MethodInfo setMethod);
        IAccessor GetAccessor(Type objectType, Type propertyType, MethodInfo getMethod, MethodInfo setMethod);
    }
}
