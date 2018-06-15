using System;
using System.Reflection.Emit;

namespace Compiler.Symbols
{
    public class LabelSymbol : Symbol
    {
        public LabelSymbol(Name name)
            : base(name)
        {

        }

        public virtual Label NetLabel { get; set; }

        public override string ToString()
        {
            return String.Format("<<Label>> {0}", Name);
        }
    }
}
