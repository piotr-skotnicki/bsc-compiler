using System;
using System.Collections.Generic;

using Compiler.Driver;
using Compiler.Emit;
using Compiler.Symbols;
using Compiler.Grammar;

namespace Compiler.AST
{
    public interface IDeclSpace
    {
        void AddNamespace(NamespaceDecl @namespace);
        void AddTypedef(TypedefDirective typedef);
        void AddImport(UsingDirective import);
        void AddType(TypeDecl type);
        void AddField(FieldDecl field);
        void AddMethod(MethodDecl method);
        void AddProperty(PropertyDecl property);
        void AddSignal(SignalDecl signal);
    }

    public class Identifier
    {
        public readonly string Text;

        public readonly Location Location;

        public Identifier(string text)
        {
            if (text == null)
                throw new Exception();

            text = text.Trim();

            if (text == String.Empty)
                throw new Exception();

            this.Text = text;
        }

        public Identifier(string text, Location loc)
            : this(text)
        {
            this.Location = loc;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }

    public abstract class ASTNode
    {
        public Location Location { get; set; }
    }

    public abstract class Statement : ASTNode
    {
        public virtual void DefineSymbols(IContext context)
        {

        }

        public virtual void ResolveStatement(IContext context)
        {

        }

        public abstract void GenerateStatement(CodeGen gen);
    }

    public abstract class Expression : ASTNode
    {
        public IType EvalType { get; protected set; }
        
        public virtual Expression ResolveLValue(IContext context)
        {
            Report.Error.InvalidLValue(this.Location);
            return null;
        }

        public virtual Expression ResolveRValue(IContext context)
        {
            Report.Error.InvalidRValue(this.Location);
            return null;
        }

        public virtual void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public virtual void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public virtual void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public virtual void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class ExpressionStatement : Statement
    {
        StatementExpression expr;

        public ExpressionStatement(
            StatementExpression expr)
        {
            this.expr = expr;
        }

        public override void ResolveStatement(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context) as StatementExpression;
        }

        public override void GenerateStatement(CodeGen gen)
        {
            this.expr.GenerateAsStatement(gen);
        }

        public StatementExpression Expr
        {
            get { return this.expr; }
        }
    }

    public abstract class TypeSignature : ASTNode
    {
        public IType Type { get; protected set; }

        public abstract void ResolveType(IContext context);
    }

    public class ResolvedType : TypeSignature
    {
        public ResolvedType(IType type)
        {
            this.Type = type;
        }

        public ResolvedType(IType type, Location loc)
            : this(type)
        {
            this.Location = loc;
        }

        public override void ResolveType(IContext context)
        {

        }
    }

    public class ArrayType : TypeSignature
    {
        TypeSignature type_sig;
        int rank;

        public ArrayType(
            TypeSignature type_sig,
            int rank)
        {
            this.type_sig = type_sig;
            this.rank = rank;
            this.Location = type_sig.Location;
        }

        public override void ResolveType(IContext context)
        {
            if (this.Type != null)
                return;

            type_sig.ResolveType(context);

            ArrayTypeSymbol array = new ArrayTypeSymbol(this.rank);
            array.ContentType = type_sig.Type;
            this.Type = array;
        }
    }

    public class TypeName : TypeSignature
    {
        Expression expr;

        public TypeName(Expression expr)
        {
            this.expr = expr;
            this.Location = expr.Location;
        }

        public override void ResolveType(IContext context)
        {
            if (this.Type != null)
                return;

            this.expr = this.expr.ResolveRValue(context);

            if (this.expr is ClassExpression)
            {
                ClassExpression ce = this.expr as ClassExpression;
                this.Type = ce.Symbol;
            }
            else if (this.expr is ValueTypeExpression)
            {
                ValueTypeExpression se = this.expr as ValueTypeExpression;
                this.Type = se.Symbol;
            }
            else if (this.expr is InterfaceExpression)
            {
                InterfaceExpression ie = this.expr as InterfaceExpression;
                this.Type = ie.Symbol;
            }
            else if (this.expr is MethodCallExpression)
            {
                MethodCallExpression mc = this.expr as MethodCallExpression;
                this.Type = mc.Symbol.ReturnType;
            }
            else
            {
                Report.Error.TypeExpected(this.Location);
            }
        }
    }

    public class CompilationUnit : ASTNode, IDeclSpace
    {
        IList<UsingDirective> imports;
        IList<TypedefDirective> typedefs;
        IList<NamespaceDecl> namespaces;
        IList<TypeDecl> typedecls;

        public CompilationUnit()
        {

        }

        public CompilationUnit(
            IList<UsingDirective> imports,
            IList<TypedefDirective> typedefs,
            IList<NamespaceDecl> namespaces,
            IList<TypeDecl> typedecls)
        {
            this.imports = imports == null ? null : new List<UsingDirective>(imports);
            this.typedefs = typedefs == null ? null : new List<TypedefDirective>(typedefs);
            this.namespaces = namespaces == null ? null : new List<NamespaceDecl>(namespaces);
            this.typedecls = typedecls == null ? null : new List<TypeDecl>(typedecls);
        }

