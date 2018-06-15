using System;
using System.Text;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class InterfaceTypeSymbol : ObjectTypeSymbol
    {
        public InterfaceTypeSymbol(Name name)
            : base(name)
        {

        }

        public override bool IsInstanceOf(IType baseType)
        {
            if (IsEqualTo(baseType))
            {
                return true;
            }
            else
            {
                if (Interfaces != null)
                {
                    foreach (InterfaceTypeSymbol @interface in Interfaces)
                    {
                        if (@interface.IsInstanceOf(baseType))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

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

            sb.AppendFormat("<<Interface>> {0} extends {1}{{\n", Name, insb);
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
