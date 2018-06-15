using Compiler.AST;

namespace Compiler.Symbols
{
    public abstract class Symbol : INetObject
    {
        public virtual Name Name { get; set; }

        public virtual IScope ParentScope { get; set; }

        public ASTNode NodeReference { get; set; }

        public virtual IType Type { get; set; }

        public virtual AccessModifier Access { get; set; }

        public Symbol(Name name)
        {
            this.Name = name;
        }

        public virtual QualifiedName GetQualifiedName()
        {
            if (this.ParentScope == null)
                return Name;
            return this.ParentScope.GetQualifiedName(Name);
        }
        
        //public virtual FullName GetFullName() {}

        //public AssemblyName AssemblyName { get; set; }
    }
}
