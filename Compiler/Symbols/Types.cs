using System;
using System.Text;
using System.Collections.Generic;

using Compiler.AST;

namespace Compiler.Symbols
{
    public class Types
    {
        private static IDictionary<string, IType> register = new Dictionary<string, IType>();

        public static TypesTable<bool> PromotionTable { get; set; }

        public static TypesTable<IType> ResultTable { get; set; }

        public static IType Result(IType a, IType b)
        {
            return ResultTable[a, b];
        }

        public static bool CanPromoteTo(IType a, IType b)
        {
            return PromotionTable[a, b];
        }

        public static void RegisterType(string name, IType type)
        {
            register[name] = type;
        }

        public static IType GetType(string name)
        {
            return register[name];
        }

        public static bool SetType(ref Expression expr, IType dstType, IContext context)
        {
            IType type = expr.EvalType;
            if (!type.CanAssignTo(dstType))
            {
                if (type.CanPromoteTo(dstType))
                {
                    expr = new TypePromotionExpression(expr, new ResolvedType(dstType));
                    expr = expr.ResolveRValue(context);
                }
                /*
                else if (type.CanImplicitlyCastTo(dstType))
                {
                }
                */
                else if ((dstType.IsEqualTo(Types.GetType("Object")) || dstType.IsEqualTo(Types.GetType("ValueType"))) && (type is ValueTypeSymbol))
                {
                    expr = new BoxExpression(expr);
                    expr = expr.ResolveRValue(context);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsConvertible(IType type, IType dstType)
        {
            if (!type.CanAssignTo(dstType))
            {
                if (type.CanPromoteTo(dstType))
                    return true;
                /*
                else if (type.CanImplicitlyCastTo(dstType))
                    return true;
                */
                else if ((dstType.IsEqualTo(Types.GetType("Object")) || dstType.IsEqualTo(Types.GetType("ValueType"))) && (type is ValueTypeSymbol))
                    return true;
                else
                    return false;
            }
            return true;
        }

        public static bool IsDelegate(IType type)
        {
            return type.IsInstanceOf(Types.GetType("MulticastDelegate"));
        }
    }
}
