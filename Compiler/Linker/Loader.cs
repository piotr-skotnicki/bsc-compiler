using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

using Compiler.Symbols;
using Compiler.Driver;

namespace Compiler.Linker
{
    public class TypeNamePair
    {
        public readonly int Length;

        public readonly QualifiedName Name;

        public readonly Type Type;

        public TypeNamePair(QualifiedName name, Type type)
        {
            Name = name;
            Type = type;
            Length = name.Length;
        }
    }

    public static class MirrorUtility
    {
        public static bool IsGenericType(Type type)
        {
            if (type.IsGenericType || type.IsGenericTypeDefinition || type.IsGenericParameter)
            {
                return true;
            }
            if (type.BaseType != null && MirrorUtility.IsGenericType(type.BaseType))
            {
                return true;
            }
            /*
            foreach (Type @interface in type.GetInterfaces())
            {
                if (MirrorUtility.IsGenericType(@interface))
                {
                    return true;
                }
            }
            */
            return false;
        }

        public static bool IsGenericMethod(MethodBase mb)
        {
            if (mb.IsGenericMethod || mb.ContainsGenericParameters || mb.IsGenericMethodDefinition)
            {
                return true;
            }
            if (mb is MethodInfo)
            {
                MethodInfo mi = (MethodInfo)mb;
                if (MirrorUtility.IsGenericType(mi.ReturnType))
                {
                    return true;
                }
            }
            foreach (ParameterInfo pi in mb.GetParameters())
            {
                if (MirrorUtility.IsGenericType(pi.ParameterType))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public abstract class Backpatcher
    {
        protected Type type;

        public abstract void Update();

        public Backpatcher(Type type)
        {
            this.type = type;
        }

        public static void Reset()
        {
            backpatchList.Clear();
            cache.Clear();
        }

        public static void SetScope(GlobalScope globalScope)
        {
            Scope = globalScope;
        }

        public static void Register(Backpatcher backpatcher)
        {
            backpatchList.AddLast(backpatcher);
        }

        public static void Run()
        {
            LinkedListNode<Backpatcher> node = backpatchList.First;
            while (node != null)
            {
                node.Value.Update();
                node = node.Next;
            }
        }

        private static LinkedList<Backpatcher> backpatchList = new LinkedList<Backpatcher>();

        private static GlobalScope Scope { get; set; }

        private static IDictionary<Type, IType> cache = new Dictionary<Type, IType>();

        public static IType Resolve(Type type)
        {
            if (type == null)
            {
                return null;
            }
            if (MirrorUtility.IsGenericType(type))
            {
                return null;
            }
            if (type.HasElementType)
            {
                Type elementType = type.GetElementType();
                if (type.IsArray)
                {
                    ArrayTypeSymbol sym = new ArrayTypeSymbol(type.GetArrayRank());
                    ArrayBackpatcher recursive = new ArrayBackpatcher(sym, type);
                    Backpatcher.Register(recursive);
                    return sym;
                }
                else if (type.IsByRef)
                {
                    ReferenceTypeSymbol sym = new ReferenceTypeSymbol();
                    ReferenceBackpatcher recursive = new ReferenceBackpatcher(sym, type);
                    Backpatcher.Register(recursive);
                    return sym;
                }
                else if (type.IsPointer)
                {
                    PointerTypeSymbol sym = new PointerTypeSymbol();
                    PointerBackpatcher recursive = new PointerBackpatcher(sym, type);
                    Backpatcher.Register(recursive);
                    return sym;
                }
                return null;
            }
            else
            {
                IType result;
                if (cache.TryGetValue(type, out result))
                {
                    return result;
                }
                else
                {
                    result = Search(type);
                    cache.Add(type, result);
                    return result;
                }
            }
        }

        public static IType Search(Type type)
        {
            if (type.IsNotPublic)
            {
                return null;
            }

            //AssemblyName assemblyName = MirrorUtility.GetAssemblyName(type.Assembly);

            string full_type_name = type.FullName;
            full_type_name = full_type_name.Replace('+', '.');
            QualifiedName fullName = new QualifiedName(full_type_name);

            Symbol resolved = Scope.GetSymbol(fullName);

            if (resolved != null)
            {
                return (IType)resolved;
            }
            else
            {
                return new UnknownType(type.Name);
            }
        }
    }

    public class ClassBackpatcher : Backpatcher
    {
        private ClassTypeSymbol symbol;

        public ClassBackpatcher(ClassTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;
            foreach (Type @interface in type.GetInterfaces())
            {
                res = Backpatcher.Resolve(@interface);
                if (res != null && !(res is UnknownType))
                {
                    symbol.AddInterface((InterfaceTypeSymbol)res);
                }
            }

            res = Backpatcher.Resolve(type.BaseType);
            if (res != null && !(res is UnknownType))
            {
                symbol.BaseClass = (ClassTypeSymbol)res;
            }
        }
    }

    public class ValueTypeBackpatcher : Backpatcher
    {
        private ValueTypeSymbol symbol;

        public ValueTypeBackpatcher(ValueTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;
            foreach (Type @interface in type.GetInterfaces())
            {
                res = Backpatcher.Resolve(@interface);
                if (res != null)
                {
                    symbol.AddInterface((InterfaceTypeSymbol)res);
                }
            }

            res = Backpatcher.Resolve(type.BaseType);
            if (res != null)
            {
                symbol.BaseClass = (ClassTypeSymbol)res;
            }
        }
    }

    public class EnumBackpatcher : Backpatcher
    {
        private EnumTypeSymbol symbol;

        public EnumBackpatcher(EnumTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type.BaseType);
            if (res != null)
            {
                symbol.BaseClass = (ClassTypeSymbol)res;
            }

            res = Backpatcher.Resolve(type.GetField(EnumTypeSymbol.DEFAULT_FIELD).FieldType);
            if (res != null)
            {
                symbol.ContentType = res;
            }
        }
    }

    public class InterfaceBackpatcher : Backpatcher
    {
        private InterfaceTypeSymbol symbol;

        public InterfaceBackpatcher(InterfaceTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            foreach (Type @interface in type.GetInterfaces())
            {
                res = Backpatcher.Resolve(@interface);
                if (res != null && !(res is UnknownType))
                {
                    symbol.AddInterface((InterfaceTypeSymbol)res);
                }
            }
        }
    }

    public class MethodBackpatcher : Backpatcher
    {
        private MethodSymbol symbol;

        public MethodBackpatcher(MethodSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type);
            if (res != null)
            {
                symbol.ReturnType = res;
            }

            symbol.Type = Backpatcher.Resolve(typeof(System.IntPtr));
        }
    }

