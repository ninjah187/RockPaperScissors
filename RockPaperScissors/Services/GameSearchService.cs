using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class GameSearchService : IGameSearchService
    {
        AppDbContext _dbContext;

        public GameSearchService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GameSearchResult> SearchGame(GameSearch gameSearch)
        {
            var game = await _dbContext
                .Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .FirstOrDefaultAsync(g => g.Id == gameSearch.GameId);

            if (game == null)
            {
                return null;
            }

            Player player = null, opponent = null;

            if (game.Player1.AccessCode == gameSearch.AccessCode)
            {
                player = game.Player1;
                opponent = game.Player2;
            }
            else if (game.Player2.AccessCode == gameSearch.AccessCode)
            {
                player = game.Player2;
                opponent = game.Player2;
            }

            if (player == null || opponent == null)
            {
                return null;
            }

            var searchResult = new GameSearchResult
            {
                PlayerName = player.Name,
                OpponentName = opponent.Name 
            };

            return searchResult;
        }
    }
}
