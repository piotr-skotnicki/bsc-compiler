using System;
using System.Text;

namespace Compiler.Symbols
{
    public struct LookupFlags
    {
        public const byte LOCAL = 0x01;
        public const byte GLOBAL = 0x02;
        public const byte FLAT = 0x04;

        private byte Flags { get; set; }

        private LookupFlags(byte i)
            : this()
        {
            Flags = i;
        }

        public static implicit operator LookupFlags(byte i)
        {
            LookupFlags lf = new LookupFlags(i);
            return lf;
        }

        public static explicit operator int(LookupFlags lf)
        {
            return lf.Flags;
        }

        private bool IsSet(LookupFlags lf)
        {
            return (Flags & lf.Flags) > 0;
        }

        public bool IsLocal
        {
            get { return IsSet(LookupFlags.LOCAL); }
        }

        public bool IsGlobal
        {
            get { return IsSet(LookupFlags.GLOBAL); }
        }

        public bool IsFlat
        {
            get { return IsSet(LookupFlags.FLAT); }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<LookupFlags>> { ");
            if (IsLocal)
            {
                sb.Append("Local, ");
            }
            if (IsGlobal)
            {
                sb.Append("Global, ");
            }
            if (IsFlat)
            {
                sb.Append("Flat, ");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
