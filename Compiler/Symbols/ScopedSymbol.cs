using System.Collections.Generic;

namespace Compiler.Symbols
{
    public abstract class ScopedSymbol : Symbol, IScope
    {
        protected SymbolTable SymbolTable { get; private set; }

        public ScopedSymbol(Name name)
            : base(name)
        {
            this.SymbolTable = new SymbolTable();
        }

        public virtual void Define(Symbol symbol)
        {
            if (this.SymbolTable.ContainsKey(symbol.Name))
            {
                Symbol tableEntry = this.SymbolTable[symbol.Name];
                if (tableEntry is IOverloadable)
                {
                    symbol.ParentScope = this;
                    Symbol newEntry = ((IOverloadable)tableEntry).Overload(symbol);
                    newEntry.ParentScope = this;
                    this.SymbolTable[symbol.Name] = newEntry;
                }
                else
                {
                    throw new SymbolAlreadyDefinedException(symbol.Name);
                }
            }
            else
            {
                symbol.ParentScope = this;
                this.SymbolTable[symbol.Name] = symbol;
            }
        }

        public virtual Symbol Resolve(Name name, LookupFlags flags)
        {
            Symbol symbol = null;
            if (this.SymbolTable.ContainsKey(name))
            {
                symbol = this.SymbolTable[name];
            }
            else
            {
                if (flags.IsGlobal)
                {
                    symbol = this.ParentScope.Resolve(name, flags);
                }
            }
            return symbol;
        }

        public virtual QualifiedName GetQualifiedName(QualifiedName name)
        {
            name.Prepend(this.Name);
            if (this.ParentScope == null)
                return name;
            return ParentScope.GetQualifiedName(name);
        }
    }
}
