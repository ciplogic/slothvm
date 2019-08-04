using System;

namespace SlothVm.JvmData
{
    [Flags]
    public enum AccessMode
    {
        Public = 1 << 1,
        Private = 1 << 2,
        Protected = 1 << 3,
        Package = 1 << 4,
        Final = 1 << 5,
        Static = 1 << 6,

    }
}