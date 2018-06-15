using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Compiler.Symbols
{
    public class MethodSymbol : ScopedSymbol, IOverloadable
    {
        public const string MAIN = "Main";

        public const string CTOR = ".ctor";

        public const string CCTOR = ".cctor";

        public const string ADD_PREFIX = "add_";

        public const string REMOVE_PREFIX = "remove_";

        public const string SET_PREFIX = "set_";

        public const string GET_PREFIX = "get_";

        public IType ReturnType { get; set; }

        public MethodSpecifier Specifier { get; set; }

        private LinkedList<ArgumentSymbol> arguments = new LinkedList<ArgumentSymbol>();

        public MethodSymbol(Name name)
            : base(name)
        {

        }

        public virtual MethodBase NetBaseInfo { get; set; }

        public virtual bool IsStatic
        {
            get { return Specifier.IsStatic; }
        }

        public virtual bool IsFinal
        {
            get { return Specifier.IsFinal; }
        }

        public virtual bool IsAbstract
        {
            get { return Specifier.IsAbstract; }
        }

        public virtual bool IsNew
        {
            get { return Specifier.IsNew; }
        }

        public virtual bool IsVirtual
        {
            get { return Specifier.IsVirtual || Specifier.IsAbstract; }
        }

        public virtual bool IsConstructor
        {
            get { return Specifier.IsConstructor; }
        }

        public virtual bool IsRuntimeManaged
        {
            get { return Specifier.IsRuntimeManaged; }
        }

        public virtual bool IsOverloaded
        {
            get { return false; }
        }

        public virtual Symbol Overload(Symbol symbol)
        {
            MethodSymbol ms = symbol as MethodSymbol;
            if (ms == null)
            {
                throw new SymbolAlreadyDefinedException(symbol.Name);
            }

            OverloadedMethodSymbol ovm = new OverloadedMethodSymbol(Name);
            ovm.Overload(this);
            ovm.Overload(symbol);

            return ovm;
        }        

        public virtual Symbol ResolveOverload(IEnumerable<IType> actual_types)
        {
            return OverloadedMethodSymbol.OverloadResolver.MatchBest(actual_types, new List<MethodSymbol>() { this });
        }

        public virtual IEnumerable<MethodSymbol> GetOverloads()
        {
            return new MethodSymbol[] { this };
        }

        public virtual MethodSymbol ResolveEqual(IEnumerable<MethodSymbol> candidates)
        {
            return OverloadedMethodSymbol.OverloadResolver.MatchEqual(this, candidates) as MethodSymbol;
        }
        
        public override void Define(Symbol symbol)
        {
            base.Define(symbol);

            if (symbol is ArgumentSymbol)
            {
                ArgumentSymbol arg = symbol as ArgumentSymbol;
                arg.Index = arguments.Count;
                arguments.AddLast(arg);
            }
        }

        public virtual int ArgumentsCount
        {
            get { return arguments.Count; }
        }

        public virtual IList<ArgumentSymbol> GetFormalArguments()
        {
            ArgumentSymbol[] args = new ArgumentSymbol[ArgumentsCount];
            foreach (ArgumentSymbol arg in arguments)
            {
                args[arg.Index] = arg;
            }
            return args;
        }

        public virtual IList<IType> GetFormalTypes()
        {
            return new List<IType>(from arg in GetFormalArguments() select arg.Type);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<<Method>> [{0}] {1}(\n\t", ReturnType.Name, Name);
            foreach (ArgumentSymbol arg in GetFormalArguments())
            {
                sb.AppendFormat("\t{0}, \n\t", arg);
            }
            sb.Remove(sb.Length - 2, 2);
            if (ArgumentsCount > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            sb.Append(") {\n");
            sb.Append(base.SymbolTable);
            sb.Append("}");
            return sb.ToString();
        }
    }
}
