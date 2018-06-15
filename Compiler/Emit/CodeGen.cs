using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

using Compiler.AST;
using Compiler.Driver;
using Compiler.Symbols;

namespace Compiler.Emit
{
    /*
    public interface ICodeGen
    {
    
    }
    */

    public class CodeGen
    {
        Options options;

        ILGenerator ilgen;

        AppDomain app_domain;

        AssemblyName assembly_name;

        AssemblyBuilder assembly_builder;

        ModuleBuilder module_builder;

        IList<Type> classes;

        Label return_label;

        bool IsInsideTry { get; set; }

        void EnterExceptionBlock()
        {
            IsInsideTry = true;
        }

        void ExitExceptionBlock()
        {
            IsInsideTry = false;
        }

        Stack<LoopFrame> loop_stack;

        LoopFrame CurrentLoopFrame
        {
            get { return loop_stack.Count > 0 ? loop_stack.Peek() : null; }
        }

        void PushLoopFrame(LoopFrame frame)
        {
            loop_stack.Push(frame);
        }

        void PopLoopFrame()
        {
            loop_stack.Pop();
        }

        Stack<TypeBuilder> type_builder_stack;

        TypeBuilder CurrentTypeBuilder
        {
            get { return type_builder_stack.Count > 0 ? type_builder_stack.Peek() : null; }
        }

        void PushTypeBuilder(TypeBuilder builder)
        {
            type_builder_stack.Push(builder);
        }
        
        void PopTypeBuilder()
        {
            type_builder_stack.Pop();
        }

        LinkedList<string> namespace_list;

        void PushNamespace(NamespaceSymbol ns)
        {
            namespace_list.AddLast(ns.Name);
        }

        void PopNamespace()
        {
            namespace_list.RemoveLast();
        }

        string CurrentNamespace
        {
            get
            {
                if (namespace_list == null)
                    return "";

                StringBuilder sb = new StringBuilder();

                foreach (var ns in namespace_list)
                    sb.AppendFormat("{0}.", ns);

                return sb.ToString();
            }
        }

        void RegisterType(Type builder)
        {
            classes.Add(builder);
        }

        TypeAttributes GetAccess(INetObject symbol)
        {
            TypeAttributes attrs = new TypeAttributes();

            if (CurrentTypeBuilder != null)
            {
                if (symbol.Access.IsPublic)
                    attrs |= TypeAttributes.NestedPublic;
                else if (symbol.Access.IsFamily)
                    attrs |= TypeAttributes.NestedFamily;
                else if (symbol.Access.IsPrivate)
                    attrs |= TypeAttributes.NestedPrivate;
                else if (symbol.Access.IsAssembly)
                    attrs |= TypeAttributes.NestedAssembly;
                else if (symbol.Access.IsFamAndAssem)
                    attrs |= TypeAttributes.NestedFamANDAssem;
                else if (symbol.Access.IsFamOrAssem)
                    attrs |= TypeAttributes.NestedFamORAssem;
            }
            else
            {
                if (symbol.Access.IsPublic)
                    attrs |= TypeAttributes.Public;
                else if (symbol.Access.IsAssembly)
                    attrs |= TypeAttributes.NotPublic;
            }
            return attrs;
        }

        public CodeGen(Options options)
        {
            this.options = options;
        }
        
        public void BuildAssembly(IEnumerable<CompilationUnit> compilation_units)
        {
            app_domain = AppDomain.CurrentDomain;
            
            string output_name = this.options.OutputFileName;

            string dir = Path.GetDirectoryName(Path.GetFullPath(output_name));
            if (!Directory.Exists(dir))
                Report.Error.OutputDirectoryNotExists(dir);

            assembly_name = new AssemblyName();
            assembly_name.Name = Path.GetFileNameWithoutExtension(output_name);

            if (this.options.HasKeyFile)
            {
                string key_file = this.options.StrongNameKeyFile;
                try
                {
                    using (FileStream fs = new FileStream(key_file, FileMode.Open))
                    {
                        StrongNameKeyPair kp = new StrongNameKeyPair(fs);
                        kp.PublicKey.ToString();
                        assembly_name.KeyPair = kp;
                    }
                }
                catch (FileNotFoundException)
                {
                    Report.Error.MissingKeyFile(key_file);
                }
                catch (Exception)
                {
                    Report.Error.InvalidKeyFile(key_file);
                }
            }

            assembly_builder = app_domain.DefineDynamicAssembly(assembly_name, AssemblyBuilderAccess.Save, dir);

            module_builder = assembly_builder.DefineDynamicModule(assembly_name.Name, Path.GetFileName(output_name));
            
            classes = new List<Type>();
            loop_stack = new Stack<LoopFrame>();
            type_builder_stack = new Stack<TypeBuilder>();
            namespace_list = new LinkedList<string>();

            foreach (CompilationUnit unit in compilation_units)
                unit.GenerateTypes(this);

            foreach (CompilationUnit unit in compilation_units)
                unit.GenerateMembers(this);

            foreach (CompilationUnit unit in compilation_units)
                unit.GenerateBodies(this);
            
            PEFileKinds kind = PEFileKinds.ConsoleApplication;

            switch (this.options.Target)
            {
                case Target.Exe:
                    kind = PEFileKinds.ConsoleApplication;
                    break;

                case Target.WinExe:
                    kind = PEFileKinds.WindowApplication;
                    break;

                case Target.Library:
                    kind = PEFileKinds.Dll;
                    break;

                case Target.Module:
                    Report.Error.ModuleTargetNotSupported();
                    break;
            }
            
            if (this.options.NeedsEntryPoint)
            {
                MethodInfo main = null;

                foreach (Type type in classes)
                {
                    MethodInfo candidate = type.GetMethod(MethodSymbol.MAIN, BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic);

                    if (candidate != null)
                    {
                        if (main == null)
                            main = candidate;
                        else
                            Report.Error.DuplicateEntryPoint();
                    }
                }

                if (main == null)
                    Report.Error.NoEntryPoint();

                assembly_builder.SetEntryPoint(main, kind);
            }

            try
            {
                assembly_builder.Save(Path.GetFileName(output_name));
            }
            catch (IOException)
            {
                Report.Error.IOError(Path.GetFileName(output_name));
            }
        }

        public void GenerateTypes(CompilationUnit cu)
        {
            if (cu.Namespaces != null)
                foreach (var ns in cu.Namespaces)
                    ns.GenerateTypes(this);
            if (cu.TypeDecls != null)
                foreach (var typedecl in cu.TypeDecls)
                    typedecl.GenerateTypes(this);
        }

        public void GenerateMembers(CompilationUnit cu)
        {
            if (cu.Namespaces != null)
                foreach (var ns in cu.Namespaces)
                    ns.GenerateMembers(this);
            if (cu.TypeDecls != null)
                foreach (var typedecl in cu.TypeDecls)
                    typedecl.GenerateMembers(this);
        }

        public void GenerateBodies(CompilationUnit cu)
        {
            if (cu.Namespaces != null)
                foreach (var ns in cu.Namespaces)
                    ns.GenerateBodies(this);
            if (cu.TypeDecls != null)
                foreach (var typedecl in cu.TypeDecls)
                    typedecl.GenerateBodies(this);
        }

        public void GenerateTypes(NamespaceDecl @namespace)
        {
            PushNamespace(@namespace.Symbol);

            if (@namespace.Namespaces != null)
                foreach (var ns in @namespace.Namespaces)
                    ns.GenerateTypes(this);
            if (@namespace.TypeDecls != null)
                foreach (var typedecl in @namespace.TypeDecls)
                    typedecl.GenerateTypes(this);

            PopNamespace();
        }
        
        public void GenerateMembers(NamespaceDecl @namespace)
        {
            PushNamespace(@namespace.Symbol);

            if (@namespace.Namespaces != null)
                foreach (var ns in @namespace.Namespaces)
                    ns.GenerateMembers(this);
            if (@namespace.TypeDecls != null)
                foreach (var typedecl in @namespace.TypeDecls)
                    typedecl.GenerateMembers(this);

            PopNamespace();
        }

        public void GenerateBodies(NamespaceDecl @namespace)
        {
            PushNamespace(@namespace.Symbol);

            if (@namespace.Namespaces != null)
                foreach (var ns in @namespace.Namespaces)
                    ns.GenerateBodies(this);
            if (@namespace.TypeDecls != null)
                foreach (var typedecl in @namespace.TypeDecls)
                    typedecl.GenerateBodies(this);

            PopNamespace();
        }

