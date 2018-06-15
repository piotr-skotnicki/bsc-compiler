using System.Text;

namespace Compiler.Symbols
{
    public struct AccessModifier
    {
        public const int PUBLIC = 0x01;
        public const int FAMILY = 0x02;
        public const int PRIVATE = 0x04;
        public const int ASSEMBLY = 0x08;
        public const int FAMORASSEM = AccessModifier.FAMILY | AccessModifier.ASSEMBLY;
        public const int FAMANDASSEM = 0x20;
        public const int ALL = 0xff;

        private int Flags { get; set; }

        private AccessModifier(int i)
            : this()
        {
            Flags = i;
        }

        public static implicit operator AccessModifier(int i)
        {
            AccessModifier am = new AccessModifier(i);
            return am;
        }

        public static explicit operator int(AccessModifier am)
        {
            return am.Flags;
        }

        private bool IsSet(AccessModifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        public bool IsEmpty
        {
            get { return (Flags & AccessModifier.ALL) == 0; }
        }

        private bool Intersects(AccessModifier am)
        {
            return (Flags & am.Flags) > 0;
        }

        public void Add(AccessModifier am)
        {
            Flags |= am.Flags;
        }

        public void Remove(AccessModifier am)
        {
            Flags &= ~am.Flags;
        }

        public static AccessModifier operator |(AccessModifier left, AccessModifier right)
        {
            AccessModifier result = 0;
            result.Add(left);
            result.Add(right);
            return result;
        }

        public bool AccessFrom(AccessModifier am)
        {
            return am.AccessTo(this);
        }

        public bool AccessTo(AccessModifier am)
        {
            return Intersects(am);
        }

        public bool IsPublic
        {
            get { return IsSet(AccessModifier.PUBLIC); }
        }

        public bool IsFamily
        {
            get { return IsSet(AccessModifier.FAMILY); }
        }

        public bool IsPrivate
        {
            get { return IsSet(AccessModifier.PRIVATE); }
        }

        public bool IsAssembly
        {
            get { return IsSet(AccessModifier.ASSEMBLY); }
        }

        public bool IsFamOrAssem
        {
            get { return IsSet(AccessModifier.FAMORASSEM); }
        }

        public bool IsFamAndAssem
        {
            get { return IsSet(AccessModifier.FAMANDASSEM); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<AccessSpecifier>> { ");
            if (IsPublic)
            {
                sb.Append("Public, ");
            }
            if (IsFamily)
            {
                sb.Append("Family, ");
            }
            if (IsPrivate)
            {
                sb.Append("Private, ");
            }
            if (IsAssembly)
            {
                sb.Append("Assembly, ");
            }
            if (IsFamOrAssem)
            {
                sb.Append("FamOrAssem, ");
            }
            if (IsFamAndAssem)
            {
                sb.Append("FamAndAssem, ");
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
