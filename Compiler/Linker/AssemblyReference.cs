using System;

namespace Compiler.Linker
{
    public class AssemblyReference
    {
        public string Alias { get; private set; }

        public string Reference { get; private set; }

        public AssemblyReference(string alias, string reference)
        {
            this.Alias = alias;
            this.Reference = reference;
        }
    }
}
