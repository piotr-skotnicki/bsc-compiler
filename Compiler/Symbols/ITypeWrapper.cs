using System;

namespace Compiler.Symbols
{
    public interface ITypeWrapper
    {
        IType ContentType { get; set; }
    }
}
