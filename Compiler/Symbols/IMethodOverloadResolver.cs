using System.Collections.Generic;

namespace Compiler.Symbols
{
    public interface IMethodOverloadResolver
    {
        Symbol MatchBest(IEnumerable<IType> actual_types, IEnumerable<MethodSymbol> candidates);

        Symbol MatchEqual(MethodSymbol pattern, IEnumerable<MethodSymbol> candidates);

        bool CanOverload(IEnumerable<IType> formal_types, IEnumerable<MethodSymbol> overloads);
    }
}
