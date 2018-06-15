using System.Text;

namespace Compiler.Symbols
{
    public class FileNamespace : NamespaceSymbol
    {
        public FileNamespace(IScope globalAssemblyScope)
            : base(null)
        {
            this.ParentScope = globalAssemblyScope;
        }

        public override void Define(Symbol symbol)
        {
            this.ParentScope.Define(symbol);
            symbol.ParentScope = this;
        }

        public override Symbol Resolve(Name name, LookupFlags flags)
        {
            Symbol symbol = base.Resolve(name, LookupFlags.LOCAL);
            /*
            if (symbol == null && flags.IsGlobal)
            {
                symbol = this.ParentScope.Resolve(name, LookupFlags.GLOBAL);
            }
            */

            if (symbol == null)
            {
                symbol = this.ParentScope.Resolve(name, flags);
            }
            return symbol;
        }

        public override QualifiedName GetQualifiedName(QualifiedName name)
        {
            return this.ParentScope.GetQualifiedName(name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<FileNamespace>> {0} {{\n", Name);
            if (imports != null)
                foreach (ScopedSymbol import in imports)
                    sb.AppendFormat("imports {0}\n", import);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
