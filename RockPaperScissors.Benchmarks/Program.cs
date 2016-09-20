using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(1000);

            new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(10000);

            new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(100000);

            new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(500000);

            Console.ReadKey();
        }
    }
}
