using System.Reflection;
using System.Text;

namespace Compiler.Symbols
{
    public class PropertySymbol : Symbol
    {
        public MethodSymbol SetMethodReference { get; set; }

        public MethodSymbol GetMethodReference { get; set; }
        
        public PropertySymbol(Name name)
            : base(name)
        {

        }

        public bool IsStatic
        {
            get
            {
                if (HasGetter && GetMethodReference.IsStatic)
                    return true;
                if (HasSetter && SetMethodReference.IsStatic)
                    return true;
                return false;
            }
        }

        public PropertyInfo NetInfo { get; set; }

        public bool HasSetter
        {
            get { return SetMethodReference != null; }
        }

        public bool HasGetter
        {
            get { return GetMethodReference != null; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Property>> {0} {{\n", Name);
            sb.AppendFormat("[getter]-> {0}\n", GetMethodReference);
            sb.AppendFormat("[setter]-> {0}\n", SetMethodReference);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
