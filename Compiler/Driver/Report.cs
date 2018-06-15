using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Compiler.AST;

namespace Compiler.Driver
{
    public class Report
    {
        public static Error Error { get; set; }

        public static Warning Warning { get; set; }

        static Report()
        {
            Error = new Error();
            Warning = new Warning();
        }
    }

    public class Error
    {
        private void DoReport(string msg, Location location)
        {
            throw new ErrorException(msg, location);
        }

        public void SyntaxError(string err, Location location)
        {
            string msg = String.Format("Syntax error, {0}", err);
            this.DoReport(msg, location);
        }

        public void UnresolvedIdentifier(string name, Location location)
        {
            string msg = String.Format("The name `{0}' does not exist in the current context", name);
            this.DoReport(msg, location);
        }

        public void InvalidLValue(Location location)
        {
            string msg = String.Format("The left-hand side of an assignment must be a variable, property or indexer");
            this.DoReport(msg, location);
        }

        public void InvalidRValue(Location location)
        {
            string msg = String.Format("The right-hand side of an assignment must be a value, variable, method call, property or indexer");
            this.DoReport(msg, location);
        }

        public void InvalidImport(Location location)
        {
            string msg = String.Format("A using namespace directive can only be applied to namespaces");
            this.DoReport(msg, location);
        }

        public void Inaccessible(string name, Location location)
        {
            string msg = String.Format("`{0}' is inaccessible due to its protection level", name);
            this.DoReport(msg, location);
        }

        public void InvalidTypedef(Location location)
        {
            string msg = String.Format("A typdef directive can only be applied to namespaces, classes and structures");
            this.DoReport(msg, location);
        }

        public void SealedBaseClass(string derive, string base_class, Location location)
        {
            string msg = String.Format("`{0}': cannot derive from sealed type `{1}'", derive, base_class);
            this.DoReport(msg, location);
        }

        public void InconsistentAccessibility(string src, string dst, Location location)
        {
            string msg = String.Format("Inconsistent accessibility: `{0}' is less accessible than `{1}'", src, dst);
            this.DoReport(msg, location);
        }

        public void InvalidBaseType(string name, Location location)
        {
            string msg = String.Format("Cannot derive from `{0}'", name);
            this.DoReport(msg, location);
        }

        public void InvalidInterface(string name, Location location)
        {
            string msg = String.Format("`{0}' in interface list is not an interface", name);
            this.DoReport(msg, location);
        }

        public void MethodWithoutBody(string name, Location location)
        {
            string msg = String.Format("`{0}' must declare a body because it is not marked as abstract", name);
            this.DoReport(msg, location);
        }

        public void PrivateVirtualMember(string name, Location location)
        {
            string msg = String.Format("`{0}': virtual or abstract members cannot be private", name);
            this.DoReport(msg, location);
        }

        public void StaticVirtualMember(string name, Location location)
        {
            string msg = String.Format("A static member `{0}' cannot be marked as virtual or abstract", name);
            this.DoReport(msg, location);
        }

        public void AbstractMethodWithBody(string name, Location location)
        {
            string msg = String.Format("`{0}' cannot declare a body because it is marked abstract", name);
            this.DoReport(msg, location);
        }

        public void AbstractMemberInNonAbstract(string name, string enc_class, Location location)
        {
            string msg = String.Format("`{0}' is abstract but it is contained in non abstract class `{1}'", name, enc_class);
            this.DoReport(msg, location);
        }

        public void InvalidModifier(string modifier, Location location)
        {
            string msg = String.Format("The modifier `{0}' is not valid for this item", modifier);
            this.DoReport(msg, location);
        }

        public void NoImplicitConversion(string from, string to, Location location)
        {
            string msg = String.Format("Cannot implicitly convert type `{0}' to `{1}'", from, to);
            this.DoReport(msg, location);
        }

        public void NoConversion(string from, string to, Location location)
        {
            string msg = String.Format("Cannot convert type `{0}' to `{1}'", from, to);
            this.DoReport(msg, location);
        }

        public void InvalidLabel(string name, Location location)
        {
            string msg = String.Format("No such label `{0}' within the scope of the goto statement", name);
            this.DoReport(msg, location);
        }

