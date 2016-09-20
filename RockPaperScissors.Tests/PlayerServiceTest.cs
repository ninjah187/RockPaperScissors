using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Tests
{
    public class PlayerServiceTest : IDisposable
    {
        AppDbContext _dbContext;
        PlayerService _service;

        public PlayerServiceTest()
        {
            _dbContext = new AppDbContext(new DbContextOptionsBuilder()
                                                .UseInMemoryDatabase()
                                                .Options);
            _service = new PlayerService(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Players.RemoveRange(_dbContext.Players.ToList());
            _dbContext.SaveChanges();

            _dbContext.Dispose();
        }

        [Fact]
        public async Task GetAll_ThereAreNoPlayers_ReturnsEmptyCollection()
        {
            var players = await _service.GetAllAsync();

            Assert.Empty(players);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public async Task GetAll_ThereArePlayers_ReturnsCollection(int playersCount)
        {
            var inputPlayers = new List<Player>();
            for (int i = 0; i < playersCount; i++)
            {
                inputPlayers.Add(new Player());
            }
            _dbContext.Players.AddRange(inputPlayers);
            await _dbContext.SaveChangesAsync();

            var players = await _service.GetAllAsync();
            
            Assert.Equal(playersCount, players.Count());
            foreach (var player in inputPlayers)
            {
                Assert.True(players.Contains(player));
            }
        }

        [Fact]
        public async Task Get_ThereIsNoSuchPlayer_ReturnsNull()
        {
            var player = await _service.GetAsync(-1);

            Assert.Null(player);
        }

        [Fact]
        public async Task Get_ThereIsSuchPlayer_ReturnsPlayer()
        {
            var player = new Player();
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();

            var result = await _service.GetAsync(player.Id);

            Assert.Equal(player, result);
        }
    }
}
