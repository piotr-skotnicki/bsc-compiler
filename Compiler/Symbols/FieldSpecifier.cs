using System.Text;

namespace Compiler.Symbols
{
    public struct FieldSpecifier
    {
        public const byte STATIC = 0x01;
        public const byte READONLY = 0x02;

        private byte Flags { get; set; }

        private FieldSpecifier(byte i)
            : this()
        {
            Flags = i;
        }

        public static implicit operator FieldSpecifier(byte i)
        {
            FieldSpecifier am = new FieldSpecifier(i);
            return am;
        }

        public static explicit operator int(FieldSpecifier am)
        {
            return am.Flags;
        }

        public bool IsSet(FieldSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        private bool Intersects(FieldSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        public void Add(FieldSpecifier am)
        {
            Flags |= am.Flags;
        }

        public void Remove(FieldSpecifier am)
        {
            Flags &= (byte)~am.Flags;
        }

        public static FieldSpecifier operator |(FieldSpecifier left, FieldSpecifier right)
        {
            FieldSpecifier result = 0;
            result.Add(left);
            result.Add(right);
            return result;
        }

        public bool IsStatic
        {
            get { return IsSet(FieldSpecifier.STATIC); }
        }

        public bool IsReadonly
        {
            get { return IsSet(FieldSpecifier.READONLY); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<FieldSpecifier>> { ");
            if (IsStatic)
            {
                sb.Append("Static, ");
            }
            if (IsReadonly)
            {
                sb.Append("Readonly, ");
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
