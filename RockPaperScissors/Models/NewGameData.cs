using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class NewGameData
    {
        public string PlayerName { get; set; }
        public Shape ChosenShape { get; set; }
    }
}
