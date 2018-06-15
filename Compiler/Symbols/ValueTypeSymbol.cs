using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class ValueTypeSymbol : ObjectTypeSymbol
    {
        public ValueTypeSymbol(Name name)
            : base(name)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<ValueType>> {0} {{\n", Name);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
