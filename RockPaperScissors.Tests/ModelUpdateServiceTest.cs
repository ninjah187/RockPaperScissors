using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Tests
{
    public class ModelUpdateServiceTest
    {
        Mock<IAccessorsProvider> _accessorsProviderMock;
        ModelUpdateService _service;

        public ModelUpdateServiceTest()
        {
            _accessorsProviderMock = new Mock<IAccessorsProvider>();
            _service = new ModelUpdateService(_accessorsProviderMock.Object);
        }

        [Fact]
        public void Update_Successful()
        {
            var testReference = new TestEntity();
            var testReference2 = new TestEntity();

            var originalModel = new TestEntity
            {
                Id = 1,
                Int = 8,
                String = "test",
                Reference = testReference,
                Structure = DateTime.MinValue
            };

            var newModel = new TestEntity
            {
                Id = 2,
                Int = 16,
                String = "test test",
                Reference = testReference2,
                Structure = DateTime.MaxValue
            };

            var testEntityAccessorsMocks = GetAccessorsMocks(originalModel, newModel);
            var testEntityAccessors = testEntityAccessorsMocks.Select(m => m.Object).ToList();

            _accessorsProviderMock
                .Setup(m => m.GetAccessors(It.Is<Type>(t => t == typeof(TestEntity))))
                .Returns(testEntityAccessors);

            _service.Update(originalModel, newModel);

            _accessorsProviderMock.VerifyAll();
            foreach (var accessorMock in testEntityAccessorsMocks)
            {
                accessorMock.Verify();
            }

            Assert.Equal(newModel.Id, originalModel.Id);
            Assert.Equal(newModel.Int, originalModel.Int);
            Assert.Equal(newModel.String, originalModel.String);
            Assert.Equal(newModel.Reference, originalModel.Reference);
            Assert.Equal(newModel.Structure, originalModel.Structure);
        }

        IEnumerable<Mock<IAccessor>> GetAccessorsMocks(TestEntity originalModel, TestEntity newModel)
        {
            var idAccessorMock = new Mock<IAccessor>();
            idAccessorMock
                .SetupGet(m => m.Getter)
                .Returns(x => ((TestEntity) x).Id);
            idAccessorMock
                .SetupGet(m => m.Setter)
                .Returns((x, value) => ((TestEntity)x).Id = (int)value);
            yield return idAccessorMock;

            var intAccessorMock = new Mock<IAccessor>();
            intAccessorMock
                .SetupGet(m => m.Getter)
                .Returns(x => ((TestEntity)x).Int);
            intAccessorMock
                .SetupGet(m => m.Setter)
                .Returns((x, value) => ((TestEntity)x).Int = (int)value);

            yield return intAccessorMock;

            var stringAccessorMock = new Mock<IAccessor>();
            stringAccessorMock
                .SetupGet(m => m.Getter)
                .Returns(x => ((TestEntity)x).String);
            stringAccessorMock
                .SetupGet(m => m.Setter)
                .Returns((x, value) => ((TestEntity)x).String = (string)value);

            yield return stringAccessorMock;

            var referenceAccessorMock = new Mock<IAccessor>();
            referenceAccessorMock
                .SetupGet(m => m.Getter)
                .Returns(x => ((TestEntity)x).Reference);
            referenceAccessorMock
                .SetupGet(m => m.Setter)
                .Returns((x, value) => ((TestEntity)x).Reference = (TestEntity)value);

            yield return referenceAccessorMock;

            var valueAccessorMock = new Mock<IAccessor>();
            valueAccessorMock
                .SetupGet(m => m.Getter)
                .Returns(x => ((TestEntity)x).Structure);
            valueAccessorMock
                .SetupGet(m => m.Setter)
                .Returns((x, value) => ((TestEntity)x).Structure = (DateTime)value);

            yield return valueAccessorMock;
        }
    }
}
