using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public class AccessCodeGenerator : IAccessCodeGenerator
    {
        static readonly Random _random = new Random();

        public string GetAccessCode()
        {
            var code = _random.Next(100, 1000);

            return code.ToString();
        }
    }
}
