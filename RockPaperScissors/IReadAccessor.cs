using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IReadAccessor
    {
        Func<object, object> Getter { get; }
    }

    public interface IReadAccessor<TType, TProperty> : IReadAccessor
    {
        new Func<TType, TProperty> Getter { get; }
    }
}
