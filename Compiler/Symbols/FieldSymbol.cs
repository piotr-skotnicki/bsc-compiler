using System;
using System.Reflection;
using System.Text;

namespace Compiler.Symbols
{
    public class FieldSymbol : VariableSymbol
    {
        public FieldSpecifier Specifier { get; set; }

        public FieldSymbol(Name name)
            : base(name)
        {

        }

        public virtual FieldInfo NetInfo { get; set; }

        public virtual bool IsLiteral
        {
            get { return false; }
        }

        public virtual bool IsStatic
        {
            get { return Specifier.IsStatic; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Field>> [{0}] {1}", Type.Name, Name);
            return sb.ToString();
        }
    }
}
