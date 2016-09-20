using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using RockPaperScissors.Services;
using RockPaperScissors.Tests;

namespace RockPaperScissors.Benchmarks
{
    public class ModelUpdateServiceWithoutCache : IModelUpdateService<TestEntity>
    {
        public void Update(TestEntity originalItem, TestEntity newItem)
        {
            foreach (var property in newItem.GetType().GetProperties())
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                property.SetValue(originalItem, property.GetValue(newItem));
            }
        }
    }
}
