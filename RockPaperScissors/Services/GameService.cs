using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class GameService : IGameService
    {
        IGamesRepository _games;
        IAccessCodeGenerator _accessCodeGenerator;

        public GameService(IGamesRepository games, IAccessCodeGenerator accessCodeGenerator)
        {
            _games = games;
            _accessCodeGenerator = accessCodeGenerator;
        }

        public async Task<Game> CreateNewGameAsync(string playerName, Shape chosenShape)
        {
            var firstPlayer = new Player
            {
                Name = playerName,
                AccessCode = _accessCodeGenerator.GetAccessCode()
            };

            var secondAccessCode = firstPlayer.AccessCode;
            while (secondAccessCode == firstPlayer.AccessCode)
            {
                secondAccessCode = _accessCodeGenerator.GetAccessCode();
            }

            var secondPlayer = new Player
            {
                AccessCode = secondAccessCode
            };

            var game = new Game
            {
                Player1 = firstPlayer,
                Player2 = secondPlayer
            };

            var firstStage = new GameStage
            {
                Player1Choice = chosenShape,
                Player2Choice = Shape.None
            };

            var gameStages = new List<GameStage> { firstStage };

            game.Stages = gameStages;

            await _games.CreateAsync(game);
            await _games.CommitAsync();

            return game;
        }

        public Task<Game> CreateNewGameAsync(NewGameData newGame)
            => CreateNewGameAsync(newGame.PlayerName, newGame.ChosenShape);
    }
}
