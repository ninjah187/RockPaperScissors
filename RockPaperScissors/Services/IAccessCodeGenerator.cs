using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public interface IAccessCodeGenerator
    {
        string GetAccessCode();
    }
}
