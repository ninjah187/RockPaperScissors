using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public interface IGameService
    {
        Task<Game> CreateNewGameAsync(string playerName, Shape chosenShape);
        Task<Game> CreateNewGameAsync(NewGameData newGame);
    }
}
