using System;
using System.Collections.Generic;

namespace Compiler.Symbols
{
    public abstract class ObjectTypeSymbol : ScopedSymbol, IObjectType
    {
        public ClassTypeSymbol BaseClass { get; set; }

        public IList<InterfaceTypeSymbol> Interfaces { get; private set; }

        public ObjectTypeSymbol(Name name)
            : base(name)
        {
            
        }

        public override IType Type
        {
            get { return this; }
        }

        public virtual Type NetType { get; set; }

        public virtual bool HasContentType
        {
            get { return false; }
        }

        public virtual IScope MembersScope
        {
            get { return this; }
        }

        public virtual void AddInterface(InterfaceTypeSymbol @interface)
        {
            if (this.Interfaces == null)
                this.Interfaces = new List<InterfaceTypeSymbol>();

            this.Interfaces.Add(@interface);
        }

        public override void Define(Symbol symbol)
        {
            if (symbol.Name == this.Name)
                throw new MemberNameSameAsTypesException(this.Name);

            base.Define(symbol);
        }

        public override Symbol Resolve(Name name, LookupFlags flags)
        {
            Symbol symbol = base.Resolve(name, LookupFlags.LOCAL);
            if (symbol != null)
            {
                return symbol;
            }
            else
            {
                if (flags.IsFlat)
                {
                    return null;
                }
                else
                {
                    if (this.BaseClass != null)
                        symbol = this.BaseClass.Resolve(name, LookupFlags.LOCAL);

                    if (symbol == null && this.Interfaces != null)
                    {
                        foreach (InterfaceTypeSymbol @interface in this.Interfaces)
                        {
                            symbol = @interface.Resolve(name, LookupFlags.LOCAL);
                            if (symbol != null)
                                break;
                        }
                    }
                    
                    if (symbol == null && flags.IsGlobal)
                    {
                        return base.Resolve(name, flags);
                    }
                }
            }
            return symbol;
        }

        public virtual bool IsInstanceOf(IType baseType)
        {
            if (IsEqualTo(baseType))
            {
                return true;
            }
            else if (this.BaseClass != null && this.BaseClass.IsInstanceOf(baseType))
            {
                return true;
            }
            else if (this.Interfaces != null)
            {
                foreach (InterfaceTypeSymbol @interface in this.Interfaces)
                {
                    if (@interface.IsInstanceOf(baseType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool IsEqualTo(IType type)
        {
            return Object.ReferenceEquals(this, type);
        }

        public virtual bool CanAssignTo(IType targetType)
        {
            return IsInstanceOf(targetType);
        }

        public virtual bool CanPromoteTo(IType targetType)
        {
            return false;
        }

        public virtual bool CanCastTo(IType targetType)
        {
            return IsInstanceOf(targetType) || targetType.IsInstanceOf(this);
        }
    }
}
