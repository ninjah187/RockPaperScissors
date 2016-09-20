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
        where TModel : class, IModelEntity
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
        public void Update(TModel updatedItem, TModel newItem)
        {
            var modelType = typeof(TModel);

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
                if (!property.CanWrite || property.Name == nameof(updatedItem.Id))
                {
                    continue;
                }

                property.SetValue(updatedItem, property.GetValue(newItem));
            }
        }
    }

    /// <summary>
    /// Default service which updates all properties using reflection.
    /// </summary>
    public class ModelUpdateService : ModelUpdateService<IModelEntity>
    {
    }
}