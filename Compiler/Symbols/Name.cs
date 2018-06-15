using System;

namespace Compiler.Symbols
{
    public struct Name
    {
        public const char NOT_A_KEYWORD_PREFIX = '$';

        public string Value { get; private set; }

        public static implicit operator Name(string name)
        {
            Name n = new Name();

            if (name == null)
            {
                n.Value = null;
                return n;
            }

            name = name.Trim();

            if (name.StartsWith(Name.NOT_A_KEYWORD_PREFIX.ToString()))
            {
                name = name.Substring(1);
            }

            n.Value = name;
            return n;
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        public static bool operator ==(Name a, Name b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Value == b.Value;
        }

        public static bool operator !=(Name left, Name right)
        {
            return !(left == right);
        }        

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
            {
                return false;
            }

            Name name = (Name)obj;
            if (Object.ReferenceEquals(name, null))
            {
                return false;
            }
            return this == name;
        }

        public bool Equals(Name obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            if (Object.ReferenceEquals(Value, null))
            {
                return 0;
            }
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            if (Value == null)
            {
                return "__noname__";
            }
            return Value.ToString();
        }

        public Name[] Split(char separator)
        {
            string[] st = Value.Split(separator);
            int size = st.Length;
            Name[] names = new Name[size];
            for (int i = 0; i < size; ++i)
            {
                names[i] = st[i];
            }
            return names;
        }
    }
}
