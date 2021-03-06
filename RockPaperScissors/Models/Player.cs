﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class Player : IModelEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string AccessCode { get; set; }

        public virtual Game Game { get; set; }
    }
}