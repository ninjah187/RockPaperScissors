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
        public DbSet<Player> Players { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
