using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class NamespaceSymbol : ScopedSymbol
    {
        protected IList<ScopedSymbol> imports;

        public NamespaceSymbol(Name name)
            : base(name)
        {

        }

        public void AddImport(ScopedSymbol ns)
        {
            if (imports == null)
                imports = new List<ScopedSymbol>();
            imports.Add(ns);
        }

        public void AddTypedef(Name alias, ScopedSymbol symbol)
        {
            if (this.SymbolTable.ContainsKey(alias))
            {
                throw new SymbolAlreadyDefinedException(symbol.Name);
            }
            else
            {
                this.SymbolTable[alias] = symbol;
            }
        }

        public override Symbol Resolve(Name name, LookupFlags flags)
        {
            Symbol symbol = base.Resolve(name, LookupFlags.LOCAL);
            if (symbol == null)
            {
                symbol = ScanImports(name);
                if (symbol == null && flags.IsGlobal)
                {
                    symbol = base.Resolve(name, flags);
                }
            }
            return symbol;
        }

        public virtual Symbol ScanImports(Name name)
        {
            if (imports == null)
            {
                return null;
            }
            else
            {
                foreach (NamespaceSymbol import in imports)
                {
                    Symbol symbol = import.Resolve(name, LookupFlags.LOCAL);
                    if (symbol != null)
                    {
                        return symbol;
                    }
                }
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Namespace>> {0} {{\n", Name);
            if (imports != null)
                foreach (ScopedSymbol import in imports)
                    sb.AppendFormat("imports {0}\n", import.Name);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
