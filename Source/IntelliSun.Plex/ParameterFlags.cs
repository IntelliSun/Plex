using System;

namespace IntelliSun.Plex
{
    [Flags]
    public enum ParameterFlags
    {
        None = 0,
        Mandatory = 1,
        ValueFromPipline = 2,
        ValueByValue = 4,
        ValueByName = 8,
        Positional = 16
    }
}