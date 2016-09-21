using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    /// <summary>
    /// Default service which updates all properties using reflection.
    /// </summary>
    public class ModelUpdateService<TModel> : IModelUpdateService<TModel>
        where TModel : class
    {
        static readonly Dictionary<Type, Accessor[]> _cache = new Dictionary<Type, Accessor[]>();

        /// <summary>
        /// Rewrites properties values from <paramref name="newItem"/> to <paramref name="originalItem"/>.
        /// </summary>
        /// <param name="originalItem">Item that will receive new values.</param>
        /// <param name="newItem">Item that will write its values to the second one.</param>
        public void Update(TModel originalItem, TModel newItem)
        {
            var modelType = newItem.GetType();

            Accessor[] accessors = null;
            
            if (_cache.ContainsKey(modelType))
            {
                accessors = _cache[modelType];
            }
            else
            {
                accessors = originalItem.GetAccessors().ToArray();
                _cache.Add(modelType, accessors);
            }

            foreach (var accessor in accessors)
            {
                accessor.Setter(originalItem, accessor.Getter(newItem));
            }
        }

        public Action<TType, TProperty> GetSetter<TType, TProperty>(MethodInfo setMethod)
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

    /// <summary>
    /// Default service which updates all <see cref="IModelEntity"/> properties using reflection.
    /// </summary>
    public class ModelUpdateService : ModelUpdateService<IModelEntity>
    {
    }
}