        public void Generate(ClassDecl @class)
        {
            ClassTypeSymbol symbol = @class.Symbol;

            TypeAttributes attrs = new TypeAttributes();

            attrs |= TypeAttributes.BeforeFieldInit;

            attrs |= GetAccess(symbol);

            if (symbol.IsFinal)
                attrs |= TypeAttributes.Sealed;

            if (symbol.IsAbstract)
                attrs |= TypeAttributes.Abstract;

            TypeBuilder builder = null;

            if (CurrentTypeBuilder != null)
                builder = CurrentTypeBuilder.DefineNestedType(symbol.Name, attrs);
            else
                builder = module_builder.DefineType(CurrentNamespace + symbol.Name.ToString(), attrs);

            symbol.NetType = builder;
        }
        
        public void GenerateTypes(ClassDecl @class)
        {
            @class.Generate(this);

            PushTypeBuilder(@class.Symbol.NetType as TypeBuilder);

            if (@class.TypeDecls != null)
                foreach (var typedecl in @class.TypeDecls)
                    typedecl.GenerateTypes(this);

            PopTypeBuilder();
        }

        public void GenerateMembers(ClassDecl @class)
        {
            ClassTypeSymbol symbol = @class.Symbol;
            TypeBuilder builder = @class.Symbol.NetType as TypeBuilder;
            builder.SetParent(symbol.BaseClass.NetType);

            if (symbol.Interfaces != null)
                foreach (var interface_symbol in symbol.Interfaces)
                    builder.AddInterfaceImplementation(interface_symbol.NetType);
            
            PushTypeBuilder(@class.Symbol.NetType as TypeBuilder);

            if (@class.TypeDecls != null)
                foreach (var typedecl in @class.TypeDecls)
                    typedecl.GenerateMembers(this);

            if (@class.Methods != null)
                foreach (var method in @class.Methods)
                    method.Generate(this);

            if (@class.Properties != null)
            {
                foreach (var property in @class.Properties)
                    property.Generate(this);
                foreach (var property in @class.Properties)
                    property.GenerateMembers(this);
            }

            if (@class.Signals != null)
            {
                foreach (var signal in @class.Signals)
                    signal.Generate(this);
                foreach (var signal in @class.Signals)
                    signal.GenerateMembers(this);
            }

            if (@class.Fields != null)
                foreach (var field in @class.Fields)
                    field.Generate(this);

            PopTypeBuilder();
        }

        public void GenerateBodies(ClassDecl @class)
        {
            PushTypeBuilder(@class.Symbol.NetType as TypeBuilder);

            if (@class.TypeDecls != null)
                foreach (var typedecl in @class.TypeDecls)
                    typedecl.GenerateBodies(this);

            if (@class.Methods != null)
                foreach (var method in @class.Methods)
                    method.GenerateBody(this);

            if (@class.Properties != null)
                foreach (var property in @class.Properties)
                    property.GenerateBodies(this);

            if (@class.Signals != null)
                foreach (var signal in @class.Signals)
                    signal.GenerateBodies(this);

            PopTypeBuilder();
           
            TypeBuilder builder = @class.Symbol.NetType as TypeBuilder;
            Type baked_class = builder.CreateType();
            RegisterType(baked_class);
        }

        public void Generate(StructDecl @struct)
        {
            StructTypeSymbol symbol = @struct.Symbol;

            TypeAttributes attrs = new TypeAttributes();

            attrs |= TypeAttributes.BeforeFieldInit | TypeAttributes.Sealed | TypeAttributes.SequentialLayout;

            attrs |= GetAccess(symbol);

            TypeBuilder builder = null;

            if (CurrentTypeBuilder != null)
                builder = CurrentTypeBuilder.DefineNestedType(symbol.Name, attrs);
            else
                builder = module_builder.DefineType(CurrentNamespace + symbol.Name.ToString(), attrs);

            symbol.NetType = builder;
        }

        public void GenerateTypes(StructDecl @struct)
        {
            @struct.Generate(this);

            PushTypeBuilder(@struct.Symbol.NetType as TypeBuilder);

            if (@struct.TypeDecls != null)
                foreach (var typedecl in @struct.TypeDecls)
                    typedecl.GenerateTypes(this);

            PopTypeBuilder();
        }

        public void GenerateMembers(StructDecl @struct)
        {
            StructTypeSymbol symbol = @struct.Symbol;
            TypeBuilder builder = @struct.Symbol.NetType as TypeBuilder;
            builder.SetParent(symbol.BaseClass.NetType);
            if (symbol.Interfaces != null)
                foreach (var interface_symbol in symbol.Interfaces)
                    builder.AddInterfaceImplementation(interface_symbol.NetType);

            PushTypeBuilder(@struct.Symbol.NetType as TypeBuilder);

            if (@struct.TypeDecls != null)
                foreach (var typedecl in @struct.TypeDecls)
                    typedecl.GenerateMembers(this);

            if (@struct.Methods != null)
                foreach (var method in @struct.Methods)
                    method.Generate(this);

            if (@struct.Fields != null)
                foreach (var field in @struct.Fields)
                    field.Generate(this);

            PopTypeBuilder();
        }

        public void GenerateBodies(StructDecl @struct)
        {
            PushTypeBuilder(@struct.Symbol.NetType as TypeBuilder);

            if (@struct.TypeDecls != null)
                foreach (var typedecl in @struct.TypeDecls)
                    typedecl.GenerateBodies(this);

            if (@struct.Methods != null)
                foreach (var method in @struct.Methods)
                    method.GenerateBody(this);

            PopTypeBuilder();

            TypeBuilder builder = @struct.Symbol.NetType as TypeBuilder;
            Type baked_class = builder.CreateType();
            RegisterType(baked_class);
        }

        public void Generate(InterfaceDecl @interface)
        {
            InterfaceTypeSymbol symbol = @interface.Symbol;

            TypeAttributes attrs = new TypeAttributes();

            attrs |= TypeAttributes.Interface | TypeAttributes.Abstract;

            attrs |= GetAccess(symbol);

            TypeBuilder builder = null;

            if (CurrentTypeBuilder != null)
                builder = CurrentTypeBuilder.DefineNestedType(symbol.Name, attrs);
            else
                builder = module_builder.DefineType(CurrentNamespace + symbol.Name.ToString(), attrs);

            symbol.NetType = builder;
        }

        public void GenerateTypes(InterfaceDecl @interface)
        {
            @interface.Generate(this);
        }

        public void GenerateMembers(InterfaceDecl @interface)
        {
            InterfaceTypeSymbol symbol = @interface.Symbol;
            TypeBuilder builder = @interface.Symbol.NetType as TypeBuilder;
            if (symbol.Interfaces != null)
                foreach (var interface_symbol in symbol.Interfaces)
                    builder.AddInterfaceImplementation(interface_symbol.NetType);

            PushTypeBuilder(@interface.Symbol.NetType as TypeBuilder);

            if (@interface.Methods != null)
                foreach (var method in @interface.Methods)
                    method.Generate(this);

            PopTypeBuilder();
        }

        public void GenerateBodies(InterfaceDecl @interface)
        {
            TypeBuilder builder = @interface.Symbol.NetType as TypeBuilder;
            Type baked_class = builder.CreateType();
            RegisterType(baked_class);
        }
                
        public void Generate(EnumDecl @enum)
        {
            EnumTypeSymbol symbol = @enum.Symbol;

            TypeAttributes attrs = new TypeAttributes();

            attrs |= GetAccess(symbol);

            attrs |= TypeAttributes.Sealed;

            TypeBuilder builder = null;

            if (CurrentTypeBuilder != null)
                builder = CurrentTypeBuilder.DefineNestedType(symbol.Name, attrs);
            else
                builder = module_builder.DefineType(CurrentNamespace + symbol.Name.ToString(), attrs);

            builder.SetParent(symbol.BaseClass.NetType);

            symbol.NetType = builder;
        }

        public void GenerateMembers(EnumDecl @enum)
        {
            if (@enum.Fields != null)
                foreach (var field in @enum.Fields)
                    field.Generate(this);
        }

        public void Generate(SignalDecl signal)
        {
            SignalSymbol symbol = signal.Symbol;

            Type type = signal.Symbol.Type.NetType;

            EventBuilder builder = CurrentTypeBuilder.DefineEvent(symbol.Name, EventAttributes.None, type);

            symbol.NetBuilder = builder;
        }

