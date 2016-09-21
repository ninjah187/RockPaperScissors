using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IAccessorsProvider
    {
        IEnumerable<IAccessor> GetAccessors<T>(T item);
    }
}
