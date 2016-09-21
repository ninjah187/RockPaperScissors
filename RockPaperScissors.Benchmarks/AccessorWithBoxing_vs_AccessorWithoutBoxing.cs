using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using RockPaperScissors.Tests;

namespace RockPaperScissors.Benchmarks
{
    public class AccessorWithBoxing_vs_AccessorWithoutBoxing
    {
        static readonly Random _random = new Random();

        //List<Tuple<TestEntity, TestEntity>> _testDataSet = new List<Tuple<TestEntity, TestEntity>>();

        TestEntity _testEntity;
        string _testPropertyName;
        Accessor<TestEntity, int> _withoutBoxing;
        Accessor _withBoxing;

        public void Initialize()
        {
            _testEntity = new TestEntity();

            _testPropertyName = "Int";

            var property = _testEntity.GetType().GetProperty(_testPropertyName);

            _withoutBoxing = new Accessor<TestEntity, int>(property.GetGetMethod(), property.GetSetMethod());
            _withBoxing = _withoutBoxing;
        }

        public void Run(int repetitions)
        {
            Initialize();

            Console.WriteLine($"> {nameof(Accessor<TestEntity, int>)} vs {nameof(Accessor)}");
            Console.WriteLine($"> \trepetitions: {repetitions}");
            Console.WriteLine($"> ");
            Console.WriteLine($"> \t{nameof(Accessor<TestEntity, int>)} (without boxing):");

            var testDataSet = new int[repetitions];

            for (int i = 0; i < testDataSet.Length; i++)
            {
                testDataSet[i] = _random.Next();
            }

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < testDataSet.Length; i++)
            {
                _withoutBoxing.Setter(_testEntity, testDataSet[i]);
            }
            stopwatch.Stop();

            Console.WriteLine($"> \tresult: {stopwatch.Elapsed}");
            Console.WriteLine($"> ");

            stopwatch.Reset();

            Console.WriteLine($"> \t{nameof(Accessor)} (with boxing):");

            stopwatch.Start();
            for (int i = 0; i < testDataSet.Length; i++)
            {
                _withBoxing.Setter(_testEntity, testDataSet[i]);
            }
            stopwatch.Stop();

            Console.WriteLine($"> \tresult: {stopwatch.Elapsed}");
            Console.WriteLine($"> ");
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
