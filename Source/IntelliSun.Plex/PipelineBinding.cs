using System;

namespace IntelliSun.Plex
{
    public class PipelineBinding
    {
        private readonly bool byValue;
        private readonly Type targetType;

        private readonly string[] nameBinding;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        private PipelineBinding(bool byValue, Type targetType, string[] nameBinding)
        {
            this.byValue = byValue;
            this.targetType = targetType;
            this.nameBinding = nameBinding;
        }

        public static PipelineBinding ByValue<T>()
        {
            return ByValue(typeof(T));
        }

        public static PipelineBinding ByValue(Type targetType)
        {
            return New(targetType, true, null);
        }

        public static PipelineBinding ByName<T>(params string[] bindings)
        {
            return ByName(typeof(T), bindings);
        }

        public static PipelineBinding ByName(Type targetType, params string[] bindings)
        {
            return New(targetType, false, bindings);
        }

        public static PipelineBinding New<T>(bool byValue, params string[] bindings)
        {
            return New(typeof(T), byValue, bindings);
        }

        public static PipelineBinding New(Type targetType, bool byValue, params string[] bindings)
        {
            return new PipelineBinding(byValue, targetType, bindings ?? new string[0]);
        }

        public bool IsByValue
        {
            get { return this.byValue; }
        }

        public Type TargetType
        {
            get { return this.targetType; }
        }

        public string[] NameBindings
        {
            get { return this.nameBinding; }
        }

        public bool IsByName
        {
            get { return this.nameBinding.Length != 0; }
        }
    }
}