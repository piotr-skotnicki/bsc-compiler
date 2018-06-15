using System;
using System.Text;

namespace Compiler.Symbols
{
    public class UnknownType : IType
    {
        public Name Name { get; set; }

        public UnknownType(Name name)
        {
            Name = name;
        }

        public AccessModifier Access
        {
            get { return AccessModifier.PRIVATE; }
        }

        public bool HasContentType
        {
            get { return false; }
        }

        public IScope ParentScope
        {
            get { return null; }
        }

        public IScope MembersScope
        {
            get { return null; }
        }

        public Type NetType
        {
            //throw new UnknownTypeException("Unresolved reference to " + Name);
            get { return null; }
        }

        public bool IsInstanceOf(IType baseType)
        {
            return false;
            //throw new UnknownTypeException("Unresolved reference to " + Name);
        }

        public bool CanAssignTo(IType targetType)
        {
            return false;
            //throw new UnknownTypeException("Unresolved reference to " + Name);
        }

        public bool CanPromoteTo(IType targetType)
        {
            return false;
            //throw new UnknownTypeException("Unresolved reference to " + Name);
        }

        public bool CanCastTo(IType targetType)
        {
            return false;
            //throw new UnknownTypeException("Unresolved reference to " + Name);
        }

        public bool IsEqualTo(IType type)
        {
            return false;
            //throw new UnknownTypeException("Unresolved reference to " + Name);
        }

        public QualifiedName GetQualifiedName()
        {
            return new QualifiedName(this.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<UnknownType>> ");
            sb.Append(Name);
            return sb.ToString();
        } 
    }

    public class UnknownTypeException : ApplicationException
    {
        public UnknownTypeException()
        {

        }

        public UnknownTypeException(string msg)
            : base(msg)
        {

        }
    }
}
