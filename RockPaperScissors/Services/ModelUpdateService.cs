using System;
using System.Collections.Generic;
using System.Linq;
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
        static readonly Dictionary<Type, PropertyInfo[]> _cache = new Dictionary<Type, PropertyInfo[]>
        {
            { typeof(Game), typeof(Game).GetProperties() },
            { typeof(GameStage), typeof(GameStage).GetProperties() },
            { typeof(Player), typeof(Player).GetProperties() }
        };

        /// <summary>
        /// Rewrites properties values from <paramref name="newItem"/> to <paramref name="originalItem"/>.
        /// </summary>
        /// <param name="originalItem">Item that will receive new values.</param>
        /// <param name="newItem">Item that will write its values to the second one.</param>
        public void Update(TModel originalItem, TModel newItem)
        {
            var modelType = newItem.GetType();

            PropertyInfo[] properties = null;
            
            if (_cache.ContainsKey(modelType))
            {
                properties = _cache[modelType];
            }
            else
            {
                properties = modelType.GetProperties();
                _cache.Add(modelType, properties);
            }

            foreach (var property in properties)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                property.SetValue(originalItem, property.GetValue(newItem));
            }
        }
    }

    /// <summary>
    /// Default service which updates all <see cref="IModelEntity"/> properties using reflection.
    /// </summary>
    public class ModelUpdateService : ModelUpdateService<IModelEntity>
    {
    }
}