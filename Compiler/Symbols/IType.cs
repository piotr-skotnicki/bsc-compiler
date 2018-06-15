using System;

namespace Compiler.Symbols
{
    public interface IType : INetObject
    {
        bool IsInstanceOf(IType baseType);

        bool CanAssignTo(IType targetType);

        bool CanPromoteTo(IType targetType);

        bool CanCastTo(IType targetType);

        bool IsEqualTo(IType type);

        bool HasContentType { get; }

        IScope MembersScope { get; }

        Type NetType { get; }

        /*
        bool IsValueType { get; }

        bool IsClassType { get; }

        bool IsPrimitive { get; }

        bool IsArray { get; }

        bool IsReference { get; }

        bool IsPointer { get; }
        
        bool IsIntegral { get; }                
        */ 
    }
}
