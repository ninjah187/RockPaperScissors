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
    public class GameSearchController : Controller
    {
        IGameSearchService _gameSearchService;

        public GameSearchController(IGameSearchService gameSearchService)
        {
            _gameSearchService = gameSearchService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] GameSearch gameSearch)
        {
            var searchResult = await _gameSearchService.SearchGame(gameSearch);

            if (searchResult == null)
            {
                return NotFound();
            }

            return Json(searchResult);
        }
    }
}
