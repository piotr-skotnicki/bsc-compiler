using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class ClassTypeSymbol : ObjectTypeSymbol
    {
        public ClassSpecifier Specifier { get; set; }

        public ClassTypeSymbol(Name name)
            : base(name)
        {

        }

        public virtual bool IsFinal
        {
            get { return Specifier.IsFinal; }
        }

        public virtual bool IsAbstract
        {
            get { return Specifier.IsAbstract; }
        }

        public override void Define(Symbol symbol)
        {
            base.Define(symbol);

            /*:
            if (symbol is SignalSymbol)
            {
                SignalSymbol signal = symbol as SignalSymbol;
                FieldSymbol field = new FieldSymbol(symbol.Name);
                field.Type = signal.Type;
                signal.DelegateField = field;
            }
            */
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Name baseClass = BaseClass == null ? "__null__" : BaseClass.Name.ToString();

            StringBuilder insb = new StringBuilder();
            if (Interfaces != null)
            {
                foreach (InterfaceTypeSymbol @interface in Interfaces)
                {
                    insb.AppendFormat("[{0}], ", @interface.Name);
                }
                if (insb.Length > 2)
                {
                    insb.Remove(insb.Length - 2, 2);
                }
            }

            sb.AppendFormat("<<Class>> {0} extends [{1}] implements {2} {{\n", Name, baseClass, insb);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