        public void VoidReturn(string method, Location location)
        {
            string msg = String.Format("Since `{0}' returns void, a return keyword must not be followed by any object", method);
            this.DoReport(msg, location);
        }

        public void NoReturnValue(string name, Location location)
        {
            string msg = String.Format("An object of a type convertible to `{0}' is required", name);
            this.DoReport(msg, location);
        }

        public void InvalidExceptionType(Location location)
        {
            string msg = String.Format("The type caught or thrown must be derived from System.Exception");
            this.DoReport(msg, location);
        }

        public void ThrowOutsideCatch(Location location)
        {
            string msg = String.Format("The throw statement with no arguments is not allowed outside of a catch clause");
            this.DoReport(msg, location);
        }

        public void NonStaticMemberAccess(string name, Location location)
        {
            string msg = String.Format("An object reference is required for the non-static field, method or property `{0}'", name);
            this.DoReport(msg, location);
        }

        public void StaticMemberAccess(string name, Location location)
        {
            string msg = String.Format("Static member `{0}' cannot be accessed with an instance reference, qualify it with a type name instead", name);
            this.DoReport(msg, location);
        }

        public void MustSpecifyRank(Location location)
        {
            string msg = String.Format("Array creation must have array size or array initializer");
            this.DoReport(msg, location);
        }

        public void CannotInstantiate(string name, Location location)
        {
            string msg = String.Format("Cannot create an instance of `{0}'", name);
            this.DoReport(msg, location);
        }

        public void CannotInstantiateAbstract(string name, Location location)
        {
            string msg = String.Format("Cannot create an instance of the abstract class or interface `{0}'", name);
            this.DoReport(msg, location);
        }

        public void InvalidIndexing(string name, Location location)
        {
            string msg = String.Format("Cannot apply indexing with [] to an expression of type `{0}'", name);
            this.DoReport(msg, location);
        }

        public void WrongNumberOfIndices(int rank, Location location)
        {
            string msg = String.Format("Wrong number of indices inside []; expected `{0}'", rank);
            this.DoReport(msg, location);
        }

        public void NoSetter(string name, Location location)
        {
            string msg = String.Format("Property or indexer `{0}' cannot be assigned to -- it is read only", name);
            this.DoReport(msg, location);
        }

        public void NoGetter(string name, Location location)
        {
            string msg = String.Format("The property or indexer `{0}' cannot be used in this context because it lacks the get accessor", name);
            this.DoReport(msg, location);
        }

        public void LocalForwardReference(string name, Location location)
        {
            string msg = String.Format("Cannot use local variable `{0}' before it is declared", name);
            this.DoReport(msg, location);
        }

        public void ThisInStatic(Location location)
        {
            string msg = String.Format("Keyword `{0}' is not valid in a static property, static method, or static field initializer", Compiler.Grammar.Tokens.KW_THIS);
            this.DoReport(msg, location);
        }

        public void BaseInStatic(Location location)
        {
            string msg = String.Format("Keyword `{0}' is not available in a static method", Compiler.Grammar.Tokens.KW_BASE);
            this.DoReport(msg, location);
        }

        public void TypeExpected(Location location)
        {
            string msg = String.Format("Unresolved type reference");
            this.DoReport(msg, location);
        }

        public void InvalidOperands(string op, string left, string right, Location location)
        {
            string msg = String.Format("Operator `{0}' cannot be applied to operands of type `{1}' and `{2}'", op, left, right);
            this.DoReport(msg, location);
        }

        public void InvalidOperand(string op, string operand, Location location)
        {
            string msg = String.Format("Operator `{0}' cannot be applied to operand of type `{1}'", op, operand);
            this.DoReport(msg, location);
        }

        public void NoConstructorFound(string name, int arguments, Location location)
        {
            string msg = String.Format("`{0}' does not contain a constructor that takes `{1}' arguments", name, arguments);
            this.DoReport(msg, location);
        }

        public void OverloadNotMatched(string name, int arguments, Location location)
        {
            string msg = String.Format("No overload for method `{0}' takes `{1}' arguments", name, arguments);
            this.DoReport(msg, location);
        }

        public void AmbiguousCall(string name, Location location)
        {
            string msg = String.Format("`{0}': the call is ambiguous", name);
            this.DoReport(msg, location);
        }

