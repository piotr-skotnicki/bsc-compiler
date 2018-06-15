using System.Text;

namespace Compiler.Symbols
{
    public struct ClassSpecifier
    {
        public const byte FINAL = 0x01;
        public const byte ABSTRACT = 0x02;

        private byte Flags { get; set; }

        private ClassSpecifier(byte i)
            : this()
        {
            Flags = i;
        }

        public static implicit operator ClassSpecifier(byte i)
        {
            ClassSpecifier am = new ClassSpecifier(i);
            return am;
        }

        public static explicit operator int(ClassSpecifier am)
        {
            return am.Flags;
        }

        public bool IsSet(ClassSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        private bool Intersects(ClassSpecifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        public void Add(ClassSpecifier am)
        {
            Flags |= am.Flags;
        }

        public void Remove(ClassSpecifier am)
        {
            Flags &= (byte)~am.Flags;
        }

        public static ClassSpecifier operator |(ClassSpecifier left, ClassSpecifier right)
        {
            ClassSpecifier result = 0;
            result.Add(left);
            result.Add(right);
            return result;
        }

        public bool IsFinal
        {
            get { return IsSet(ClassSpecifier.FINAL); }
        }

        public bool IsAbstract
        {
            get { return IsSet(ClassSpecifier.ABSTRACT); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<ClassSpecifier>> { ");
            if (IsFinal)
            {
                sb.Append("Final, ");
            }
            if (IsAbstract)
            {
                sb.Append("Abstract, ");
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
