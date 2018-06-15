using System;
using System.Text;
using System.Reflection;

namespace Compiler.Symbols
{
    public class ReferenceTypeSymbol : Symbol, IType, ITypeWrapper
    {
        public IType ContentType { get; set; }

        public ReferenceTypeSymbol()
            : base(null)
        {

        }

        public override Name Name
        {
            get { return this.ContentType.Name + "&"; }
            set { base.Name = value; }
        }

        public override AccessModifier Access
        {
            get { return ContentType.Access; }
            set { throw new AccessViolationException(); }
        }

        public bool HasContentType
        {
            get { return true; }
        }

        public override IScope ParentScope
        {
            get { return ContentType.ParentScope; }
        }

        public IScope MembersScope
        {
            get { return ContentType.MembersScope; }
        }

        public Type NetType
        {
            get
            {
                if (ContentType == null)
                    return null;
                return ContentType.NetType.MakeByRefType();
            }
        }

        public override IType Type
        {
            get { return this; }
        }
        
        public virtual bool IsInstanceOf(IType baseType)
        {
            if (IsEqualTo(baseType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual bool IsEqualTo(IType type)
        {
            if (Object.ReferenceEquals(this, type))
            {
                return true;
            }
            else
            {
                ReferenceTypeSymbol rts = type as ReferenceTypeSymbol;
                if (rts != null)
                {
                    if (ContentType.IsEqualTo(rts.ContentType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }       

        public virtual bool CanAssignTo(IType targetType)
        {
            return IsEqualTo(targetType) || IsInstanceOf(targetType);
        }
        
        public virtual bool CanPromoteTo(IType targetType)
        {
            return false;
        }

        public virtual bool CanCastTo(IType targetType)
        {
            return CanAssignTo(targetType);
        }

        public override QualifiedName GetQualifiedName()
        {
            if (this.ContentType == null)
                return "";
            return new QualifiedName(this.ContentType.GetQualifiedName().ToString() + "&");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Reference>> [{0}]", ContentType.Name);
            return sb.ToString();
        }
    }
}
