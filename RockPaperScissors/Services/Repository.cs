using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : class, IModelEntity
    {
        protected DbContext DbContext { get; }
        protected IModelUpdateService ModelUpdateService { get; }

        public Repository(DbContext dbContext, IModelUpdateService modelUpdateService)
        {
            DbContext = dbContext;
            ModelUpdateService = modelUpdateService;
        }

        public async Task CommitAsync()
            => await DbContext.SaveChangesAsync();

        public async Task<IEnumerable<TModel>> GetAllAsync()
            => await DbContext.Set<TModel>().ToListAsync();

        public async Task<TModel> GetAsync(int id)
            => await DbContext.Set<TModel>().FirstOrDefaultAsync(i => i.Id == id);

        public async Task<int> CountAsync()
            => await DbContext.Set<TModel>().CountAsync();

        public Task CreateAsync(TModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.Id != 0) throw new ArgumentException("Item's id must be 0.", nameof(item));

            DbContext.Set<TModel>().Add(item);

            return Task.CompletedTask;
        }

        public async Task UpdateAsync(TModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var originalItem = await DbContext
                .Set<TModel>()
                .FirstOrDefaultAsync(i => i.Id == item.Id);

            if (originalItem == null)
            {
                throw new InvalidOperationException($"There is no item with id {item.Id} in database.");
            }

            ModelUpdateService.Update(originalItem, item);
        }

        public async Task DeleteAsync(int id)
        {
            var dbSet = DbContext.Set<TModel>();

            var item = await dbSet
                .FirstOrDefaultAsync(i => i.Id == id);

            if (item != null)
            {
                dbSet.Remove(item);
            }
        }
    }
}
