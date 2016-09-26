using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class GamesRepository : Repository<Game>, IGamesRepository
    {
        public GamesRepository(AppDbContext dbContext, IModelUpdateService modelUpdateService)
            : base(dbContext, modelUpdateService)
        {
        }
    }
}
