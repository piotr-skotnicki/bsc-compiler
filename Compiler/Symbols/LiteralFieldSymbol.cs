using System.Text;

namespace Compiler.Symbols
{
    public class LiteralFieldSymbol : FieldSymbol
    {        
        public object LiteralValue { get; private set; }

        public LiteralFieldSymbol(Name name)
            : base(name)
        {
            LiteralValue = 0;
        }

        public LiteralFieldSymbol(Name name, object value)
            : base(name)
        {
            LiteralValue = value;
        }

        public override bool IsLiteral
        {
            get { return true; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<LiteralField>> [{0}] {1}, Value={2}", Type.Name, Name, LiteralValue);
            return sb.ToString();
        }
    }
}