        public void DefineSymbols(IContext context)
        {
            context.PushScope(context.GlobalNamespace);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.DefineSymbols(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.DefineSymbols(context);

            context.PopScope();
        }

        public void ResolveSymbols(IContext context)
        {
            context.PushScope(context.GlobalNamespace);

            if (imports != null)
                foreach (var import in imports)
                    import.Resolve(context);

            if (typedefs != null)
                foreach (var typedef in typedefs)
                    typedef.Resolve(context);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.ResolveSymbols(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveSymbols(context);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.ResolveBodies(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveBodies(context);

            context.PopScope();
        }

        public void GenerateTypes(CodeGen gen)
        {
            gen.GenerateTypes(this);
        }

        public void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public void AddNamespace(NamespaceDecl @namespace)
        {
            if (this.namespaces == null)
                this.namespaces = new List<NamespaceDecl>();
            this.namespaces.Add(@namespace);
        }

        public void AddTypedef(TypedefDirective typedef)
        {
            if (this.typedefs == null)
                this.typedefs = new List<TypedefDirective>();
            this.typedefs.Add(typedef);
        }

        public void AddImport(UsingDirective import)
        {
            if (this.imports == null)
                this.imports = new List<UsingDirective>();
            this.imports.Add(import);
        }

        public void AddType(TypeDecl type)
        {
            if (this.typedecls == null)
                this.typedecls = new List<TypeDecl>();
            this.typedecls.Add(type);
        }

        public void AddField(FieldDecl field)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddMethod(MethodDecl method)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddProperty(PropertyDecl property)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddSignal(SignalDecl signal)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public IEnumerable<UsingDirective> Imports
        {
            get { return this.imports; }
        }

        public IEnumerable<TypedefDirective> Typedefs
        {
            get { return this.typedefs; }
        }

        public IEnumerable<NamespaceDecl> Namespaces
        {
            get { return this.namespaces; }
        }

        public IEnumerable<TypeDecl> TypeDecls
        {
            get { return this.typedecls; }
        }
    }

    public abstract class BaseDecl : ASTNode
    {
        
    }

    public class NamespaceDecl : BaseDecl, IDeclSpace
    {
        Identifier id;
        IList<UsingDirective> imports;
        IList<TypedefDirective> typedefs;
        IList<NamespaceDecl> namespaces;
        IList<TypeDecl> typedecls;

        public NamespaceSymbol Symbol { get; private set; }

        public NamespaceDecl(
            Identifier id)
        {
            this.id = id;
            this.Location = id.Location;
        }

        public NamespaceDecl(
            Identifier id,
            IList<UsingDirective> imports,
            IList<TypedefDirective> typedefs,
            IList<NamespaceDecl> namespaces,
            IList<TypeDecl> typedecls)
            : this(id)
        {
            this.imports = imports == null ? null : new List<UsingDirective>(imports);
            this.typedefs = typedefs == null ? null : new List<TypedefDirective>(typedefs);
            this.namespaces = namespaces == null ? null : new List<NamespaceDecl>(namespaces);
            this.typedecls = typedecls == null ? null : new List<TypeDecl>(typedecls);
        }

        public void DefineSymbols(IContext context)
        {
            NamespaceSymbol already_existing = context.CurrentScope.Resolve(id.Text, LookupFlags.FLAT) as NamespaceSymbol;
            if (already_existing != null)
            {
                this.Symbol = already_existing;
            }
            else
            {
                this.Symbol = new NamespaceSymbol(id.Text);
                this.Symbol.NodeReference = this;
                context.CurrentScope.Define(this.Symbol);
            }
            
            context.PushScope(this.Symbol);
            context.PushNamespace(this.Symbol);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.DefineSymbols(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.DefineSymbols(context);

            context.PopNamespace();
            context.PopScope();
        }

        public void ResolveSymbols(IContext context)
        {
            context.PushScope(this.Symbol);
            context.PushNamespace(this.Symbol);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.ResolveSymbols(context);

            if (imports != null)
                foreach (var import in imports)
                    import.Resolve(context);

            if (typedefs != null)
                foreach (var typedef in typedefs)
                    typedef.Resolve(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveSymbols(context);

            context.PopNamespace();
            context.PopScope();
        }
        
        public void ResolveBodies(IContext context)
        {
            context.PushScope(this.Symbol);
            context.PushNamespace(this.Symbol);

            if (namespaces != null)
                foreach (var ns in namespaces)
                    ns.ResolveBodies(context);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveBodies(context);

            context.PopNamespace();
            context.PopScope();
        }

        public void GenerateTypes(CodeGen gen)
        {
            gen.GenerateTypes(this);
        }

        public void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public void AddNamespace(NamespaceDecl @namespace)
        {
            if (this.namespaces == null)
                this.namespaces = new List<NamespaceDecl>();
            this.namespaces.Add(@namespace);
        }

        public void AddTypedef(TypedefDirective typedef)
        {
            if (this.typedefs == null)
                this.typedefs = new List<TypedefDirective>();
            this.typedefs.Add(typedef);
        }

        public void AddImport(UsingDirective import)
        {
            if (this.imports == null)
                this.imports = new List<UsingDirective>();
            this.imports.Add(import);
        }

        public void AddType(TypeDecl type)
        {
            if (this.typedecls == null)
                this.typedecls = new List<TypeDecl>();
            this.typedecls.Add(type);
        }

        public void AddField(FieldDecl field)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddMethod(MethodDecl method)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddProperty(PropertyDecl property)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public void AddSignal(SignalDecl signal)
        {
            Report.Error.FieldOrMethodInNamespace(this.Location);
        }

        public IEnumerable<UsingDirective> Imports
        {
            get { return this.imports; }
        }

        public IEnumerable<TypedefDirective> Typedefs
        {
            get { return this.typedefs; }
        }

        public IEnumerable<NamespaceDecl> Namespaces
        {
            get { return this.namespaces; }
        }

        public IEnumerable<TypeDecl> TypeDecls
        {
            get { return this.typedecls; }
        }
    }

    public class UsingDirective : ASTNode
    {
        Expression import;

        public UsingDirective(
            Expression import)
        {
            this.import = import;
            this.Location = import.Location;
        }

        public void Resolve(IContext context)
        {
            import = import.ResolveRValue(context);

            if (!(import is NamespaceExpression))
                Report.Error.InvalidImport(this.Location);

            NamespaceExpression ne = import as NamespaceExpression;

            NamespaceSymbol symbol = ne.Symbol;

            /* jeżeli oprócz przestrzeni nazw pozwolę na coś innego, ten kod będzie potrzebny
            if (!context.CanAccess(symbol))
                Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);
            */

            NamespaceSymbol ns = context.CurrentScope as NamespaceSymbol;

            try
            {
                ns.AddImport(symbol);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Warning.DuplicateImport(e.Name, this.Location);
            }
        }
    }

    public class TypedefDirective : ASTNode
    {
        Identifier id;
        Expression type;

        public TypedefDirective(
            Identifier id,
            Expression type)
        {
            this.id = id;
            this.Location = id.Location;
            this.type = type;
        }

        public void Resolve(IContext context)
        {
            type = type.ResolveRValue(context);

            ScopedSymbol symbol = null;

            if (type is NamespaceExpression)
                symbol = ((NamespaceExpression)type).Symbol;
            else if (type is ClassExpression)
                symbol = ((ClassExpression)type).Symbol;
            else if (type is ValueTypeExpression)
                symbol = ((ValueTypeExpression)type).Symbol;
            else if (type is InterfaceExpression)
                symbol = ((InterfaceExpression)type).Symbol;
            else
                Report.Error.InvalidTypedef(this.Location);

            RegisterTypedef(symbol, context);
        }

        private void RegisterTypedef(ScopedSymbol symbol, IContext context)
        {
            NamespaceSymbol ns = context.CurrentScope as NamespaceSymbol;

            if (!context.CanAccess(symbol))
                Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

            try
            {
                ns.AddTypedef(id.Text, symbol);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Error.MemberAlreadyDefined(ns.GetQualifiedName(), e.Name, this.Location);
            }
        }
    }

    public abstract class TypeDecl : BaseDecl, IDeclSpace
    {
        public abstract void DefineSymbols(IContext context);

        public abstract void ResolveSymbols(IContext context);

        public abstract void ResolveBodies(IContext context);

        public abstract void Generate(CodeGen gen);

        public abstract void GenerateTypes(CodeGen gen);

        public abstract void GenerateMembers(CodeGen gen);

        public abstract void GenerateBodies(CodeGen gen);
        
        public virtual void AddNamespace(NamespaceDecl @namespace)
        {
            throw new NotSupportedException();
        }

        public virtual void AddTypedef(TypedefDirective typedef)
        {
            throw new NotSupportedException();
        }

        public virtual void AddImport(UsingDirective import)
        {
            throw new NotSupportedException();
        }

        public virtual void AddType(TypeDecl type)
        {
            throw new NotSupportedException();
        }

        public virtual void AddField(FieldDecl field)
        {
            throw new NotSupportedException();
        }

        public virtual void AddMethod(MethodDecl method)
        {
            throw new NotSupportedException();
        }

        public virtual void AddProperty(PropertyDecl property)
        {
            throw new NotSupportedException();
        }

        public virtual void AddSignal(SignalDecl signal)
        {
            throw new NotSupportedException();
        }
    }

    public class ClassDecl : TypeDecl
    {
        Identifier id;
        TypeSignature base_class;
        IList<TypeSignature> interfaces;
        IList<TypeDecl> typedecls;
        IList<FieldDecl> fields;
        IList<MethodDecl> methods;
        IList<PropertyDecl> properties;
        IList<SignalDecl> signals;
        ClassSpecifier specifiers;
        AccessModifier access;
        
        public ClassTypeSymbol Symbol { get; private set; }

        public ClassDecl(
            Identifier id,
            AccessModifier access,
            ClassSpecifier specifiers,
            TypeSignature base_class,
            IList<TypeSignature> interfaces)
        {
            this.id = id;
            this.Location = id.Location;
            this.access = access;
            this.specifiers = specifiers;
            this.base_class = base_class;
            this.interfaces = interfaces == null ? null : new List<TypeSignature>(interfaces);
        }

        public ClassDecl(
            Identifier id,
            AccessModifier access,
            ClassSpecifier specifiers,
            TypeSignature base_class,
            IList<TypeSignature> interfaces,
            IList<TypeDecl> typedecls,
            IList<FieldDecl> fields,
            IList<MethodDecl> methods,
            IList<PropertyDecl> properties,
            IList<SignalDecl> signals)
            : this(id, access, specifiers, base_class, interfaces)
        {
            this.typedecls = typedecls == null ? null : new List<TypeDecl>(typedecls);
            this.fields = fields == null ? null : new List<FieldDecl>(fields);
            this.methods = methods == null ? null : new List<MethodDecl>(methods);
            this.properties = properties == null ? null : new List<PropertyDecl>(properties);
            this.signals = signals == null ? null : new List<SignalDecl>(signals);
        }

        public override void DefineSymbols(IContext context)
        {
            this.Symbol = new ClassTypeSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Specifier = specifiers;
            this.Symbol.Access = access;

            if(!context.IsNested && (this.access.IsPrivate || this.access.IsFamily || this.access.IsFamAndAssem))
                Report.Error.InvalidGlobalAccessModifier(this.Location);

            context.CurrentScope.Define(this.Symbol);

            context.PushScope(this.Symbol);
            context.PushType(this.Symbol);

            try
            {
                if (typedecls != null)
                    foreach (var type in typedecls)
                        type.DefineSymbols(context);

                if (fields != null)
                    foreach (var field in fields)
                        field.Define(context);

                if (methods != null)
                    foreach (var method in methods)
                        method.DefineSymbols(context);

                if (properties != null)
                    foreach (var property in properties)
                        property.DefineComponents(context);

                if (signals != null)
                    foreach (var signal in signals)
                        signal.DefineComponents(context);
                
            }
            catch (MemberNameSameAsTypesException e)
            {
                Report.Error.MemberNameSameAsTypes(e.Name, this.Location);
            }
            catch (MethodAlreadyDefinedException e)
            {
                Report.Error.MethodAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Error.MemberAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }

            if (this.Symbol.Resolve(MethodSymbol.CTOR, LookupFlags.FLAT) == null)
            {
                CtorDecl ctor = CtorDecl.CreateDefault();
                ctor.DefineSymbols(context);
                this.AddMethod(ctor);
            }

            context.PopType();
            context.PopScope();
        }

        public override void ResolveSymbols(IContext context)
        {
            ResolveBaseClass(context);
            ResolveInterfaces(context);

            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveSymbols(context);

            if (fields != null)
                foreach (var field in fields)
                    field.Resolve(context);

            if (methods != null)
                foreach (var method in methods)
                    method.ResolveSymbols(context);

            if (properties != null)
                foreach (var property in properties)
                    property.ResolveComponents(context);

            if (signals != null)
                foreach (var signal in signals)
                    signal.ResolveComponents(context);

            context.PopType();
            context.PopScope();
        }

        public override void ResolveBodies(IContext context)
        {
            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveBodies(context);

            if (methods != null)
                foreach (var method in methods)
                    method.ResolveBody(context);

            if (properties != null)
                foreach (var property in properties)
                    property.ResolveComponentsBodies(context);

            if (signals != null)
                foreach (var signal in signals)
                    signal.ResolveComponentsBodies(context);

            context.PopType();
            context.PopScope();
        }

        private void ResolveBaseClass(IContext context)
        {
            if (base_class == null)
            {
                this.Symbol.BaseClass = (ClassTypeSymbol)Types.GetType("Object");
                return;
            }

            base_class.ResolveType(context);
            ClassTypeSymbol bs = base_class.Type as ClassTypeSymbol;

            if (bs == null)
                Report.Error.InvalidBaseType(base_class.Type.GetQualifiedName(), base_class.Location);

            IObjectType curr = bs;
            do 
            {
                if (this.Symbol.IsEqualTo(curr))
                    Report.Error.BaseClassCycle(this.Location);
                curr = curr.BaseClass;
            } while(curr != null);

            if (!context.CanAccess(bs))
                Report.Error.Inaccessible(bs.GetQualifiedName(), base_class.Location);

            if (!context.HasConsistentAccessibility(bs, access))
                Report.Error.InconsistentAccessibility(bs.GetQualifiedName(), this.Symbol.GetQualifiedName(), base_class.Location);

            if (bs.IsFinal)
                Report.Error.SealedBaseClass(this.Symbol.GetQualifiedName(), bs.GetQualifiedName(), base_class.Location);

            this.Symbol.BaseClass = bs;
        }

        private void ResolveInterfaces(IContext context)
        {
            if (interfaces == null)
                return;

            foreach (var @interface in interfaces)
            {
                @interface.ResolveType(context);
                InterfaceTypeSymbol ns = @interface.Type as InterfaceTypeSymbol;

                if (ns == null)
                    Report.Error.InvalidInterface(@interface.Type.GetQualifiedName(), Location);

                if (!context.CanAccess(ns))
                    Report.Error.Inaccessible(ns.GetQualifiedName(), @interface.Location);

                /*
                if (!context.HasConsistentAccessibility(ns, access))
                    Report.Error.InconsistentAccessibility(ns.GetQualifiedName(), this.Symbol.GetQualifiedName(), @interface.Location);
                */

                this.Symbol.AddInterface(ns);
            }
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateTypes(CodeGen gen)
        {
            gen.GenerateTypes(this);
        }

        public override void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public override void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public override void AddType(TypeDecl type)
        {
            if (this.typedecls == null)
                this.typedecls = new List<TypeDecl>();
            this.typedecls.Add(type);
        }

        public override void AddMethod(MethodDecl method)
        {
            if (this.methods == null)
                this.methods = new List<MethodDecl>();
            this.methods.Add(method);
        }

        public override void AddField(FieldDecl field)
        {
            if (this.fields == null)
                this.fields = new List<FieldDecl>();
            this.fields.Add(field);
        }

        public override void AddProperty(PropertyDecl property)
        {
            if (this.properties == null)
                this.properties = new List<PropertyDecl>();
            this.properties.Add(property);
        }

        public override void AddSignal(SignalDecl signal)
        {
            if (this.signals == null)
                this.signals = new List<SignalDecl>();
            this.signals.Add(signal);
        }

        public IEnumerable<TypeDecl> TypeDecls
        {
            get { return this.typedecls; }
        }

        public IEnumerable<MethodDecl> Methods
        {
            get { return this.methods; }
        }

        public IEnumerable<FieldDecl> Fields
        {
            get { return this.fields; }
        }

        public IEnumerable<PropertyDecl> Properties
        {
            get { return this.properties; }
        }

        public IEnumerable<SignalDecl> Signals
        {
            get { return this.signals; }
        }
    }

    public class FieldDecl : BaseDecl
    {
        protected Identifier id;
        TypeSignature type;
        FieldSpecifier specifiers;
        AccessModifier access;

        public FieldSymbol Symbol { get; private set; }

        public FieldDecl(
            Identifier id,
            FieldSpecifier specifiers,
            AccessModifier access,
            TypeSignature type)
        {
            this.id = id;
            this.Location = id.Location;
            this.specifiers = specifiers;
            this.access = access;
            this.type = type;
        }

        public void Define(IContext context)
        {
            this.Symbol = new FieldSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = this.access;
            this.Symbol.Specifier = this.specifiers;
            context.CurrentScope.Define(this.Symbol);
        }

        public virtual void Resolve(IContext context)
        {
            type.ResolveType(context);
            this.Symbol.Type = type.Type;

            if (!context.CanAccess(type.Type))
                Report.Error.Inaccessible(type.Type.GetQualifiedName(), this.Location);

            if (!context.HasConsistentAccessibility(type.Type, this.access))
                Report.Error.InconsistentAccessibility(type.Type.GetQualifiedName(), this.Symbol.GetQualifiedName(), this.Location);
        }

        public virtual void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class LiteralFieldDecl : FieldDecl
    {
        Expression expr;

        public new LiteralFieldSymbol Symbol { get; private set; }
        
        public LiteralFieldDecl(
            Identifier id,
            FieldSpecifier specifiers,
            AccessModifier access,
            TypeSignature type,
            Expression expr)
            : base(id, specifiers, access, type)
        {
            this.expr = expr;
        }

        public override void Resolve(IContext context)
        {
            base.Resolve(context);
            this.expr = this.expr.ResolveRValue(context);

            if (!(this.expr is LiteralExpression))
                Report.Error.MustBeConstant(this.id.ToString(), this.Location);
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Expression Expr
        {
            get { return this.expr; }
        }
    }

    public class MethodDecl : BaseDecl
    {
        Identifier id;
        TypeSignature return_type;
        IList<ArgumentDecl> arguments;
        BlockStatement body;
        AccessModifier access;
        MethodSpecifier specifiers;

        public MethodSymbol Symbol { get; private set; }

        public MethodDecl(
            Identifier id,
            MethodSpecifier specifiers,
            AccessModifier access,
            TypeSignature return_type,
            IList<ArgumentDecl> arguments,
            BlockStatement body)
        {
            this.id = id;
            this.Location = id.Location;
            this.specifiers = specifiers;
            this.access = access;
            this.return_type = return_type;
            this.arguments = arguments == null ? null : new List<ArgumentDecl>(arguments);
            this.body = body;
        }

        public virtual void DefineSymbols(IContext context)
        {
            this.Symbol = new MethodSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = access;
            this.Symbol.Specifier = specifiers;

            context.PushScope(this.Symbol);
            context.EnterMethod(this.Symbol);
            if (arguments != null)
                foreach (var arg in arguments)
                    arg.DefineSymbols(context);
            context.ExitMethod();
            context.PopScope();


            context.CurrentScope.Define(this.Symbol);

            context.PushScope(this.Symbol);
            context.EnterMethod(this.Symbol);

            if (this.Symbol.IsAbstract || this.Symbol.IsVirtual)
            {
                if (this.Symbol.Access.IsPrivate)
                    Report.Error.PrivateVirtualMember(this.Symbol.GetQualifiedName(), this.Location);
                if (this.Symbol.IsStatic)
                    Report.Error.StaticVirtualMember(this.Symbol.GetQualifiedName(), this.Location);
            }

            if (body == null && !this.Symbol.IsAbstract)
                Report.Error.MethodWithoutBody(this.Symbol.GetQualifiedName(), this.Location);

            if (body != null && this.Symbol.IsAbstract)
                Report.Error.AbstractMethodWithBody(this.Symbol.GetQualifiedName(), this.Location);

            if (this.Symbol.IsAbstract)
            {
                IType enclosing = context.GetEnclosingType(context.CurrentScope);
                if (enclosing is ClassTypeSymbol)
                {
                    ClassTypeSymbol enc_class = enclosing as ClassTypeSymbol;
                    if (!enc_class.IsAbstract)
                        Report.Error.AbstractMemberInNonAbstract(this.Symbol.GetQualifiedName(), enc_class.GetQualifiedName(), this.Location);
                }
                else
                    if (!(enclosing is InterfaceTypeSymbol))
                        Report.Error.InvalidModifier(Tokens.KW_ABSTRACT, this.Location);
            }

            if (body != null)
                body.DefineSymbols(context);

            context.ExitMethod();
            context.PopScope();
        }

        public virtual void ResolveSymbols(IContext context)
        {
            this.Symbol.Type = Types.GetType("IntPtr");

            return_type.ResolveType(context);
            this.Symbol.ReturnType = return_type.Type;

            if (arguments != null)
                foreach (var arg in arguments)
                    arg.Resolve(context);

            if (!context.CanAccess(return_type.Type))
                Report.Error.Inaccessible(return_type.Type.GetQualifiedName(), this.Location);

            if (!context.HasConsistentAccessibility(return_type.Type, this.access))
                Report.Error.InconsistentAccessibility(return_type.Type.GetQualifiedName(), this.Symbol.GetQualifiedName(), this.Location);

            if (arguments != null)
            {
                foreach (var arg in arguments)
                {
                    if (!context.HasConsistentAccessibility(arg.Type, this.access))
                        Report.Error.InconsistentAccessibility(arg.Type.GetQualifiedName(), this.Symbol.GetQualifiedName(), this.Location);
                }
            }
        }

        public virtual void ResolveBody(IContext context)
        {
            context.PushScope(this.Symbol);
            context.EnterMethod(this.Symbol);

            if (body != null)
                body.ResolveStatement(context);

            context.ExitMethod();
            context.PopScope();
        }

        public virtual void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public virtual void GenerateBody(CodeGen gen)
        {
            gen.GenerateBody(this);
        }

        public BlockStatement Body
        {
            get { return this.body; }
        }
    }

    public class CtorDecl : MethodDecl
    {
        MethodCallExpression ctor_chain;

        public CtorDecl(
            AccessModifier access,
            MethodSpecifier specifier,
            IList<ArgumentDecl> arguments,
            BlockStatement body,
            MethodCallExpression ctor_chain)
            : base(
                new Identifier(MethodSymbol.CTOR),
                specifier,
                access,
                new ResolvedType(Types.GetType("Void")),
                arguments,
                body)
        {
            this.ctor_chain = ctor_chain;
        }

        public static CtorDecl CreateDefault()
        {
            CtorDecl ctor = new CtorDecl(
                AccessModifier.PUBLIC,
                MethodSpecifier.CONSTRUCTOR,
                null,
                new BlockStatement(new Statement[0]),
                null
            );
            return ctor;
        }

        public override void ResolveBody(IContext context)
        {
            base.ResolveBody(context);

            context.PushScope(base.Symbol);
            context.EnterMethod(base.Symbol);

            if (!this.Symbol.IsRuntimeManaged)
            {
                if (this.ctor_chain == null)
                {
                    this.ctor_chain = new MethodCallExpression(
                        new AnyExpression(Tokens.KW_BASE),
                        new Identifier(MethodSymbol.CTOR),
                        null
                    );
                }
                this.ctor_chain = (MethodCallExpression)this.ctor_chain.ResolveRValue(context);
            }

            context.ExitMethod();
            context.PopScope();
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateBody(CodeGen gen)
        {
            gen.GenerateBody(this);
        }

        public MethodCallExpression CtorChain
        {
            get { return this.ctor_chain; }
        }
    }

    public class CCtorDecl : MethodDecl
    {
        public CCtorDecl(
            BlockStatement body)
            : base(
                new Identifier(MethodSymbol.CCTOR),
                MethodSpecifier.CONSTRUCTOR | MethodSpecifier.STATIC,
                AccessModifier.ASSEMBLY,
                new ResolvedType(Types.GetType("Void")),
                null,
                body)
        {

        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateBody(CodeGen gen)
        {
            gen.GenerateBody(this);
        }
    }

    public class OperatorDecl : BaseDecl
    {
        private enum Arity { Unary, Binary };

        Arity arity;
        MethodDecl proxy;

        public MethodSymbol Symbol
        {
            get { return this.proxy.Symbol; }
        }

        public OperatorDecl(
            Operator.Unary op,
            MethodSpecifier specifiers,
            AccessModifier access,
            TypeSignature return_type,
            IList<ArgumentDecl> arguments,
            BlockStatement body)
        {
            this.arity = Arity.Unary;
            
            this.proxy = new MethodDecl(
                new Identifier(Operator.GetMethodName(op)),
                MethodSpecifier.STATIC,
                AccessModifier.PUBLIC,
                return_type,
                arguments,
                body);
        }

        public OperatorDecl(
            Operator.Binary op,
            MethodSpecifier specifiers,
            AccessModifier access,
            TypeSignature return_type,
            IList<ArgumentDecl> arguments,
            BlockStatement body)
        {
            this.arity = Arity.Binary;
        }

        public void DefineSymbols(IContext context)
        {
            this.proxy.DefineSymbols(context);
        }

        public void ResolveSymbols(IContext context)
        {
            this.proxy.ResolveSymbols(context);
        }
    }

    public class ArgumentDecl : BaseDecl
    {
        Identifier id;
        TypeSignature type_sig;

        public ArgumentSymbol Symbol { get; private set; }

        public ArgumentDecl(
            Identifier id,
            TypeSignature type_sig)
        {
            this.id = id;
            this.Location = id.Location;
            this.type_sig = type_sig;
        }

        public void DefineSymbols(IContext context)
        {
            this.Symbol = new ArgumentSymbol(id.Text);
            this.Symbol.NodeReference = this;
            context.CurrentScope.Define(this.Symbol);
        }

        public void Resolve(IContext context)
        {
            type_sig.ResolveType(context);

            if (!context.CanAccess(type_sig.Type))
                Report.Error.Inaccessible(type_sig.Type.GetQualifiedName(), this.Location);

            this.Symbol.Type = type_sig.Type;
        }

        public IType Type
        {
            get { return type_sig.Type; }
        }

        public ArgumentDecl Clone()
        {
            ArgumentDecl copy = new ArgumentDecl(new Identifier(this.id.Text, this.Location), this.type_sig);
            return copy;
        }
    }

    public class StructDecl : TypeDecl
    {
        Identifier id;
        IList<TypeSignature> interfaces;
        IList<TypeDecl> typedecls;
        IList<FieldDecl> fields;
        IList<MethodDecl> methods;
        IList<PropertyDecl> properties;
        IList<SignalDecl> signals;
        AccessModifier access;

        public StructTypeSymbol Symbol { get; private set; }

        public StructDecl(
            Identifier id,
            AccessModifier access,
            IList<TypeSignature> interfaces)
        {
            this.id = id;
            this.Location = id.Location;
            this.access = access;
            this.interfaces = interfaces == null ? null : new List<TypeSignature>(interfaces);
        }

        public StructDecl(
            Identifier id,
            AccessModifier access,
            IList<TypeSignature> interfaces,
            IList<TypeDecl> typedecls,
            IList<FieldDecl> fields,
            IList<MethodDecl> methods,
            IList<PropertyDecl> properties,
            IList<SignalDecl> signals)
            : this(id, access, interfaces)
        {
            this.typedecls = typedecls == null ? null : new List<TypeDecl>(typedecls);
            this.fields = fields == null ? null : new List<FieldDecl>(fields);
            this.methods = methods == null ? null : new List<MethodDecl>(methods);
            this.properties = properties == null ? null : new List<PropertyDecl>(properties);
            this.signals = signals == null ? null : new List<SignalDecl>(signals);
        }

        public override void DefineSymbols(IContext context)
        {
            this.Symbol = new StructTypeSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = access;

            if (!context.IsNested && (this.access.IsPrivate || this.access.IsFamily || this.access.IsFamAndAssem))
                Report.Error.InvalidGlobalAccessModifier(this.Location);

            context.CurrentScope.Define(this.Symbol);

            context.PushScope(this.Symbol);
            context.PushType(this.Symbol);

            try
            {
                if (typedecls != null)
                    foreach (var type in typedecls)
                        type.DefineSymbols(context);

                if (fields != null)
                    foreach (var field in fields)
                        field.Define(context);

                if (methods != null)
                    foreach (var method in methods)
                        method.DefineSymbols(context);
                               
                if (properties != null)
                    foreach (var property in properties)
                        property.DefineComponents(context);

                /*
                if (signals != null)
                    foreach (var signal in signals)
                        signal.DefineSymbols(context);
                */
            }
            catch (MemberNameSameAsTypesException e)
            {
                Report.Error.MemberNameSameAsTypes(e.Name, this.Location);
            }
            catch (MethodAlreadyDefinedException e)
            {
                Report.Error.MethodAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Error.MemberAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }

            MethodSymbol ctors = this.Symbol.Resolve(MethodSymbol.CTOR, LookupFlags.FLAT) as MethodSymbol;            
            if (ctors != null)
            {
                MethodSymbol default_ctor = ctors.ResolveOverload(new IType[0]) as MethodSymbol;
                if (default_ctor != null)
                    Report.Error.DefaultConstructorInStruct(this.Location);
            }

            context.PopType();
            context.PopScope();
        }

        public override void ResolveSymbols(IContext context)
        {
            this.Symbol.BaseClass = (ClassTypeSymbol)Types.GetType("ValueType");
            ResolveInterfaces(context);

            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveSymbols(context);

            if (fields != null)
                foreach (var field in fields)
                    field.Resolve(context);

            if (methods != null)
                foreach (var method in methods)
                    method.ResolveSymbols(context);

            if (properties != null)
                foreach (var property in properties)
                    property.ResolveComponents(context);

            context.PopType();
            context.PopScope();
        }

        public override void ResolveBodies(IContext context)
        {
            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (typedecls != null)
                foreach (var type in typedecls)
                    type.ResolveBodies(context);

            if (methods != null)
                foreach (var method in methods)
                    method.ResolveBody(context);

            if (properties != null)
                foreach (var property in properties)
                    property.ResolveComponentsBodies(context);

            context.PopType();
            context.PopScope();
        }

        private void ResolveInterfaces(IContext context)
        {
            if (interfaces == null)
                return;

            foreach (var @interface in interfaces)
            {
                @interface.ResolveType(context);
                InterfaceTypeSymbol ns = @interface.Type as InterfaceTypeSymbol;

                if (ns == null)
                    Report.Error.InvalidInterface(@interface.Type.GetQualifiedName(), Location);

                if (!context.CanAccess(ns))
                    Report.Error.Inaccessible(ns.GetQualifiedName(), @interface.Location);

                if (!context.HasConsistentAccessibility(ns, access))
                    Report.Error.InconsistentAccessibility(ns.GetQualifiedName(), this.Symbol.GetQualifiedName(), @interface.Location);

                this.Symbol.AddInterface(ns);
            }
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateTypes(CodeGen gen)
        {
            gen.GenerateTypes(this);
        }

        public override void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public override void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public override void AddType(TypeDecl type)
        {
            if (this.typedecls == null)
                this.typedecls = new List<TypeDecl>();
            this.typedecls.Add(type);
        }

        public override void AddMethod(MethodDecl method)
        {
            if (this.methods == null)
                this.methods = new List<MethodDecl>();
            this.methods.Add(method);
        }

        public override void AddProperty(PropertyDecl property)
        {
            if (this.properties == null)
                this.properties = new List<PropertyDecl>();
            this.properties.Add(property);
        }

        public override void AddField(FieldDecl field)
        {
            if (this.fields == null)
                this.fields = new List<FieldDecl>();
            this.fields.Add(field);
        }

        public IEnumerable<TypeDecl> TypeDecls
        {
            get { return this.typedecls; }
        }

        public IEnumerable<MethodDecl> Methods
        {
            get { return this.methods; }
        }

        public IEnumerable<FieldDecl> Fields
        {
            get { return this.fields; }
        }

        public IEnumerable<PropertyDecl> Properties
        {
            get { return this.properties; }
        }

        public IEnumerable<SignalDecl> Signals
        {
            get { return this.signals; }
        }
    }

    public class InterfaceDecl : TypeDecl
    {
        Identifier id;
        IList<TypeSignature> interfaces;
        AccessModifier access;
        IList<MethodDecl> methods;
        //IList<SignalDecl> signals;

        public InterfaceTypeSymbol Symbol { get; private set; }

        public InterfaceDecl(
            Identifier id,
            AccessModifier access,
            IList<TypeSignature> interfaces)
        {
            this.id = id;
            this.Location = id.Location;
            this.interfaces = interfaces == null ? null : new List<TypeSignature>(interfaces);
            this.access = access;
        }

        public InterfaceDecl(
            Identifier id,
            AccessModifier access,
            IList<TypeSignature> interfaces,
            IList<MethodDecl> methods)
            : this(id, access, interfaces)
        {
            this.methods = methods == null ? null : new List<MethodDecl>(methods);
        }

        public override void DefineSymbols(IContext context)
        {
            this.Symbol = new InterfaceTypeSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = access;

            if (!context.IsNested && (this.access.IsPrivate || this.access.IsFamily || this.access.IsFamAndAssem))
                Report.Error.InvalidGlobalAccessModifier(this.Location);

            context.CurrentScope.Define(this.Symbol);

            context.PushScope(this.Symbol);
            context.PushType(this.Symbol);

            try
            {
                if (methods != null)
                    foreach (var method in methods)
                        method.DefineSymbols(context);
            }
            catch (MemberNameSameAsTypesException e)
            {
                Report.Error.MemberNameSameAsTypes(e.Name, this.Location);
            }
            catch (MethodAlreadyDefinedException e)
            {
                Report.Error.MethodAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Error.MemberAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }

            context.PopType();
            context.PopScope();
        }

        public override void ResolveSymbols(IContext context)
        {
            ResolveInterfaces(context);

            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (methods != null)
                foreach (var method in methods)
                    method.ResolveSymbols(context);

            context.PopType();
            context.PopScope();
        }

        public override void ResolveBodies(IContext context)
        {

        }

        private void ResolveInterfaces(IContext context)
        {
            if (interfaces == null)
                return;

            foreach (var @interface in interfaces)
            {
                @interface.ResolveType(context);
                InterfaceTypeSymbol ns = @interface.Type as InterfaceTypeSymbol;

                if (ns == null)
                    Report.Error.InvalidInterface(@interface.Type.GetQualifiedName(), Location);

                if (!context.CanAccess(ns))
                    Report.Error.Inaccessible(ns.GetQualifiedName(), @interface.Location);

                if (!context.HasConsistentAccessibility(ns, access))
                    Report.Error.InconsistentAccessibility(ns.GetQualifiedName(), this.Symbol.GetQualifiedName(), @interface.Location);

                this.Symbol.AddInterface(ns);
            }
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateTypes(CodeGen gen)
        {
            gen.GenerateTypes(this);
        }

        public override void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public override void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public override void AddMethod(MethodDecl method)
        {
            if (this.methods == null)
                this.methods = new List<MethodDecl>();
            this.methods.Add(method);
        }

        public IEnumerable<MethodDecl> Methods
        {
            get { return this.methods; }
        }
    }

    public class EnumDecl : TypeDecl
    {
        Identifier id;
        AccessModifier access;
        TypeSignature base_type;
        IList<LiteralFieldDecl> fields;

        public EnumTypeSymbol Symbol { get; private set; }

        public EnumDecl(
            Identifier id,
            AccessModifier access,
            TypeSignature base_type)
        {
            this.id = id;
            this.Location = id.Location;
            this.access = access;
            this.base_type = base_type;
        }

        public EnumDecl(
            Identifier id,
            AccessModifier access,
            TypeSignature base_type,
            IList<LiteralFieldDecl> fields)
            : this(id, access, base_type)
        {
            this.fields = fields == null ? null : new List<LiteralFieldDecl>(fields);
        }

        public override void DefineSymbols(IContext context)
        {
            this.Symbol = new EnumTypeSymbol(id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = this.access;

            if(!context.IsNested && (this.access.IsPrivate || this.access.IsFamily || this.access.IsFamAndAssem))
                Report.Error.InvalidGlobalAccessModifier(this.Location);

            context.CurrentScope.Define(this.Symbol);

            context.PushScope(this.Symbol);
            context.PushType(this.Symbol);

            try
            {
                if (fields != null)
                    foreach (var field in fields)
                        field.Define(context);
            }
            catch (SymbolAlreadyDefinedException e)
            {
                Report.Error.MemberAlreadyDefined(this.Symbol.GetQualifiedName(), e.Name, this.Location);
            }

            context.PopType();
            context.PopScope();
        }

        public override void ResolveSymbols(IContext context)
        {
            ResolveBaseType(context);

            this.Symbol.BaseClass = (ClassTypeSymbol)Types.GetType("Enum");

            context.PushScope(Symbol);
            context.PushType(Symbol);

            if (fields != null)
                foreach (var field in fields)
                    field.Resolve(context);

            context.PopType();
            context.PopScope();
        }

        public override void ResolveBodies(IContext context)
        {

        }

        private void ResolveBaseType(IContext context)
        {
            if (base_type == null)
            {
                this.Symbol.BaseClass = (ClassTypeSymbol)Types.GetType("Int32");
                return;
            }

            base_type.ResolveType(context);
            PrimitiveTypeSymbol ps = base_type.Type as PrimitiveTypeSymbol;

            if (ps == null)
                Report.Error.InvalidBaseType(base_type.Type.GetQualifiedName(), base_type.Location);

            this.Symbol.ContentType = ps;
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateTypes(CodeGen gen)
        {

        }

        public override void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public override void GenerateBodies(CodeGen gen)
        {

        }

        public IEnumerable<LiteralFieldDecl> Fields
        {
            get { return this.fields; }
        }
    }

    public class DelegateDecl : TypeDecl
    {
        Identifier id;
        TypeSignature return_type;
        IList<ArgumentDecl> arguments;
        AccessModifier access;
        
        ClassDecl proxy;

        public DelegateDecl(
            Identifier id,
            AccessModifier access,
            TypeSignature return_type,
            IList<ArgumentDecl> arguments)
        {
            this.id = id;
            this.Location = id.Location;
            this.access = access;
            this.return_type = return_type;
            this.arguments = arguments == null ? null : new List<ArgumentDecl>(arguments);
        }

        public override void DefineSymbols(IContext context)
        {
            if (this.proxy != null)
                return;

            IType @object = Types.GetType("Object");
            IType @native_int = Types.GetType("IntPtr");
            IType @iasync_result = Types.GetType("IAsyncResult");
            IType @async_callback = Types.GetType("AsyncCallback");
            IType @void = Types.GetType("Void");
  
            // .class private auto ansi sealed [Identifier] extends [mscorlib]System.MulticastDelegate
            this.proxy = new ClassDecl(
                id,
                access,
                ClassSpecifier.FINAL,
                new ResolvedType(Types.GetType("MulticastDelegate")),
                null
            );

            // .method public hidebysig specialname rtspecialname instance void .ctor(object 'object', native int 'method') runtime managed
            CtorDecl ctor = new CtorDecl(
                AccessModifier.PUBLIC,
                MethodSpecifier.CONSTRUCTOR | MethodSpecifier.RUNTIME_MANAGED,
                new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("object"),
                        new ResolvedType(@object)
                    ),
                    new ArgumentDecl(
                        new Identifier("method"),
                        new ResolvedType(@native_int)
                    )},
                new BlockStatement(null),
                null
            );

            // .method public hidebysig newslot virtual instance void Invoke(int32 a) runtime managed
            List<ArgumentDecl> invoke_args = new List<ArgumentDecl>();
            foreach (var arg in this.arguments)
                invoke_args.Add(arg.Clone());

            MethodDecl invoke = new MethodDecl(
                new Identifier("Invoke"),
                MethodSpecifier.NEW | MethodSpecifier.VIRTUAL | MethodSpecifier.RUNTIME_MANAGED,
                AccessModifier.PUBLIC,
                this.return_type,
                invoke_args,
                new BlockStatement(null)
            );

            // .method public hidebysig newslot virtual instance class [mscorlib]System.IAsyncResult BeginInvoke(int32 a, class [mscorlib]System.AsyncCallback callback, object 'object') runtime managed
            List<ArgumentDecl> begin_invoke_args = new List<ArgumentDecl>();
            foreach (var arg in this.arguments)
                begin_invoke_args.Add(arg.Clone());

            begin_invoke_args.AddRange(
                new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("callback"),
                        new ResolvedType(@async_callback)
                    ),
                    new ArgumentDecl(
                        new Identifier("object"),
                        new ResolvedType(@object)
                    )}
                );

            MethodDecl begin_invoke = new MethodDecl(
                new Identifier("BeginInvoke"),
                MethodSpecifier.NEW | MethodSpecifier.VIRTUAL | MethodSpecifier.RUNTIME_MANAGED,
                AccessModifier.PUBLIC,
                new ResolvedType(@iasync_result),
                begin_invoke_args,
                new BlockStatement(null)
            );
            
            // .method public hidebysig newslot virtual instance void EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
            MethodDecl end_invoke = new MethodDecl(
                new Identifier("EndInvoke"),
                MethodSpecifier.NEW | MethodSpecifier.VIRTUAL | MethodSpecifier.RUNTIME_MANAGED,
                AccessModifier.PUBLIC,
                new ResolvedType(@void),
                new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("result"),
                        new ResolvedType(@iasync_result)
                    )},
                new BlockStatement(null)
            );

            this.proxy.AddMethod(ctor);
            this.proxy.AddMethod(invoke);
            this.proxy.AddMethod(begin_invoke);
            this.proxy.AddMethod(end_invoke);
            
            this.proxy.DefineSymbols(context);
        }

        public override void ResolveSymbols(IContext context)
        {
            this.proxy.ResolveSymbols(context);
        }

        public override void ResolveBodies(IContext context)
        {
            this.proxy.ResolveBodies(context);
        }

        public override void Generate(CodeGen gen)
        {
            this.proxy.Generate(gen);
        }

        public override void GenerateTypes(CodeGen gen)
        {
            this.proxy.Generate(gen);
        }

        public override void GenerateMembers(CodeGen gen)
        {
            this.proxy.GenerateMembers(gen);
        }

        public override void GenerateBodies(CodeGen gen)
        {
            this.proxy.GenerateBodies(gen);
        }
    }

    public class SignalDecl : BaseDecl
    {
        Identifier id;
        TypeSignature type;
        MethodSpecifier specifiers;
        AccessModifier access;

        FieldDecl delegate_field;
        MethodDecl add_method;
        MethodDecl remove_method;

        public SignalSymbol Symbol { get; private set; }

        public SignalDecl(
            Identifier id,
            MethodSpecifier specifiers,
            AccessModifier access,
            TypeSignature type)
        {
            this.type = type;
            this.id = id;
            this.Location = id.Location;
            this.specifiers = specifiers;
            this.access = access;
        }

        public void DefineComponents(IContext context)
        {
            IType @void = Types.GetType("Void");

            this.delegate_field = new FieldDecl(
                this.id,
                default(FieldSpecifier),
                AccessModifier.PRIVATE,
                this.type
            );
            
            // void add_<<delegate_field>>(<<delegate>> value)
            // {
            //     this.<<delegate_field>> += value;
            // }

            this.add_method = new MethodDecl(
                new Identifier(MethodSymbol.ADD_PREFIX + this.id.Text),
                this.specifiers,
                this.access,
                new ResolvedType(@void),
                new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("value"),
                        this.type
                    )},
                new BlockStatement(
                    new Statement[] {
                        new ExpressionStatement(
                            new ComplexAssignment(
                                Operator.Binary.Addition,
                                new AnyExpression(
                                    new Identifier(this.id.Text)
                                ),
                                new AnyExpression(
                                    new Identifier("value")
                                ))
                        )}
                ));

            // void remove_<<delegate_field>>(<<delegate>> value)
            // {
            //     this.<<delegate_field>> -= value;
            // }

            this.remove_method = new MethodDecl(
                new Identifier(MethodSymbol.REMOVE_PREFIX + this.id.Text),
                this.specifiers,
                this.access,
                new ResolvedType(@void),
                new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("value"),
                        this.type
                    )},
                new BlockStatement(
                    new Statement[] {
                        new ExpressionStatement(
                            new ComplexAssignment(
                                Operator.Binary.Subtraction,
                                new AnyExpression(
                                    new Identifier(this.id.Text)
                                ),
                                new AnyExpression(
                                    new Identifier("value")
                                ))
                        )}
                ));

            this.delegate_field.Define(context);
            this.add_method.DefineSymbols(context);
            this.remove_method.DefineSymbols(context);
            
            this.Symbol = new SignalSymbol(this.id.Text + "2");
            this.Symbol.NodeReference = this;
            this.Symbol.Access = this.access;

            this.Symbol.AddMethodReference = this.add_method.Symbol;
            this.Symbol.RemoveMethodReference = this.remove_method.Symbol;
            this.Symbol.DelegateField = this.delegate_field.Symbol;

            context.CurrentScope.Define(this.Symbol);
        }

        public void ResolveComponents(IContext context)
        {
            this.type.ResolveType(context);
            this.Symbol.Type = this.type.Type;

            this.delegate_field.Resolve(context);
            this.add_method.ResolveSymbols(context);
            this.remove_method.ResolveSymbols(context);
        }

        public void ResolveComponentsBodies(IContext context)
        {
            this.add_method.ResolveBody(context);
            this.remove_method.ResolveBody(context);
        }

        public void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public MethodDecl AddMethodDecl
        {
            get { return this.add_method; }
        }

        public MethodDecl RemoveMethodDecl
        {
            get { return this.remove_method; }
        }

        public FieldDecl DelegateField
        {
            get { return this.delegate_field; }
        }
    }

    public class PropertyDecl : BaseDecl
    {
        Identifier id;
        TypeSignature type;
        MethodSpecifier specifiers;
        AccessModifier access;
        BlockStatement setter_body;
        BlockStatement getter_body;

        MethodDecl set_method;
        MethodDecl get_method;

        public PropertySymbol Symbol { get; private set; }

        public PropertyDecl(
            Identifier id,
            MethodSpecifier specifiers,
            AccessModifier access,
            TypeSignature type,
            BlockStatement setter_body,
            BlockStatement getter_body)
        {
            this.type = type;
            this.id = id;
            this.Location = id.Location;
            this.specifiers = specifiers;
            this.access = access;
            this.setter_body = setter_body;
            this.getter_body = getter_body;
        }

        public void DefineComponents(IContext context)
        {
            this.Symbol = new PropertySymbol(this.id.Text);
            this.Symbol.NodeReference = this;
            this.Symbol.Access = this.access;

            IType @void = Types.GetType("Void");

            // void set_<<name>>(<<type>> value)
            // {
            //     <<settter_body>>
            // }

            if (this.setter_body != null)
            {
                this.set_method = new MethodDecl(
                    new Identifier(MethodSymbol.SET_PREFIX + this.id.Text),
                    this.specifiers,
                    this.access,
                    new ResolvedType(@void),
                    new ArgumentDecl[] {
                    new ArgumentDecl(
                        new Identifier("value"),
                        this.type
                    )},
                    this.setter_body
                    );

                this.set_method.DefineSymbols(context);
                this.Symbol.SetMethodReference = this.set_method.Symbol;
            }

            // <<type>> get_<<name>>()
            // {
            //     <<getter_body>>
            // }

            if (this.getter_body != null)
            {
                this.get_method = new MethodDecl(
                    new Identifier(MethodSymbol.GET_PREFIX + this.id.Text),
                    this.specifiers,
                    this.access,
                    this.type,
                    new ArgumentDecl[0],
                    this.getter_body
                    );

                this.get_method.DefineSymbols(context);
                this.Symbol.GetMethodReference = this.get_method.Symbol;
            }

            context.CurrentScope.Define(this.Symbol);
        }

        public void ResolveComponents(IContext context)
        {
            this.type.ResolveType(context);

            if (this.type.Type.IsEqualTo(Types.GetType("Void")))
                Report.Error.VoidPropertyIndexer(this.Symbol.GetQualifiedName(), this.Location);

            this.Symbol.Type = this.type.Type;

            if (this.set_method != null)
                this.set_method.ResolveSymbols(context);
            if (this.get_method != null)
                this.get_method.ResolveSymbols(context);
        }

        public void ResolveComponentsBodies(IContext context)
        {
            if (this.set_method != null)
                this.set_method.ResolveBody(context);
            if (this.get_method != null)
                this.get_method.ResolveBody(context);
        }

        public void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public void GenerateMembers(CodeGen gen)
        {
            gen.GenerateMembers(this);
        }

        public void GenerateBodies(CodeGen gen)
        {
            gen.GenerateBodies(this);
        }

        public MethodDecl SetMethodDecl
        {
            get { return this.set_method; }
        }

        public MethodDecl GetMethodDecl
        {
            get { return this.get_method; }
        }
    }
        
    public class IfStatement : Statement
    {        
        Expression condition;
        Statement true_block;
        Statement false_block;

        public IfStatement(
            Expression condition,
            Statement true_block)
        {
            this.condition = condition;
            this.true_block = true_block;
        }

        public IfStatement(
            Expression condition,
            Statement true_block,
            Statement false_block)
            : this(condition, true_block)
        {
            this.false_block = false_block;
        }

        public override void DefineSymbols(IContext context)
        {
            if (true_block != null)
                true_block.DefineSymbols(context);

            if (false_block != null)
                false_block.DefineSymbols(context);
        }

        public override void ResolveStatement(IContext context)
        {
            if (condition != null)
                condition = condition.ResolveRValue(context);

            if (condition is Assignment)
                Report.Warning.AssignmentInCondition(condition.Location);

            if (true_block != null)
                true_block.ResolveStatement(context);

            if (false_block != null)
                false_block.ResolveStatement(context);

            if (!condition.EvalType.IsEqualTo(Types.GetType("Boolean")))
                Report.Error.NoImplicitConversion(condition.EvalType.GetQualifiedName(), Types.GetType("Boolean").GetQualifiedName(), this.Location);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Expression Condition
        {
            get { return this.condition; }
        }

        public Statement TrueBlock
        {
            get { return this.true_block; }
        }

        public Statement FalseBlock
        {
            get { return this.false_block; }
        }
    }

    public abstract class LoopStatement : Statement
    {
        protected Expression condition;
        protected Statement block;

        public LoopStatement(
            Expression condition,
            Statement block)
        {
            this.condition = condition;
            this.block = block;
        }

        public override void DefineSymbols(IContext context)
        {
            context.EnterLoop();

            if (block != null)
                block.DefineSymbols(context);

            context.ExitLoop();
        }

        public override void ResolveStatement(IContext context)
        {
            context.EnterLoop();

            if (condition != null)
                condition = condition.ResolveRValue(context);

            if (condition is Assignment)
                Report.Warning.AssignmentInCondition(condition.Location);

            if (block != null)
                block.ResolveStatement(context);

            if (condition != null && !condition.EvalType.IsEqualTo(Types.GetType("Boolean")))
                Report.Error.NoImplicitConversion(condition.EvalType.GetQualifiedName(), Types.GetType("Boolean").GetQualifiedName(), condition.Location);
            
            context.ExitLoop();
        }

        public Expression Condition
        {
            get { return this.condition; }
        }

        public Statement Block
        {
            get { return this.block; }
        }
    }

    public class ForStatement : LoopStatement
    {
        StatementExpression initializer;
        StatementExpression iteration;
        LocalDecl local_decl;
        IScope scope;

        public ForStatement(
            StatementExpression initializer, // i = 1, j = 1.5f, ++k
            Expression condition,
            StatementExpression iteration,
            Statement block)
            : base(condition, block)
        {
            this.initializer = initializer;
            this.iteration = iteration;
        }

        public ForStatement(
            LocalDecl local_decl, // int i = 1, j = 2, k = 3
            Expression condition,
            StatementExpression iteration,
            Statement block)
            : base(condition, block)
        {
            this.local_decl = local_decl;
            this.iteration = iteration;
        }

        public override void DefineSymbols(IContext context)
        {
            scope = new BlockScope(context.CurrentScope);
            context.PushScope(scope);

            if (initializer != null)
                initializer.DefineSymbols(context);

            if (local_decl != null)
                local_decl.Define(context);

            if (iteration != null)
                iteration.DefineSymbols(context);

            base.DefineSymbols(context);

            context.PopScope();
        }

        public override void ResolveStatement(IContext context)
        {
            context.PushScope(scope);

            if (initializer != null)
                initializer = (StatementExpression)initializer.ResolveRValue(context);

            if (local_decl != null)
                local_decl.Resolve(context);

            if (iteration != null)
                iteration = (StatementExpression)iteration.ResolveRValue(context);

            base.ResolveStatement(context);

            context.PopScope();
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public StatementExpression Initializer
        {
            get { return this.initializer; }
        }

        public StatementExpression Iteration
        {
            get { return this.iteration; }
        }

        public LocalDecl LocalDecl
        {
            get { return this.local_decl; }
        }
    }

    public class WhileStatement : LoopStatement
    {
        public WhileStatement(
            Expression condition,
            Statement block)
            : base(condition, block)
        {

        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class DoStatement : LoopStatement
    {
        public DoStatement(
            Expression condition,
            Statement block)
            : base(condition, block)
        {

        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class ContinueStatement : Statement
    {
        public ContinueStatement(Location loc)
        {
            this.Location = loc;
        }

        public override void ResolveStatement(IContext context)
        {
            if (!context.IsInsideLoop)
                Report.Error.BreakContinueOutsideLoop(this.Location);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class BreakStatement : Statement
    {
        public BreakStatement(Location loc)
        {
            this.Location = loc;
        }

        public override void ResolveStatement(IContext context)
        {
            if (!context.IsInsideLoop)
                Report.Error.BreakContinueOutsideLoop(this.Location);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class EmptyStatement : Statement
    {
        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class LabeledStatement : Statement
    {
        Identifier id;
        Statement statement;

        public LabelSymbol Symbol { get; private set; }

        public LabeledStatement(
            Identifier id,
            Statement statement)
        {
            this.id = id;
            this.Location = id.Location;
            this.statement = statement;
        }

        public override void DefineSymbols(IContext context)
        {
            Symbol = new LabelSymbol(id.Text);
            Symbol.NodeReference = this;
            context.CurrentScope.Define(Symbol);

            if (statement != null)
                statement.DefineSymbols(context);
        }

        public override void ResolveStatement(IContext context)
        {
            if (statement != null)
                statement.ResolveStatement(context);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Statement Statement
        {
            get { return this.statement; }
        }
    }

    public class GotoStatement : Statement
    {
        Identifier id;

        public LabelSymbol Symbol { get; private set; }

        public GotoStatement(
            Identifier id)
        {
            this.id = id;
            this.Location = id.Location;
        }

        public override void ResolveStatement(IContext context)
        {
            LabelSymbol label = context.CurrentScope.Resolve(id.Text, LookupFlags.GLOBAL) as LabelSymbol;

            if (label == null)
                Report.Error.InvalidLabel(id.Text, this.Location);

            this.Symbol = label;
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class ReturnStatement : Statement
    {
        Expression expr;

        public ReturnStatement(
            Expression expr,
            Location loc)
        {
            this.expr = expr;
            this.Location = loc;
        }

        public override void ResolveStatement(IContext context)
        {
            if (this.expr != null)
                this.expr = this.expr.ResolveRValue(context);

            IType return_type = context.CurrentMethod.ReturnType;

            if (return_type.IsEqualTo(Types.GetType("Void")))
            {
                if (this.expr == null)
                    return;
                else
                    Report.Error.VoidReturn(context.CurrentMethod.GetQualifiedName(), this.expr.Location);
            }

            if (this.expr == null || this.expr.EvalType == null)
                Report.Error.NoReturnValue(return_type.GetQualifiedName(), this.Location);

            if (!Types.SetType(ref this.expr, return_type, context))
                Report.Error.NoImplicitConversion(this.expr.EvalType.GetQualifiedName(), return_type.GetQualifiedName(), this.expr.Location);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Expression Expression
        {
            get { return this.expr; }
        }
    }

    public class ThrowStatement : Statement
    {
        Expression expr;

        public ThrowStatement(
            Expression expr,
            Location loc)
        {
            this.expr = expr;
            this.Location = loc;
        }

        public override void ResolveStatement(IContext context)
        {
            if (this.expr != null)
            {
                this.expr = this.expr.ResolveRValue(context);
                if (!this.expr.EvalType.IsInstanceOf(Types.GetType("Exception")))
                    Report.Error.InvalidExceptionType(this.expr.Location);
            }
            else
            {
                if (!context.IsInsideCatchClause)
                    Report.Error.ThrowOutsideCatch(this.Location);
            }
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Expression Expression
        {
            get { return this.expr; }
        }
    }

    public class TryStatement : Statement
    {
        Statement block;
        IList<CatchClause> catch_clauses;
        FinallyClause finally_clause;

        public TryStatement(
            Statement block,
            IList<CatchClause> catch_clauses,
            FinallyClause finally_clause)
        {
            this.block = block;
            this.catch_clauses = catch_clauses == null ? null : new List<CatchClause>(catch_clauses);
            this.finally_clause = finally_clause;
        }

        public TryStatement(
            Statement block,
            IList<CatchClause> catch_clauses)
            : this(block, catch_clauses, null)
        {

        }

        public TryStatement(
            Statement block,
            FinallyClause finally_clause)
            : this(block, null, finally_clause)
        {

        }
        
        public override void DefineSymbols(IContext context)
        {
            if (block != null)
                block.DefineSymbols(context);

            if (catch_clauses != null)
                foreach (var clause in catch_clauses)
                    clause.DefineSymbols(context);

            if (finally_clause != null)
                finally_clause.DefineSymbols(context);
        }

        public override void ResolveStatement(IContext context)
        {
            if (block != null)
                block.ResolveStatement(context);

            if (catch_clauses != null)
                foreach (var clause in catch_clauses)
                    clause.ResolveStatement(context);

            if (finally_clause != null)
                finally_clause.ResolveStatement(context);

            if ((catch_clauses == null || catch_clauses.Count == 0) && finally_clause == null)
                Report.Error.ExpectedCatchFinally(this.Location);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Statement ProtectedBlock
        {
            get { return this.block; }
        }

        public IEnumerable<CatchClause> CatchClauses
        {
            get { return this.catch_clauses; }
        }

        public FinallyClause FinallyClause
        {
            get { return this.finally_clause; }
        }
    }

    public class CatchClause : Statement
    {
        Identifier id;
        TypeSignature type;
        Statement block; // } catch(E e) { empty }

        IScope scope;

        public LocalVariableSymbol Symbol { get; private set; }

        public CatchClause(
            TypeSignature type,
            Identifier id,
            Statement block)
        {
            this.id = id;
            this.Location = id.Location;
            this.type = type;
            this.block = block;
        }

        public override void DefineSymbols(IContext context)
        {
            this.scope = new BlockScope(context.CurrentScope);
            context.PushScope(this.scope);
            context.EnterCatchClause();

            if (id != null)
            {
                this.Symbol = new LocalVariableSymbol(id.Text);
                this.Symbol.NodeReference = this;
                context.CurrentScope.Define(this.Symbol);
            }

            if (this.block != null)
                this.block.DefineSymbols(context);

            context.ExitCatchClause();
            context.PopScope();
        }

        public override void ResolveStatement(IContext context)
        {
            if (this.id != null)
            {
                this.type.ResolveType(context);

                if (!context.CanAccess(this.type.Type))
                    Report.Error.Inaccessible(this.type.Type.GetQualifiedName(), this.Location);

                this.Symbol.Type = this.type.Type;
            }

            context.PushScope(this.scope);
            context.EnterCatchClause();

            if (block != null)
                block.ResolveStatement(context);

            context.ExitCatchClause();
            context.PopScope();
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Statement Block
        {
            get { return this.block; }
        }
    }

    public class FinallyClause : Statement
    {
        Statement block;

        public FinallyClause(
            Statement block)
        {
            this.block = block;
        }

        public override void DefineSymbols(IContext context)
        {
            if (this.block != null)
                this.block.DefineSymbols(context);
        }

        public override void ResolveStatement(IContext context)
        {
            if (this.block != null)
                this.block.ResolveStatement(context);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Statement Block
        {
            get { return this.block; }
        }
    }

    public class BlockStatement : Statement
    {
        IList<Statement> statements;
        BlockScope scope;

        public BlockStatement(
            IList<Statement> statements)
        {
            this.statements = statements == null ? null : new List<Statement>(statements);
        }

        public override void DefineSymbols(IContext context)
        {
            scope = new BlockScope(context.CurrentScope);

            context.PushScope(scope);

            if (statements != null)
                foreach (var stmt in statements)
                    stmt.DefineSymbols(context);

            context.PopScope();
        }

        public override void ResolveStatement(IContext context)
        {
            context.PushScope(scope);

            if (statements != null)
                foreach (var stmt in statements)
                    stmt.ResolveStatement(context);

            context.PopScope();
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public IEnumerable<Statement> Statements
        {
            get { return this.statements; }
        }
    }

    public class ForeachStatement : Statement
    {
        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class LocalDeclStatement : Statement
    {
        LocalDecl locals;

        public LocalDeclStatement(
            LocalDecl locals)
        {
            this.locals = locals;
        }

        public override void DefineSymbols(IContext context)
        {
            this.locals.Define(context);
        }

        public override void ResolveStatement(IContext context)
        {
            this.locals.Resolve(context);
        }

        public override void GenerateStatement(CodeGen gen)
        {
            gen.Generate(this);
        }

        public LocalDecl Locals
        {
            get { return this.locals; }
        }
    }

    public abstract class LocalDecl : ASTNode
    {
        public abstract void Define(IContext context);

        public abstract void Resolve(IContext context);

        public abstract void Generate(CodeGen gen);
    }

    public class ExplicitlyTypedLocalDecl : LocalDecl // int i = 1, j = 2;
    {
        TypeSignature type;
        IList<VariableDeclarator> declarators;

        public ExplicitlyTypedLocalDecl(
            TypeSignature type,
            IList<VariableDeclarator> declarators,
            Location loc)
        {
            this.type = type;
            this.declarators = declarators == null ? null : new List<VariableDeclarator>(declarators);
            this.Location = loc;
        }

        public override void Define(IContext context)
        {
            foreach (var decl in declarators)
                decl.Define(context);
        }

        public override void Resolve(IContext context)
        {
            this.type.ResolveType(context);

            if (!context.CanAccess(this.type.Type))
                Report.Error.Inaccessible(this.type.Type.GetQualifiedName(), this.Location);

            foreach (var decl in declarators)
            {
                decl.SetSymbolType(this.type.Type);
                decl.Resolve(context);
            }
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public IEnumerable<VariableDeclarator> Declarators
        {
            get { return this.declarators; }
        }
    }

    public class ImplicitlyTypedLocalDecl : LocalDecl // var i = 123;
    {
        VariableDeclarator declarator;

        public ImplicitlyTypedLocalDecl(
            VariableDeclarator declarator,
            Location loc)
        {
            this.declarator = declarator;
            this.Location = loc;
        }

        public override void Define(IContext context)
        {
            this.declarator.Define(context);
        }

        public override void Resolve(IContext context)
        {
            if (!this.declarator.HasInitialValue)
                Report.Error.VarLocalNotInitialized(this.Location);

            this.declarator.ResolveType(context);
            IType decl_type = this.declarator.GetExpressionType();
            this.declarator.SetSymbolType(decl_type);
            this.declarator.Resolve(context);

            if (!context.CanAccess(decl_type))
                Report.Error.Inaccessible(decl_type.GetQualifiedName(), this.Location);

            this.declarator.SetSymbolType(decl_type);
        }

        public override void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public VariableDeclarator Declarator
        {
            get { return this.declarator; }
        }
    }

    public class VariableDeclarator : ASTNode
    {
        Identifier id;
        Expression initial_value;
        Statement initializer;

        public LocalVariableSymbol Symbol { get; private set; }

        public VariableDeclarator(
            Identifier id,
            Expression initial_value)
        {
            this.id = id;
            this.Location = id.Location;
            this.initial_value = initial_value;
        }

        public void Define(IContext context)
        {
            this.Symbol = new LocalVariableSymbol(this.id.Text);
            this.Symbol.NodeReference = this;
            context.CurrentScope.Define(this.Symbol);
        }

        public void Resolve(IContext context)
        {
            if (this.initial_value != null)
            {
                LocalExpression local_exp = new LocalExpression(this.Symbol);
                local_exp.Location = this.Location;
                StatementExpression assign = new Assignment(
                    local_exp,
                    this.initial_value
                );
                assign.Location = this.Location;
                assign = (StatementExpression)assign.ResolveRValue(context);
                this.initializer = new ExpressionStatement(assign);
            }
        }

        public void ResolveType(IContext context)
        {
            if (this.initial_value != null)
                this.initial_value = this.initial_value.ResolveRValue(context);
        }

        public void Generate(CodeGen gen)
        {
            gen.Generate(this);
        }

        public void SetSymbolType(IType type)
        {
            this.Symbol.Type = type;
        }

        public IType GetExpressionType()
        {
            if (this.initial_value != null)
                return this.initial_value.EvalType;
            return null;
        }

        public bool HasInitialValue
        {
            get { return this.initial_value != null; }
        }

        public Identifier Id
        {
            get { return this.id; }
        }

        public Statement Initializer
        {
            get { return this.initializer; }
        }
    }

    public abstract class StatementExpression : Expression
    {
        public virtual void DefineSymbols(IContext context)
        {

        }

        public virtual void GenerateAsStatement(CodeGen gen)
        {
            gen.GenerateAsStatement(this);
        }
    }

    public class AnyExpression : Expression
    {
        Identifier id;

        public AnyExpression(
            Identifier id)
        {
            this.id = id;
            this.Location = id.Location;
        }

        public AnyExpression(
            string id)
            : this(new Identifier(id))
        {

        }

        public AnyExpression(
            string id,
            Location loc)
            : this(id)
        {
            this.Location = loc;
        }

        public override Expression ResolveLValue(IContext context)
        {
            Expression evolved = Evolve(context);

            evolved.Location = this.Location;

            if (evolved != this)
                evolved = evolved.ResolveLValue(context);

            this.EvalType = evolved.EvalType;

            return evolved;
        }

        public override Expression ResolveRValue(IContext context)
        {
            Expression evolved = Evolve(context);

            evolved.Location = this.Location;

            if (evolved != this)
                evolved = evolved.ResolveRValue(context);

            this.EvalType = evolved.EvalType;

            return evolved;
        }

        private Expression Evolve(IContext context)
        {
            if (id.Text == Tokens.KW_THIS)
            {
                IType type = context.GetEnclosingType(context.CurrentScope);
                ObjectTypeSymbol obj = type as ObjectTypeSymbol;
                if (obj == null)
                    Report.Error.InvalidInContext(Tokens.KW_THIS, this.Location);
                return new ThisExpression(obj);
            }

            if (id.Text == Tokens.KW_BASE)
            {
                IType type = context.GetEnclosingType(context.CurrentScope);
                ObjectTypeSymbol obj = type as ObjectTypeSymbol;
                if (obj == null)
                    Report.Error.InvalidInContext(Tokens.KW_BASE, this.Location);
                return new BaseExpression(obj);
            }

            if (id.Text == Tokens.KW_GLOBAL)
            {
                return new NamespaceExpression(context.GlobalNamespace);
            }

            Symbol symbol = context.CurrentScope.Resolve(id.Text, LookupFlags.GLOBAL);

            if (symbol == null)
                Report.Error.UnresolvedIdentifier(id.Text, this.Location);

            if (!context.CanAccess(symbol))
                Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

            if (symbol is NamespaceSymbol)
            {
                return new NamespaceExpression(symbol as NamespaceSymbol);
            }

            if (symbol is ClassTypeSymbol)
            {
                return new ClassExpression(symbol as ClassTypeSymbol);
            }

            if (symbol is StructTypeSymbol)
            {
                return new ValueTypeExpression(symbol as StructTypeSymbol);
            }

            if (symbol is InterfaceTypeSymbol)
            {
                return new InterfaceExpression(symbol as InterfaceTypeSymbol);
            }

            if (symbol is FieldSymbol)
            {
                FieldSymbol field = symbol as FieldSymbol;
                Expression instance = null;
                if (!field.IsStatic)
                {
                    instance = new AnyExpression(Tokens.KW_THIS);
                    instance = instance.ResolveRValue(context);
                }

                return new FieldExpression(field, instance);
            }

            if (symbol is PropertySymbol)
            {
                PropertySymbol property = symbol as PropertySymbol;
                Expression instance = null;
                if (!property.IsStatic)
                {
                    instance = new AnyExpression(Tokens.KW_THIS);
                    instance = instance.ResolveRValue(context);
                }

                return new PropertyExpression(property, instance);
            }

            if (symbol is MethodSymbol)
            {
                MethodSymbol method = symbol as MethodSymbol;
                Expression instance = null;
                if (!method.IsStatic)
                {
                    instance = new AnyExpression(Tokens.KW_THIS);
                    instance = instance.ResolveRValue(context);
                }
                return new MethodPointerExpression(symbol as MethodSymbol, instance);
            }

            if (symbol is ArgumentSymbol)
            {
                return new ArgumentExpression(symbol as ArgumentSymbol);
            }

            if (symbol is LocalVariableSymbol)
            {
                return new LocalExpression(symbol as LocalVariableSymbol);
            }
            
            Report.Error.InvalidInContext(symbol.Name, this.Location);

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }
    
    public class DottedExpression : Expression
    {
        Identifier id;
        Expression left;

        public DottedExpression(
            Expression left,
            Identifier id)
        {
            this.id = id;
            this.Location = id.Location;
            this.left = left;
        }

        public override Expression ResolveLValue(IContext context)
        {
            left = left.ResolveRValue(context);
            Expression evolved = Evolve(context);

            evolved.Location = this.Location;

            if (evolved != this)
                evolved = evolved.ResolveLValue(context);

            this.EvalType = evolved.EvalType;

            return evolved;
        }

        public override Expression ResolveRValue(IContext context)
        {
            left = left.ResolveRValue(context);
            Expression evolved = Evolve(context);

            evolved.Location = this.Location;

            if (evolved != this)
                evolved = evolved.ResolveRValue(context);

            this.EvalType = evolved.EvalType;

            return evolved;
        }

        private Expression Evolve(IContext context)
        {
            if (left is NamespaceExpression)
            {
                NamespaceExpression ex = left as NamespaceExpression;
                NamespaceSymbol scope = ex.Symbol;

                Symbol symbol = scope.Resolve(id.Text, LookupFlags.LOCAL);

                if (symbol == null)
                    Report.Error.UnresolvedIdentifier(id.Text, this.Location);
                
                if (!context.CanAccess(symbol))
                    Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

                if (symbol is NamespaceSymbol)
                    return new NamespaceExpression(symbol as NamespaceSymbol);

                if (symbol is ClassTypeSymbol)
                    return new ClassExpression(symbol as ClassTypeSymbol);

                if (symbol is StructTypeSymbol)
                    return new ValueTypeExpression(symbol as StructTypeSymbol);

                if (symbol is InterfaceTypeSymbol)
                    return new InterfaceExpression(symbol as InterfaceTypeSymbol);

                Report.Error.InvalidInContext(symbol.Name, this.Location);
            }
            else if (left is TypeExpression)
            {
                if (left.EvalType == null)
                    Report.Error.InvalidInContext(id.Text, this.Location);

                IScope scope = left.EvalType.MembersScope;

                if (scope == null)
                    Report.Error.InvalidInContext(id.Text, this.Location);

                Symbol symbol = scope.Resolve(id.Text, LookupFlags.LOCAL);

                if (symbol == null)
                    Report.Error.UnresolvedIdentifier(id.Text, this.Location);

                if (!context.CanAccess(symbol))
                    Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

                if (symbol is NamespaceSymbol)
                    return new NamespaceExpression(symbol as NamespaceSymbol);

                if (symbol is ClassTypeSymbol)
                    return new ClassExpression(symbol as ClassTypeSymbol);

                if (symbol is StructTypeSymbol)
                    return new ValueTypeExpression(symbol as StructTypeSymbol);

                if (symbol is InterfaceTypeSymbol)
                    return new InterfaceExpression(symbol as InterfaceTypeSymbol);

                if (symbol is FieldSymbol)
                {
                    FieldSymbol field = symbol as FieldSymbol;
                    if (!field.IsStatic)
                        Report.Error.NonStaticMemberAccess(field.GetQualifiedName(), this.Location);
                    return new FieldExpression(field, null);
                }

                if (symbol is MethodSymbol)
                {
                    MethodSymbol method = symbol as MethodSymbol;
                    if (!method.IsStatic)
                        Report.Error.NonStaticMemberAccess(method.GetQualifiedName(), this.Location);
                    return new MethodPointerExpression(method, null);
                }

                if (symbol is PropertySymbol)
                {
                    PropertySymbol property = symbol as PropertySymbol;
                    if (!property.IsStatic)
                        Report.Error.NonStaticMemberAccess(property.GetQualifiedName(), this.Location);
                    return new PropertyExpression(property, null);
                }
            }
            else
            {
                if (left.EvalType == null)
                    Report.Error.InvalidInContext(id.Text, this.Location);

                IScope scope = left.EvalType.MembersScope;

                if (scope == null)
                    Report.Error.InvalidInContext(id.Text, this.Location);

                Symbol symbol = scope.Resolve(id.Text, LookupFlags.LOCAL);

                if (symbol == null)
                    Report.Error.UnresolvedIdentifier(id.Text, this.Location);

                if (!context.CanAccess(symbol))
                    Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

                if (symbol is NamespaceSymbol)
                    return new NamespaceExpression(symbol as NamespaceSymbol);

                if (symbol is ClassTypeSymbol)
                    return new ClassExpression(symbol as ClassTypeSymbol);

                if (symbol is StructTypeSymbol)
                    return new ValueTypeExpression(symbol as StructTypeSymbol);

                if (symbol is InterfaceTypeSymbol)
                    return new InterfaceExpression(symbol as InterfaceTypeSymbol);

                if (symbol is FieldSymbol)
                {
                    FieldSymbol field = symbol as FieldSymbol;
                    if (field.IsStatic)
                        Report.Error.StaticMemberAccess(field.GetQualifiedName(), this.Location);
                    return new FieldExpression(field, left);
                }

                if (symbol is MethodSymbol)
                {
                    MethodSymbol method = symbol as MethodSymbol;
                    if (method.IsStatic)
                        Report.Error.StaticMemberAccess(method.GetQualifiedName(), this.Location);
                    return new MethodPointerExpression(method, left);
                }

                if (symbol is PropertySymbol)
                {
                    PropertySymbol property = symbol as PropertySymbol;
                    if (property.IsStatic)
                        Report.Error.StaticMemberAccess(property.GetQualifiedName(), this.Location);
                    return new PropertyExpression(property, left);
                }
            }

            Report.Error.InvalidInContext(this.id.Text, this.Location);

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class MethodCallExpression : StatementExpression
    {
        Identifier id;
        Expression expr;
        Expression instance;
        IList<Expression> actual_args;

        public MethodSymbol Symbol { get; private set; }
        
        public MethodCallExpression(
            Expression expr,
            Identifier id,
            IList<Expression> actual_args)
        {
            this.id = id;
            this.Location = id.Location;
            this.expr = expr;
            this.actual_args = actual_args == null ? null : new List<Expression>(actual_args);
        }

        public MethodCallExpression(
            MethodSymbol symbol,
            Expression instance,
            IList<Expression> actual_args)
        {
            this.Symbol = symbol;
            this.instance = instance;
            this.actual_args = actual_args == null ? null : new List<Expression>(actual_args);
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.IsPolymorphicCall = true;

            if (this.Symbol == null)
            {
                IList<IType> actual_types = new List<IType>();
                if (this.actual_args != null)
                {
                    int arity = this.actual_args.Count;
                    for (int i = 0; i < arity; ++i)
                    {
                        this.actual_args[i] = this.actual_args[i].ResolveRValue(context);
                        actual_types.Add(this.actual_args[i].EvalType);
                    }
                }

                if (this.expr == null)
                {
                    Symbol symbol = context.CurrentScope.Resolve(id.Text, LookupFlags.GLOBAL);

                    if (symbol == null)
                        Report.Error.UnresolvedIdentifier(id.Text, this.Location);

                    if (!context.CanAccess(symbol))
                        Report.Error.Inaccessible(symbol.GetQualifiedName(), this.Location);

                    MethodSymbol methods = symbol as MethodSymbol;

                    if (methods == null)
                        Report.Error.InvalidInContext(this.id.Text, this.Location);

                    try
                    {
                        MethodSymbol method = methods.ResolveOverload(actual_types) as MethodSymbol;

                        if (method == null)
                            Report.Error.UnresolvedIdentifier(this.id.Text, this.Location);

                        if (context.CurrentMethod.IsStatic && !method.IsStatic)
                            Report.Error.NonStaticMemberAccess(method.GetQualifiedName(), this.Location);

                        if (!context.CanAccess(method))
                            Report.Error.Inaccessible(method.GetQualifiedName(), this.Location);
                        
                        Expression instance = null;
                        if (!method.IsStatic)
                        {
                            instance = new AnyExpression(Tokens.KW_THIS);
                            instance = instance.ResolveRValue(context);
                        }

                        Expression call = new MethodCallExpression(method, instance, this.actual_args);
                        call = call.ResolveRValue(context);
                        return call;
                    }
                    catch (AmbiguousMatchException)
                    {
                        Report.Error.AmbiguousCall(methods.GetQualifiedName(), this.Location);
                    }
                }
                else
                {
                    this.expr = this.expr.ResolveRValue(context);
                    this.instance = this.expr;

                    bool must_be_static = false;

                    IScope scope;

                    if (this.expr is TypeExpression)
                    {
                        scope = this.expr.EvalType.MembersScope;
                        must_be_static = true;
                    }
                    else
                    {
                        scope = this.expr.EvalType.MembersScope;
                    }

                    if (scope == null)
                        Report.Error.InvalidInContext(id.Text, this.Location);

                    if (this.expr is BaseExpression)
                        this.IsPolymorphicCall = false;

                    Symbol methods_symbol = scope.Resolve(this.id.Text, LookupFlags.LOCAL);

                    MethodSymbol methods = methods_symbol as MethodSymbol;

                    if (methods == null)
                        Report.Error.InvalidInContext(this.id.Text, this.Location);

                    try
                    {
                        MethodSymbol method = methods.ResolveOverload(actual_types) as MethodSymbol;

                        if (method == null)
                            Report.Error.UnresolvedIdentifier(this.id.Text, this.Location);

                        if (must_be_static && !method.IsStatic)
                            Report.Error.NonStaticMemberAccess(method.GetQualifiedName(), this.Location);
                        else if (!must_be_static && method.IsStatic)
                            Report.Error.StaticMemberAccess(method.GetQualifiedName(), this.Location);

                        if (!context.CanAccess(method))
                            Report.Error.Inaccessible(method.GetQualifiedName(), this.Location);

                        if (must_be_static)
                            this.instance = null;

                        this.Symbol = method;
                    }
                    catch (AmbiguousMatchException)
                    {
                        Report.Error.AmbiguousCall(methods.GetQualifiedName(), this.Location);
                    }
                }
            }
            else
            {
                if (this.instance is BaseExpression)
                    this.IsPolymorphicCall = false;
            }

            this.EvalType = this.Symbol.ReturnType;

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAsStatement(CodeGen gen)
        {
            gen.GenerateAsStatement(this);
        }

        public bool IsStaticCall
        {
            get { return this.Symbol.IsStatic; }
        }

        public bool IsPolymorphicCall
        {
            get; private set;
        }

        public Expression Instance
        {
            get { return this.instance; }
        }

        public IEnumerable<Expression> Arguments
        {
            get { return this.actual_args; }
        }
    }

    public class CompoundExpression : StatementExpression // a=1,b=2,new Z(1),c=5*4
    {
        IList<StatementExpression> list;

        public CompoundExpression(
            IList<StatementExpression> list)
        {
            this.list = list == null ? null : new List<StatementExpression>(list);
        }

        public override Expression ResolveRValue(IContext context)
        {
            if (this.list != null)
            {
                int size = this.list.Count;
                for (int i = 0; i < size; ++i)
                    this.list[i] = this.list[i].ResolveRValue(context) as StatementExpression;

                if (size > 0)
                    this.EvalType = this.list[size - 1].EvalType;
            }
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAsStatement(CodeGen gen)
        {
            gen.GenerateAsStatement(this);
        }

        public IEnumerable<StatementExpression> List
        {
            get { return this.list; }
        }
    }

    public class NewArrayExpression : Expression
    {
        TypeSignature type;
        IList<Expression> rank_list;

        public ArrayTypeSymbol Symbol { get; private set; }

        public NewArrayExpression(
            TypeSignature type,
            IList<Expression> rank_list)
        {
            this.type = type;
            this.rank_list = rank_list == null ? null : new List<Expression>(rank_list);
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.type.ResolveType(context);

            if (!context.CanAccess(this.type.Type))
                Report.Error.Inaccessible(this.type.Type.GetQualifiedName(), this.Location);

            if (this.rank_list == null || this.rank_list.Count == 0)
                Report.Error.MustSpecifyRank(this.Location);

            int rank = this.rank_list.Count;

            this.Symbol = new ArrayTypeSymbol(rank);
            this.Symbol.ContentType = this.type.Type;

            if (rank > 1)
            {
                Expression new_obj = new NewObjectExpression(new ResolvedType(this.Symbol), this.rank_list);
                new_obj.Location = this.Location;
                new_obj = new_obj.ResolveRValue(context);
                return new_obj;
            }

            for (int i = 0; i < rank; ++i)
                this.rank_list[i] = this.rank_list[i].ResolveRValue(context);

            this.EvalType = this.Symbol;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public IEnumerable<Expression> RankList
        {
            get { return this.rank_list; }
        }
    }

    public class NewObjectExpression : StatementExpression
    {
        TypeSignature type;
        IList<Expression> actual_args;

        public MethodSymbol Ctor { get; private set; }

        public bool IsRefClass { get; private set; }

        public NewObjectExpression(
            TypeSignature type,
            IList<Expression> actual_args)
        {
            this.type = type;
            this.actual_args = actual_args == null ? null : new List<Expression>(actual_args);
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.type.ResolveType(context);

            if (!context.CanAccess(this.type.Type))
                Report.Error.Inaccessible(this.type.Type.GetQualifiedName(), this.Location);

            IType resolved = this.type.Type;

            //if (!(resolved is ClassTypeSymbol) && !(resolved is ValueTypeSymbol) && !(resolved is InterfaceTypeSymbol))
            //    Report.Error.CannotInstantiate(resolved.Name, this.Location);

            IList<IType> actual_types = new List<IType>();

            if (this.actual_args != null)
            {
                int arity = this.actual_args.Count;
                for (int i = 0; i < arity; ++i)
                {
                    this.actual_args[i] = this.actual_args[i].ResolveRValue(context);
                    actual_types.Add(this.actual_args[i].EvalType);
                }
            }
                
            if (resolved is ClassTypeSymbol)
            {
                ClassTypeSymbol class_symbol = resolved as ClassTypeSymbol;

                if (Types.IsDelegate(resolved))
                {
                    if (this.actual_args == null || this.actual_args.Count != 1 || !(this.actual_args[0] is MethodPointerExpression))
                        Report.Error.NotAMethodPointer(this.Location);

                    Expression new_delegate = new NewDelegateExpression(
                        class_symbol,
                        (MethodPointerExpression)this.actual_args[0]
                    );
                    new_delegate = new_delegate.ResolveRValue(context);
                    return new_delegate;
                }

                this.IsRefClass = true;


                if (class_symbol.IsAbstract)
                    Report.Error.CannotInstantiateAbstract(class_symbol.GetQualifiedName(), this.Location);

                if (!context.CanAccess(class_symbol))
                    Report.Error.Inaccessible(class_symbol.GetQualifiedName(), this.Location);

                Symbol ctors_symbol = class_symbol.Resolve(MethodSymbol.CTOR, LookupFlags.FLAT);

                if (ctors_symbol == null)
                    throw new Exception();

                MethodSymbol ctors = ctors_symbol as MethodSymbol;

                try
                {
                    MethodSymbol ctor = ctors.ResolveOverload(actual_types) as MethodSymbol;

                    if (ctor == null)
                        Report.Error.NoConstructorFound(class_symbol.GetQualifiedName(), actual_types.Count, this.Location);

                    if (!context.CanAccess(ctor))
                        Report.Error.Inaccessible(ctor.GetQualifiedName(), this.Location);

                    this.Ctor = ctor;
                }
                catch (AmbiguousMatchException)
                {
                    Report.Error.AmbiguousCall(ctors.GetQualifiedName(), this.Location);
                }
            }
            else if (resolved is StructTypeSymbol)
            {
                this.IsRefClass = false;

                StructTypeSymbol struct_symbol = resolved as StructTypeSymbol;

                if (!context.CanAccess(struct_symbol))
                    Report.Error.Inaccessible(struct_symbol.GetQualifiedName(), this.Location);

                if (actual_args == null || actual_args.Count == 0)
                {
                    Expression init = new InitObjectExpression(struct_symbol);
                    init.Location = this.Location;
                    init = init.ResolveRValue(context);
                    return init;
                }
                else
                {
                    Symbol ctors_symbol = struct_symbol.Resolve(MethodSymbol.CTOR, LookupFlags.FLAT);

                    if (ctors_symbol == null)
                        throw new Exception();

                    MethodSymbol ctors = ctors_symbol as MethodSymbol;

                    try
                    {
                        MethodSymbol ctor = ctors.ResolveOverload(actual_types) as MethodSymbol;

                        Expression new_value = new NewValueTypeExpression(struct_symbol, ctor, actual_args);
                        new_value.Location = this.Location;
                        new_value = new_value.ResolveRValue(context);
                        return new_value;
                    }
                    catch (AmbiguousMatchException)
                    {
                        Report.Error.AmbiguousCall(ctors.GetQualifiedName(), this.Location);
                    }

                }
            }
            else if (resolved is InterfaceTypeSymbol)
            {
                Report.Error.CannotInstantiateAbstract(resolved.GetQualifiedName(), this.Location);
            }

            this.EvalType = resolved;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public IEnumerable<Expression> Arguments
        {
            get { return this.actual_args; }
        }
    }

    public class InitObjectExpression : Expression
    {
        public StructTypeSymbol Symbol { get; private set; }

        public InitObjectExpression(
            StructTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = this.Symbol.Type;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class NewValueTypeExpression : Expression
    {
        IList<Expression> actual_args;

        public StructTypeSymbol Symbol { get; private set; }
        public MethodSymbol Ctor { get; private set; }

        public NewValueTypeExpression(
            StructTypeSymbol symbol,
            MethodSymbol ctor,
            IList<Expression> actual_args)
        {
            this.Symbol = symbol;
            this.Ctor = ctor;
            this.actual_args = actual_args == null ? null : new List<Expression>(actual_args);
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = this.Symbol.Type;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }

        public IEnumerable<Expression> Arguments
        {
            get { return this.actual_args; }
        }
    }

    public class NewDelegateExpression : Expression
    {
        MethodPointerExpression pointer_expr;

        public ClassTypeSymbol Symbol { get; private set; }
        public MethodSymbol Ctor { get; private set; }
        
        public NewDelegateExpression(
            ClassTypeSymbol symbol,
            MethodPointerExpression pointer_expr)
        {
            this.Symbol = symbol;
            this.pointer_expr = pointer_expr;
        }

        public override Expression ResolveRValue(IContext context)
        {
            IScope scope = this.Symbol.MembersScope;
            MethodSymbol invoke_method = scope.Resolve("Invoke", LookupFlags.LOCAL) as MethodSymbol;

            this.Ctor = scope.Resolve(MethodSymbol.CTOR, LookupFlags.FLAT) as MethodSymbol;

            if (invoke_method == null || this.Ctor == null || invoke_method.IsOverloaded || this.Ctor.IsOverloaded)
                throw new Exception();

            if (invoke_method == null)
                Report.Error.InvalidInContext(this.Symbol.Name, this.Location);

            if (this.pointer_expr == null)
                Report.Error.NotAMethodPointer(this.Location);

            IList<IType> invoke_method_args = invoke_method.GetFormalTypes();

            MethodSymbol methods = this.pointer_expr.Symbol;

            MethodSymbol equal_method = invoke_method.ResolveEqual(methods.GetOverloads());

            if (equal_method == null)
                Report.Error.NoOverloadMatchesDelegate(methods.Name, this.Symbol.GetQualifiedName(), this.Location);

            if (!context.CanAccess(equal_method))
                Report.Error.Inaccessible(equal_method.GetQualifiedName(), this.Location);

            this.pointer_expr = new MethodPointerExpression(
                equal_method,
                this.pointer_expr.Instance
            );

            this.EvalType = this.Symbol.Type;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public MethodPointerExpression MethodPointer
        {
            get { return this.pointer_expr; }
        }
    }

    /* TODO: narazie nie działa, musi być wspierane zarówno w gramatyce np. a()() jak i wykrywane w MethodCallExpression a()
    public class InvocationExpression : StatementExpression
    {
        Expression expr;
        IList<Expression> actual_args;

        public InvocationExpression(
            Expression expr,
            IList<Expression> actual_args)
        {
            this.expr = expr;
            this.actual_args = actual_args == null ? null : new List<Expression>(actual_args);
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context);

            if (this.expr is SignalExpression)
            {
                SignalExpression signal_expr = this.expr as SignalExpression;
                SignalSymbol symbol = signal_expr.Symbol;
                FieldDecl field = symbol.DelegateField;

            }
            else if (this.expr is DelegateExpression)
            {
                Expression invoke = new MethodCallExpression(
                    this.expr,
                    new Identifier("Invoke"),
                    this.actual_args
                );
                invoke = invoke.ResolveRValue(context);
                return invoke;
            }
            else
            {
                Report.Error.InvalidInContext();
            }            
        }
    }
    */

    public class ArrayAccessExpression : Expression
    {
        Expression expr;
        IList<Expression> indices;

        public ArrayTypeSymbol Symbol { get; private set; }

        public ArrayAccessExpression(
            Expression expr,
            IList<Expression> indices)
        {
            this.expr = expr;
            this.indices = indices == null ? null : new List<Expression>(indices);
        }

        public override Expression ResolveLValue(IContext context)
        {
            return Resolve(context);
        }        

        public override Expression ResolveRValue(IContext context)
        {
            return Resolve(context);
        }

        private Expression Resolve(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context);
            
            if (!(this.expr.EvalType is ArrayTypeSymbol))
                Report.Error.InvalidIndexing(this.expr.EvalType.GetQualifiedName(), this.Location);

            this.Symbol = this.expr.EvalType as ArrayTypeSymbol;

            if (this.indices == null || this.indices.Count == 0)
                Report.Error.WrongNumberOfIndices(this.Symbol.Rank, this.Location);

            int size = this.indices.Count;

            if (size != this.Symbol.Rank)
                Report.Error.WrongNumberOfIndices(this.Symbol.Rank, this.Location);

            IType index_type = Types.GetType("Int32");

            for (int i = 0; i < size; ++i)
            {
                this.indices[i] = this.indices[i].ResolveRValue(context);
                Expression tmp = this.indices[i];

                if (!Types.SetType(ref tmp, index_type, context))
                    Report.Error.NoImplicitConversion(this.indices[i].EvalType.GetQualifiedName(), index_type.GetQualifiedName(), this.Location);
                this.indices[i] = tmp;
            }

            this.EvalType = this.Symbol.ContentType;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }

        public Expression Expr
        {
            get { return this.expr; }
        }

        public IEnumerable<Expression> Indices
        {
            get { return this.indices; }
        }
    }

    public class Assignment : StatementExpression
    {
        Expression lhs;
        Expression rhs;

        public Assignment(
            Expression lhs,
            Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }

        public override Expression ResolveRValue(IContext context)
        {
            lhs = lhs.ResolveLValue(context);
            rhs = rhs.ResolveRValue(context);

            if (lhs is PropertyExpression)
            {
                PropertyExpression property = (PropertyExpression)lhs;

                if (!property.Symbol.HasSetter)
                    Report.Error.NoSetter(property.Symbol.GetQualifiedName(), this.Location);

                Expression setter = new MethodCallExpression(
                    property.Symbol.SetMethodReference,
                    property.Instance,
                    new Expression[] { 
                        rhs
                    });

                setter = setter.ResolveRValue(context);
                setter.Location = lhs.Location;
                return setter;
            }

            /*
            if (lhs is ArrayAccessExpression)
            {
                ArrayAccessExpression array = (ArrayAccessExpression)lhs;

                ArrayTypeSymbol symbol = array.Symbol;
                if (symbol.Rank > 1)
                {
                    MethodSymbol set_method = (MethodSymbol)symbol.Resolve("Set", LookupFlags.LOCAL);
                    set_method = (MethodSymbol)set_method.ResolveOverload(new IType[] { Types.GetType("Int32"), Types.GetType("Int32") });

                    Expression set = new MethodCallExpression(
                        lhs,
                        set_method,
                        new Expression[] { 
                            rhs
                        });

                    set = set.ResolveRValue(context);
                    set.Location = lhs.Location;
                    return set;
                }
            }
            */

            IType dstType = lhs.EvalType;

            if (!Types.SetType(ref rhs, dstType, context))
                Report.Error.NoImplicitConversion(rhs.EvalType.GetQualifiedName(), dstType.GetQualifiedName(), this.Location);

		    this.EvalType = dstType;

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAsStatement(CodeGen gen)
        {
            gen.GenerateAsStatement(this);
        }

        public Expression LeftHandSide
        {
            get { return this.lhs; }
        }

        public Expression RightHandSide
        {
            get { return this.rhs; }
        }
    }

    public class ComplexAssignment : StatementExpression // +=, -=, *= etc.
    {
        Operator.Binary op;
        Expression lhs;
        Expression rhs;

        public ComplexAssignment(
            Operator.Binary op,
            Expression lhs,
            Expression rhs)
        {
            this.op = op;
            this.lhs = lhs;
            this.rhs = rhs;
        }

        public override Expression ResolveRValue(IContext context)
        {
            lhs = lhs.ResolveLValue(context);
            rhs = rhs.ResolveRValue(context);

            /*
            if (this.op == Operator.Binary.Addition
                && lhs is SignalExpression)
            {
                SignalExpression signal = (SignalExpression)lhs;

                if (!signal.Symbol.HasAddon)
                    Report.Error.NoAddon(signal.Symbol.GetQualifiedName(), this.Location);

                Expression addon = new MethodCallExpression(
                    signal.Symbol.AddMethodReference,
                    signal.Instance,
                    new Expression[] { 
                        rhs
                    });

                addon = setter.ResolveRValue(context);
                addon.Location = lhs.Location;
                return addon;
            }
            */ 

            Expression assign = new Assignment(
                this.lhs,
                new BinaryExpression(
                    this.op,
                    this.lhs,
                    this.rhs
                ));

            assign = assign.ResolveRValue(context);
            assign.Location = lhs.Location;

            return assign;
        }        
    }

    public class LocalExpression : Expression
    {
        public LocalVariableSymbol Symbol { get; private set; }

        public LocalExpression(
            LocalVariableSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveLValue(IContext context)
        {
            this.Resolve(context);
            return this;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.Resolve(context);
            return this;
        }

        private void Resolve(IContext context)
        {
            Location def_location = this.Symbol.NodeReference.Location;
            if (this.Location < def_location)
                Report.Error.LocalForwardReference(this.Symbol.Name, this.Location);

            this.EvalType = this.Symbol.Type;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class ArgumentExpression : Expression
    {
        public ArgumentSymbol Symbol { get; private set; }

        public ArgumentExpression(
            ArgumentSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public bool IsInStatic { get; private set; }

        public override Expression ResolveLValue(IContext context)
        {
            return Resolve(context);
        }

        public override Expression ResolveRValue(IContext context)
        {
            return Resolve(context);
        }
        
        public Expression Resolve(IContext context)
        {
            MethodSymbol method = context.CurrentMethod;
            if (method.IsStatic)
                this.IsInStatic = true;
            else
                this.IsInStatic = false;

            this.EvalType = this.Symbol.Type;
            return this;
        }
        
        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class ThisExpression : Expression // this.
    {
        public ObjectTypeSymbol Symbol { get; private set; }

        public ThisExpression(
            ObjectTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
 	        MethodSymbol method = context.CurrentMethod;
            if (method == null || method.IsStatic)
                Report.Error.ThisInStatic(this.Location);

            this.EvalType = this.Symbol;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class BaseExpression : Expression // base.
    {
        public ObjectTypeSymbol Symbol { get; private set; }

        public BaseExpression(
            ObjectTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
 	        MethodSymbol method = context.CurrentMethod;
            if (method == null || method.IsStatic)
                Report.Error.BaseInStatic(this.Location);

            this.EvalType = this.Symbol.BaseClass;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
    }

    public class NamespaceExpression : Expression
    {
        public NamespaceSymbol Symbol { get; private set; }

        public NamespaceExpression(
            NamespaceSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class TypeExpression : Expression // tag
    {

    }

    public class ClassExpression : TypeExpression
    {
        public ClassTypeSymbol Symbol { get; private set; }

        public ClassExpression(
            ClassTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = this.Symbol;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class ValueTypeExpression : TypeExpression
    {
        public ValueTypeSymbol Symbol { get; private set; }

        public ValueTypeExpression(
            ValueTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = this.Symbol;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class InterfaceExpression : TypeExpression
    {
        public InterfaceTypeSymbol Symbol { get; private set; }

        public InterfaceExpression(
            InterfaceTypeSymbol symbol)
        {
            this.Symbol = symbol;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = this.Symbol;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class FieldExpression : Expression
    {
        Expression instance;

        public FieldSymbol Symbol { get; private set; }

        public FieldExpression(
            FieldSymbol symbol,
            Expression instance)
        {
            this.Symbol = symbol;
            this.instance = instance;
        }

        public override Expression ResolveLValue(IContext context)
        {
            if (instance != null)
                instance = instance.ResolveRValue(context);

            this.EvalType = this.Symbol.Type;
            return this;
        }

        public override Expression ResolveRValue(IContext context)
        {
            if (instance != null)
                instance = instance.ResolveRValue(context);

            this.EvalType = this.Symbol.Type;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public override void GenerateAddressOf(CodeGen gen)
        {
            gen.GenerateAddressOf(this);
        }
        
        public Expression Instance
        {
            get { return this.instance; }
        }
    }

    public class PropertyExpression : Expression
    {
        Expression instance;

        public PropertySymbol Symbol { get; private set; }

        public PropertyExpression(
            PropertySymbol symbol,
            Expression instance)
        {
            this.Symbol = symbol;
            this.instance = instance;
        }

        public override Expression ResolveLValue(IContext context)
        {
            if (!this.Symbol.HasSetter)
                Report.Error.NoSetter(this.Symbol.GetQualifiedName(), this.Location);
            
            this.EvalType = this.Symbol.GetMethodReference.ReturnType;
            return this;
        }

        public override Expression ResolveRValue(IContext context)
        {
            if (!this.Symbol.HasGetter)
                Report.Error.NoGetter(this.Symbol.GetQualifiedName(), this.Location);

            Expression getter = new MethodCallExpression(
                this.Symbol.GetMethodReference,
                this.instance,
                null
            );

            getter.Location = this.Location;
            getter = getter.ResolveRValue(context);

            return getter;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Instance
        {
            get { return this.instance; }
        }
    }

    public class SignalExpression : Expression
    {
        Expression instance;

        public SignalSymbol Symbol { get; private set; }

        public SignalExpression(
            SignalSymbol symbol,
            Expression instance)
        {
            this.Symbol = symbol;
            this.instance = instance;
        }

        public override Expression ResolveRValue(IContext context)
        {
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Instance
        {
            get { return this.instance; }
        }
    }

    public class MethodPointerExpression : Expression
    {
        Expression instance;

        public MethodSymbol Symbol { get; private set; }

        public MethodPointerExpression(
            MethodSymbol symbol,
            Expression instance)
        {
            this.Symbol = symbol;
            this.instance = instance;
        }

        public override Expression ResolveRValue(IContext context)
        {
            if (this.instance != null)
                this.instance = this.instance.ResolveRValue(context);

            this.EvalType = this.Symbol.Type; // System.IntPtr
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Instance
        {
            get { return this.instance; }
        }
    }

    public class TypeOfExpression : Expression
    {
        TypeSignature type_sig;

        public TypeOfExpression(
            TypeSignature type_sig)
        {
            this.type_sig = type_sig;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.type_sig.ResolveType(context);
            this.EvalType = Types.GetType("Type");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public IType Type
        {
            get { return this.type_sig.Type; }
        }
    }

    public class IsExpression : Expression
    {
        TypeSignature type_sig;
        Expression expr;

        public IsExpression(
            Expression expr,
            TypeSignature type_sig)
        {
            this.expr = expr;
            this.type_sig = type_sig;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context);
            this.type_sig.ResolveType(context);

            this.EvalType = Types.GetType("Boolean");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public Expression Left
        {
            get { return this.expr; }
        }

        public IType Type
        {
            get { return this.type_sig.Type; }
        }
    }

    public class AsExpression : CastBaseExpression
    {
        public AsExpression(
            Expression expr,
            TypeSignature dst_type)
            : base(dst_type, expr)
        {

        }

        public override Expression ResolveRValue(IContext context)
        {
            base.ResolveRValue(context);
            
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }
    }


    public abstract class CastBaseExpression : Expression
    {
        protected TypeSignature dst_type;
        protected Expression expr;

        public CastBaseExpression(
            TypeSignature type,
            Expression expr)
        {
            this.dst_type = type;
            this.expr = expr;
            this.Location = this.expr.Location;
        }

        public override Expression ResolveRValue(IContext context)
        {
            dst_type.ResolveType(context);

            if (!context.CanAccess(dst_type.Type))
                Report.Error.Inaccessible(dst_type.Type.GetQualifiedName(), this.Location);

            this.expr = this.expr.ResolveRValue(context);

            this.EvalType = dst_type.Type;
            return this;
        }
        
        public Expression Expr
        {
            get { return this.expr; }
        }

        public IType DestType
        {
            get { return this.dst_type.Type; }
        }
    }

    public class ExplicitCastExpression : CastBaseExpression
    {
        public ExplicitCastExpression(
            TypeSignature dst_type,
            Expression expr)
            : base(dst_type, expr)
        {

        }

        public override Expression ResolveRValue(IContext context)
        {
            base.ResolveRValue(context);

            IType src_type = this.expr.EvalType;

            if (src_type == null || src_type is NamespaceExpression || src_type is TypeExpression)
                Report.Error.InvalidInContext(dst_type.Type.GetQualifiedName().ToString(), this.Location);

            if (src_type.CanAssignTo(dst_type.Type)) // && (expr.EvalClass == Value || expr.EvalClass == Variable)
            {
                return this.expr;
            }

            
            // (int)object
            if (src_type.IsEqualTo(Types.GetType("Object")) && dst_type.Type is ValueTypeSymbol)
                return new UnboxExpression(this.expr);

            // (object)int
            if (dst_type.Type.IsEqualTo(Types.GetType("Object")) && src_type is ValueTypeSymbol)
                return new BoxExpression(this.expr);

            // (short)int
            if (dst_type.Type is PrimitiveTypeSymbol && src_type is PrimitiveTypeSymbol)
            {
                Expression cast_expr = new NumericCastExpression(
                    this.expr,
                    new ResolvedType(src_type),
                    dst_type
                );
                cast_expr = cast_expr.ResolveRValue(context);
                return cast_expr;
            }

            // (class)class
            if (src_type.IsInstanceOf(dst_type.Type) || dst_type.Type.IsInstanceOf(src_type))
            {
                Expression cast_expr = new ClassCastExpression(dst_type, this.expr);
                cast_expr = cast_expr.ResolveRValue(context);
                return cast_expr;
            }

            return this;
        }
    }

    public class TypePromotionExpression : CastBaseExpression
    {
        public TypePromotionExpression(
            Expression expr,
            TypeSignature dst_type)
            : base(dst_type, expr)
        {

        }

        public override Expression ResolveRValue(IContext context)
        {
            base.ResolveRValue(context);

            IType src_type = this.expr.EvalType;

            Expression numeric_cast = new NumericCastExpression(
                this.expr,
                new ResolvedType(src_type),
                this.dst_type
            );
            numeric_cast = numeric_cast.ResolveRValue(context);
            return numeric_cast;

            /*            
            this.expr = this.expr.ResolveRValue(context);
            this.type.ResolveType(context);
            this.EvalType = this.type.Type;
            return this;
            */ 
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }
    }

    public class NumericCastExpression : CastBaseExpression
    {
        TypeSignature src_type;

        public Cast.Mode Mode { get; private set; }

        public NumericCastExpression(
            Expression expr,
            TypeSignature src_type,
            TypeSignature dst_type)
            : base(dst_type, expr)
        {
            this.src_type = src_type;
            this.Mode = Cast.Mode.NO_CAST;
        }

        public override Expression ResolveRValue(IContext context)
        {
            base.ResolveRValue(context);

            this.src_type.ResolveType(context);

            IType from = this.src_type.Type;
            IType to = this.dst_type.Type;
            
            IType @char = Types.GetType("Char");
            IType @byte = Types.GetType("Byte");
            IType @sbyte = Types.GetType("SByte");
            IType @short = Types.GetType("Int16");
            IType @ushort = Types.GetType("UInt16");
            IType @int = Types.GetType("Int32");
            IType @uint = Types.GetType("UInt32");
            IType @long = Types.GetType("Int64");
            IType @ulong = Types.GetType("UInt64");
            IType @float = Types.GetType("Single");
            IType @double = Types.GetType("Double");
            IType @intptr = Types.GetType("IntPtr");
            IType @uintptr = Types.GetType("UIntPtr");

            if (from.IsEqualTo(@sbyte))
            {
                // sbyte do byte, ushort, uint, ulong, char

                if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.I1_U1;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.I1_U2;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.I1_U4;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.I1_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.I1_CH;
            }
            else if (from.IsEqualTo(@byte))
            {
                // byte do sbyte and char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.U1_I1;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.U1_CH;
            }
            else if (from.IsEqualTo(@short))
            {
                // short do sbyte, byte, ushort, uint, ulong, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.I2_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.I2_U1;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.I2_U2;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.I2_U4;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.I2_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.I2_CH;
            }
            else if (from.IsEqualTo(@ushort))
            {
                // ushort do sbyte, byte, short, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.U2_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.U2_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.U2_I2;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.U2_CH;
            }
            else if (from.IsEqualTo(@int))
            {
                // int do sbyte, byte, short, ushort, uint, ulong, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.I4_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.I4_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.I4_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.I4_U2;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.I4_U4;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.I4_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.I4_CH;
            }
            else if (from.IsEqualTo(@uint))
            {
                // uint do sbyte, byte, short, ushort, int, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.U4_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.U4_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.U4_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.U4_U2;
                else if (to.IsEqualTo(@int))
                    this.Mode = Cast.Mode.U4_I4;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.U4_CH;
            }
            else if (from.IsEqualTo(@long))
            {
                // long do sbyte, byte, short, ushort, int, uint, ulong, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.I8_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.I8_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.I8_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.I8_U2;
                else if (to.IsEqualTo(@int))
                    this.Mode = Cast.Mode.I8_I4;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.I8_U4;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.I8_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.I8_CH;
            }
            else if (from.IsEqualTo(@ulong))
            {
                // ulong do sbyte, byte, short, ushort, int, uint, long, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.U8_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.U8_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.U8_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.U8_U2;
                else if (to.IsEqualTo(@int))
                    this.Mode = Cast.Mode.U8_I4;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.U8_U4;
                else if (to.IsEqualTo(@long))
                    this.Mode = Cast.Mode.U8_I8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.U8_CH;
            }
            else if (from.IsEqualTo(@char))
            {
                // char do sbyte, byte, short

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.CH_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.CH_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.CH_I2;
            }
            else if (from.IsEqualTo(@float))
            {
                // float do sbyte, byte, short, ushort, int, uint, long, ulong, char

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.R4_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.R4_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.R4_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.R4_U2;
                else if (to.IsEqualTo(@int))
                    this.Mode = Cast.Mode.R4_I4;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.R4_U4;
                else if (to.IsEqualTo(@long))
                    this.Mode = Cast.Mode.R4_I8;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.R4_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.R4_CH;
            }
            else if (from.IsEqualTo(@double))
            {
                // double do sbyte, byte, short, ushort, int, uint, long, ulong, char, float

                if (to.IsEqualTo(@sbyte))
                    this.Mode = Cast.Mode.R8_I1;
                else if (to.IsEqualTo(@byte))
                    this.Mode = Cast.Mode.R8_U1;
                else if (to.IsEqualTo(@short))
                    this.Mode = Cast.Mode.R8_I2;
                else if (to.IsEqualTo(@ushort))
                    this.Mode = Cast.Mode.R8_U2;
                else if (to.IsEqualTo(@int))
                    this.Mode = Cast.Mode.R8_I4;
                else if (to.IsEqualTo(@uint))
                    this.Mode = Cast.Mode.R8_U4;
                else if (to.IsEqualTo(@long))
                    this.Mode = Cast.Mode.R8_I8;
                else if (to.IsEqualTo(@ulong))
                    this.Mode = Cast.Mode.R8_U8;
                else if (to.IsEqualTo(@char))
                    this.Mode = Cast.Mode.R8_CH;
                else if (to.IsEqualTo(@float))
                    this.Mode = Cast.Mode.R8_R4;
            }

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public bool IsCheckedConversion { get; private set; }

        public IType SrcType
        {
            get { return this.src_type.Type; }
        }
    }

    public class ClassCastExpression : CastBaseExpression
    {
        public ClassCastExpression(
            TypeSignature dst_type,
            Expression expr)
            : base(dst_type, expr)
        {

        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }
    }

    public class BoxExpression : Expression
    {
        Expression expr;

        public BoxExpression(
            Expression expr)
        {
            this.expr = expr;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context);
            this.EvalType = Types.GetType("Object");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Expr
        {
            get { return this.expr; }
        }
    }

    public class UnboxExpression : Expression
    {
        Expression expr;

        public UnboxExpression(
            Expression expr)
        {
            this.expr = expr;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.expr = this.expr.ResolveRValue(context);
            this.EvalType = this.expr.EvalType;
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Expr
        {
            get { return this.expr; }
        }
    }

    public class UnaryExpression : Expression
    {
        public readonly Operator.Unary Op;

        Expression expr;

        public UnaryExpression(
            Operator.Unary op,
            Expression expr)
        {
            this.Op = op;
            this.expr = expr;
        }

        public override Expression ResolveRValue(IContext context)
        {
            expr = expr.ResolveRValue(context);

            IType type = expr.EvalType;

            if (this.Op == Operator.Unary.Plus)
            {
                if (!Types.IsConvertible(type, Types.GetType("Int64")))
                    if (!Types.IsConvertible(type, Types.GetType("UInt64")))
                        if (!Types.IsConvertible(type, Types.GetType("Double")))
                            Report.Error.InvalidOperand(Operator.GetToken(this.Op), type.GetQualifiedName(), this.Location);

                expr.Location = this.Location;
                return expr;
            }
            else if (this.Op == Operator.Unary.Negation)
            {
                if (!Types.IsConvertible(type, Types.GetType("Int64")))
                    if (!Types.IsConvertible(type, Types.GetType("UInt64")))
                        if (!Types.IsConvertible(type, Types.GetType("Double")))
                            Report.Error.InvalidOperand(Operator.GetToken(this.Op), type.GetQualifiedName(), this.Location);

                this.EvalType = type;
            }
            else if (this.Op == Operator.Unary.LogicalNot)
            {
                IType dstType = Types.GetType("Boolean");
                if (!Types.SetType(ref this.expr, dstType, context))
                    Report.Error.InvalidOperand(Operator.GetToken(this.Op), type.GetQualifiedName(), this.Location);

                this.EvalType = dstType;
            }
            else if (this.Op == Operator.Unary.OnesComplement)
            {
                IType dstType = Types.GetType("Int32");
                if (!Types.SetType(ref this.expr, dstType, context))
                    Report.Error.InvalidOperand(Operator.GetToken(this.Op), type.GetQualifiedName(), this.Location);

                this.EvalType = dstType;
            }
            else if (this.Op == Operator.Unary.AddressOf)
            {

            }

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression Expr
        {
            get { return this.expr; }
        }
    }

    public class BinaryExpression : Expression
    {
        public readonly Operator.Binary Op;

        Expression left;
        Expression right;

        public BinaryExpression(
            Operator.Binary op,
            Expression left,
            Expression right)
        {
            this.Op = op;
            this.left = left;
            this.right = right;
        }

        public override Expression ResolveRValue(IContext context)
        {
            left = left.ResolveRValue(context);
            right = right.ResolveRValue(context);

            IType ltype = left.EvalType;
            IType rtype = right.EvalType;
            
            if (this.Op == Operator.Binary.Addition
                && (ltype.IsEqualTo(Types.GetType("String"))
                    || rtype.IsEqualTo(Types.GetType("String"))))
            {

                Expression concat = new MethodCallExpression(
                    new DottedExpression(
                        new AnyExpression("System"),
                        new Identifier("String")),
                    new Identifier("Concat"),
                    new Expression[] {
                        left, right
                    });

                concat.Location = this.Location;
                concat = concat.ResolveRValue(context);
                return concat;
            }
            
            if (this.Op == Operator.Binary.Addition
                && Types.IsDelegate(ltype)
                && Types.IsDelegate(rtype)
                && ltype.IsEqualTo(rtype))
            {

                Expression concat = new ExplicitCastExpression(
                    new ResolvedType(ltype),
                    new MethodCallExpression(
                        new DottedExpression(
                            new AnyExpression("System"),
                            new Identifier("Delegate")),
                        new Identifier("Combine"),
                        new Expression[] {
                            left, right
                        }
                    ));

                concat.Location = this.Location;
                concat = concat.ResolveRValue(context);
                return concat;
            }

            if (this.Op == Operator.Binary.Subtraction
                && Types.IsDelegate(ltype)
                && Types.IsDelegate(rtype)
                && ltype.IsEqualTo(rtype))
            {

                Expression concat = new ExplicitCastExpression(
                    new ResolvedType(ltype),
                    new MethodCallExpression(
                        new DottedExpression(
                            new AnyExpression("System"),
                            new Identifier("Delegate")),
                        new Identifier("Remove"),
                        new Expression[] {
                            left, right
                        }
                    ));

                concat.Location = this.Location;
                concat = concat.ResolveRValue(context);
                return concat;
            }
            
            if ((this.Op & Operator.Binary.ArithmeticMask) > 0)
            {
                IType common = Types.Result(ltype, rtype);

                if (common == null)
                    Report.Error.InvalidOperands(Operator.GetMethodName(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref left, common, context))
                    Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref right, common, context))
                    Report.Error.NoImplicitConversion(rtype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                this.EvalType = common;
            }
            else if ((this.Op & Operator.Binary.RelationalMask) > 0)
            {
                IType common = Types.Result(ltype, rtype);

                if (common == null || common.IsEqualTo(Types.GetType("Boolean")))
                    Report.Error.InvalidOperands(Operator.GetMethodName(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref left, common, context))
                    Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref right, common, context))
                    Report.Error.NoImplicitConversion(rtype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                this.EvalType = Types.GetType("Boolean");
            }
            else if ((this.Op & Operator.Binary.EqualityMask) > 0)
            {
                IType value_type = Types.GetType("ValueType");
                if (ltype.IsInstanceOf(value_type))
                {
                    if (rtype.IsInstanceOf(value_type))
                    {
                        IType common = Types.Result(ltype, rtype);

                        if (common == null)
                            Report.Error.InvalidOperands(Operator.GetMethodName(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);

                        if (!Types.SetType(ref left, common, context))
                            Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                        if (!Types.SetType(ref right, common, context))
                            Report.Error.NoImplicitConversion(rtype.GetQualifiedName(), common.GetQualifiedName(), this.Location);
                    }
                    else
                    {
                        Report.Error.InvalidOperands(Operator.GetMethodName(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);
                    }
                }

                this.EvalType = Types.GetType("Boolean");
            }
            else if ((this.Op & Operator.Binary.LogicalMask) > 0)
            {
                IType boolean = Types.GetType("Boolean");

                if (!Types.SetType(ref left, boolean, context))
                    Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), boolean.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref right, boolean, context))
                    Report.Error.NoImplicitConversion(rtype.GetQualifiedName(), boolean.GetQualifiedName(), this.Location);

                this.EvalType = boolean;
            }
            else if ((this.Op & Operator.Binary.BitwiseMask) > 0)
            {
                IType common = Types.Result(ltype, rtype);

                if (!Types.IsConvertible(common, Types.GetType("Int64")))
                    if (!Types.IsConvertible(common, Types.GetType("UInt64")))
                        Report.Error.InvalidOperands(Operator.GetToken(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref left, common, context))
                    Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref right, common, context))
                    Report.Error.NoImplicitConversion(rtype.GetQualifiedName(), common.GetQualifiedName(), this.Location);

                this.EvalType = common;
            }
            else if ((this.Op & Operator.Binary.ShiftMask) > 0)
            {
                IType integer = Types.GetType("Int32");

                if (!Types.SetType(ref left, integer, context))
                    Report.Error.NoImplicitConversion(ltype.GetQualifiedName(), integer.GetQualifiedName(), this.Location);

                if (!Types.SetType(ref right, Types.GetType("Int64"), context))
                    if (!Types.SetType(ref right, Types.GetType("UInt64"), context))
                        Report.Error.InvalidOperands(Operator.GetToken(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);

                this.EvalType = integer;
            }
            else if (this.Op == Operator.Binary.NullCoalescing)
            {   
                if (ltype.IsInstanceOf(rtype))
                    this.EvalType = rtype;
                else if (rtype.IsInstanceOf(ltype))
                    this.EvalType = ltype;
                else
                    Report.Error.InvalidOperands(Operator.GetToken(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);
            }
            else
            {
                Report.Error.InvalidOperands(Operator.GetToken(this.Op), ltype.GetQualifiedName(), rtype.GetQualifiedName(), this.Location);
            }

            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override void GenerateLValuePre(CodeGen gen)
        {
            gen.GenerateLValuePre(this);
        }

        public override void GenerateLValuePost(CodeGen gen)
        {
            gen.GenerateLValuePost(this);
        }

        public Expression LeftHandSide
        {
            get { return this.left; }
        }

        public Expression RightHandSide
        {
            get { return this.right; }
        }
    }

    public static class Operator
    {
        public enum Unary
        {
            Plus = 0,
            Negation = 1,
            LogicalNot = 2,
            OnesComplement = 3,
            AddressOf = 4
        }

        public enum Binary
        {
            Multiply = 0 | ArithmeticMask,
            Division = 1 | ArithmeticMask,
            Modulus = 2 | ArithmeticMask,
            Addition = 3 | ArithmeticMask | AdditionMask,
            Subtraction = 4 | ArithmeticMask | SubtractionMask,

            LeftShift = 5 | ShiftMask,
            RightShift = 6 | ShiftMask,

            LessThan = 7 | ComparisonMask | RelationalMask,
            GreaterThan = 8 | ComparisonMask | RelationalMask,
            LessThanOrEqual = 9 | ComparisonMask | RelationalMask,
            GreaterThanOrEqual = 10 | ComparisonMask | RelationalMask,
            Equality = 11 | ComparisonMask | EqualityMask,
            Inequality = 12 | ComparisonMask | EqualityMask,

            BitwiseAnd = 13 | BitwiseMask,
            ExclusiveOr = 14 | BitwiseMask,
            BitwiseOr = 15 | BitwiseMask,

            LogicalAnd = 16 | LogicalMask,
            LogicalOr = 17 | LogicalMask,

            NullCoalescing = 18,

            ValuesOnlyMask = ArithmeticMask - 1,
            ArithmeticMask = 1 << 5,
            ShiftMask = 1 << 6,
            ComparisonMask = 1 << 7,
            EqualityMask = 1 << 8,
            BitwiseMask = 1 << 9,
            LogicalMask = 1 << 10,
            AdditionMask = 1 << 11,
            SubtractionMask = 1 << 12,
            RelationalMask = 1 << 13
        }

        static IDictionary<Operator.Binary, string[]> binary = new Dictionary<Operator.Binary, string[]>();

        static IDictionary<Operator.Unary, string[]> unary = new Dictionary<Operator.Unary, string[]>();

        static Operator()
        {
            unary.Add(Unary.LogicalNot, new string[] { "!", "op_LogicalNot" });
            unary.Add(Unary.OnesComplement, new string[] { "~", "op_OnesComplement" });
            unary.Add(Unary.Plus, new string[] { "+", "op_UnaryPlus" });
            unary.Add(Unary.Negation, new string[] { "-", "op_UnaryNegation" });

            binary.Add(Binary.Multiply, new string[] { "*", "op_Multiply" });
            binary.Add(Binary.Division, new string[] { "/", "op_Division" });
            binary.Add(Binary.Addition, new string[] { "+", "op_Addition" });
            binary.Add(Binary.Subtraction, new string[] { "-", "op_Subtraction" });
            binary.Add(Binary.Modulus, new string[] { "%", "op_Modulus" });
            binary.Add(Binary.BitwiseAnd, new string[] { "&", "op_BitwiseAnd" });
            binary.Add(Binary.BitwiseOr, new string[] { "|", "op_BitwiseOr" });
            binary.Add(Binary.ExclusiveOr, new string[] { "^", "op_ExclusiveOr" });
            binary.Add(Binary.LeftShift, new string[] { "<<", "op_LeftShift" });
            binary.Add(Binary.RightShift, new string[] { ">>", "op_RightShift"});
            binary.Add(Binary.Equality, new string[] { "==", "op_Equality" });
            binary.Add(Binary.Inequality, new string[] { "!=", "op_Inequality" });
            binary.Add(Binary.GreaterThan, new string[] { ">", "op_GreaterThan" });
            binary.Add(Binary.LessThan, new string[] { "<", "op_LessThan" });
            binary.Add(Binary.GreaterThanOrEqual, new string[] { ">=", "op_GreaterThanOrEqual" });
            binary.Add(Binary.LessThanOrEqual, new string[] { "<=", "op_LessThanOrEqual" });
            binary.Add(Binary.NullCoalescing, new string[] { "??", "" });

            /*
            "op_Implicit";
            "op_Explicit";
            "op_Increment";
            "op_Decrement";
            "op_True";
            "op_False";
            */
        }

        public static string GetToken(Unary op)
        {
            return unary[op][0];
        }

        public static string GetToken(Binary op)
        {
            return binary[op][0];
        }

        public static string GetMethodName(Unary op)
        {
            return unary[op][1];
        }

        public static string GetMethodName(Binary op)
        {
            return binary[op][1];
        }        
    }

    public class Cast
    {
        public enum Mode : byte
        {
            NO_CAST,
            I1_U1, I1_U2, I1_U4, I1_U8, I1_CH,
            U1_I1, U1_CH,
            I2_I1, I2_U1, I2_U2, I2_U4, I2_U8, I2_CH,
            U2_I1, U2_U1, U2_I2, U2_CH,
            I4_I1, I4_U1, I4_I2, I4_U2, I4_U4, I4_U8, I4_CH,
            U4_I1, U4_U1, U4_I2, U4_U2, U4_I4, U4_CH,
            I8_I1, I8_U1, I8_I2, I8_U2, I8_I4, I8_U4, I8_U8, I8_CH, I8_I,
            U8_I1, U8_U1, U8_I2, U8_U2, U8_I4, U8_U4, U8_I8, U8_CH, U8_I,
            CH_I1, CH_U1, CH_I2,
            R4_I1, R4_U1, R4_I2, R4_U2, R4_I4, R4_U4, R4_I8, R4_U8, R4_CH,
            R8_I1, R8_U1, R8_I2, R8_U2, R8_I4, R8_U4, R8_I8, R8_U8, R8_CH, R8_R4,
            I_I8,
        }
    }

    public abstract class LiteralExpression : Expression
    {
        public abstract object Data { get; }

        public virtual bool IsIntegral
        {
            get { return false; }
        }
        
        public override void GenerateLValuePre(CodeGen gen)
        {

        }

        public override void GenerateLValuePost(CodeGen gen)
        {

        }
    }

    public class BoolLiteral : LiteralExpression
    {
        public readonly bool Value;

        public BoolLiteral(bool value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Boolean");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class StringLiteral : LiteralExpression
    {
        public readonly string Value;

        public StringLiteral(string value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("String");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class CharLiteral : LiteralExpression
    {
        public readonly char Value;

        public CharLiteral(char value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Char");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class SByteLiteral : LiteralExpression
    {
        public readonly sbyte Value;

        public SByteLiteral(sbyte value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("SByte");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class ByteLiteral : LiteralExpression
    {
        public readonly byte Value;

        public ByteLiteral(byte value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Byte");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class ShortLiteral : LiteralExpression
    {
        public readonly short Value;

        public ShortLiteral(short value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Int16");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class UShortLiteral : LiteralExpression
    {
        public readonly ushort Value;

        public UShortLiteral(ushort value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("UInt16");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class IntLiteral : LiteralExpression
    {
        public readonly int Value;

        public IntLiteral(int value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Int32");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class UIntLiteral : LiteralExpression
    {
        public readonly uint Value;

        public UIntLiteral(uint value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("UInt32");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class LongLiteral : LiteralExpression
    {
        public readonly long Value;

        public LongLiteral(long value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Int64");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class ULongLiteral : LiteralExpression
    {
        public readonly ulong Value;

        public ULongLiteral(ulong value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("UInt64");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override bool IsIntegral 
        {
	        get { return true; }
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class FloatLiteral : LiteralExpression
    {
        public readonly float Value;

        public FloatLiteral(float value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Single");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class DoubleLiteral : LiteralExpression
    {
        public readonly double Value;

        public DoubleLiteral(double value, Location loc)
        {
            this.Value = value;
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = Types.GetType("Double");
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return this.Value; }
        }
    }

    public class NullLiteral : LiteralExpression
    {
        public NullLiteral(Location loc)
        {
            this.Location = loc;
        }

        public override Expression ResolveRValue(IContext context)
        {
            this.EvalType = new NullType();
            return this;
        }

        public override void GenerateRValue(CodeGen gen)
        {
            gen.Generate(this);
        }

        public override object Data
        {
            get { return null; }
        }
    }
    
}
