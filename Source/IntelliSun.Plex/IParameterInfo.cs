using System;

namespace IntelliSun.Plex
{
    public interface IParameterInfo
    {
        string Name { get; }
        string[] Aliases { get; }
        ExtendedType ValueType { get; }

        bool IsDynamic { get; }
        bool IsFlag { get; }

        IParameterAnnotation[] Annotations { get; }
    }
}