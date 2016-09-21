using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IWriteAccessor
    {
        Action<object, object> Setter { get; }
    }

    public interface IWriteAccessor<TType, TProperty> : IWriteAccessor
    {
        new Action<TType, TProperty> Setter { get; }
    }
}
