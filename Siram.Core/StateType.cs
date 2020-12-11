using System;

namespace Siram.Core
{
    [Flags]
    public enum StateType
    {
        None = 0,
        Hit = 1,
        Miss = 2,
        BadCut = 4
    }
}