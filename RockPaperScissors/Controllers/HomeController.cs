using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissors.Controllers
{
    public class HomeController
    {
        public IActionResult Index()
        {
            return new ObjectResult("Hello world");
        }
    }
}