        public void GenerateMembers(SignalDecl signal)
        {
            SignalSymbol symbol = signal.Symbol;

            if (signal.DelegateField != null)
                signal.DelegateField.Generate(this);

            if (signal.AddMethodDecl != null)
                signal.AddMethodDecl.Generate(this);

            if (signal.RemoveMethodDecl != null)
                signal.RemoveMethodDecl.Generate(this);
        }

        public void GenerateBodies(SignalDecl signal)
        {
            SignalSymbol symbol = signal.Symbol;
            EventBuilder builder = signal.Symbol.NetBuilder;

            if (signal.AddMethodDecl != null)
            {
                signal.AddMethodDecl.GenerateBody(this);
                builder.SetAddOnMethod((MethodBuilder)symbol.AddMethodReference.NetBaseInfo);
            }

            if (signal.RemoveMethodDecl != null)
            {
                signal.RemoveMethodDecl.GenerateBody(this);
                builder.SetRemoveOnMethod((MethodBuilder)symbol.RemoveMethodReference.NetBaseInfo);
            }
        }

        public void Generate(PropertyDecl property)
        {
            PropertySymbol symbol = property.Symbol;

            Type type = property.Symbol.Type.NetType;

            PropertyBuilder builder = CurrentTypeBuilder.DefineProperty(symbol.Name, PropertyAttributes.None, type, new Type[] { type });

            symbol.NetInfo = builder;
        }

        public void GenerateMembers(PropertyDecl property)
        {
            PropertySymbol symbol = property.Symbol;

            if (property.GetMethodDecl != null)
                property.GetMethodDecl.Generate(this);

            if (property.SetMethodDecl != null)
                property.SetMethodDecl.Generate(this);
        }

        public void GenerateBodies(PropertyDecl property)
        {
            PropertySymbol symbol = property.Symbol;
            PropertyBuilder builder = (PropertyBuilder)property.Symbol.NetInfo;

            if (property.SetMethodDecl != null)
            {
                property.SetMethodDecl.GenerateBody(this);
                builder.SetSetMethod((MethodBuilder)symbol.SetMethodReference.NetBaseInfo);
            }

            if (property.GetMethodDecl != null)
            {
                property.GetMethodDecl.GenerateBody(this);
                builder.SetGetMethod((MethodBuilder)symbol.GetMethodReference.NetBaseInfo);
            }
        }

        public void Generate(FieldDecl field)
        {
            FieldSymbol symbol = field.Symbol;

            FieldAttributes attrs = new FieldAttributes();

            if (symbol.Access.IsPublic)
                attrs |= FieldAttributes.Public;
            else if (symbol.Access.IsFamily)
                attrs |= FieldAttributes.Family;
            else if (symbol.Access.IsPrivate)
                attrs |= FieldAttributes.Private;
            else if (symbol.Access.IsAssembly)
                attrs |= FieldAttributes.Assembly;
            else if (symbol.Access.IsFamAndAssem)
                attrs |= FieldAttributes.FamANDAssem;
            else if (symbol.Access.IsFamOrAssem)
                attrs |= FieldAttributes.FamORAssem;

            if (symbol.IsStatic)
                attrs |= FieldAttributes.Static;

            Type type = symbol.Type.NetType;

            FieldBuilder builder = CurrentTypeBuilder.DefineField(symbol.Name, type, attrs);

            symbol.NetInfo = builder;
        }

        public void Generate(LiteralFieldDecl field)
        {
            LiteralFieldSymbol symbol = field.Symbol;

            FieldAttributes attrs = new FieldAttributes();

            attrs |= FieldAttributes.Literal;

            if (symbol.Access.IsPublic)
                attrs |= FieldAttributes.Public;
            else if (symbol.Access.IsFamily)
                attrs |= FieldAttributes.Family;
            else if (symbol.Access.IsPrivate)
                attrs |= FieldAttributes.Private;
            else if (symbol.Access.IsAssembly)
                attrs |= FieldAttributes.Assembly;
            else if (symbol.Access.IsFamAndAssem)
                attrs |= FieldAttributes.FamANDAssem;
            else if (symbol.Access.IsFamOrAssem)
                attrs |= FieldAttributes.FamORAssem;

            if (symbol.IsStatic)
                attrs |= FieldAttributes.Static;

            Type type = symbol.Type.NetType;

            FieldBuilder builder = CurrentTypeBuilder.DefineField(symbol.Name, type, attrs);

            LiteralExpression literal = (LiteralExpression)field.Expr;

            builder.SetConstant(literal.Data);

            symbol.NetInfo = builder;
        }

        public void Generate(MethodDecl method)
        {
            MethodSymbol symbol = method.Symbol;

            MethodAttributes attrs = new MethodAttributes();
            
            attrs |= MethodAttributes.HideBySig;

            if (symbol.Access.IsPublic)
                attrs |= MethodAttributes.Public;
            else if (symbol.Access.IsFamily)
                attrs |= MethodAttributes.Family;
            else if (symbol.Access.IsPrivate)
                attrs |= MethodAttributes.Private;
            else if (symbol.Access.IsAssembly)
                attrs |= MethodAttributes.Assembly;
            else if (symbol.Access.IsFamAndAssem)
                attrs |= MethodAttributes.FamANDAssem;
            else if (symbol.Access.IsFamOrAssem)
                attrs |= MethodAttributes.FamORAssem;

            if (symbol.IsStatic)
                attrs |= MethodAttributes.Static;

            if (symbol.IsVirtual)
                attrs |= MethodAttributes.Virtual;

            if (symbol.IsAbstract)
                attrs |= MethodAttributes.Abstract | MethodAttributes.Virtual | MethodAttributes.NewSlot;

            if (symbol.IsNew)
                attrs |= MethodAttributes.NewSlot;

            if (symbol.IsFinal)
                attrs |= MethodAttributes.Final;

            //attrs |= MethodAttributes.SpecialName;

            Type return_type = symbol.ReturnType.NetType;

            int arguments = symbol.ArgumentsCount;

            Type[] parameter_types = new Type[arguments];

            IList<IType> formal_types = symbol.GetFormalTypes();
            for (int i = 0; i < arguments; ++i)
            {
                parameter_types[i] = formal_types[i].NetType;
            }

            MethodBase builder = null;

            if (symbol.IsConstructor) // method is CtorDecl || method is CCtorDecl
            {
                builder = CurrentTypeBuilder.DefineConstructor(attrs, CallingConventions.Standard, parameter_types);
            }
            else
            {
                builder = CurrentTypeBuilder.DefineMethod(method.Symbol.Name, attrs, return_type, parameter_types);
            }
            
            if (symbol.IsRuntimeManaged)
            {
                if(symbol.IsConstructor)
                    ((ConstructorBuilder)builder).SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
                else
                    ((MethodBuilder)builder).SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
            }

            symbol.NetBaseInfo = builder;
        }

        public void GenerateBody(MethodDecl method)
        {
            if (method.Symbol.IsRuntimeManaged)
                return;

            MethodBuilder builder = (MethodBuilder)method.Symbol.NetBaseInfo;
            ilgen = builder.GetILGenerator();
            return_label = ilgen.DefineLabel();
            
            //foreach (var local in method.Symbol.GetLocals())
            //    local.NetBuilder = ilgen.DeclareLocal(local.Type.NetType);

            if (method.Body != null)
            {
                ilgen.Emit(OpCodes.Nop);
                method.Body.GenerateStatement(this);
            }

            ilgen.MarkLabel(return_label);
            ilgen.Emit(OpCodes.Ret);

            ilgen = null;
        }

        public void GenerateBody(CtorDecl ctor)
        {
            if (ctor.Symbol.IsRuntimeManaged)
                return;

            ConstructorBuilder builder = (ConstructorBuilder)ctor.Symbol.NetBaseInfo;
            ilgen = builder.GetILGenerator();
            return_label = ilgen.DefineLabel();

            if (ctor.CtorChain != null)
                ctor.CtorChain.GenerateAsStatement(this);

            if (ctor.Body != null)
                ctor.Body.GenerateStatement(this);

            ilgen.MarkLabel(return_label);
            ilgen.Emit(OpCodes.Ret);

            ilgen = null;
        }

        public void GenerateBody(CCtorDecl ctor)
        {
            ConstructorBuilder builder = (ConstructorBuilder)ctor.Symbol.NetBaseInfo;
            ilgen = builder.GetILGenerator();
            return_label = ilgen.DefineLabel();

            if (ctor.Body != null)
                ctor.Body.GenerateStatement(this);

            ilgen.MarkLabel(return_label);
            ilgen.Emit(OpCodes.Ret);

            ilgen = null;
        }
        
