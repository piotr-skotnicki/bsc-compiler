using System;

namespace Compiler.Symbols
{
    public class SymbolAlreadyDefinedException : ApplicationException
    {
        public readonly Name Name;

        public SymbolAlreadyDefinedException(Name name)
        {
            this.Name = name;
        }
    }
}
