using System.Text;

namespace Compiler.Symbols
{
    public class PrimitiveTypeSymbol : ValueTypeSymbol
    {
        public PrimitiveTypeSymbol(Name name)
            : base(name)
        {

        }

        public override bool CanAssignTo(IType targetType)
        {
            return IsEqualTo(targetType);// || IsInstanceOf(targetType);
        }

        public override bool CanPromoteTo(IType targetType)
        {
            if (targetType is PrimitiveTypeSymbol)
            {
                return Types.CanPromoteTo(this, targetType);
            }
            else
            {
                return false;
            }
        }

        public override bool CanCastTo(IType targetType)
        {
            if (targetType.CanPromoteTo(this) || CanPromoteTo(targetType))
            {
                return true;
            }
            else if (IsInstanceOf(targetType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<PrimitiveType>> {0} {{\n", Name);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