        public void Generate(ExplicitlyTypedLocalDecl local)
        {
            foreach (var declarator in local.Declarators)
                declarator.Generate(this);
        }
        
        public void Generate(ImplicitlyTypedLocalDecl var_local)
        {
            var_local.Declarator.Generate(this);
        }

        public void Generate(VariableDeclarator declarator)
        {
            LocalVariableSymbol symbol = declarator.Symbol;
            symbol.NetBuilder = ilgen.DeclareLocal(symbol.Type.NetType);
            if (declarator.HasInitialValue)
                declarator.Initializer.GenerateStatement(this);
        }

        public void Generate(Statement statement)
        {
            throw new NotSupportedException();
        }

        public void Generate(Assignment expression)
        {
            EmitAssignment(expression);
            expression.LeftHandSide.GenerateRValue(this);
        }

        public void GenerateAsStatement(Assignment expression)
        {
            EmitAssignment(expression);
        }

        private void EmitAssignment(Assignment expression)
        {
            /*
            // a = b (jako Statement)
            
            [a] (l-value pre)
            [b] (r-value)
            [a] (l-value post)
            */

            expression.LeftHandSide.GenerateLValuePre(this);
            expression.RightHandSide.GenerateRValue(this);
            expression.LeftHandSide.GenerateLValuePost(this);
        }

        public void Generate(LocalDeclStatement statement)
        {
            if (statement.Locals != null)
                statement.Locals.Generate(this);
        }

        public void Generate(BlockStatement statement)
        {
            if (statement.Statements != null)
                foreach (var stmt in statement.Statements)
                    stmt.GenerateStatement(this);
        }

        public void Generate(ContinueStatement statement)
        {
            ilgen.Emit(OpCodes.Br, this.CurrentLoopFrame.ContinueLabel);
        }

        public void Generate(BreakStatement statement)
        {
            ilgen.Emit(OpCodes.Br, this.CurrentLoopFrame.BreakLabel);
        }

        public void Generate(EmptyStatement statement)
        {

        }

        public void Generate(LabeledStatement statement)
        {
            LabelSymbol symbol = statement.Symbol;
            Label label = ilgen.DefineLabel();
            symbol.NetLabel = label;
            ilgen.MarkLabel(label);
            if (statement.Statement != null)
                statement.Statement.GenerateStatement(this);
        }

        public void Generate(GotoStatement statement)
        {
            LabelSymbol symbol = statement.Symbol;
            Label label = symbol.NetLabel;
            ilgen.Emit(OpCodes.Br, label);
        }

        public void Generate(ReturnStatement statement)
        {
            if (statement.Expression != null)
            {
                statement.Expression.GenerateRValue(this);
            }
            EmitReturn();
        }

        public void Generate(ThrowStatement statement)
        {
            if (statement.Expression != null)
            {
                statement.Expression.GenerateRValue(this);
                ilgen.Emit(OpCodes.Throw);
            }
            else // throw; -> rethrow
            {
                ilgen.Emit(OpCodes.Rethrow);
            }
        }

        public void Generate(TryStatement statement)
        {
            EnterExceptionBlock();

            Label block_end = ilgen.BeginExceptionBlock();

            statement.ProtectedBlock.GenerateStatement(this);

            if (statement.CatchClauses != null)
            {
                foreach (var clause in statement.CatchClauses)
                {
                    if (clause.Symbol != null)
                    {
                        LocalVariableSymbol symbol = clause.Symbol;
                        LocalBuilder e_builder = ilgen.DeclareLocal(symbol.Type.NetType);
                        symbol.NetBuilder = e_builder;

                        ilgen.BeginCatchBlock(symbol.Type.NetType);
                        Emit_Stloc(e_builder);
                    }
                    else
                    {
                        ilgen.BeginCatchBlock(typeof(object));
                        ilgen.Emit(OpCodes.Pop);
                    }
                    clause.Block.GenerateStatement(this);
                }
            }

            if (statement.FinallyClause != null)
            {
                ilgen.BeginFinallyBlock();
                statement.FinallyClause.Block.GenerateStatement(this);
            }

            ilgen.EndExceptionBlock();

            ExitExceptionBlock();
        }

        public void Generate(IfStatement statement)
        {
            /*
            // if (Condition) TrueBlock
            
            [Condition]
            br.false l1
            [TrueBlock]
            l1:
                 
            // if (Condition) TrueBlock else FalseBlock
             
            [Condition]
            br.false l1
            [TrueBlock]
            br l2
            l1:
            [FalseBlock]
            l2:
            */

            statement.Condition.GenerateRValue(this);
            Label l1 = ilgen.DefineLabel();
            ilgen.Emit(OpCodes.Brfalse, l1);
            statement.TrueBlock.GenerateStatement(this);

            if (statement.FalseBlock == null)
            {
                ilgen.MarkLabel(l1);
            }
            else
            {
                Label l2 = ilgen.DefineLabel();
                ilgen.Emit(OpCodes.Br, l2);
                ilgen.MarkLabel(l1);
                statement.FalseBlock.GenerateStatement(this);
                ilgen.MarkLabel(l2);
            }
        }

        public void Generate(ForStatement statement)
        {
            /*
            // for (Initializer;Condition;Iteration) Block
    
            [Initializer]
            l1:
            [Condition]
            br.false l2
            [Block]
            l3:
            [Iteration]        
            br l1
            l2:
            */

            Label l1 = ilgen.DefineLabel();
            Label l2 = ilgen.DefineLabel(); // break
            Label l3 = ilgen.DefineLabel(); // continue

            PushLoopFrame(new LoopFrame(l2, l3));

            if (statement.Initializer != null)
                statement.Initializer.GenerateAsStatement(this);
            else if (statement.LocalDecl != null)
                statement.LocalDecl.Generate(this);

            ilgen.MarkLabel(l1);
            if (statement.Condition != null)
            {
                statement.Condition.GenerateRValue(this);
                ilgen.Emit(OpCodes.Brfalse, l2);
            }

            if (statement.Block != null)
                statement.Block.GenerateStatement(this);

            ilgen.MarkLabel(l3);
            if (statement.Iteration != null)
                statement.Iteration.GenerateAsStatement(this);
            ilgen.Emit(OpCodes.Br, l1);
            ilgen.MarkLabel(l2);

            PopLoopFrame();
        }

        public void Generate(WhileStatement statement)
        {
            /*
            // while (Condition) Block
       
            l1:
            [Condition]
            br.false l2
            [Block]
            br l1
            l2:
            */

            Label l1 = ilgen.DefineLabel();
            Label l2 = ilgen.DefineLabel();

            PushLoopFrame(new LoopFrame(l2, l1));

            ilgen.MarkLabel(l1);
            statement.Condition.GenerateRValue(this);
            ilgen.Emit(OpCodes.Brfalse, l2);
            statement.Block.GenerateStatement(this);
            ilgen.Emit(OpCodes.Br, l1);
            ilgen.MarkLabel(l2);

            PopLoopFrame();
        }

        public void Generate(DoStatement statement)
        {
            /*
            // do Block while (Condition);
       
            l1:            
            [Block]
            l2:
            [Condition]
            br.true l1     
            l3:
            */

            Label l1 = ilgen.DefineLabel();
            Label l2 = ilgen.DefineLabel(); // continue
            Label l3 = ilgen.DefineLabel(); // break

            PushLoopFrame(new LoopFrame(l3, l2));

            ilgen.MarkLabel(l1);
            statement.Block.GenerateStatement(this);
            ilgen.MarkLabel(l2);
            statement.Condition.GenerateRValue(this);
            ilgen.Emit(OpCodes.Brtrue, l1);
            ilgen.MarkLabel(l3);

            PopLoopFrame();
        }

        /*
        public void Generate(ForeachStatement statement)
        {
            LocalBuilder enumerator = ilgen.DeclareLocal(type);
            EmitCall(get_enumerator);
            Emit_Stloc(enumerator);

            EnterExceptionBlock();

            Label block_end = ilgen.BeginExceptionBlock();

            Label l1 = ilgen.DefineLabel();

            ilgen.MarkLabel(l1);
            Emit_Ldloc(enumerator);

            ilgen.BeginFinallyBlock();
            statement.DisposeBlock.GenerateStatement(this);
            ilgen.EndExceptionBlock();

            ExitExceptionBlock();
        }
        */

        public void GenerateAsStatement(StatementExpression expression)
        {
            expression.GenerateRValue(this);
            ilgen.Emit(OpCodes.Pop);
        }

