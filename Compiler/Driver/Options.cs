using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using Compiler.Linker;

namespace Compiler.Driver
{   
    public class Options
    {
        private string output_file_name;

        public string OutputFileName
        {
            get
            {
                if (this.output_file_name == null)
                {
                    if (this.files.Count == 0)
                        Report.Error.NoOutputFileName();

                    string name = this.files[0];
                    int pos = name.LastIndexOf(".");
                    if (pos != -1)
                        name = name.Substring(0, pos);

                    name += this.GetExtension();
                    return name;
                }
                else
                {
                    string o = this.output_file_name.ToLower(CultureInfo.InvariantCulture);
                    if (!o.EndsWith(".exe") && !o.EndsWith(".netmodule") && !o.EndsWith(".dll"))
                        o += this.GetExtension();
                    return o;
                }
            }
        }

        private string GetExtension()
        {
            switch (this.Target)
            {
                case Target.Exe:
                case Target.WinExe:
                    return ".exe";

                case Target.Library:
                    return ".dll";

                case Target.Module:
                    return ".netmodule";
            }
            return "";
        }

        public string StrongNameKeyFile { get; private set; }

        public bool HasKeyFile
        {
            get { return this.StrongNameKeyFile != null; }
        }
        
        public bool NeedsEntryPoint
        {
            get { return this.Target == Target.Exe || this.Target == Target.WinExe; }
        }

        private List<AssemblyReference> references;

        public IEnumerable<AssemblyReference> References
        {
            get { return this.references; }
        }

        private List<string> libraries;

        public IEnumerable<string> Libraries
        {
            get { return this.libraries; }
        }

        public Target Target { get; private set; }

        private List<string> files;

        public IEnumerable<string> Files
        {
            get { return this.files; }
        }

        public int FilesNumber
        {
            get { return this.files.Count; }
        }

        private const string OPTION_PREFIX = "/";

        private const string OPTION_VALUE = ":";

        private static readonly char[] VALUE_SEPARATOR = { ';', ',' };

        private const string VALUE_ARGUMENT = "=";

        public Options(string[] args)
        {
            Reset();

            foreach (string a in args)
            {
                string arg = a;
                if (arg.StartsWith(Options.OPTION_PREFIX))
                {
                    arg = arg.Substring(1);
                    int pos = arg.IndexOf(Options.OPTION_VALUE);
                    string option = null;
                    string rest = null;
                    if (pos != -1)
                    {
                        option = arg.Substring(0, pos).ToLower(CultureInfo.InvariantCulture);
                        rest = arg.Substring(pos + 1);
                    }
                    else
                    {
                        option = arg.ToLower(CultureInfo.InvariantCulture);
                        rest = null;
                    }

                    switch (option)
                    {
                        case "help":
                        case "h":
                        case "?":
                            PrintUsage();
                            break;


                        case "out":
                            if (rest == null || rest.Length == 0)
                                Report.Error.MissingArgument("out");
                            
                            this.output_file_name = rest;
                            break;


                        case "lib":
                            if (rest == null || rest.Length == 0)
                                Report.Error.MissingArgument("lib");

                            foreach (string item in rest.Split(Options.VALUE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries))
                            {
                                this.libraries.Add(item);
                            }
                            break;


                        case "reference":
                        case "r":
                            if (rest == null || rest.Length == 0)
                                Report.Error.MissingArgument("reference");

                            foreach (string item in rest.Split(Options.VALUE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries))
                            {
                                int p = item.IndexOf(Options.VALUE_ARGUMENT);
                                string alias = null;
                                string reference = null;

                                if (p != -1)
                                {
                                    alias = item.Substring(0, p);
                                    reference = item.Substring(p + 1);
                                    if (alias.Length == 0 || reference.Length == 0)
                                        Report.Error.InvalidReferenceAlias();
                                }
                                else
                                {
                                    reference = item;
                                    if (reference.Length == 0)
                                        Report.Error.InvalidReferenceAlias();
                                }

                                this.references.Add(new AssemblyReference(alias, reference));
                            }
                            break;


                        case "target":
                        case "t":
                            if (rest == null || rest.Length == 0)
                                Report.Error.InvalidTargetOption();

                            switch (rest)
                            {
                                case "exe":
                                    this.Target = Target.Exe;
                                    break;

                                case "winexe":
                                    this.Target = Target.WinExe;
                                    break;

                                case "library":
                                    this.Target = Target.Library;
                                    break;

                                case "module":
                                    this.Target = Target.Module;
                                    break;

                                default:
                                    Report.Error.InvalidTargetOption();
                                    break;
                            }
                            break;


                        case "keyfile":
                            if (rest == null || rest.Length == 0)
                                Report.Error.MissingArgument("keyfile");

                            this.StrongNameKeyFile = rest;
                            break;


                        default:
                            Report.Error.UnrecognizedOption(option);
                            break;
                    }

                }
                else
                {
                    this.files.Add(arg);
                }
            }
        }

        private void Reset()
        {
            this.files = new List<string>();
            this.references = new List<AssemblyReference>();
            this.libraries = new List<string>();
            this.Target = Target.Exe;
        }

        private void PrintUsage()
        {
            Console.WriteLine(
                "Piotr Skotnicki, 2010/2011\n" +
                "Compiler [options] [source-files]\n" +
                "/?                           Lists all compiler options\n" +
                "/keyfile:<file>              Specifies a strong name key file\n" +
                "/lib:<dir1>[;<dir2>]         Specifies the location of referenced assemblies\n" +
                "/out:<name>                  Specifies output assembly name\n" +
                "/reference:<file1>[;<file2>] Imports metadata from the specified assemblies\n" +
                "/reference:<alias>=<file>    Imports metadata using specified extern alias\n" +	
                "/target:exe                  Creates an executable (EXE), console application\n" +
                "/target:library              Creates a dynamic-link library (DLL)\n" +
                "/target:module               Creates a module without an assembly manifest\n" +
                "/target:winexe               Creates an executable (EXE), Windows program\n"
                );
            Environment.Exit(0);
        }
    }
}
