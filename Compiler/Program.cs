using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using Antlr.Runtime;

using Compiler.AST;
using Compiler.Driver;
using Compiler.Emit;
using Compiler.Grammar;
using Compiler.Symbols;
using Compiler.Linker;

namespace Compiler
{
    public class Program
    {
        public void Run(Options options)
        {
            GlobalScope globalScope = new GlobalScope();
            
            Loader ld = new Loader(globalScope, options);
            ld.Load(options.References);

            Types.RegisterType("Boolean", (IType)globalScope.GetSymbol("System.Boolean"));
            Types.RegisterType("Char", (IType)globalScope.GetSymbol("System.Char"));
            Types.RegisterType("SByte", (IType)globalScope.GetSymbol("System.SByte"));
            Types.RegisterType("Byte", (IType)globalScope.GetSymbol("System.Byte"));
            Types.RegisterType("Int16", (IType)globalScope.GetSymbol("System.Int16"));
            Types.RegisterType("UInt16", (IType)globalScope.GetSymbol("System.UInt16"));
            Types.RegisterType("Int32", (IType)globalScope.GetSymbol("System.Int32"));
            Types.RegisterType("UInt32", (IType)globalScope.GetSymbol("System.UInt32"));
            Types.RegisterType("Int64", (IType)globalScope.GetSymbol("System.Int64"));
            Types.RegisterType("UInt64", (IType)globalScope.GetSymbol("System.UInt64"));
            Types.RegisterType("IntPtr", (IType)globalScope.GetSymbol("System.IntPtr"));
            Types.RegisterType("UIntPtr", (IType)globalScope.GetSymbol("System.UIntPtr"));
            Types.RegisterType("Single", (IType)globalScope.GetSymbol("System.Single"));
            Types.RegisterType("Double", (IType)globalScope.GetSymbol("System.Double"));
            Types.RegisterType("String", (IType)globalScope.GetSymbol("System.String"));
            Types.RegisterType("Object", (IType)globalScope.GetSymbol("System.Object"));
            Types.RegisterType("ValueType", (IType)globalScope.GetSymbol("System.ValueType"));
            Types.RegisterType("Enum", (IType)globalScope.GetSymbol("System.Enum"));
            Types.RegisterType("Void", (IType)globalScope.GetSymbol("System.Void"));
            Types.RegisterType("Array", (IType)globalScope.GetSymbol("System.Array"));
            Types.RegisterType("Exception", (IType)globalScope.GetSymbol("System.Exception"));
            Types.RegisterType("Type", (IType)globalScope.GetSymbol("System.Type"));
            Types.RegisterType("MulticastDelegate", (IType)globalScope.GetSymbol("System.MulticastDelegate"));
            Types.RegisterType("IAsyncResult", (IType)globalScope.GetSymbol("System.IAsyncResult"));
            Types.RegisterType("AsyncCallback", (IType)globalScope.GetSymbol("System.AsyncCallback"));
            
            TypesHelper th = new TypesHelper();
            th.Prepare();
            Types.ResultTable = th.ResultTable;
            Types.PromotionTable = th.PromotionTable;

            int files_number = options.FilesNumber;

            if (files_number == 0)
                Report.Error.NoFilesToCompile();

            List<FileNamespace> file_namespace = new List<FileNamespace>();
            List<CompilationUnit> compilation_units = new List<CompilationUnit>();

            foreach (string source in options.Files)
            {
                try
                {
                    FileStream file = new FileStream(source, FileMode.Open, FileAccess.Read);

                    ANTLRInputStream input = new ANTLRInputStream(file);

                    GrammarLexer lexer = new GrammarLexer(input);

                    CommonTokenStream tokens = new CommonTokenStream(lexer);

                    GrammarParser parser = new GrammarParser(tokens);

                    compilation_units.Add(parser.program());
                    file_namespace.Add(new FileNamespace(globalScope));
                }
                catch (FileNotFoundException)
                {
                    Report.Error.SourceFileNotFound(source);
                }
                catch (DirectoryNotFoundException)
                {
                    Report.Error.SourceFileNotFound(source);
                }
                catch (IOException)
                {
                    Report.Error.IOError(source);
                }
            }
            
            CodeGen codegen = new CodeGen(options);

            for (int i = 0; i < files_number; ++i)
                compilation_units[i].DefineSymbols(new Context(file_namespace[i]));

            for (int i = 0; i < files_number; ++i)
                compilation_units[i].ResolveSymbols(new Context(file_namespace[i]));

            codegen.BuildAssembly(compilation_units);
        }
    }
}