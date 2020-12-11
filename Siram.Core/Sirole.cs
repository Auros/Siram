using System;

namespace Siram.Core
{
    [Flags]
    public enum Sirole
    {
        None = 0,
        Competitor = 1,
        Coordinator = 2,
        Admin = 4
    }
}