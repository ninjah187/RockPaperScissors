using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using RockPaperScissors.Tests;

namespace RockPaperScissors.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var propName = "Int";
            var entity = new TestEntity();
            var getMethod = entity.GetType().GetProperty(propName).GetGetMethod();
            var setMethod = entity.GetType().GetProperty(propName).GetSetMethod();

            var a = new Accessor<TestEntity, int>(getMethod, setMethod);
            var accessor = (Accessor) a;
            //var accessor = new Accessor(entity.GetType(), entity.GetType().GetProperty(propName));

            //new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(5);

            //new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(10000);

            //new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(100000);

            //new ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache().Run(500000);

            //accessor.Setter(entity, 100);

            //Console.WriteLine(accessor.Getter(entity));

            new AccessorWithBoxing_vs_AccessorWithoutBoxing().Run(1000);

            new AccessorWithBoxing_vs_AccessorWithoutBoxing().Run(10000);

            new AccessorWithBoxing_vs_AccessorWithoutBoxing().Run(100000);

            new AccessorWithBoxing_vs_AccessorWithoutBoxing().Run(500000);

            Console.ReadKey();
        }
    }
}