        public void MethodAlreadyDefined(string type, string member, Location location)
        {
            string msg = String.Format("Type `{0}' already defines a mamber called `{1}' with the same parameter types", type, member);
            this.DoReport(msg, location);
        }

        public void MemberAlreadyDefined(string type, string member, Location location)
        {
            string msg = String.Format("The type `{0}' already contains a definition for `{1}'", type, member);
            this.DoReport(msg, location);
        }

        public void MemberNameSameAsTypes(string name, Location location)
        {
            string msg = String.Format("`{0}': member names cannot be the same as their enclosing type", name);
            this.DoReport(msg, location);
        }

        public void InvalidInContext(string name, Location location)
        {
            string msg = String.Format("`{0}' is not valid in the given context", name);
            this.DoReport(msg, location);
        }

        public void ForeachNotEnumerable(string name, Location location)
        {
            string msg = String.Format("Foreach statement cannot operate on variables of type `{0}' because `{0}' does not contain a public definition for `GetEnumerator'", name);
            this.DoReport(msg, location);
        }

        public void OperatorInvalidSignature(string name, Location location)
        {
            string msg = String.Format("User-defined operator `{0}' must be declared static and public", name);
            this.DoReport(msg, location);
        }

        public void OperatorVoidReturn(Location location)
        {
            string msg = String.Format("User-defined operators cannot return void");
            this.DoReport(msg, location);
        }

        public void OperatorUnaryMissingType(Location location)
        {
            string msg = String.Format("The parameter of an unary operator must be the containing type");
            this.DoReport(msg, location);
        }

        public void OperatorBinaryMissingType(Location location)
        {
            string msg = String.Format("One of the parameters of a binary operator must be the containing type");
            this.DoReport(msg, location);
        }

        public void DuplicateModifier(Location location)
        {
            string msg = String.Format("Duplicate modifier");
            this.DoReport(msg, location);
        }

        public void ExpectedCatchFinally(Location location)
        {
            string msg = String.Format("Expected catch or finally");
            this.DoReport(msg, location);
        }

        public void IntegralConstantTooLarge(Location location)
        {
            string msg = String.Format("Integral constant is too large");
            this.DoReport(msg, location);
        }

        public void FloatingPointConstantTooLarge(string name, Location location)
        {
            string msg = String.Format("Floating-point constant is outside the range of type `{0}'", name);
            this.DoReport(msg, location);
        }

        public void BreakContinueOutsideLoop(Location location)
        {
            string msg = String.Format("No enclosing loop out of which to break or continue");
            this.DoReport(msg, location);
        }

        public void FieldOrMethodInNamespace(Location location)
        {
            string msg = String.Format("A namespace does not directly contain members such as fields or methods");
            this.DoReport(msg, location);
        }

        public void BaseClassCycle(Location location)
        {
            string msg = String.Format("Circular base class dependency");
            this.DoReport(msg, location);
        }

        public void InvalidGlobalAccessModifier(Location location)
        {
            string msg = String.Format("Elements defined in a namespace cannot be explicitly declared as private or protected");
            this.DoReport(msg, location);
        }

        public void NestedAccessModifier(Location location)
        {
            string msg = String.Format("A nested type cannot have an access specifier as part of its declaration");
            this.DoReport(msg, location);
        }

        public void DuplicateEntryPoint()
        {
            string msg = String.Format("Compilation unit has more than one entry point defined");
            this.DoReport(msg, new Location(0, 0));
        }

        public void NoEntryPoint()
        {
            string msg = String.Format("Compilation unit does not contain a static `Main' method suitable for an entry point");
            this.DoReport(msg, new Location(0, 0));
        }

        public void InvalidStatement(Location location)
        {
            string msg = String.Format("Only assignment, call, increment, decrement and new object expressions can be used as a statement");
            this.DoReport(msg, location);
        }

        public void MustBeConstant(string name, Location location)
        {
            string msg = String.Format("The expression being assigned to `{0}' must be constant", name);
            this.DoReport(msg, location);
        }

        public void VarLocalNotInitialized(Location location)
        {
            string msg = String.Format("Implicitly-typed local variables must be initialized");
            this.DoReport(msg, location);
        }

        public void VarLocalMultipleDeclarators(Location location)
        {
            string msg = String.Format("Implicitly-typed local variables cannot have multiple declarators");
            this.DoReport(msg, location);
        }

