using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public PlayerViewModel Player { get; set; }
        public PlayerViewModel Opponent { get; set; }
        public List<GameStageViewModel> Stages { get; set; }
    }
}
