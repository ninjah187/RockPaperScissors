using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Xunit;
using Moq;

namespace RockPaperScissors.Tests
{
    public class ReadAccessorTest
    {
        [Fact]
        public void Getter_ReadsInt_Successful()
            => Getter_Reads_Successful<int>(nameof(TestEntity.Int));

        [Fact]
        public void Getter_ReadsReference_Successful()
            => Getter_Reads_Successful<TestEntity>(nameof(TestEntity.Reference));

        [Fact]
        public void Getter_ReadsString_Successful()
            => Getter_Reads_Successful<string>(nameof(TestEntity.String));

        [Fact]
        public void Getter_ReadsStructure_Successful()
            => Getter_Reads_Successful<DateTime>(nameof(TestEntity.Structure));

        public void Getter_Reads_Successful<TProperty>(string propertyName)
        {
            var reference = new TestEntity();
            var value = DateTime.MaxValue;
            var entity = new TestEntity
            {
                Int = 7,
                Reference = reference,
                String = "string",
                Structure = value
            };
            var property = entity.GetType().GetProperty(propertyName);

            var readAccessor = new ReadAccessor<TestEntity, TProperty>(property.GetGetMethod());

            var read = readAccessor.Getter(entity);

            Assert.Equal(property.GetValue(entity), read);
        }
    }
}
