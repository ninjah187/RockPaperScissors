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
        static readonly Dictionary<Type, IAccessor[]> _cache = new Dictionary<Type, IAccessor[]>();

        IAccessorsProvider _accessorsProvider;

        public ModelUpdateService(IAccessorsProvider accessorsProvider)
        {
            _accessorsProvider = accessorsProvider;
        }

        /// <summary>
        /// Rewrites properties values from <paramref name="newItem"/> to <paramref name="originalItem"/>.
        /// </summary>
        /// <param name="originalItem">Item that will receive new values.</param>
        /// <param name="newItem">Item that will write its values to the second one.</param>
        public void Update(TModel originalItem, TModel newItem)
        {
            if (originalItem == null) throw new ArgumentNullException(nameof(originalItem));
            if (newItem == null) throw new ArgumentNullException(nameof(newItem));

            var modelType = newItem.GetType();

            IAccessor[] accessors = null;
            
            if (_cache.ContainsKey(modelType))
            {
                accessors = _cache[modelType];
            }
            else
            {
                accessors = _accessorsProvider.GetAccessors(modelType).ToArray();
                _cache.Add(modelType, accessors);
            }

            foreach (var accessor in accessors)
            {
                accessor.Setter(originalItem, accessor.Getter(newItem));
            }
        }
    }

    /// <summary>
    /// Default service which updates all <see cref="IModelEntity"/> properties using reflection.
    /// </summary>
    public class ModelUpdateService : ModelUpdateService<IModelEntity>, IModelUpdateService
    {
        public ModelUpdateService(IAccessorsProvider accessorsProvider)
            : base(accessorsProvider)
        {
        }
    }
}