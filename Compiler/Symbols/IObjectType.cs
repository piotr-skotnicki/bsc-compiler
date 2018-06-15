using System;

namespace Compiler.Symbols
{
    public interface IObjectType : IType
    {
        ClassTypeSymbol BaseClass { get; set; }

        void AddInterface(InterfaceTypeSymbol @interface);
    }
}
