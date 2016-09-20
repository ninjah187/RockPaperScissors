using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Tests
{
    public class TestEntity : IModelEntity
    {
        public int Id { get; set; }

        public string String { get; set; }
        public int Int { get; set; }
        public TestEntity Reference { get; set; }
        public DateTime Structure { get; set; }
    }
}
