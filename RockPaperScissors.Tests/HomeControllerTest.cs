using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Controllers;

namespace RockPaperScissors.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void HomeController_Index_ReturnsView()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}
