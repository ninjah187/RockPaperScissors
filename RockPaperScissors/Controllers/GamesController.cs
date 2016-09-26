using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RockPaperScissors.Services;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    public class GamesController : ApiBaseController<Game>
    {
        public GamesController(IRepository<Game> repository)
            : base(repository)
        {
        }
    }
}
