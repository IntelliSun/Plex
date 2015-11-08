using System;

namespace IntelliSun.Plex
{
    public struct ParameterPosition
    {
        private readonly uint position;
        private readonly bool isPositional;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        private ParameterPosition(uint position, bool isPositional)
        {
            this.position = position;
            this.isPositional = isPositional;
        }

        public static ParameterPosition Positional(uint position)
        {
            if (position == 0)
                throw new ArgumentException("${Resources.ParameterPositionZero}", "position");

            return new ParameterPosition(position, true);
        }

        public static ParameterPosition Named()
        {
            return new ParameterPosition(0, false);
        }

        public uint Position
        {
            get { return this.isPositional ? this.position : 0; }
        }

        public bool IsPositional
        {
            get { return this.isPositional; }
        }
    }
}