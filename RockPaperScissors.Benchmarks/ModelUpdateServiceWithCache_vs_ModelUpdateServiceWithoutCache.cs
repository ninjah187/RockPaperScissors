using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using RockPaperScissors.Services;
using RockPaperScissors.Tests;

namespace RockPaperScissors.Benchmarks
{
    public class ModelUpdateServiceWithCache_vs_ModelUpdateServiceWithoutCache
    {
        static readonly Random _random = new Random();

        List<Tuple<TestEntity, TestEntity>> _testDataSet = new List<Tuple<TestEntity, TestEntity>>();

        ModelUpdateService _withCache = new ModelUpdateService();
        ModelUpdateServiceWithoutCache _withoutCache = new ModelUpdateServiceWithoutCache();

        public void Run(int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                _testDataSet.Add(new Tuple<TestEntity, TestEntity>(GetRandomTestEntity(), GetRandomTestEntity()));
            }

            var stopwatch = new Stopwatch();

            Console.WriteLine($"> {nameof(ModelUpdateService)} vs {nameof(ModelUpdateServiceWithoutCache)}");
            Console.WriteLine($"> \trepetitions: {repetitions}");
            Console.WriteLine($"> ");
            Console.WriteLine($"> \t{nameof(ModelUpdateService)} (with cache):");

            stopwatch.Start();
            foreach (var data in _testDataSet)
            {
                _withCache.Update(data.Item1, data.Item2);
            }
            stopwatch.Stop();

            Console.WriteLine($"> \tresult: {stopwatch.Elapsed}");
            Console.WriteLine($"> ");

            stopwatch.Reset();
            _testDataSet.Clear();

            for (int i = 0; i < repetitions; i++)
            {
                _testDataSet.Add(new Tuple<TestEntity, TestEntity>(GetRandomTestEntity(), GetRandomTestEntity()));
            }

            Console.WriteLine($"> \t{nameof(ModelUpdateServiceWithoutCache)} (without cache):");

            stopwatch.Start();
            foreach (var data in _testDataSet)
            {
                _withoutCache.Update(data.Item1, data.Item2);
            }
            stopwatch.Stop();
            Console.WriteLine($"> \tresult: {stopwatch.Elapsed}");
            Console.WriteLine($"> ------");
        }

        TestEntity GetRandomTestEntity()
        {
            return new TestEntity
            {
                Id = _random.Next(),
                Int = _random.Next(),
                Reference = new TestEntity(),
                String = _random.Next().ToString(),
                Structure = new DateTime(_random.Next())
            };
        }
    }
}
