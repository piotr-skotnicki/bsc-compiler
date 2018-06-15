using System;

namespace Compiler.Symbols
{
    public class MemberNameSameAsTypesException : ApplicationException
    {
        public readonly Name Name;

        public MemberNameSameAsTypesException(Name name)
        {
            this.Name = name;
        }
    }
}
