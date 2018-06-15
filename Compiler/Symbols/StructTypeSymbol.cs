using System.Text;

namespace Compiler.Symbols
{
    public class StructTypeSymbol : ValueTypeSymbol
    {
        public StructTypeSymbol(Name name)
            : base(name)
        {
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Struct>> {0} {{\n", Name);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
