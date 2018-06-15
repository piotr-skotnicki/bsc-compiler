using System;

namespace Compiler.Symbols
{
    public abstract class VariableSymbol : Symbol
    {
        public VariableSymbol(Name name)
            : base(name)
        {

        }

        public override string ToString()
        {
            return String.Format("<<Variable>> [{0}] {1}", Type.Name, Name);
        }
    }
}
