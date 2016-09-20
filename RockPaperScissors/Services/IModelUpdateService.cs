using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    /// <summary>
    /// Service which updates model entity values.
    /// </summary>
    public interface IModelUpdateService<in TModel> where TModel : class
    {
        /// <summary>
        /// Rewrites properties values from <paramref name="newItem"/> to <paramref name="originalItem"/>.
        /// </summary>
        /// <param name="originalItem">Item that will receive new values.</param>
        /// <param name="newItem">Item that will write its values to the second one.</param>
        void Update(TModel originalItem, TModel newItem);
    }

    /// <summary>
    /// Service which updates <see cref="IModelEntity"/> values.
    /// </summary>
    public interface IModelUpdateService : IModelUpdateService<IModelEntity>
    {
    }
}