        public void Generate(Expression expression)
        {

        }

        public void GenerateLValuePre(Expression expression)
        {

        }

        public void GenerateLValuePost(Expression expression)
        {

        }

        public void GenerateAddressOf(Expression expression)
        {
            LocalBuilder temp_local = ilgen.DeclareLocal(expression.EvalType.NetType);
            expression.GenerateRValue(this);
            Emit_Stloc(temp_local);
            Emit_LdlocA(temp_local);
        }

        public void Generate(ArgumentExpression expression)
        {
            ArgumentSymbol symbol = expression.Symbol;

            int index = symbol.Index;
            if (!expression.IsInStatic)
                ++index;

            Emit_Ldarg(index);
        }

        public void GenerateLValuePre(ArgumentException expression)
        {
            /*if (symbol.Type.NetType.IsByRef)
            {

            }
            */ 
        }
        
        public void GenerateLValuePost(ArgumentExpression expression)
        {
            ArgumentSymbol symbol = expression.Symbol;

            int index = symbol.Index;
            if (!expression.IsInStatic)
                ++index;

            Emit_Starg(index);
        }

        public void GenerateAddressOf(ArgumentExpression expression)
        {
            ArgumentSymbol symbol = expression.Symbol;
            Type type = symbol.Type.NetType;

            int index = symbol.Index;
            if (!expression.IsInStatic)
                ++index;

            if (type.IsByRef)
            {
                Emit_Ldarg(index);
            }
            else
            {
                Emit_LdargA(index);
            }
        }

        public void Generate(LocalExpression expression)
        {
            LocalVariableSymbol symbol = expression.Symbol;
            LocalBuilder builder = symbol.NetBuilder;
            Emit_Ldloc(builder);
        }

        public void GenerateLValuePost(LocalExpression expression)
        {
            LocalVariableSymbol symbol = expression.Symbol;
            LocalBuilder builder = symbol.NetBuilder;

            /*if (symbol.Type.NetType.IsByRef)
            {
                Emit_Sti(expression.EvalType.NetType.GetElementType());
            }
            else*/
            {
                Emit_Stloc(builder);
            }
        }

        public void GenerateAddressOf(LocalExpression expression)
        {
            LocalVariableSymbol symbol = expression.Symbol;
            LocalBuilder builder = symbol.NetBuilder;
            Emit_LdlocA(builder);
        }

        public void Generate(FieldExpression expression)
        {
            FieldSymbol symbol = expression.Symbol;
            FieldInfo info = symbol.NetInfo;

            if (symbol.IsStatic)
            {
                ilgen.Emit(OpCodes.Ldsfld, info);
            }
            else
            {
                expression.Instance.GenerateRValue(this);
                ilgen.Emit(OpCodes.Ldfld, info);
            }
        }

        public void GenerateLValuePre(FieldExpression expression)
        {
            FieldSymbol symbol = expression.Symbol;
            FieldInfo info = symbol.NetInfo;

            /*if (symbol.Type.NetType.IsByRef)
            {

            }
            else*/ if (!symbol.IsStatic)
            {
                Type type = expression.Instance.EvalType.NetType;
                if (NeedAddress(type))
                    expression.Instance.GenerateAddressOf(this);
                else
                    expression.Instance.GenerateRValue(this);
            }
        }

        public void GenerateLValuePost(FieldExpression expression)
        {
            FieldSymbol symbol = expression.Symbol;
            FieldInfo info = symbol.NetInfo;

            /*if (symbol.Type.NetType.IsByRef)
            {
                Emit_Sti(symbol.Type.NetType.GetElementType());
            }
            else*/ if (symbol.IsStatic)
            {
                ilgen.Emit(OpCodes.Stsfld, info);
            }
            else
            {
                ilgen.Emit(OpCodes.Stfld, info);
            }
        }

        public void GenerateAddressOf(FieldExpression expression)
        {
            FieldSymbol symbol = expression.Symbol;
            FieldInfo info = symbol.NetInfo;

            if (symbol.IsStatic)
            {
                ilgen.Emit(OpCodes.Ldsflda, info);
            }
            else
            {
                Type type = expression.Instance.EvalType.NetType;
                if (type.IsByRef)
                {
                    Type element_type = type.GetElementType();

                    //if(element_type.IsValueType) ??
                    expression.Instance.GenerateRValue(this);
                }
                else
                {
                    if (type.IsValueType)
                        expression.Instance.GenerateAddressOf(this);
                    else
                        expression.Instance.GenerateRValue(this);
                }
                ilgen.Emit(OpCodes.Ldflda, info);
            }
        }

        public void GenerateAddressOf(ThisExpression expression)
        {
            EmitThisPointer();
        }

        public void GenerateAddressOf(BaseExpression expression)
        {
            EmitThisPointer();
        }

        public void Generate(MethodCallExpression expression)
        {
            if (!expression.IsStaticCall)
            {
                Expression instance = expression.Instance;
                Type type = instance.EvalType.NetType;

                if (type.IsByRef)
                    type = type.GetElementType();

                if (type.IsValueType)
                    expression.Instance.GenerateAddressOf(this);
                else
                    expression.Instance.GenerateRValue(this);
            }

            if (expression.Arguments != null)
                foreach (var arg in expression.Arguments)
                    arg.GenerateRValue(this);

            MethodSymbol symbol = expression.Symbol;

            if (expression.IsPolymorphicCall)
            {
                EmitCall(symbol);
            }
            else
            {
                EmitNonPolymorphicCall(symbol);
            }
        }

        public void GenerateAsStatement(MethodCallExpression expression)
        {
            expression.GenerateRValue(this);

            MethodSymbol symbol = expression.Symbol;

            Type return_type = null;

            if (symbol.IsConstructor)
            {
                return_type = typeof(void);
            }
            else
            {
                MethodInfo info = (MethodInfo)symbol.NetBaseInfo;
                return_type = info.ReturnType;
            }

            if (return_type != typeof(void))
                ilgen.Emit(OpCodes.Pop);
        }

        public void Generate(MethodPointerExpression expression)
        {
            MethodInfo info = expression.Symbol.NetBaseInfo as MethodInfo;
            ilgen.Emit(OpCodes.Ldftn, info);
        }

        public void Generate(CompoundExpression expression)
        {
            IList<StatementExpression> list = new List<StatementExpression>(expression.List);
            int size = list.Count;

            for (int i = 0; i < size - 1; ++i)
                list[i].GenerateAsStatement(this);

            if (size > 0)
                list[size - 1].GenerateRValue(this);
        }

        public void GenerateAsStatement(CompoundExpression expression)
        {
            if (expression.List != null)
            {
                IList<StatementExpression> list = new List<StatementExpression>(expression.List);
                int size = list.Count;

                for (int i = 0; i < size; ++i)
                    list[i].GenerateAsStatement(this);
            }
        }

        public void Generate(NewObjectExpression expression)
        {
            /*
            // ref type: 
            // new Ctor(Arguments)
            
            [Arguments]
            newobj [Ctor]
            */

            if (expression.Arguments != null)
                foreach (var arg in expression.Arguments)
                    arg.GenerateRValue(this);

            MethodSymbol ctor = expression.Ctor;
            ConstructorInfo info = (ConstructorInfo)ctor.NetBaseInfo;
            ilgen.Emit(OpCodes.Newobj, info);
        }

        public void Generate(InitObjectExpression expression)
        {
            /*
            // new Struktura();
            
            ldloca [TempLocal]
            initobj [Type]
            ldloc [TempLocal]
            */
            
            StructTypeSymbol symbol = expression.Symbol;
            Type type = symbol.Type.NetType;
            LocalBuilder temp_local = ilgen.DeclareLocal(type);
            Emit_LdlocA(temp_local);
            ilgen.Emit(OpCodes.Initobj, type);
            Emit_Ldloc(temp_local);
        }

        public void GenerateAddressOf(InitObjectExpression expression)
        {
            /*
            // new Struktura();
            
            ldloca [TempLocal]
            initobj [Type]
            ldloca [TempLocal]
            */

            StructTypeSymbol symbol = expression.Symbol;
            Type type = symbol.Type.NetType;
            LocalBuilder temp_local = ilgen.DeclareLocal(type);
            Emit_LdlocA(temp_local);
            ilgen.Emit(OpCodes.Initobj, type);
            Emit_LdlocA(temp_local);
        }