        public void DefaultConstructorInStruct(Location location)
        {
            string msg = String.Format("Structs cannot contain explicit parameterless constructors");
            this.DoReport(msg, location);
        }

        public void InterfaceMemberDefinition(Location location)
        {
            string msg = String.Format("Interface members cannot have a definition");
            this.DoReport(msg, location);
        }

        public void NotAMethodPointer(Location location)
        {
            string msg = String.Format("The following expression is not a method pointer");
            this.DoReport(msg, location);
        }

        public void NoOverloadMatchesDelegate(string method_name, string delegate_name, Location location)
        {
            string msg = String.Format("No overload for `{0}' matches delegate `{1}'", method_name, delegate_name);
            this.DoReport(msg, location);
        }

        public void NotADelegate(Location location)
        {
            string msg = String.Format("Expression is not a valid delegate");
            this.DoReport(msg, location);
        }

        public void VoidPropertyIndexer(string name, Location location)
        {
            string msg = String.Format("`{0}': property or indexer cannot have void type", name);
            this.DoReport(msg, location);
        }

        public void MissingKeyFile(string name)
        {
            string msg = String.Format("`{0}': strong name key file is missing", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void InvalidKeyFile(string name)
        {
            string msg = String.Format("`{0}': strong name key file is invalid", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void NoFilesToCompile()
        {
            string msg = String.Format("No files to compile were specified");
            this.DoReport(msg, new Location(0, 0));
        }

        public void SourceFileNotFound(string name)
        {
            string msg = String.Format("Source file `{0}' could not be found", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void MissingArgument(string name)
        {
            string msg = String.Format("`{0}' requires an argument", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void UnrecognizedOption(string name)
        {
            string msg = String.Format("Unrecognized command-line option: `{0}'", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void InvalidReferenceAlias()
        {
            string msg = String.Format("Invalid reference alias");
            this.DoReport(msg, new Location(0, 0));
        }

        public void ReferenceAliasExists(string name)
        {
            string msg = String.Format("Invalid reference alias. Name `{0}' already exists", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void NoOutputFileName()
        {
            string msg = String.Format("If no source files are specified you must specify the output file with /out:");
            this.DoReport(msg, new Location(0, 0));
        }

        public void InvalidTargetOption()
        {
            string msg = String.Format("Invalid target type for /target. Valid options are `exe', `winexe', `library' or `module'");
            this.DoReport(msg, new Location(0, 0));
        }

        public void BadAssembly(string name)
        {
            string msg = String.Format("Referenced file `{0}' is not an assembly", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void AssemblyNotFound(string name)
        {
            string msg = String.Format("Referenced file `{0}' could not be found", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void OutputDirectoryNotExists(string name)
        {
            string msg = String.Format("Specified output directory `{0}' does not exist", name);
            this.DoReport(msg, new Location(0, 0));            
        }

        public void IOError(string name)
        {
            string msg = String.Format("Error while accessing file `{0}'", name);
            this.DoReport(msg, new Location(0, 0));
        }

        public void ModuleTargetNotSupported()
        {
            string msg = String.Format("Modules are not supported");
            this.DoReport(msg, new Location(0, 0));
        }
    }

    public class ErrorException : ApplicationException
    {
        public readonly Location Location;

        public ErrorException(string msg, Location location)
            : base(msg)
        {
            this.Location = location;
        }
    }

    public class Warning
    {
        private void DoReport(string msg, Location location)
        {
            
        }

        public void DuplicateImport(string name, Location location)
        {
            string msg = String.Format("The using directive for `{0}' appeared previously in this namespace", name);
            this.DoReport(msg, location);
        }

        public void NegativeIndexing(Location location)
        {
            string msg = String.Format("Indexing an array with a negative index (array indices always start at zero)");
            this.DoReport(msg, location);
        }

        public void ProtectedInSealed(string name, Location location)
        {
            string msg = String.Format("`{0}': new protected member declared in sealed class", name);
            this.DoReport(msg, location);
        }

        public void AssignmentInCondition(Location location)
        {
            string msg = String.Format("Assignment in conditional expression is always constant; did you mean to use == instead of = ?");
            this.DoReport(msg, location);
        }
    }
}
