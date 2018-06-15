using System.Collections.Generic;

namespace Compiler.Symbols
{
    public interface IOverloadable
    {
        bool IsOverloaded { get; }

        Symbol Overload(Symbol symbol);

        Symbol ResolveOverload(IEnumerable<IType> actual_types);
    }
}
