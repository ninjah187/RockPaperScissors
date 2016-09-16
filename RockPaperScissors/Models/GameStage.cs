using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class GameStage
    {
        public int Id { get; set; }

        public Figure Player1Choice { get; set; }
        public Figure Player2Choice { get; set; }

        public virtual Game Game { get; set; }
    }
}
