using System.Collections.Generic;

namespace Compiler.Symbols
{
    public class SimpleMethodOverloadResolver : IMethodOverloadResolver
    {
        public virtual Symbol MatchBest(IEnumerable<IType> actual_types, IEnumerable<MethodSymbol> candidates)
        {
            IList<IType> actual_types_list = new List<IType>(actual_types);

            LinkedList<MethodSymbol> matchingMethods = new LinkedList<MethodSymbol>();
            int argsNum = actual_types_list.Count;
            
            foreach (MethodSymbol method in candidates)
            {
                if (method.ArgumentsCount == argsNum)
                {
                    matchingMethods.AddLast(method);
                }
            }

            LinkedListNode<MethodSymbol> next = null, node;

            next = null;
            node = matchingMethods.First;
            while (node != null)
            {
                next = node.Next;
                IList<IType> formalTypes = node.Value.GetFormalTypes();
                bool allEquals = true;
                for (int i = 0; i < argsNum; ++i)
                {
                    if (!actual_types_list[i].IsEqualTo(formalTypes[i]))
                    {
                        allEquals = false;
                        break;
                    }
                }
                if (allEquals)
                {
                    return node.Value;
                }
                node = next;
            }

            next = null;
            node = matchingMethods.First;
            while (node != null)
            {
                next = node.Next;
                IList<IType> formalTypes = node.Value.GetFormalTypes();
                for (int i = 0; i < argsNum; ++i)
                {
                    if (!actual_types_list[i].CanAssignTo(formalTypes[i]) && !actual_types_list[i].CanPromoteTo(formalTypes[i]))
                    {
                        matchingMethods.Remove(node);
                        break;
                    }
                }
                node = next;
            }

            if (matchingMethods.Count == 0)
            {
                return null;
            }
            else if (matchingMethods.Count == 1)
            {
                return matchingMethods.First.Value;
            }
            else // matchingMethods.Count > 1
            {
                throw new AmbiguousMatchException();
            }
        }

        public virtual bool CanOverload(IEnumerable<IType> formal_types, IEnumerable<MethodSymbol> overloads)
        {
            IList<IType> formal_types_list = new List<IType>(formal_types);

            int argsNum = formal_types_list.Count;
            foreach (MethodSymbol method in overloads)
            {
                if (method.ArgumentsCount == argsNum)
                {
                    bool allEquals = true;
                    IList<IType> methodArgs = method.GetFormalTypes();
                    for (int i = 0; i < argsNum; ++i)
                    {
                        if (formal_types_list[i] == null)
                        {
                            allEquals = false;
                            break;
                        }

                        if (!formal_types_list[i].IsEqualTo(methodArgs[i]))
                        {
                            allEquals = false;
                            break;
                        }
                    }
                    if (allEquals)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public virtual Symbol MatchEqual(MethodSymbol pattern, IEnumerable<MethodSymbol> candidates)
        {
            int argsNum = pattern.ArgumentsCount;
            IList<IType> formalTypes = pattern.GetFormalTypes();
            foreach (MethodSymbol method in candidates)
            {
                if ((method.ReturnType == null && pattern.ReturnType == null) || pattern.ReturnType.IsEqualTo(method.ReturnType))
                {
                    if (method.ArgumentsCount == argsNum)
                    {
                        bool allEquals = true;
                        IList<IType> methodArgs = method.GetFormalTypes();
                        for (int i = 0; i < argsNum; ++i)
                        {
                            if (!formalTypes[i].IsEqualTo(methodArgs[i]))
                            {
                                allEquals = false;
                                break;
                            }
                        }
                        if (allEquals)
                        {
                            return method;
                        }
                    }
                }
            }
            return null;
        }
    }
}
