using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class Game : IModelEntity
    {
        public int Id { get; set; }
        
        public string Token { get; set; }

        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }

        public virtual ICollection<GameStage> Stages { get; set; }

        public virtual Player Winner { get; set; }
    }
}
