using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        AppDbContext _dbContext;

        public GamesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{gameId}/{accessCode}")]
        public async Task<IActionResult> Get(int gameId, string accessCode)
        {
            var game = await _dbContext
                .Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.Stages)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return NotFound();
            }

            Player player = null, opponent = null;

            Func<GameStage, GameStageViewModel> stagesSelector = null;

            if (game.Player1.AccessCode == accessCode)
            {
                player = game.Player1;
                opponent = game.Player2;

                stagesSelector = s => new GameStageViewModel
                {
                    PlayerShape = s.Player1Choice,
                    OpponentShape = s.Player2Choice
                };
            }
            else if (game.Player2.AccessCode == accessCode)
            {
                player = game.Player2;
                opponent = game.Player1;

                stagesSelector = s => new GameStageViewModel
                {
                    PlayerShape = s.Player2Choice,
                    OpponentShape = s.Player1Choice
                };
            }

            var stages = game.Stages.Select(stagesSelector).ToList();

            var viewModel = new GameViewModel
            {
                Id = game.Id,
                Opponent = new PlayerViewModel { Name = opponent.Name },
                Player = new PlayerViewModel
                {
                    Name = player.Name,
                    AccessCode = player.AccessCode
                },
                Stages = stages
            };

            return Json(viewModel);
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> Get(int gameId)
        {
            var game = await _dbContext
                .Games
                .Include(g => g.Player1)
                .Include(g => g.Player2)
                .Include(g => g.Stages)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return NotFound();
            }

            //var viewModel = new
            //{
            //    Id = game.Id,
            //    Player1 = new { Name = game.Player1.Name },
            //    Player2 = new { Name = game.Player2.Name },
            //    Stages = game.Stages.Select(s => new
            //    {
            //        Player1Shape = s.Player1Choice,
            //        Player2Shape = s.Player2Choice
            //    }).ToList()
            //};

            var viewModel = new GameViewModel
            {
                Id = game.Id,
                Player = new PlayerViewModel { Name = game.Player1.Name },
                Opponent = new PlayerViewModel { Name = game.Player2.Name }
            };

            return Json(viewModel);
        }
    }
}
