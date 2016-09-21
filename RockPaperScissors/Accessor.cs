using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public class Accessor<TType, TProperty> : Accessor, IAccessor<TType, TProperty>
    {
        public new Func<TType, TProperty> Getter { get; }
        public new Action<TType, TProperty> Setter { get; }

        public Accessor(MethodInfo getMethod, MethodInfo setMethod)
        {
            Getter = GetGetter(getMethod);
            Setter = GetSetter(setMethod);

            base.Getter = @object => Getter((TType) @object);
            base.Setter = (@object, property) => Setter((TType) @object, (TProperty) property);
        }

        protected static Func<TType, TProperty> GetGetter(MethodInfo getMethod)
        {
            var parameterTType = Expression.Parameter(typeof(TType), "TType");

            var expression = Expression.Lambda<Func<TType, TProperty>>(
                        Expression.Call(parameterTType, getMethod),
                        parameterTType
                    );

            return expression.Compile();
        }

        protected static Action<TType, TProperty> GetSetter(MethodInfo setMethod)
        {
            var parameterTType = Expression.Parameter(typeof(TType), "TType");
            var parameterTProperty = Expression.Parameter(typeof(TProperty), "TProperty");

            var expression = Expression.Lambda<Action<TType, TProperty>>(
                        Expression.Call(parameterTType, setMethod, parameterTProperty),
                        parameterTType,
                        parameterTProperty
                    );

            return expression.Compile();
        }
    }

    public abstract class Accessor : IAccessor
    {
        public Func<object, object> Getter { get; protected set; }
        public Action<object, object> Setter { get; protected set; }
    }
}
