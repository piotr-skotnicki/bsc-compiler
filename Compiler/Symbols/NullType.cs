using System;

namespace Compiler.Symbols
{
    public class NullType : IType
    {
        public Name Name
        {
            get { return "null"; }
        }

        public AccessModifier Access
        {
            get { return AccessModifier.PUBLIC; }
        }

        public Type NetType
        {
            get { return null; }
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

        public bool IsInstanceOf(IType baseType)
        {
            return false;
        }

        public bool CanAssignTo(IType targetType)
        {
            if (targetType is ClassTypeSymbol)
            {
                return true;
            }
            return false;
        }

        public bool CanPromoteTo(IType targetType)
        {
            return false;
        }

        public bool CanCastTo(IType targetType)
        {
            return false;
        }

        public bool IsEqualTo(IType type)
        {
            if (type is NullType)
            {
                return true;
            }
            return false;
        }

        public QualifiedName GetQualifiedName()
        {
            return new QualifiedName(this.Name);
        }

        public override string ToString()
        {
            return String.Format("<<NullType>>");
        }
    }
}
