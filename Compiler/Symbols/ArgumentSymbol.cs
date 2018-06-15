using System.Reflection;
using System.Text;

namespace Compiler.Symbols
{
    public class ArgumentSymbol : VariableSymbol
    {
        public int Index { get; set; }

        public ArgumentSymbol(Name name)
            : base(name)
        {

        }

        public ParameterInfo NetInfo { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Argument>> [{0}] {1}, Index={2}", Type.Name, Name, Index);
            return sb.ToString();
        }
    }
}
