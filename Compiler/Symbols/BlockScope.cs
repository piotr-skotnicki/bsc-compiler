using System;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class BlockScope : BasicScope
    {
        public BlockScope(IScope parentScope)
            : base(parentScope)
        {

        }
    }
}
