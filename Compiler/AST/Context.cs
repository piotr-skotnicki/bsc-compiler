using System;
using System.Collections.Generic;
using System.Text;

using Compiler.Symbols;

namespace Compiler.AST
{
    public interface IContext
    {
        // CurrentAssembly { get; }

        NamespaceSymbol GlobalNamespace { get; }

        void PushScope(IScope scope);

        void PopScope();

        IScope CurrentScope { get; }

        void PushType(IType type);

        void PopType();

        IType EnclosingType { get; }

        bool IsNested { get; }

        void PushNamespace(NamespaceSymbol ns);

        void PopNamespace();

        NamespaceSymbol CurrentNamespace { get; }

        void EnterMethod(MethodSymbol method);

        void ExitMethod();

        MethodSymbol CurrentMethod { get; }
        
        void EnterCatchClause();

        void ExitCatchClause();

        bool IsInsideCatchClause { get; }

        void EnterLoop();

        void ExitLoop();

        bool IsInsideLoop { get; }

        IType GetEnclosingType(IScope scope);

        bool HasAncestor(IScope obj, IScope ancestor);

        bool CanAccess(INetObject obj);

        AccessModifier WorldAccess(INetObject obj);

        bool HasConsistentAccessibility(INetObject obj, AccessModifier access);
    }

    public class Context : IContext
    {
        public Context(NamespaceSymbol global)
        {
            this.GlobalNamespace = global;
        }

        public NamespaceSymbol GlobalNamespace { get; private set; }

        private Stack<IScope> scope_stack = new Stack<IScope>();

        public void PushScope(IScope scope)
        {
            scope_stack.Push(scope);
        }

        public void PopScope()
        {
            scope_stack.Pop();
        }

        public IScope CurrentScope
        {
            get { return scope_stack.Peek(); }
        }

        private Stack<IType> type_stack = new Stack<IType>();

        public void PushType(IType type)
        {
            type_stack.Push(type);
        }

        public void PopType()
        {
            type_stack.Pop();
        }

        public IType EnclosingType
        {
            get { return type_stack.Count > 0 ? type_stack.Peek() : null; }
        }

        public bool IsNested
        {
            get { return type_stack.Count > 0; }
        }

        private Stack<NamespaceSymbol> namespace_stack = new Stack<NamespaceSymbol>();

        public void PushNamespace(NamespaceSymbol ns)
        {
            namespace_stack.Push(ns);
        }

        public void PopNamespace()
        {
            namespace_stack.Pop();
        }

        public NamespaceSymbol CurrentNamespace
        {
            get { return namespace_stack.Count > 0 ? namespace_stack.Peek() : null; }
        }

        public void EnterMethod(MethodSymbol method)
        {
            CurrentMethod = method;
        }

        public void ExitMethod()
        {
            CurrentMethod = null;
        }

        public MethodSymbol CurrentMethod { get; set; }
        
        public void EnterCatchClause()
        {
            IsInsideCatchClause = true;
        }

        public void ExitCatchClause()
        {
            IsInsideCatchClause = false;
        }

        public bool IsInsideCatchClause { get; private set; }

        public void EnterLoop()
        {
            IsInsideLoop = true;
        }

        public void ExitLoop()
        {
            IsInsideLoop = false;
        }

        public bool IsInsideLoop { get; private set; }

        public IType GetEnclosingType(IScope scope)
        {
            while (scope != null)
            {
                if (scope is IType)
                    return scope as IType;
                scope = scope.ParentScope;
            }
            return null;
        }

        public bool CanAccess(INetObject obj)
        {
            if (obj.Access.IsEmpty)
                return true;

            IScope from = CurrentScope;

            AccessModifier grantedAccess = new AccessModifier();
            grantedAccess.Add(AccessModifier.PUBLIC);

            bool sameAssembly = false;

            /*
            if (currentAssembly == to.Assembly)
            {
                sameAssembly = true;
                grantedAccess.Add(AccessModifier.ASSEMBLY);
            }
            */

            if (HasAncestor(from, obj.ParentScope))
            {
                grantedAccess.Add(AccessModifier.FAMORASSEM);
                grantedAccess.Add(AccessModifier.FAMILY);
                grantedAccess.Add(AccessModifier.PRIVATE);

                if (sameAssembly)
                {
                    grantedAccess.Add(AccessModifier.FAMANDASSEM);
                }
            }

            IType fromObject = GetEnclosingType(from);
            if (fromObject != null)
            {
                if (fromObject.IsInstanceOf(GetEnclosingType(obj.ParentScope)))
                {
                    grantedAccess.Add(AccessModifier.FAMILY);

                    if (sameAssembly)
                    {
                        grantedAccess.Add(AccessModifier.FAMANDASSEM);
                    }
                }
            }

            return grantedAccess.AccessTo(obj.Access);
        }

        public IScope GetEnclosingScope(INetObject obj)
        {
            if (obj is IScope)
                return (IScope)obj;
            return obj.ParentScope;
        }

        public bool HasAncestor(IScope scope, IScope ancestor)
        {
            while (scope != null)
            {
                if (scope == ancestor)
                {
                    return true;
                }
                scope = scope.ParentScope;
            }
            return false;
        }

        public AccessModifier WorldAccess(INetObject obj)
        {
            AccessModifier worldAccess = new AccessModifier();
            worldAccess.Add(obj.Access);

            IScope scope = obj.ParentScope;
            while (scope != null)
            {
                if (scope is Symbol)
                {
                    worldAccess.Add(((Symbol)scope).Access);
                }
                scope = scope.ParentScope;
            }

            return worldAccess;
        }

        public bool HasConsistentAccessibility(INetObject obj, AccessModifier access)
        {
            AccessModifier worldAccess = WorldAccess(obj);

            if (worldAccess.IsFamAndAssem)
            {
                if (access.IsFamAndAssem)
                {
                    return true;
                }
            }
            else if (worldAccess.IsFamOrAssem)
            {
                if (access.IsPrivate || access.IsFamOrAssem)
                {
                    return true;
                }
            }
            else if (worldAccess.IsAssembly)
            {
                if (access.IsPrivate || access.IsFamAndAssem || access.IsAssembly)
                {
                    return true;
                }
            }
            else if (worldAccess.IsPrivate)
            {
                if (access.IsPrivate)
                {
                    return true;
                }
            }
            else if (worldAccess.IsFamily)
            {
                if (access.IsPrivate || (access.IsFamily && !access.IsAssembly) || access.IsFamAndAssem)
                {
                    return true;
                }
            }
            else if (worldAccess.IsPublic)
            {
                return true;
            }

            return false;
        }
    }
}
