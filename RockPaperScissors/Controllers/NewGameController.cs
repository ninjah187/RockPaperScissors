using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    public class NewGameController : Controller
    {
        public IGameService _gameService;

        public NewGameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewGameData newGame)
        {
            var game = await _gameService.CreateNewGameAsync(newGame);

            return CreatedAtRoute(
                    new { controller = "Games", action = "Get" },
                    game
                );
        }
    }
}
