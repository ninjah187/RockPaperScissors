using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IAccessor
    {
        Func<object, object> Getter { get; }
        Action<object, object> Setter { get; }
    }

    public interface IAccessor<TType, TProperty> : IAccessor
    {
        new Func<TType, TProperty> Getter { get; }
        new Action<TType, TProperty> Setter { get; }
    }
}
