using System.Text;

namespace Compiler.Symbols
{
    public struct MethodSpecifier
    {
        public const byte FINAL = 0x01;
        public const byte ABSTRACT = 0x02;
        public const byte NEW = 0x04;
        public const byte VIRTUAL = 0x08;
        public const byte STATIC = 0x10;
        public const byte CONSTRUCTOR = 0x20;

        public const byte RUNTIME_MANAGED = 0x40;

        private byte Flags { get; set; }

        private MethodSpecifier(byte i)
            : this()
        {
            Flags = i;
        }

        public static implicit operator MethodSpecifier(byte i)
        {
            MethodSpecifier am = new MethodSpecifier(i);
            return am;
        }

        public static explicit operator int(MethodSpecifier am)
        {
            return am.Flags;
        }

        public bool IsSet(MethodSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        private bool Intersects(MethodSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        public void Add(MethodSpecifier am)
        {
            Flags |= am.Flags;
        }

        public void Remove(MethodSpecifier am)
        {
            Flags &= (byte)~am.Flags;
        }

        public static MethodSpecifier operator |(MethodSpecifier left, MethodSpecifier right)
        {
            MethodSpecifier result = 0;
            result.Add(left);
            result.Add(right);
            return result;
        }

        public bool IsFinal
        {
            get { return IsSet(MethodSpecifier.FINAL); }
        }

        public bool IsAbstract
        {
            get { return IsSet(MethodSpecifier.ABSTRACT); }
        }

        public bool IsNew
        {
            get { return IsSet(MethodSpecifier.NEW); }
        }

        public bool IsVirtual
        {
            get { return IsSet(MethodSpecifier.VIRTUAL); }
        }

        public bool IsStatic
        {
            get { return IsSet(MethodSpecifier.STATIC); }
        }

        public bool IsConstructor
        {
            get { return IsSet(MethodSpecifier.CONSTRUCTOR); }
        }

        public bool IsRuntimeManaged
        {
            get { return IsSet(MethodSpecifier.RUNTIME_MANAGED); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<MethodSpecifier>> { ");
            if (IsFinal)
                sb.Append("Final, ");
            if (IsAbstract)
                sb.Append("Abstract, ");
            if (IsNew)
                sb.Append("New, ");
            if (IsVirtual)
                sb.Append("Virtual, ");
            if (IsStatic)
                sb.Append("Static, ");
            if (IsConstructor)
                sb.Append("Constructor, ");
            if (IsRuntimeManaged)
                sb.Append("RuntimeManaged, ");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
