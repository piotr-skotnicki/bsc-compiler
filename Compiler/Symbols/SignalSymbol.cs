using System.Text;
using System.Reflection.Emit;

namespace Compiler.Symbols
{
    public class SignalSymbol : Symbol
    {
        public MethodSymbol AddMethodReference { get; set; }

        public MethodSymbol RemoveMethodReference { get; set; }

        public FieldSymbol DelegateField { get; set; }

        public SignalSymbol(Name name)
            : base(name)
        {

        }

        public EventBuilder NetBuilder { get; set; }

        public bool HasAddon
        {
            get { return AddMethodReference != null; }
        }

        public bool HasRemove
        {
            get { return RemoveMethodReference != null; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Signal>> {0} {{\n", Name);
            sb.AppendFormat("[field]-> {0}\n", DelegateField.Type);
            sb.AppendFormat("[add]-> {0}\n", AddMethodReference);
            sb.AppendFormat("[remove]-> {0}\n", RemoveMethodReference);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
