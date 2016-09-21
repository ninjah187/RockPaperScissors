using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;

namespace RockPaperScissors
{
    public abstract class ReadAccessor : IReadAccessor
    {
        public Func<object, object> Getter { get; protected set; }
    }

    public class ReadAccessor<TType, TProperty> : ReadAccessor, IReadAccessor<TType, TProperty>
    {
        public new Func<TType, TProperty> Getter { get; }

        public ReadAccessor(MethodInfo getMethod)
        {
            Getter = GetGetter(getMethod);

            base.Getter = @object => Getter((TType) @object);
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
    }
}
