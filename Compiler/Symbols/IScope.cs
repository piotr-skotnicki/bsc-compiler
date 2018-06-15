namespace Compiler.Symbols
{
    public interface IScope
    {
        IScope ParentScope { get; set; }

        Name Name { get; }

        void Define(Symbol symbol);

        Symbol Resolve(Name name, LookupFlags flags);

        QualifiedName GetQualifiedName(QualifiedName name);
    }
}
