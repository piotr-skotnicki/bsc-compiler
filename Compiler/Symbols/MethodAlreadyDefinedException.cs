using System;

namespace Compiler.Symbols
{
    public class MethodAlreadyDefinedException : ApplicationException
    {
        public readonly Name Name;

        public MethodAlreadyDefinedException(Name name)
        {
            this.Name = name;
        }
    }
}
