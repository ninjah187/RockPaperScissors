using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockPaperScissors.Models;

namespace RockPaperScissors
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStage> Stages { get; set; }
        public DbSet<Player> Players { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasOne(g => g.Player1);
            modelBuilder.Entity<Game>().HasOne(g => g.Player2);
            modelBuilder.Entity<Game>().HasOne(g => g.Winner);

            modelBuilder.Entity<Player>().HasOne(p => p.Game);
        }
    }
}
