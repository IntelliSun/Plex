using System;
using System.Text;

namespace IntelliSun.Plex
{
    public class ExtendedType
    {
        private const string PluralSymbol = "[]";
        private const string OneOrManySymbol = "[+]";

        private readonly Type clrType;
        private readonly Plurality plurality;

        private readonly Lazy<Type> viewType;

        public ExtendedType(Type clrType)
            : this(clrType, Plurality.Singular)
        {

        }

        public ExtendedType(Type clrType, Plurality plurality)
        {
            if (clrType == null)
                throw new ArgumentNullException("clrType");

            this.clrType = clrType;
            this.plurality = plurality;

            this.viewType = new Lazy<Type>(this.InitializeViewType);
        }

        private Type InitializeViewType()
        {
            return CreateViewType(this.clrType, this.plurality);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var symbol = !this.IsPlural
                ? String.Empty
                : this.plurality == Plurality.Plural
                    ? PluralSymbol
                    : OneOrManySymbol;

            var builder = new StringBuilder(this.clrType.ToString());
            builder.Append(symbol);

            return builder.ToString();
        }

        private static Type CreateViewType(Type type, Plurality plurality)
        {
            return plurality != Plurality.Singular ? type.MakeArrayType() : type;
        }

        public Type ClrType
        {
            get { return this.clrType; }
        }

        public Plurality Plurality
        {
            get { return this.plurality; }
        }

        public Type ViewType
        {
            get { return this.viewType.Value; }
        }

        public bool IsPlural
        {
            get { return this.plurality != Plurality.Singular; }
        }
    }
}
