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

        public Accessor(IReadAccessor<TType, TProperty> readAccessor,
                        IWriteAccessor<TType, TProperty> writeAccessor)
            : base(
                      @object => readAccessor.Getter((TType) @object),
                      (@object, property) => writeAccessor.Setter((TType) @object, (TProperty) property)
                  )
        {
            Getter = readAccessor.Getter;
            Setter = writeAccessor.Setter;
        }

        public Accessor(MethodInfo getMethod, MethodInfo setMethod)
        {
            Getter = GetGetter(getMethod);
            Setter = GetSetter(setMethod);

            base.Getter = @object => Getter((TType) @object);
            base.Setter = (@object, property) => Setter((TType) @object, (TProperty) property);
        }

        public static Func<TType, TProperty> GetGetter(MethodInfo getMethod)
        {
            var parameterTType = Expression.Parameter(typeof(TType), "propertyType");

            var expression = Expression.Lambda<Func<TType, TProperty>>(
                        Expression.Call(parameterTType, getMethod),
                        parameterTType
                    );

            return expression.Compile();
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

    public abstract class Accessor : IAccessor
    {
        public Func<object, object> Getter { get; protected set; }
        public Action<object, object> Setter { get; protected set; }

        public Accessor()
        {
        }

        public Accessor(Func<object, object> getter, Action<object, object> setter)
        {
            Getter = getter;
            Setter = setter;
        }
    }
}
