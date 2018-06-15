using System.Text;
using System.Collections.Generic;

using Compiler.Symbols;

namespace Compiler.AST
{
    public class AccessScopeStack
    {
        public static readonly AccessModifier DefaultGlobalAccess = AccessModifier.PUBLIC;

        public static readonly AccessModifier DefaultClassAccess = AccessModifier.PRIVATE;

        public static readonly AccessModifier DefaultStructAccess = AccessModifier.PUBLIC;

        public static readonly AccessModifier DefaultInterfaceAccess = AccessModifier.PUBLIC;

        Stack<AccessModifier> stack = new Stack<AccessModifier>();

        public void Push(AccessModifier am)
        {
            stack.Push(am);
        }

        public void Pop()
        {
            stack.Pop();
        }

        public void Set(AccessModifier am)
        {
            stack.Pop();
            stack.Push(am);
        }

        public AccessModifier CurrentAccess
        {
            get
            {
                if (stack.Count == 0)
                    return AccessScopeStack.DefaultGlobalAccess;
                else
                    return stack.Peek();
            }
        }

        public bool IsEmpty
        {
            get { return stack.Count == 0; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<<AccessScopeStack>> {\n");
            foreach (AccessModifier am in stack)
            {
                sb.AppendFormat("{0}\n", am);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
