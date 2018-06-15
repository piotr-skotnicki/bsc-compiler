using System;
using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class SymbolTable
    {
        private IDictionary<Name, Symbol> table = new Dictionary<Name, Symbol>();

        public bool ContainsKey(Name name)
        {
            return table.ContainsKey(name);
        }

        public Symbol this[Name name]
        {
            get { return table[name]; }
            set { table[name] = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Symbol symbol in table.Values)
            {
                sb.AppendFormat("{0}\n", symbol);
            }
            return sb.ToString();
        }
    }
}
