using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class OverloadedMethodSymbol : MethodSymbol, IOverloadable
    {
        private IList<MethodSymbol> overloads = new List<MethodSymbol>();

        public static IMethodOverloadResolver OverloadResolver { get; set; }

        static OverloadedMethodSymbol()
        {
            OverloadResolver = new SimpleMethodOverloadResolver();
        }

        public OverloadedMethodSymbol(Name name)
            : base(name)
        {

        }

        public override bool IsOverloaded
        {
            get { return overloads.Count > 1; }
        }

        public override Symbol Overload(Symbol symbol)
        {
            MethodSymbol ms = symbol as MethodSymbol;
            if (ms == null)
            {
                throw new SymbolAlreadyDefinedException(symbol.Name);
            }

            if (OverloadedMethodSymbol.OverloadResolver.CanOverload(ms.GetFormalTypes(), this.overloads))
            {
                this.overloads.Add(ms);
                return this;
            }
            else
            {
                throw new MethodAlreadyDefinedException(symbol.Name);
            }
        }
        
        public override Symbol ResolveOverload(IEnumerable<IType> actual_types)
        {
            return OverloadedMethodSymbol.OverloadResolver.MatchBest(actual_types, this.overloads);
        }

        public override IEnumerable<MethodSymbol> GetOverloads()
        {
            return this.overloads;
        }

        public override MethodSymbol ResolveEqual(IEnumerable<MethodSymbol> candidates)
        {
            throw new UnresolvedOverloadException();
        }

        public override int ArgumentsCount
        {
            get { throw new UnresolvedOverloadException(); }
        }

        public override IList<ArgumentSymbol> GetFormalArguments()
        {
            throw new UnresolvedOverloadException();
        }

        public override IList<IType> GetFormalTypes()
        {
            throw new UnresolvedOverloadException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<OverloadedMethod>> {0} {{\n\t", Name);
            foreach (MethodSymbol method in overloads)
            {
                sb.AppendFormat("\t{0}\n\t", method);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
