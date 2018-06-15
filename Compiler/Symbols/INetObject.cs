using System;

namespace Compiler.Symbols
{
    public interface INetObject
    {
        Name Name { get; }

        QualifiedName GetQualifiedName();

        AccessModifier Access { get; }

        IScope ParentScope { get; }
    }
}
