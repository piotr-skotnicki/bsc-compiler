using System.Text;

namespace Compiler.Symbols
{
    public class EnumTypeSymbol : ValueTypeSymbol
    {
        public const string DEFAULT_FIELD = "value__";

        public IType ContentType { get; set; }

        public EnumTypeSymbol(Name name)
            : base(name)
        {

        }

        public override void Define(Symbol symbol)
        {
            if (this.SymbolTable.ContainsKey(symbol.Name))
            {
                throw new SymbolAlreadyDefinedException(symbol.Name);
            }
            else
            {
                symbol.ParentScope = this;
                this.SymbolTable[symbol.Name] = symbol;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Enum>> [{0}] {1} {{\n", ContentType, Name);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
