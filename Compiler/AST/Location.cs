using System;

namespace Compiler.AST
{
    public struct Location
    {
        public readonly int Line;

        public readonly int Char;

        public Location(int line, int ch)
        {
            Line = line;
            Char = ch;
        }

        public static bool operator ==(Location a, Location b)
        {
            if (a.Line == b.Line && a.Char == b.Char)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Location a, Location b)
        {
            return !(a == b);
        }

        public static bool operator <(Location a, Location b)
        {
            if (a.Line == b.Line)
                return a.Char < b.Char;
            return a.Line < b.Line;
        }

        public static bool operator >(Location a, Location b)
        {
            if (a.Line == b.Line)
                return a.Char > b.Char;
            return a.Line > b.Line;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }
            return this == (Location)obj;
        }

        public bool Equals(Location obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return this.Char;
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}", Line, Char);
        }
    }
}
