using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Xunit;
using Moq;

namespace RockPaperScissors.Tests
{
    public class AccessorTest
    {
        static readonly Random _random = new Random();

        TestEntity _entity;

        public AccessorTest()
        {
            _entity = new TestEntity();
        }

        [Fact]
        public void SimpleTypeAccessor_Initialize_Successful()
        {
            var testedProperty = "Int";
            var getMethod = _entity.GetType().GetProperty(testedProperty).GetGetMethod();
            var setMethod = _entity.GetType().GetProperty(testedProperty).GetSetMethod();

            var accessor = new Accessor<TestEntity, int>(getMethod, setMethod);

            Assert.NotNull(accessor);
        }
    }
}
