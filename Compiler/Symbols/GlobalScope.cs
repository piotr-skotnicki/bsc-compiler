using System.Text;

namespace Compiler.Symbols
{
    public class GlobalScope : BasicScope
    {
        public GlobalScope() 
        {

        }

        public virtual Symbol GetSymbol(QualifiedName qualifiedName)
        {
            QualifiedName part = qualifiedName;
            IScope scope = this;
            while (part.Tail != null)
            {
                Symbol resolved = scope.Resolve(part.Head, LookupFlags.LOCAL);
                scope = resolved as IScope;
                if (scope == null)
                {
                    return null; 
                }
                part = part.Tail;
            }

            return scope.Resolve(part.Head, LookupFlags.LOCAL);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<GlobalScope>> {\n");
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
