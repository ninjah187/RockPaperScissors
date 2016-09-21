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
    public abstract class ModelUpdateServiceTest
    {
        //Mock<IAccessorsProvider>
        ModelUpdateService _service;

        public ModelUpdateServiceTest()
        {
            //_service = new ModelUpdateService();
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

            _service.Update(originalModel, newModel);

            Assert.Equal(newModel.Id, originalModel.Id);
            Assert.Equal(newModel.Int, originalModel.Int);
            Assert.Equal(newModel.String, originalModel.String);
            Assert.Equal(newModel.Reference, originalModel.Reference);
            Assert.Equal(newModel.Structure, originalModel.Structure);
        }
    }
}
