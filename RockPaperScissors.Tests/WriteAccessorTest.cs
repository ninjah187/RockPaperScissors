using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Xunit;
using Moq;

namespace RockPaperScissors.Tests
{
    public class WriteAccessorTest
    {
        [Fact]
        public void Setter_WritesInt_Successful()
            => Setter_Writes_Successful<int>(nameof(TestEntity.Int));

        [Fact]
        public void Setter_WritesReference_Successful()
            => Setter_Writes_Successful<TestEntity>(nameof(TestEntity.Reference));

        [Fact]
        public void Setter_WritesString_Successful()
            => Setter_Writes_Successful<string>(nameof(TestEntity.String));

        [Fact]
        public void Setter_WritesStructure_Successful()
            => Setter_Writes_Successful<DateTime>(nameof(TestEntity.Structure));

        public void Setter_Writes_Successful<TProperty>(string propertyName)
        {
            var reference = new TestEntity();
            var value = DateTime.MaxValue;
            var testData = new TestEntity
            {
                Int = 7,
                Reference = reference,
                String = "string",
                Structure = value
            };
            var entity = new TestEntity();
            var property = entity.GetType().GetProperty(propertyName);

            var writeAccessor = new WriteAccessor<TestEntity, TProperty>(property.GetSetMethod());

            writeAccessor.Setter(entity, (TProperty) property.GetValue(testData));

            Assert.Equal(property.GetValue(testData), property.GetValue(entity));
        }
    }
}
