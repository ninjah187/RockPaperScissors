﻿using System;
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

            //var result = new
            //{
            //    Id = game.Id,
            //    Player = new
            //    {
            //        Name = game.Player1.Name,
            //        AccessCode = game.Player1.AccessCode
            //    },
            //    ChosenShape = game.Stages.First().Player1Choice
            //};

            var result = new
            {
                Id = game.Id,
                AccessCode = game.Player1.AccessCode
            };

            return CreatedAtRoute(
                    new { controller = "Games", action = "Get" },
                    result
                );
        }
    }
}
