using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class PlayerService
    {
        AppDbContext _dbContext;

        public PlayerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
            => await _dbContext.Players.ToListAsync();

        public async Task<Player> GetAsync(int id)
            => await _dbContext.Players.FirstOrDefaultAsync();
    }
}
