using System;
using System.Reflection.Emit;

namespace Compiler.Symbols
{
    public class LocalVariableSymbol : VariableSymbol
    {
        public LocalVariableSymbol(Name name)
            : base(name)
        {

        }

        public virtual LocalBuilder NetBuilder { get; set; }

        public override string ToString()
        {
            return String.Format("<<LocalVariable>> [{0}] {1}", Type.Name, Name);
        }
    }
}