        public void Generate(NewValueTypeExpression expression)
        {
            /*            
            // value type: 
            // new Ctor(Arguments)
            
            ldloca [TempLocal] 
            [Arguments]
            call [Ctor]
            ldloc [TempLocal]
            */

            StructTypeSymbol symbol = expression.Symbol;
            Type type = symbol.Type.NetType;
            LocalBuilder temp_local = ilgen.DeclareLocal(type);
            Emit_LdlocA(temp_local);
            
            if (expression.Arguments != null)
                foreach (var arg in expression.Arguments)
                    arg.GenerateRValue(this);
            
            MethodSymbol ctor = expression.Ctor;
            EmitNonPolymorphicCall(ctor);
            Emit_Ldloc(temp_local);
        }

        public void GenerateAddressOf(NewValueTypeExpression expression)
        {
            /*            
            // value type: 
            // new Ctor(Arguments)
            
            ldloca [TempLocal] 
            [Arguments]
            call [Ctor]
            ldloca [TempLocal]
            */

            StructTypeSymbol symbol = expression.Symbol;
            Type type = symbol.Type.NetType;
            LocalBuilder temp_local = ilgen.DeclareLocal(type);
            Emit_LdlocA(temp_local);

            if (expression.Arguments != null)
                foreach (var arg in expression.Arguments)
                    arg.GenerateRValue(this);

            MethodSymbol ctor = expression.Ctor;
            EmitNonPolymorphicCall(ctor);
            Emit_LdlocA(temp_local);
        }

        public void Generate(NewDelegateExpression expression)
        {
            /*
            // instancyjne:
            
            [MethodPointerInstance]
            ldftn [MethodPointer]
            newobj [Ctor]
             
            // statyczne:
            
            ldnull
            ldftn [MethodPointer]
            newobj [Ctor]
            */

            if (expression.MethodPointer.Instance == null)
            {
                ilgen.Emit(OpCodes.Ldnull);
            }
            else
            {
                Type type = expression.MethodPointer.Instance.EvalType.NetType;
                if (NeedAddress(type))
                    expression.MethodPointer.Instance.GenerateAddressOf(this);
                else
                    expression.MethodPointer.Instance.GenerateRValue(this);
            }

            expression.MethodPointer.GenerateRValue(this);

            MethodSymbol ctor = expression.Ctor;
            ConstructorInfo info = (ConstructorInfo)ctor.NetBaseInfo;
            ilgen.Emit(OpCodes.Newobj, info);
        }

        public void Generate(NewArrayExpression expression)
        {
            /*
            // new ElementType[RankList];
            
            [RankList]
            newarr [ElementType]
             
            [RankList]
            newobj [ArraySymbolType]::ctor([IndexTypes])
            */
            
            ArrayTypeSymbol symbol = expression.Symbol;
            Type element_type = symbol.ContentType.NetType;

            foreach (var expr in expression.RankList)
                expr.GenerateRValue(this);

            ilgen.Emit(OpCodes.Newarr, element_type);
            
            //if(rank > 1)
            //    ilgen.Emit(OpCodes.Newobj, symbol.NetType.GetConstructor(types));
        }

        public void Generate(ArrayAccessExpression expression)
        {
            /*
            // a[i]
            
            [a]
            [i]
            ldelem [type]            
            */

            expression.Expr.GenerateRValue(this);

            foreach (var index in expression.Indices)
                index.GenerateRValue(this);

            ArrayTypeSymbol symbol = expression.Symbol;
            Type element_type = symbol.ContentType.NetType;
            Emit_Ldelem(element_type);
        }

        public void GenerateLValuePre(ArrayAccessExpression expression)
        {
            /*
            // a[i] = Value
            
            [a] (pre)
            [i]
            [Value]
            stelem [type] (post)
            */

            expression.Expr.GenerateRValue(this);

            foreach (var index in expression.Indices)
                index.GenerateRValue(this);
        }

        public void GenerateLValuePost(ArrayAccessExpression expression)
        {
            ArrayTypeSymbol symbol = expression.Symbol;
            Type element_type = symbol.ContentType.NetType;
            Emit_Stelem(element_type);
        }

        public void GenerateAddressOf(ArrayAccessExpression expression)
        {
            ArrayTypeSymbol symbol = expression.Symbol;
            Type element_type = symbol.ContentType.NetType;

            expression.Expr.GenerateRValue(this);

            foreach (var index in expression.Indices)
                index.GenerateRValue(this);

            ilgen.Emit(OpCodes.Ldelema, element_type);
        }

        public void Generate(BoxExpression expression)
        {
            expression.Expr.GenerateRValue(this);
            Type type = expression.Expr.EvalType.NetType;
            ilgen.Emit(OpCodes.Box, type);
        }

        public void Generate(UnboxExpression expression)
        {
            ilgen.Emit(OpCodes.Unbox);
        }

        public void Generate(ExplicitCastExpression expression)
        {
            //expression.Expr.GenerateRValue(this);
            //ilgen.Emit(OpCodes.Castclass, expression.TargetType.NetType);
        }

        public void Generate(TypeOfExpression expression)
        {
            Type type = typeof(Type);
            ilgen.Emit(OpCodes.Ldtoken, expression.Type.NetType);
            ilgen.Emit(OpCodes.Call, type.GetMethod("GetTypeFromHandle"));
        }

        public void Generate(IsExpression expression)
        {
            Type type = expression.Type.NetType;

            expression.Left.GenerateRValue(this);
            ilgen.Emit(OpCodes.Isinst, type);
            ilgen.Emit(OpCodes.Ldnull);
            ilgen.Emit(OpCodes.Cgt_Un);
        }

        public void Generate(AsExpression expression)
        {
            Type type = expression.DestType.NetType;

            expression.Expr.GenerateRValue(this);
            ilgen.Emit(OpCodes.Isinst, type);
        }

        public void Generate(ClassCastExpression expression)
        {
            Type type = expression.DestType.NetType;

            expression.Expr.GenerateRValue(this);
            ilgen.Emit(OpCodes.Castclass, type);
        }

