using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public abstract class WriteAccessor : IWriteAccessor
    {
        public Action<object, object> Setter { get; protected set; }
    }

    public class WriteAccessor<TType, TProperty> : WriteAccessor, IWriteAccessor<TType, TProperty>
    {
        public new Action<TType, TProperty> Setter { get; }

        public WriteAccessor(MethodInfo setMethod)
        {
            Setter = GetSetter(setMethod);

            base.Setter = (@object, property) => Setter((TType) @object, (TProperty) property);
        }

        protected static Action<TType, TProperty> GetSetter(MethodInfo setMethod)
        {
            var parameterTType = Expression.Parameter(typeof(TType), "objectType");
            var parameterTProperty = Expression.Parameter(typeof(TProperty), "propertyType");

            var expression = Expression.Lambda<Action<TType, TProperty>>(
                        Expression.Call(parameterTType, setMethod, parameterTProperty),
                        parameterTType,
                        parameterTProperty
                    );

            return expression.Compile();
        }
    }
}
