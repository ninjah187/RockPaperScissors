using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public interface IRepository<TModel>
        where TModel : class, IModelEntity
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetAsync(int id);
        Task<int> CountAsync();
        Task CreateAsync(TModel item);
        Task UpdateAsync(TModel item);
        Task DeleteAsync(int id);
        Task CommitAsync();
    }
}