        public void Generate(NumericCastExpression expression)
        {
            expression.Expr.GenerateRValue(this);

            Cast.Mode mode = expression.Mode;

            if (mode == Cast.Mode.NO_CAST)
                return;

            if (expression.IsCheckedConversion)
            {
                switch (mode)
                {
                    case Cast.Mode.I1_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.I1_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.I1_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.I1_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.I1_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;

                    case Cast.Mode.U1_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1_Un); break;
                    case Cast.Mode.U1_CH: ; break;

                    case Cast.Mode.I2_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1); break;
                    case Cast.Mode.I2_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.I2_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.I2_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.I2_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.I2_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;

                    case Cast.Mode.U2_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1_Un); break;
                    case Cast.Mode.U2_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1_Un); break;
                    case Cast.Mode.U2_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2_Un); break;
                    case Cast.Mode.U2_CH: ; break;

                    case Cast.Mode.I4_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1); break;
                    case Cast.Mode.I4_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.I4_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2); break;
                    case Cast.Mode.I4_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.I4_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.I4_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.I4_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;

                    case Cast.Mode.U4_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1_Un); break;
                    case Cast.Mode.U4_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1_Un); break;
                    case Cast.Mode.U4_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2_Un); break;
                    case Cast.Mode.U4_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2_Un); break;
                    case Cast.Mode.U4_I4: ilgen.Emit(OpCodes.Conv_Ovf_I4_Un); break;
                    case Cast.Mode.U4_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2_Un); break;

                    case Cast.Mode.I8_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1); break;
                    case Cast.Mode.I8_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.I8_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2); break;
                    case Cast.Mode.I8_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.I8_I4: ilgen.Emit(OpCodes.Conv_Ovf_I4); break;
                    case Cast.Mode.I8_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.I8_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.I8_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.I8_I: ilgen.Emit(OpCodes.Conv_Ovf_U); break;

                    case Cast.Mode.U8_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1_Un); break;
                    case Cast.Mode.U8_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1_Un); break;
                    case Cast.Mode.U8_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2_Un); break;
                    case Cast.Mode.U8_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2_Un); break;
                    case Cast.Mode.U8_I4: ilgen.Emit(OpCodes.Conv_Ovf_I4_Un); break;
                    case Cast.Mode.U8_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4_Un); break;
                    case Cast.Mode.U8_I8: ilgen.Emit(OpCodes.Conv_Ovf_I8_Un); break;
                    case Cast.Mode.U8_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2_Un); break;
                    case Cast.Mode.U8_I: ilgen.Emit(OpCodes.Conv_Ovf_U_Un); break;

                    case Cast.Mode.CH_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1_Un); break;
                    case Cast.Mode.CH_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1_Un); break;
                    case Cast.Mode.CH_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2_Un); break;

                    case Cast.Mode.R4_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1); break;
                    case Cast.Mode.R4_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.R4_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2); break;
                    case Cast.Mode.R4_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.R4_I4: ilgen.Emit(OpCodes.Conv_Ovf_I4); break;
                    case Cast.Mode.R4_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.R4_I8: ilgen.Emit(OpCodes.Conv_Ovf_I8); break;
                    case Cast.Mode.R4_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.R4_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;

                    case Cast.Mode.R8_I1: ilgen.Emit(OpCodes.Conv_Ovf_I1); break;
                    case Cast.Mode.R8_U1: ilgen.Emit(OpCodes.Conv_Ovf_U1); break;
                    case Cast.Mode.R8_I2: ilgen.Emit(OpCodes.Conv_Ovf_I2); break;
                    case Cast.Mode.R8_U2: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.R8_I4: ilgen.Emit(OpCodes.Conv_Ovf_I4); break;
                    case Cast.Mode.R8_U4: ilgen.Emit(OpCodes.Conv_Ovf_U4); break;
                    case Cast.Mode.R8_I8: ilgen.Emit(OpCodes.Conv_Ovf_I8); break;
                    case Cast.Mode.R8_U8: ilgen.Emit(OpCodes.Conv_Ovf_U8); break;
                    case Cast.Mode.R8_CH: ilgen.Emit(OpCodes.Conv_Ovf_U2); break;
                    case Cast.Mode.R8_R4: ilgen.Emit(OpCodes.Conv_R4); break;

                    case Cast.Mode.I_I8: ilgen.Emit(OpCodes.Conv_Ovf_I8_Un); break;
                }
            }
            else
            {
                switch (mode)
                {
                    case Cast.Mode.I1_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.I1_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.I1_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.I1_U8: ilgen.Emit(OpCodes.Conv_I8); break;
                    case Cast.Mode.I1_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.U1_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.U1_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.I2_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.I2_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.I2_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.I2_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.I2_U8: ilgen.Emit(OpCodes.Conv_I8); break;
                    case Cast.Mode.I2_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.U2_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.U2_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.U2_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.U2_CH: ; break;

                    case Cast.Mode.I4_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.I4_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.I4_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.I4_U4: ; break;
                    case Cast.Mode.I4_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.I4_U8: ilgen.Emit(OpCodes.Conv_I8); break;
                    case Cast.Mode.I4_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.U4_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.U4_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.U4_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.U4_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.U4_I4: ; break;
                    case Cast.Mode.U4_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.I8_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.I8_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.I8_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.I8_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.I8_I4: ilgen.Emit(OpCodes.Conv_I4); break;
                    case Cast.Mode.I8_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.I8_U8: ; break;
                    case Cast.Mode.I8_CH: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.I8_I: ilgen.Emit(OpCodes.Conv_U); break;

                    case Cast.Mode.U8_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.U8_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.U8_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.U8_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.U8_I4: ilgen.Emit(OpCodes.Conv_I4); break;
                    case Cast.Mode.U8_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.U8_I8: ; break;
                    case Cast.Mode.U8_CH: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.U8_I: ilgen.Emit(OpCodes.Conv_U); break;

                    case Cast.Mode.CH_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.CH_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.CH_I2: ilgen.Emit(OpCodes.Conv_I2); break;

                    case Cast.Mode.R4_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.R4_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.R4_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.R4_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.R4_I4: ilgen.Emit(OpCodes.Conv_I4); break;
                    case Cast.Mode.R4_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.R4_I8: ilgen.Emit(OpCodes.Conv_I8); break;
                    case Cast.Mode.R4_U8: ilgen.Emit(OpCodes.Conv_U8); break;
                    case Cast.Mode.R4_CH: ilgen.Emit(OpCodes.Conv_U2); break;

                    case Cast.Mode.R8_I1: ilgen.Emit(OpCodes.Conv_I1); break;
                    case Cast.Mode.R8_U1: ilgen.Emit(OpCodes.Conv_U1); break;
                    case Cast.Mode.R8_I2: ilgen.Emit(OpCodes.Conv_I2); break;
                    case Cast.Mode.R8_U2: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.R8_I4: ilgen.Emit(OpCodes.Conv_I4); break;
                    case Cast.Mode.R8_U4: ilgen.Emit(OpCodes.Conv_U4); break;
                    case Cast.Mode.R8_I8: ilgen.Emit(OpCodes.Conv_I8); break;
                    case Cast.Mode.R8_U8: ilgen.Emit(OpCodes.Conv_U8); break;
                    case Cast.Mode.R8_CH: ilgen.Emit(OpCodes.Conv_U2); break;
                    case Cast.Mode.R8_R4: ilgen.Emit(OpCodes.Conv_R4); break;

                    case Cast.Mode.I_I8: ilgen.Emit(OpCodes.Conv_U8); break;
                }
            }
        }

        public void Generate(ThisExpression expression)
        {
            EmitThisPointer();
        }

        public void Generate(BaseExpression expression)
        {
            EmitThisPointer();
        }
        
        public void Generate(BoolLiteral literal)
        {
            if (literal.Value)
                ilgen.Emit(OpCodes.Ldc_I4_1);
            else
                ilgen.Emit(OpCodes.Ldc_I4_0);
        }

        public void Generate(StringLiteral literal)
        {
            if (literal.Value == null)
                ilgen.Emit(OpCodes.Ldnull);
            else
                ilgen.Emit(OpCodes.Ldstr, literal.Value);
        }

        public void Generate(CharLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(SByteLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(ByteLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(ShortLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(UShortLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(IntLiteral literal)
        {
            EmitInt(literal.Value);
        }

        public void Generate(UIntLiteral literal)
        {
            EmitInt(unchecked((int)literal.Value));
        }

        public void Generate(LongLiteral literal)
        {
            EmitLong(literal.Value);
        }

        public void Generate(ULongLiteral literal)
        {
            EmitLong(unchecked((long)literal.Value));
        }

        public void Generate(FloatLiteral literal)
        {
            ilgen.Emit(OpCodes.Ldc_R4, literal.Value);
        }

        public void Generate(DoubleLiteral literal)
        {
            ilgen.Emit(OpCodes.Ldc_R8, literal.Value);
        }

        public void Generate(NullLiteral literal)
        {
            ilgen.Emit(OpCodes.Ldnull);
        }

        public void Generate(UnaryExpression expression)
        {
            Operator.Unary op = expression.Op;

            expression.Expr.GenerateRValue(this);

            switch (op)
            {
                case Operator.Unary.Plus: // +a
                    break;

                case Operator.Unary.LogicalNot: // !a
                    ilgen.Emit(OpCodes.Ldc_I4_0);
                    ilgen.Emit(OpCodes.Ceq);
                    break;

                case Operator.Unary.Negation: // -a
                    ilgen.Emit(OpCodes.Neg);
                    break;

                case Operator.Unary.OnesComplement: // ~a
                    ilgen.Emit(OpCodes.Not);
                    break;
            }
        }

        public void Generate(BinaryExpression expression)
        {
            /*
            // Left Op Right
            
            [Left]
            [Right]
            [Op]

            // Exp1 && Exp2
            
            [Left]
            dup
            br.false l1
            pop
            [Right]
            l1:               

            // Exp1 || Exp2
            
            [Left]
            dup
            br.true l1
            pop
            [Right]
            l1:
            */

            Operator.Binary op = expression.Op;
            Expression left = expression.LeftHandSide;
            Expression right = expression.RightHandSide;

            if (op == Operator.Binary.LogicalAnd)
            {
                Label l1 = ilgen.DefineLabel();
                left.GenerateRValue(this);
                ilgen.Emit(OpCodes.Dup);
                ilgen.Emit(OpCodes.Brfalse, l1);
                ilgen.Emit(OpCodes.Pop);
                right.GenerateRValue(this);
                ilgen.MarkLabel(l1);
            }
            else if (op == Operator.Binary.LogicalOr)
            {
                Label l1 = ilgen.DefineLabel();
                left.GenerateRValue(this);
                ilgen.Emit(OpCodes.Dup);
                ilgen.Emit(OpCodes.Brtrue, l1);
                ilgen.Emit(OpCodes.Pop);
                right.GenerateRValue(this);
                ilgen.MarkLabel(l1);
            }
            else if (op == Operator.Binary.NullCoalescing)
            {
                Label l1 = ilgen.DefineLabel();
                left.GenerateRValue(this);
                ilgen.Emit(OpCodes.Dup);
                ilgen.Emit(OpCodes.Brtrue, l1);
                ilgen.Emit(OpCodes.Pop);
                right.GenerateRValue(this);
                ilgen.MarkLabel(l1);
            }
            else
            {
                left.GenerateRValue(this);
                right.GenerateRValue(this);
                EmitBinaryOp(op);
            }
        }

        private void EmitBinaryOp(Operator.Binary op)
        {
            OpCode code = OpCodes.Nop;
       
            switch (op)
            {
                case Operator.Binary.Addition: code = OpCodes.Add; break;
                case Operator.Binary.Subtraction: code = OpCodes.Sub; break;
                case Operator.Binary.Multiply: code = OpCodes.Mul; break;
                case Operator.Binary.Division: code = OpCodes.Div; break;
                case Operator.Binary.Modulus: code = OpCodes.Rem; break;
                case Operator.Binary.Equality: code = OpCodes.Ceq; break;
                case Operator.Binary.LessThan: code = OpCodes.Clt; break;
                case Operator.Binary.GreaterThan: code = OpCodes.Cgt; break;
                    
                case Operator.Binary.BitwiseAnd: code = OpCodes.And; break;
                case Operator.Binary.BitwiseOr: code = OpCodes.Or; break;
                case Operator.Binary.ExclusiveOr: code = OpCodes.Xor; break;

                case Operator.Binary.LeftShift: code = OpCodes.Shl; break;
                case Operator.Binary.RightShift: code = OpCodes.Shr; break;

                case Operator.Binary.LessThanOrEqual:  
                    ilgen.Emit(OpCodes.Cgt);
                    ilgen.Emit(OpCodes.Ldc_I4_0);
                    ilgen.Emit(OpCodes.Ceq);
                    return;

                case Operator.Binary.GreaterThanOrEqual:
                    ilgen.Emit(OpCodes.Clt);
                    ilgen.Emit(OpCodes.Ldc_I4_0);
                    ilgen.Emit(OpCodes.Ceq);
                    return;

                case Operator.Binary.Inequality:
                    ilgen.Emit(OpCodes.Ceq);
                    ilgen.Emit(OpCodes.Ldc_I4_0);
                    ilgen.Emit(OpCodes.Ceq);
                    return;
            }

            ilgen.Emit(code);
        }

        private void EmitCall(MethodSymbol symbol)
        {
            if (symbol.IsConstructor)
            {
                ConstructorInfo info = (ConstructorInfo)symbol.NetBaseInfo;
                ilgen.Emit(OpCodes.Call, info);
            }
            else
            {
                MethodInfo info = (MethodInfo)symbol.NetBaseInfo;
                if (symbol.IsVirtual)
                {
                    ilgen.Emit(OpCodes.Callvirt, info);
                }
                else
                {
                    ilgen.Emit(OpCodes.Call, info);
                }
            }
        }

        private void EmitNonPolymorphicCall(MethodSymbol symbol)
        {
            if (symbol.IsConstructor)
            {
                ConstructorInfo info = (ConstructorInfo)symbol.NetBaseInfo;
                ilgen.Emit(OpCodes.Call, info);
            }
            else
            {
                MethodInfo info = (MethodInfo)symbol.NetBaseInfo;              
                ilgen.Emit(OpCodes.Call, info);
            }
        }

        private void Emit_Ldloc(LocalBuilder builder)
        {
            ilgen.Emit(OpCodes.Ldloc, builder);
        }

        private void Emit_LdlocA(LocalBuilder builder)
        {
            ilgen.Emit(OpCodes.Ldloca, builder);
        }

        private void Emit_Stloc(LocalBuilder builder)
        {
            ilgen.Emit(OpCodes.Stloc, builder);
        }

        private void Emit_Ldarg(int index)
        {
            OpCode code = OpCodes.Ldarg;
            switch (index)
            {
                case 0: code = OpCodes.Ldarg_0; break;
                case 1: code = OpCodes.Ldarg_1; break;
                case 2: code = OpCodes.Ldarg_2; break;
                case 3: code = OpCodes.Ldarg_3; break;
            }
            if (4 <= index && index <= 255)
                code = OpCodes.Ldarg_S;

            if (index < 4)
                ilgen.Emit(code);
            else
                ilgen.Emit(code, index);
        }

        private void Emit_LdargA(int index)
        {
            ilgen.Emit(OpCodes.Ldarga, index);
        }

        private void Emit_Starg(int index)
        {
            ilgen.Emit(OpCodes.Starg, index);
        }

        private void Emit_Ldelem(Type element_type)
        {
            if (element_type == typeof(int) || element_type.IsEnum)
            {
                ilgen.Emit(OpCodes.Ldelem_I4);
            }
            else if (element_type == typeof(char))
            {
                ilgen.Emit(OpCodes.Ldelem_U2);
            }
            else if (element_type.IsValueType)
            {
                ilgen.Emit(OpCodes.Ldelema, element_type);
                ilgen.Emit(OpCodes.Ldobj, element_type);
            }
            else
            {
                ilgen.Emit(OpCodes.Ldelem_Ref);
            }
        }

        private void Emit_Stelem(Type element_type)
        {
            if (element_type == typeof(int) || element_type.IsEnum)
            {
                ilgen.Emit(OpCodes.Stelem_I4);
            }
            else if (element_type == typeof(char))
            {
                ilgen.Emit(OpCodes.Stelem_I2);
            }
            else
            {
                ilgen.Emit(OpCodes.Stelem_Ref);
            }
        }

        private void EmitInt(int value)
        {
            OpCode code = OpCodes.Nop;
            switch (value)
            {
                case -1: code = OpCodes.Ldc_I4_M1; break;
                case 0: code = OpCodes.Ldc_I4_0; break;
                case 1: code = OpCodes.Ldc_I4_1; break;
                case 2: code = OpCodes.Ldc_I4_2; break;
                case 3: code = OpCodes.Ldc_I4_3; break;
                case 4: code = OpCodes.Ldc_I4_4; break;
                case 5: code = OpCodes.Ldc_I4_5; break;
                case 6: code = OpCodes.Ldc_I4_6; break;
                case 7: code = OpCodes.Ldc_I4_7; break;
                case 8: code = OpCodes.Ldc_I4_8; break;
            }

            if (code.Equals(OpCodes.Nop))
            {
                if (-128 < value && value < 128)
                    ilgen.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
                else
                    ilgen.Emit(OpCodes.Ldc_I4, value);
            }
            else
            {
                ilgen.Emit(code);
            }
        }

        private void EmitLong(long value)
        {
            if (int.MinValue <= value && value <= int.MaxValue)
            {
                EmitInt(unchecked((int)value));
                ilgen.Emit(OpCodes.Conv_I8);
            }
            else if (0 <= value && value <= uint.MaxValue)
            {
                EmitInt(unchecked((int)value));
                ilgen.Emit(OpCodes.Conv_U8);
            }
            else
            {
                ilgen.Emit(OpCodes.Ldc_I8, value);
            }
        }

        private void EmitThisPointer()
        {
            ilgen.Emit(OpCodes.Ldarg_0);
        }

        private void EmitReturn()
        {
            if (IsInsideTry)
            {
                ilgen.Emit(OpCodes.Leave, return_label);
            }
            else
            {
                ilgen.Emit(OpCodes.Br, return_label);
            }
        }

        private void Emit_Ldi(Type type)
        {
            if (type == typeof(int) || type.IsEnum)
                ilgen.Emit(OpCodes.Ldind_I4);
            else if (type == typeof(char))
                ilgen.Emit(OpCodes.Ldind_U2);
            else if (type.IsValueType)
                ilgen.Emit(OpCodes.Ldobj, type);
            else
                ilgen.Emit(OpCodes.Ldind_Ref);
        }

        private void Emit_Sti(Type type)
        {
            if (type == typeof(int) || type.IsEnum)
                ilgen.Emit(OpCodes.Stind_I4);
            else if (type == typeof(char))
                ilgen.Emit(OpCodes.Stind_I2);
            else if (type.IsValueType)
                ilgen.Emit(OpCodes.Stobj, type);
            else
                ilgen.Emit(OpCodes.Stind_Ref);
        }
        
        private bool NeedAddress(Type type)
        {
            if (type.IsValueType || (type.IsByRef && type.GetElementType().IsValueType))
                return true;
            return false;
        }
    }
}
