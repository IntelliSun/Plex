using System;

namespace IntelliSun.Plex
{
    public interface IParameterMetadata : IParameterInfo
    {
        bool IsMandatory { get; }

        ParameterPosition Position { get; }
        PipelineBinding PipelineBinding { get; }

        ParameterFlags Flags { get; }
    }
}