using System;
using System.Text;

namespace Compiler.Symbols
{
    public class ArrayTypeSymbol : ObjectTypeSymbol, ITypeWrapper
    {
        public IType ContentType { get; set; }
        
        public int Rank { get; private set; }

        public ArrayTypeSymbol(int rank)
            : base(null)
        {
            this.Rank = rank;
        }

        public override Name Name
        {
            get { return String.Format("{0}[{1}]", this.ContentType.Name, this.Rank); }
            set { base.Name = value; }
        }

        public override Type NetType
        {
            get
            {
                if (ContentType == null)
                    return null;

                if (this.Rank == 1)
                    return ContentType.NetType.MakeArrayType();

                return ContentType.NetType.MakeArrayType(this.Rank);
            }
        }

        public override AccessModifier Access
        {
            get { return ContentType.Access; }
            set { throw new AccessViolationException(); }
        }

        public override bool HasContentType
        {
            get { return true; }
        }

        public override IScope ParentScope
        {
            get { return ContentType.ParentScope; }
        }

        public override IScope MembersScope
        {
            get { return this; }
        }

        public override bool IsEqualTo(IType type)
        {
            if (Object.ReferenceEquals(this, type))
            {
                return true;
            }
            else
            {
                ArrayTypeSymbol ats = type as ArrayTypeSymbol;
                if (ats != null)
                {
                    if (Rank == ats.Rank && ContentType.IsEqualTo(ats.ContentType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override QualifiedName GetQualifiedName()
        {
            if (this.ContentType == null)
                return "";
            return new QualifiedName(this.ContentType.GetQualifiedName().ToString() + String.Format("[{0}]", this.Rank));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Array>> [{0}], Rank={1}", ContentType.Name, Rank);
            return sb.ToString();
        }
    }
}