    public class PropertyBackpatcher : Backpatcher
    {
        private PropertySymbol symbol;

        public PropertyBackpatcher(PropertySymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = Backpatcher.Resolve(type);
            symbol.Type = res;
        }
    }

    public class VariableBackpatcher : Backpatcher
    {
        private VariableSymbol symbol;

        public VariableBackpatcher(VariableSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type);
            if (res != null)
            {
                symbol.Type = res;
            }
        }
    }

    public class ArrayBackpatcher : Backpatcher
    {
        private ArrayTypeSymbol symbol;

        public ArrayBackpatcher(ArrayTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type.BaseType);
            if (res != null)
            {
                symbol.BaseClass = (ClassTypeSymbol)res;
            }

            res = Backpatcher.Resolve(type.GetElementType());
            if (res != null)
            {
                symbol.ContentType = (IType)res;
            }
        }
    }

    public class ReferenceBackpatcher : Backpatcher
    {
        private ReferenceTypeSymbol symbol;

        public ReferenceBackpatcher(ReferenceTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type.GetElementType());
            if (res != null)
            {
                symbol.ContentType = res;
            }
        }
    }

    public class PointerBackpatcher : Backpatcher
    {
        private PointerTypeSymbol symbol;

        public PointerBackpatcher(PointerTypeSymbol symbol, Type type)
            : base(type)
        {
            this.symbol = symbol;
        }

        public override void Update()
        {
            IType res = null;

            res = Backpatcher.Resolve(type.GetElementType());
            if (res != null)
            {
                symbol.ContentType = res;
            }
        }
    }

    public class Loader
    {
        GlobalScope globalScope;
        Options options;

        public Loader(GlobalScope globalScope, Options options)
        {
            this.globalScope = globalScope;
            this.options = options;
        }

        public void Load(IEnumerable<AssemblyReference> referenced_assemblies)
        {
            IList<Assembly> references = new List<Assembly>();
            IList<string> aliases = new List<string>();

            Assembly mscorlib = Assembly.Load("mscorlib");
            references.Add(mscorlib);
            aliases.Add(null);

            foreach (AssemblyReference user_ref in referenced_assemblies)
            {
                Assembly assembly = null;
                string reference = user_ref.Reference;
                bool found = false;

                try
                {
                    char[] path_chars = { '/', '\\' };

                    if (reference.IndexOfAny(path_chars) != -1)
                    {
                        assembly = Assembly.LoadFrom(reference);
                    }
                    else
                    {
                        string r = reference;
                        if (r.EndsWith(".dll") || r.EndsWith(".exe"))
                            r = reference.Substring(0, reference.Length - 4);

                        assembly = Assembly.Load(r);
                    }

                    found = true;
                }
                catch
                {
                    foreach (string dir in this.options.Libraries)
                    {
                        string full_path = Path.Combine(dir, reference);
                        if (!reference.EndsWith(".dll") && !reference.EndsWith(".exe"))
                            full_path += ".dll";

                        try
                        {
                            assembly = Assembly.LoadFrom(full_path);
                            found = true;
                            break;
                        }
                        catch { }
                    }
                }

                if (found)
                {
                    references.Add(assembly);
                    aliases.Add(user_ref.Alias);
                }
                else
                {
                    Report.Error.AssemblyNotFound(reference);
                }
            }
            
            Type SYSTEM_ENUM = typeof(System.Enum);

            Backpatcher.Reset();
            Backpatcher.SetScope(globalScope);

            for(int i = 0; i < references.Count; ++i)
            {
                Assembly reference = references[i];
                Name alias = aliases[i];

                IScope referenceScope = this.globalScope;

                if (alias.Value != null && alias.Value.Length != 0)
                {
                    Symbol resolved = globalScope.Resolve(alias, LookupFlags.LOCAL);
                    if (resolved == null)
                    {
                        NamespaceSymbol namespaceSymbol = new NamespaceSymbol(alias);
                        globalScope.Define(namespaceSymbol);
                        referenceScope = namespaceSymbol;
                    }
                    else
                    {
                        referenceScope = resolved as NamespaceSymbol;
                        if (referenceScope == null)
                        {
                            Report.Error.ReferenceAliasExists(alias);
                            continue;
                        }
                    }
                }

                Type[] exportedTypes = reference.GetExportedTypes();

                List<TypeNamePair> types = new List<TypeNamePair>(exportedTypes.Length);
                foreach (Type type in exportedTypes)
                {
                    if (MirrorUtility.IsGenericType(type))
                        continue;

                    string full_type_name = type.FullName;

                    full_type_name = full_type_name.Replace('+', '.');

                    QualifiedName fullName = new QualifiedName(full_type_name);
                    TypeNamePair pair = new TypeNamePair(fullName, type);
                    types.Add(pair);
                }
                types.Sort((a, b) => a.Length - b.Length);

                BindingFlags declaredMembersBinding = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic;
                BindingFlags staticMembersBinding = declaredMembersBinding | BindingFlags.Static;
                BindingFlags instanceMembersBinding = declaredMembersBinding | BindingFlags.Instance;
                BindingFlags allMembersBinding = declaredMembersBinding | staticMembersBinding | instanceMembersBinding;

                foreach (TypeNamePair pair in types)
                {
                    QualifiedName fullName = pair.Name;
                    Type type = pair.Type;
                    Name typeName = fullName.Back();
                    fullName.PopBack();

                    IScope scope = referenceScope;
                    foreach (Name name in fullName)
                    {
                        ScopedSymbol scopedSymbol = (ScopedSymbol)scope.Resolve(name, LookupFlags.LOCAL);
                        if (scopedSymbol == null)
                        {
                            scopedSymbol = new NamespaceSymbol(name);
                            scope.Define(scopedSymbol);
                        }
                        scope = scopedSymbol;
                    }

                    Symbol symbol = null;

                    AccessModifier access = new AccessModifier();
                    if (type.IsNested)
                    {
                        if (type.IsNestedPublic)
                            access.Add(AccessModifier.PUBLIC);
                        else if (type.IsNestedFamily)
                            access.Add(AccessModifier.FAMILY);
                        else if (type.IsNestedPrivate)
                            access.Add(AccessModifier.PRIVATE);
                        else if (type.IsNestedAssembly)
                            access.Add(AccessModifier.ASSEMBLY);
                        else if (type.IsNestedFamANDAssem)
                            access.Add(AccessModifier.FAMANDASSEM);
                        else if (type.IsNestedFamORAssem)
                            access.Add(AccessModifier.FAMORASSEM);
                    }
                    else
                    {
                        if (type.IsPublic)
                            access.Add(AccessModifier.PUBLIC);
                        else if (type.IsNotPublic)
                            access.Add(AccessModifier.ASSEMBLY);
                    }

                    if (type.IsClass || type == SYSTEM_ENUM)
                    {
                        ClassTypeSymbol @class = new ClassTypeSymbol(typeName);
                        @class.NetType = type;
                        symbol = @class;
                        Backpatcher.Register(new ClassBackpatcher(@class, type));

                        ClassSpecifier cs = new ClassSpecifier();
                        if (type.IsAbstract)
                            cs.Add(ClassSpecifier.ABSTRACT);
                        if (type.IsSealed)
                            cs.Add(ClassSpecifier.FINAL);
                        @class.Specifier = cs;

                        @class.Access = access;

                        foreach (FieldInfo fi in type.GetFields(allMembersBinding))
                        {
                            if (fi.IsPrivate || fi.IsAssembly || fi.IsFamilyAndAssembly)
                                continue;

                            if (MirrorUtility.IsGenericType(fi.FieldType))
                                continue;

                            FieldSymbol field = null;
                            if (fi.IsLiteral)
                                field = new LiteralFieldSymbol(fi.Name);
                            else
                                field = new FieldSymbol(fi.Name);

                            field.NetInfo = fi;
                            Backpatcher.Register(new VariableBackpatcher(field, fi.FieldType));

                            FieldSpecifier fs = new FieldSpecifier();
                            if (fi.IsStatic)
                                fs.Add(FieldSpecifier.STATIC);
                            if (fi.IsInitOnly)
                                fs.Add(FieldSpecifier.READONLY);
                            field.Specifier = fs;

                            AccessModifier am = new AccessModifier();

                            if (fi.IsPublic)
                                am = AccessModifier.PUBLIC;
                            else if (fi.IsFamily)
                                am = AccessModifier.FAMILY;
                            else if (fi.IsPrivate)
                                am = AccessModifier.PRIVATE;
                            else if (fi.IsAssembly)
                                am = AccessModifier.ASSEMBLY;
                            else if (fi.IsFamilyOrAssembly)
                                am = AccessModifier.FAMORASSEM;
                            else if (fi.IsFamilyAndAssembly)
                                am = AccessModifier.FAMANDASSEM;

                            field.Access = am;

                            @class.Define(field);
                        }

                        IDictionary<MethodInfo, MethodSymbol> methodsMap = new Dictionary<MethodInfo, MethodSymbol>();

                        foreach (MethodInfo mi in type.GetMethods(allMembersBinding))
                        {
                            if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                continue;

                            if (MirrorUtility.IsGenericMethod(mi))
                                continue;

                            MethodSymbol method = new MethodSymbol(mi.Name);
                            method.NetBaseInfo = mi;
                            Backpatcher.Register(new MethodBackpatcher(method, mi.ReturnType));

                            methodsMap.Add(mi, method);

                            foreach (ParameterInfo pi in mi.GetParameters())
                            {
                                ArgumentSymbol arg = new ArgumentSymbol(pi.Name);
                                arg.NetInfo = pi;
                                method.Define(arg);

                                Backpatcher.Register(new VariableBackpatcher(arg, pi.ParameterType));
                            }

                            MethodSpecifier ms = new MethodSpecifier();
                            if (mi.IsStatic)
                                ms.Add(MethodSpecifier.STATIC);
                            if (mi.IsAbstract)
                                ms.Add(MethodSpecifier.ABSTRACT);
                            if (mi.IsFinal)
                                ms.Add(MethodSpecifier.FINAL);
                            if (mi.IsVirtual)
                                ms.Add(MethodSpecifier.VIRTUAL);
                            method.Specifier = ms;

                            AccessModifier am = new AccessModifier();
                            if (mi.IsPublic)
                                am = AccessModifier.PUBLIC;
                            else if (mi.IsFamily)
                                am = AccessModifier.FAMILY;
                            else if (mi.IsPrivate)
                                am = AccessModifier.PRIVATE;
                            else if (mi.IsAssembly)
                                am = AccessModifier.ASSEMBLY;
                            else if (mi.IsFamilyOrAssembly)
                                am = AccessModifier.FAMORASSEM;
                            else if (mi.IsFamilyAndAssembly)
                                am = AccessModifier.FAMANDASSEM;
                            method.Access = am;

                            @class.Define(method);
                        }

                        foreach (ConstructorInfo ci in type.GetConstructors(allMembersBinding))
                        {
                            if (ci.IsPrivate || ci.IsAssembly || ci.IsFamilyAndAssembly)
                                continue;

                            if (MirrorUtility.IsGenericMethod(ci))
                                continue;

                            MethodSymbol method = new MethodSymbol(ci.Name);
                            method.NetBaseInfo = ci;
                            Backpatcher.Register(new MethodBackpatcher(method, typeof(void)));

                            foreach (ParameterInfo pi in ci.GetParameters())
                            {
                                ArgumentSymbol arg = new ArgumentSymbol(pi.Name);
                                arg.NetInfo = pi;
                                method.Define(arg);

                                Backpatcher.Register(new VariableBackpatcher(arg, pi.ParameterType));
                            }

                            MethodSpecifier ms = new MethodSpecifier();
                            ms.Add(MethodSpecifier.CONSTRUCTOR);
                            if (ci.IsStatic)
                                ms.Add(MethodSpecifier.STATIC);
                            method.Specifier = ms;

                            AccessModifier am = new AccessModifier();
                            if (ci.IsPublic)
                                am = AccessModifier.PUBLIC;
                            else if (ci.IsFamily)
                                am = AccessModifier.FAMILY;
                            else if (ci.IsPrivate)
                                am = AccessModifier.PRIVATE;
                            else if (ci.IsAssembly)
                                am = AccessModifier.ASSEMBLY;
                            else if (ci.IsFamilyOrAssembly)
                                am = AccessModifier.FAMORASSEM;
                            else if (ci.IsFamilyAndAssembly)
                                am = AccessModifier.FAMANDASSEM;
                            method.Access = am;

                            @class.Define(method);
                        }

                        foreach (PropertyInfo pi in type.GetProperties(allMembersBinding))
                        {
                            MethodInfo[] accessors = pi.GetAccessors();
                            foreach (var mi in accessors)
                            {
                                if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                    goto skip;

                                if (MirrorUtility.IsGenericMethod(mi))
                                    goto skip;
                            }

                            PropertySymbol property = new PropertySymbol(pi.Name);
                            property.NetInfo = pi;
                            Backpatcher.Register(new PropertyBackpatcher(property, pi.PropertyType));

                            property.Access = AccessModifier.PUBLIC;

                            if (pi.CanRead && pi.GetGetMethod() != null)
                                property.GetMethodReference = methodsMap[pi.GetGetMethod()];

                            if (pi.CanWrite && pi.GetSetMethod() != null)
                                property.SetMethodReference = methodsMap[pi.GetSetMethod()];

                            try
                            {
                                @class.Define(property);
                            }
                            catch (SymbolAlreadyDefinedException) { }

                        skip: ;
                        }

                        /*
                        foreach (EventInfo ei in type.GetEvents(allMembersBinding))
                        {
                            SignalSymbol signal = new SignalSymbol(ei.Name);
                            signal.Access = AccessModifier.PUBLIC;
                            signal.AddMethodReference = methodsMap[ei.GetAddMethod()];
                            signal.RemoveMethodReference = methodsMap[ei.GetRemoveMethod()];
                            Backpatcher.Register(new SignalBackpatcher(ei.EventHandlerType));
                            @class.Define(signal);
                        }
                        */
                        // ---------------------------------------
                    }
                    else if (type.IsValueType)
                    {
                        if (type.IsEnum)
                        {
                            EnumTypeSymbol @enum = new EnumTypeSymbol(typeName);

                            @enum.Access = access;

                            @enum.NetType = type;
                            symbol = @enum;
                            Backpatcher.Register(new EnumBackpatcher(@enum, type));

                            foreach (FieldInfo fi in type.GetFields(staticMembersBinding))
                            {
                                LiteralFieldSymbol field = new LiteralFieldSymbol(fi.Name);
                                field.NetInfo = fi;
                                field.Access = AccessModifier.PUBLIC;
                                field.Specifier = FieldSpecifier.STATIC;

                                @enum.Define(field);
                            }
                        }
                        else
                        {
                            ValueTypeSymbol valueType = null;

                            if (type.IsPrimitive)
                                valueType = new PrimitiveTypeSymbol(typeName);
                            else
                                valueType = new StructTypeSymbol(typeName);

                            valueType.Access = access;

                            valueType.NetType = type;
                            symbol = valueType;
                            Backpatcher.Register(new ValueTypeBackpatcher(valueType, type));

                            foreach (FieldInfo fi in type.GetFields(allMembersBinding))
                            {
                                if (fi.IsPrivate || fi.IsAssembly || fi.IsFamilyAndAssembly)
                                    continue;

                                if (MirrorUtility.IsGenericType(fi.FieldType))
                                    continue;

                                FieldSymbol field = null;
                                if (fi.IsLiteral)
                                    field = new LiteralFieldSymbol(fi.Name);
                                else
                                    field = new FieldSymbol(fi.Name);

                                field.NetInfo = fi;
                                Backpatcher.Register(new VariableBackpatcher(field, fi.FieldType));

                                FieldSpecifier fs = new FieldSpecifier();
                                if (fi.IsStatic)
                                    fs.Add(FieldSpecifier.STATIC);
                                if (fi.IsInitOnly)
                                    fs.Add(FieldSpecifier.READONLY);
                                field.Specifier = fs;

                                AccessModifier am = new AccessModifier();
                                if (fi.IsPublic)
                                    am = AccessModifier.PUBLIC;
                                else if (fi.IsFamily)
                                    am = AccessModifier.FAMILY;
                                else if (fi.IsPrivate)
                                    am = AccessModifier.PRIVATE;
                                else if (fi.IsAssembly)
                                    am = AccessModifier.ASSEMBLY;
                                else if (fi.IsFamilyOrAssembly)
                                    am = AccessModifier.FAMORASSEM;
                                else if (fi.IsFamilyAndAssembly)
                                    am = AccessModifier.FAMANDASSEM;
                                field.Access = am;

                                valueType.Define(field);
                            }

                            IDictionary<MethodInfo, MethodSymbol> methodsMap = new Dictionary<MethodInfo, MethodSymbol>();

                            foreach (MethodInfo mi in type.GetMethods(allMembersBinding))
                            {
                                if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                    continue;

                                if (MirrorUtility.IsGenericMethod(mi))
                                    continue;

                                MethodSymbol method = new MethodSymbol(mi.Name);
                                method.NetBaseInfo = mi;
                                Backpatcher.Register(new MethodBackpatcher(method, mi.ReturnType));

                                methodsMap.Add(mi, method);

                                foreach (ParameterInfo pi in mi.GetParameters())
                                {
                                    ArgumentSymbol arg = new ArgumentSymbol(pi.Name);
                                    arg.NetInfo = pi;
                                    method.Define(arg);

                                    Backpatcher.Register(new VariableBackpatcher(arg, pi.ParameterType));
                                }

                                MethodSpecifier ms = new MethodSpecifier();
                                if (mi.IsStatic)
                                    ms.Add(MethodSpecifier.STATIC);
                                if (mi.IsAbstract)
                                    ms.Add(MethodSpecifier.ABSTRACT);
                                if (mi.IsFinal)
                                    ms.Add(MethodSpecifier.FINAL);
                                if (mi.IsVirtual)
                                    ms.Add(MethodSpecifier.VIRTUAL);
                                method.Specifier = ms;

                                AccessModifier am = new AccessModifier();
                                if (mi.IsPublic)
                                    am = AccessModifier.PUBLIC;
                                else if (mi.IsFamily)
                                    am = AccessModifier.FAMILY;
                                else if (mi.IsPrivate)
                                    am = AccessModifier.PRIVATE;
                                else if (mi.IsAssembly)
                                    am = AccessModifier.ASSEMBLY;
                                else if (mi.IsFamilyOrAssembly)
                                    am = AccessModifier.FAMORASSEM;
                                else if (mi.IsFamilyAndAssembly)
                                    am = AccessModifier.FAMANDASSEM;
                                method.Access = am;

                                valueType.Define(method);
                            }

                            foreach (ConstructorInfo ci in type.GetConstructors(allMembersBinding))
                            {
                                if (ci.IsPrivate || ci.IsAssembly || ci.IsFamilyAndAssembly)
                                    continue;

                                if (MirrorUtility.IsGenericMethod(ci))
                                    continue;

                                MethodSymbol method = new MethodSymbol(ci.Name);
                                method.NetBaseInfo = ci;
                                Backpatcher.Register(new MethodBackpatcher(method, typeof(void)));

                                foreach (ParameterInfo pi in ci.GetParameters())
                                {
                                    ArgumentSymbol arg = new ArgumentSymbol(pi.Name);
                                    arg.NetInfo = pi;
                                    method.Define(arg);

                                    Backpatcher.Register(new VariableBackpatcher(arg, pi.ParameterType));
                                }

                                MethodSpecifier ms = new MethodSpecifier();
                                ms.Add(MethodSpecifier.CONSTRUCTOR);
                                if (ci.IsStatic)
                                    ms.Add(MethodSpecifier.STATIC);
                                method.Specifier = ms;

                                AccessModifier am = new AccessModifier();
                                if (ci.IsPublic)
                                    am = AccessModifier.PUBLIC;
                                else if (ci.IsFamily)
                                    am = AccessModifier.FAMILY;
                                else if (ci.IsPrivate)
                                    am = AccessModifier.PRIVATE;
                                else if (ci.IsAssembly)
                                    am = AccessModifier.ASSEMBLY;
                                else if (ci.IsFamilyOrAssembly)
                                    am = AccessModifier.FAMORASSEM;
                                else if (ci.IsFamilyAndAssembly)
                                    am = AccessModifier.FAMANDASSEM;
                                method.Access = am;

                                valueType.Define(method);
                            }

                            foreach (PropertyInfo pi in type.GetProperties(allMembersBinding))
                            {
                                MethodInfo[] accessors = pi.GetAccessors();
                                foreach (var mi in accessors)
                                {
                                    if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                        goto skip;

                                    if (MirrorUtility.IsGenericMethod(mi))
                                        goto skip;
                                }

                                PropertySymbol property = new PropertySymbol(pi.Name);
                                property.NetInfo = pi;
                                Backpatcher.Register(new PropertyBackpatcher(property, pi.PropertyType));

                                property.Access = AccessModifier.PUBLIC;

                                if (pi.CanRead && pi.GetGetMethod() != null)
                                    property.GetMethodReference = methodsMap[pi.GetGetMethod()];

                                if (pi.CanWrite && pi.GetSetMethod() != null)
                                    property.SetMethodReference = methodsMap[pi.GetSetMethod()];

                                try
                                {
                                    valueType.Define(property);
                                }
                                catch (SymbolAlreadyDefinedException) { }

                                skip: ;
                            }
                        }
                    }
                    else if (type.IsInterface)
                    {
                        InterfaceTypeSymbol @interface = new InterfaceTypeSymbol(typeName);
                        @interface.Access = access;

                        @interface.NetType = type;
                        symbol = @interface;
                        Backpatcher.Register(new InterfaceBackpatcher(@interface, type));

                        IDictionary<MethodInfo, MethodSymbol> methodsMap = new Dictionary<MethodInfo, MethodSymbol>();

                        foreach (MethodInfo mi in type.GetMethods(allMembersBinding))
                        {
                            if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                continue;

                            if (MirrorUtility.IsGenericMethod(mi))
                                continue;

                            MethodSymbol method = new MethodSymbol(mi.Name);
                            method.NetBaseInfo = mi;
                            Backpatcher.Register(new MethodBackpatcher(method, mi.ReturnType));

                            methodsMap.Add(mi, method);

                            foreach (ParameterInfo pi in mi.GetParameters())
                            {
                                ArgumentSymbol arg = new ArgumentSymbol(pi.Name);
                                arg.NetInfo = pi;
                                method.Define(arg);

                                Backpatcher.Register(new VariableBackpatcher(arg, pi.ParameterType));
                            }

                            MethodSpecifier ms = new MethodSpecifier();
                            if (mi.IsStatic)
                                ms.Add(MethodSpecifier.STATIC);
                            if (mi.IsAbstract)
                                ms.Add(MethodSpecifier.ABSTRACT);
                            if (mi.IsFinal)
                                ms.Add(MethodSpecifier.FINAL);
                            if (mi.IsVirtual)
                                ms.Add(MethodSpecifier.VIRTUAL);
                            method.Specifier = ms;

                            AccessModifier am = new AccessModifier();
                            if (mi.IsPublic)
                                am = AccessModifier.PUBLIC;
                            else if (mi.IsFamily)
                                am = AccessModifier.FAMILY;
                            else if (mi.IsPrivate)
                                am = AccessModifier.PRIVATE;
                            else if (mi.IsAssembly)
                                am = AccessModifier.ASSEMBLY;
                            else if (mi.IsFamilyOrAssembly)
                                am = AccessModifier.FAMORASSEM;
                            else if (mi.IsFamilyAndAssembly)
                                am = AccessModifier.FAMANDASSEM;
                            method.Access = am;

                            @interface.Define(method);
                        }

                        foreach (PropertyInfo pi in type.GetProperties(allMembersBinding))
                        {
                            MethodInfo[] accessors = pi.GetAccessors();
                            foreach (var mi in accessors)
                            {
                                if (mi.IsPrivate || mi.IsAssembly || mi.IsFamilyAndAssembly)
                                    goto skip;

                                if (MirrorUtility.IsGenericMethod(mi))
                                    goto skip;
                            }

                            PropertySymbol property = new PropertySymbol(pi.Name);
                            property.NetInfo = pi;
                            Backpatcher.Register(new PropertyBackpatcher(property, pi.PropertyType));

                            property.Access = AccessModifier.PUBLIC;

                            if (pi.CanRead && pi.GetGetMethod() != null)
                                property.GetMethodReference = methodsMap[pi.GetGetMethod()];

                            if (pi.CanWrite && pi.GetSetMethod() != null)
                                property.SetMethodReference = methodsMap[pi.GetSetMethod()];

                            try
                            {
                                @interface.Define(property);
                            }
                            catch (SymbolAlreadyDefinedException) { }

                            skip: ;
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("Nierozpoznany typ: " + type.Assembly.FullName + " typ = " + type.FullName);
                    }

                    if (symbol != null)
                    {
                        scope.Define(symbol);
                    }
                }
            }

            Backpatcher.Run();        

        }
    }
}
