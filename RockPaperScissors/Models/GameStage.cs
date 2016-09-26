using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class GameStage : IModelEntity
    {
        public int Id { get; set; }

        public Shape Player1Choice { get; set; }
        public Shape Player2Choice { get; set; }

        public virtual Game Game { get; set; }
    }
}
