grammar Grammar;

options {
	language = CSharp2;
}

@lexer::namespace {
	Compiler.Grammar
}

@parser::namespace {
	Compiler.Grammar
}

@parser::header {
	using System;
	using System.Collections.Generic;

	using Compiler.AST;
	using Compiler.Driver;
	using Compiler.Symbols;
}

@parser::members {
	Stack<IDeclSpace> declspace_stack = new Stack<IDeclSpace>();

	AccessScopeStack access_scope = new AccessScopeStack();

	IDeclSpace CurrentDeclSpace
	{
		get { return declspace_stack.Count > 0 ? declspace_stack.Peek() : null; }
	}

	void PushDeclSpace(IDeclSpace declspace)
	{
		declspace_stack.Push(declspace);
	}

	void PopDeclSpace()
	{
		declspace_stack.Pop();
	}

	Location GetLocation(IToken token)
	{
		return new Location(token.Line, token.CharPositionInLine);
	}
}

/* G R A M M A R */

program returns [CompilationUnit value]
	:
	{
		$value = new CompilationUnit();
		PushDeclSpace($value);
	}
	using_directives?
	typedef_directives?
	(namespace_definition
	| type_definition)*
	EOF
	{
		PopDeclSpace();
	}
	;

using_directives
	: using_directive+
	;
	
using_directive returns [UsingDirective value]
	: KW_USING typename_expression SEMI
	{
		$value = new UsingDirective($typename_expression.value);
		CurrentDeclSpace.AddImport($value);
	}
	;

typedef_directives
	: typedef_directive+
	;

typedef_directive returns [TypedefDirective value]
	: KW_TYPEDEF identifier '=' typename_expression SEMI
	{
		$value = new TypedefDirective($identifier.value, $typename_expression.value);
		CurrentDeclSpace.AddTypedef($value);
	}
	;
	
namespace_definition returns [NamespaceDecl value]
	: KW_NAMESPACE identifier
	{
		$value = new NamespaceDecl($identifier.value);
		CurrentDeclSpace.AddNamespace($value);
		PushDeclSpace($value);
	}
	namespace_block SEMI?
	{
		PopDeclSpace();
	}
	;

namespace_block
	: '{' namespace_body? '}'
	;

namespace_body
	: using_directives?
	typedef_directives?
	(namespace_definition
	| type_definition)+
	;

type_definition
	: class_declaration
	| struct_declaration
	| enum_declaration
	| interface_declaration
	| delegate_declaration
	;

class_declaration returns [ClassDecl value]
	: access_modifier? class_specifiers? KW_CLASS identifier class_base? base_interfaces?
	{
		AccessModifier am = new AccessModifier();
		if ($access_modifier.value.IsEmpty)
			am = access_scope.CurrentAccess;
		else
			if(access_scope.IsEmpty)
				am = $access_modifier.value;
			else // IsNested
				Report.Error.NestedAccessModifier(GetLocation($start));

		$value = new ClassDecl(
			$identifier.value,
			am,
			$class_specifiers.value,
			$class_base.value,
			$base_interfaces.value
		);
		CurrentDeclSpace.AddType($value);
		PushDeclSpace($value);
		access_scope.Push(AccessScopeStack.DefaultClassAccess);
	}
	class_block SEMI?
	{
		access_scope.Pop();
		PopDeclSpace();
	}
	;

class_specifiers returns [ClassSpecifier value]
@init {
	$value = new ClassSpecifier();
}
	: (class_specifier
	{
		if ($value.IsSet($class_specifier.value))
			Report.Error.DuplicateModifier(GetLocation($class_specifier.start));
		$value.Add($class_specifier.value);
	} )+
	;
	
class_specifier returns [ClassSpecifier value]
	: KW_ABSTRACT	{ $value = ClassSpecifier.ABSTRACT; }
	| KW_FINAL		{ $value = ClassSpecifier.FINAL; }
	;

class_base returns [TypeSignature value]
	: '(' type ')'
	{
		$value = $type.value;
	}
	;

base_interfaces returns [IList<TypeSignature> value]
@init {
	$value = new List<TypeSignature>();
}
	: ':' head=type { $value.Add($head.value); }
	(COMMA tail=type { $value.Add($tail.value); } )*
	;

class_block
	: '{' class_body? '}'
	;

class_body
	: (class_member
	| type_definition)+
	;

class_member
options {
	backtrack = true;
}
	: field_declaration
	| method_declaration
	| constructor_declaration
	| static_constructor_declaration
	| access_scope_directive
	| signal_declaration
	| property_declaration
	//| destructor_declaration
	;

struct_declaration returns [StructDecl value]
	: access_modifier? KW_STRUCT identifier base_interfaces?
	{
		AccessModifier am = new AccessModifier();
		if ($access_modifier.value.IsEmpty)
			am = access_scope.CurrentAccess;
		else
			if(access_scope.IsEmpty)
				am = $access_modifier.value;
			else // IsNested
				Report.Error.NestedAccessModifier(GetLocation($start));

		$value = new StructDecl(
			$identifier.value,
			am,
			$base_interfaces.value
		);
		CurrentDeclSpace.AddType($value);
		PushDeclSpace($value);
		access_scope.Push(AccessScopeStack.DefaultStructAccess);
	}
	struct_block SEMI?
	{
		access_scope.Pop();
		PopDeclSpace();
	}
	;

struct_block
	: '{' struct_body? '}'
	;

struct_body
	: (struct_member
	| type_definition)+
	;

struct_member
options {
	backtrack = true;
}
	: field_declaration
	| method_declaration
	| constructor_declaration
	| static_constructor_declaration
	| signal_declaration
	| property_declaration
	//| destructor_definition
	;

enum_declaration returns [EnumDecl value]
	: access_modifier? KW_ENUM identifier enum_base?
	{
		AccessModifier am = new AccessModifier();
		if ($access_modifier.value.IsEmpty)
			am = access_scope.CurrentAccess;
		else
			if(access_scope.IsEmpty)
				am = $access_modifier.value;
			else // IsNested
				Report.Error.NestedAccessModifier(GetLocation($start));

		$value = new EnumDecl(
			$identifier.value,
			am,
			$enum_base.value
		);
		CurrentDeclSpace.AddType($value);
		PushDeclSpace($value);
	}
	enum_block SEMI?
	{
		PopDeclSpace();
	}
	;

enum_base returns [TypeSignature value]
	: '(' primitive_integral_type ')'
	{
		$value = $primitive_integral_type.value;
	}
	;

enum_block
	: '{' enum_body? '}'
	;

enum_body
	: enum_member (COMMA enum_member)*
	;

enum_member returns [LiteralFieldDecl value]
	: identifier '=' literal
	{
		$value = new LiteralFieldDecl(
			$identifier.value,
			FieldSpecifier.STATIC,
			AccessModifier.PUBLIC,
			new ResolvedType(Types.GetType("Int64")),
			$literal.value
		);
		CurrentDeclSpace.AddField($value);
	}
	;

interface_declaration returns [InterfaceDecl value]
	: access_modifier? KW_INTERFACE identifier base_interfaces?
	{
		AccessModifier am = new AccessModifier();
		if ($access_modifier.value.IsEmpty)
			am = access_scope.CurrentAccess;
		else
			if(access_scope.IsEmpty)
				am = $access_modifier.value;
			else // IsNested
				Report.Error.NestedAccessModifier(GetLocation($start));

		$value = new InterfaceDecl(
			$identifier.value,
			am,
			$base_interfaces.value
		);
		CurrentDeclSpace.AddType($value);
		PushDeclSpace($value);
		access_scope.Push(AccessScopeStack.DefaultInterfaceAccess);
	}
	interface_block SEMI?
	{
		access_scope.Pop();
		PopDeclSpace();
	}
	;

interface_block
	: '{' interface_body? '}'
	;

interface_body
	: interface_member+
	;

interface_member
	: method_signature (method_block | SEMI)
	{
		if ($method_block.value != null)
			Report.Error.InterfaceMemberDefinition(GetLocation($start));
	}
	//| signal_declaration
	;

delegate_declaration returns [DelegateDecl value]
	: access_modifier? KW_DELEGATE return_type identifier '(' formal_arguments? ')' SEMI
	{
		AccessModifier am = new AccessModifier();
		if ($access_modifier.value.IsEmpty)
			am = access_scope.CurrentAccess;
		else
			if(access_scope.IsEmpty)
				am = $access_modifier.value;
			else // IsNested
				Report.Error.NestedAccessModifier(GetLocation($start));

		$value = new DelegateDecl(
			$identifier.value,
			am,
			$return_type.value,
			$formal_arguments.value
		);
		CurrentDeclSpace.AddType($value);
	}
	;

signal_declaration returns [SignalDecl value]
	: method_specifiers? KW_SIGNAL type identifier SEMI
	{
		$value = new SignalDecl(
			$identifier.value,
			$method_specifiers.value,
			access_scope.CurrentAccess,
			$type.value
		);
		CurrentDeclSpace.AddSignal($value);
	}
	;

property_declaration returns [PropertyDecl value]
	: method_specifiers? type identifier '{' accessor_declarations '}'
	{
		$value = new PropertyDecl(
			$identifier.value,
			$method_specifiers.value,
			access_scope.CurrentAccess,
			$type.value,
			$accessor_declarations.setter,
			$accessor_declarations.getter
		);
		CurrentDeclSpace.AddProperty($value);
	}
	;

accessor_declarations returns [BlockStatement setter, BlockStatement getter]
	: a=get_accessor b=set_accessor? { $setter = $b.value; $getter = $a.value; }
	| c=set_accessor d=get_accessor? { $setter = $c.value; $getter = $d.value; }
	;

get_accessor returns [BlockStatement value]
	: KW_GET method_block
	{
		$value = $method_block.value;
	}
	;

set_accessor returns [BlockStatement value]
	: KW_SET method_block
	{
		$value = $method_block.value;
	}
	;

field_declaration returns [FieldDecl value]
	: field_specifiers? type identifier SEMI
	{
		$value = new FieldDecl(
			$identifier.value,
			$field_specifiers.value,
			access_scope.CurrentAccess,
			$type.value
		);
		CurrentDeclSpace.AddField($value);
	}
	;

field_specifiers returns [FieldSpecifier value]
@init {
	$value = new FieldSpecifier();
}
	: (field_specifier
	{
		if ($value.IsSet($field_specifier.value))
			Report.Error.DuplicateModifier(GetLocation($field_specifier.start));
		$value.Add($field_specifier.value);
	} )+
	;

field_specifier returns [FieldSpecifier value]
	: KW_STATIC	{ $value = FieldSpecifier.STATIC; }
	;

return_type returns [TypeSignature value]
	: type		{ $value = $type.value; }
	| KW_VOID	{ $value = new ResolvedType(Types.GetType("Void")); }
	;

method_declaration returns [MethodDecl value]
	: method_specifiers? return_type identifier '(' formal_arguments? ')' (method_block | SEMI)
	{
		$value = new MethodDecl(
			$identifier.value,
			$method_specifiers.value,
			access_scope.CurrentAccess,
			$return_type.value,
			$formal_arguments.value,
			$method_block.value
		);
		CurrentDeclSpace.AddMethod($value);
	}
	;

method_signature returns [MethodDecl value]
	: return_type identifier '(' formal_arguments? ')'
	{
		$value = new MethodDecl(
			$identifier.value,
			MethodSpecifier.ABSTRACT | MethodSpecifier.VIRTUAL,
			access_scope.CurrentAccess,
			$return_type.value,
			$formal_arguments.value,
			null
		);
		CurrentDeclSpace.AddMethod($value);
	}
	;

method_block returns [BlockStatement value]
	: block
	{
		$value = $block.value as BlockStatement;
	}
	;

formal_arguments returns [IList<ArgumentDecl> value]
@init {
	$value = new List<ArgumentDecl>();
}
	: head=formal_argument { $value.Add($head.value); }
	(COMMA tail=formal_argument { $value.Add($tail.value); } )*
	;

formal_argument returns [ArgumentDecl value]
	: type identifier
	{
		$value = new ArgumentDecl($identifier.value, $type.value);
	}
	;

method_specifiers returns [MethodSpecifier value]
@init {
	$value = new MethodSpecifier();
}
	: (method_specifier
	{
		if ($value.IsSet($method_specifier.value))
			Report.Error.DuplicateModifier(GetLocation($method_specifier.start));
		$value.Add($method_specifier.value);
	} )+
	;

method_specifier returns [MethodSpecifier value]
	: KW_ABSTRACT	{ $value = MethodSpecifier.ABSTRACT; }
	| KW_FINAL		{ $value = MethodSpecifier.FINAL; }
	| KW_STATIC		{ $value = MethodSpecifier.STATIC; }
	| KW_VIRTUAL	{ $value = MethodSpecifier.VIRTUAL; }
	| KW_NEW		{ $value = MethodSpecifier.NEW; }
	;

constructor_declaration returns [CtorDecl value]
	: KW_THIS '(' formal_arguments? ')' constructor_initializer? constructor_block
	{
		$value = new CtorDecl(
			access_scope.CurrentAccess,
			MethodSpecifier.CONSTRUCTOR,
			$formal_arguments.value,
			$constructor_block.value,
			$constructor_initializer.value
		);
		CurrentDeclSpace.AddMethod($value);
	}
	;

constructor_initializer returns [MethodCallExpression value]
	: ':' (e=KW_THIS | e=KW_BASE) '(' expressions_list? ')'
	{
		$value = new MethodCallExpression(
			new AnyExpression($e.Text),
			new Identifier(MethodSymbol.CTOR),
			$expressions_list.value
		);
	}
	;

constructor_block returns [BlockStatement value]
	: block
	{
		$value = $block.value as BlockStatement;
	}
	;

static_constructor_declaration returns [CCtorDecl value]
	: KW_STATIC KW_THIS '(' ')' static_constructor_body
	{
		$value = new CCtorDecl($static_constructor_body.value);
		CurrentDeclSpace.AddMethod($value);
	}
	;

static_constructor_body returns [BlockStatement value]
	: block
	{
		$value = $block.value as BlockStatement;
	}
	;

statement returns [Statement value]
/*options {
	backtrack = true;
}*/
	: embedded_statement		{ $value = $embedded_statement.value; }
	| declaration_statement		{ $value = $declaration_statement.value; }
	| labeled_statement			{ $value = $labeled_statement.value; }
	;

statements returns [IList<Statement> value]
@init {
	$value = new List<Statement>();
}
	: (statement { $value.Add($statement.value); } )+
	;

block returns [Statement value]
	: '{' statements? '}'
	{
		$value = new BlockStatement($statements.value);
	}
	;

labeled_statement returns [Statement value]
	: identifier ':' statement
	{
		$value = new LabeledStatement($identifier.value, $statement.value);
	}
	;

declaration_statement returns [Statement value]
	: variable_declaration_statement
	{
		$value = $variable_declaration_statement.value;
	}
	;

variable_declaration_statement returns [Statement value]
	: local_declaration SEMI
	{
		$value = new LocalDeclStatement($local_declaration.value);
	}
	;

local_declaration returns [LocalDecl value]
	: type variable_declarators
	{
		$value = new ExplicitlyTypedLocalDecl($type.value, $variable_declarators.value, GetLocation($start));
	}
	| KW_VAR variable_declarators
	{
		if ($variable_declarators.value.Count > 1)
			Report.Error.VarLocalMultipleDeclarators(GetLocation($start));
		$value = new ImplicitlyTypedLocalDecl($variable_declarators.value[0], GetLocation($start));
	}
	;

variable_declarators returns [IList<VariableDeclarator> value]
@init {
	$value = new List<VariableDeclarator>();
}
	: head=variable_declarator { $value.Add($head.value); }
	(COMMA tail=variable_declarator { $value.Add($tail.value); } )*
	;

variable_declarator returns [VariableDeclarator value]
	: identifier ('=' expression)?
	{
		$value = new VariableDeclarator($identifier.value, $expression.value);
	}
	;

embedded_statement returns [Statement value]
	: block					{ $value = $block.value; }
	| expression_statement	{ $value = $expression_statement.value; }
	| if_statement			{ $value = $if_statement.value; }
	| loop_statement		{ $value = $loop_statement.value; }
	| jump_statement		{ $value = $jump_statement.value; }
	| try_statement			{ $value = $try_statement.value; }
	| throw_statement		{ $value = $throw_statement.value; }
	| empty_statement		{ $value = $empty_statement.value; }
	;

if_statement returns [Statement value]
	: KW_IF '(' expression ')' embedded_statement else_statement?
	{
		$value = new IfStatement(
			$expression.value,
			$embedded_statement.value,
			$else_statement.value
		);
	}
	;

else_statement returns [Statement value]
	: KW_ELSE embedded_statement
	{
		$value = $embedded_statement.value;
	}
	;

loop_statement returns [Statement value]
	: for_statement			{ $value = $for_statement.value; }
	| while_statement		{ $value = $while_statement.value; }
	| do_statement			{ $value = $do_statement.value; }
	//| foreach_statement
	;

for_statement returns [Statement value]
	: KW_FOR '(' init=expression? SEMI cond=expression? SEMI iter=expression? ')' embedded_statement
	{
		if ($init.value != null && !($init.value is StatementExpression))
			Report.Error.InvalidStatement(GetLocation($start));

		if ($iter.value != null && !($iter.value is StatementExpression))
			Report.Error.InvalidStatement(GetLocation($start));

		$value = new ForStatement(
			(StatementExpression)$init.value,
			$cond.value,
			(StatementExpression)$iter.value,
			$embedded_statement.value
		);
	}

	| KW_FOR '(' decl=local_declaration SEMI cond=expression? SEMI iter=expression? ')' embedded_statement
	{
		if ($iter.value != null && !($iter.value is StatementExpression))
			Report.Error.InvalidStatement(GetLocation($start));
		
		$value = new ForStatement(
			$decl.value,
			$cond.value,
			(StatementExpression)$iter.value,
			$embedded_statement.value
		);
	}
	;

/*
foreach_statement returns [Statement value]
	: KW_FOREACH '(' type identifier KW_IN expression ')' embedded_statement
	{
		$value = new ForeachStatement();
	}
	;
*/

while_statement returns [Statement value]
	: KW_WHILE '(' expression ')' embedded_statement
	{
		$value = new WhileStatement(
			$expression.value,
			$embedded_statement.value
		);
	}
	;

do_statement returns [Statement value]
	: KW_DO embedded_statement KW_WHILE '(' expression ')' SEMI
	{
		$value = new DoStatement(
			$expression.value,
			$embedded_statement.value
		);
	}
	;

jump_statement returns [Statement value]
	: break_statement		{ $value = $break_statement.value; }
	| goto_statement		{ $value = $goto_statement.value; }
	| continue_statement	{ $value = $continue_statement.value; }
	| return_statement		{ $value = $return_statement.value; }
	;

goto_statement returns [Statement value]
	: KW_GOTO identifier SEMI
	{
		$value = new GotoStatement($identifier.value);
	}
	;

break_statement returns [Statement value]
	: KW_BREAK SEMI
	{
		$value = new BreakStatement(GetLocation($start));
	}
	;

continue_statement returns [Statement value]
	: KW_CONTINUE SEMI
	{
		$value = new ContinueStatement(GetLocation($start));
	}
	;

return_statement returns [Statement value]
	: KW_RETURN expression? SEMI
	{
		$value = new ReturnStatement($expression.value, GetLocation($start));
	}
	;

try_statement returns [Statement value]
	: KW_TRY block
		(catch_statements a=finally_statement?
		{
			$value = new TryStatement(
				$block.value,
				$catch_statements.value,
				$a.value
			);
		}
		| b=finally_statement
		{
			$value = new TryStatement(
				$block.value,
				null,
				$b.value
			);
		})
	;

catch_statements returns [IList<CatchClause> value]
@init {
	$value = new List<CatchClause>();
}
	: (catch_statement { $value.Add($catch_statement.value); } )+
	;

catch_statement returns [CatchClause value]
	: KW_CATCH '(' type identifier ')' block
	{
		$value = new CatchClause(
			$type.value,
			$identifier.value,
			$block.value
		);
	}
	;

finally_statement returns [FinallyClause value]
	: KW_FINALLY block
	{
		$value = new FinallyClause($block.value);
	}
	;

throw_statement returns [Statement value]
	: KW_THROW expression? SEMI
	{
		$value = new ThrowStatement($expression.value, GetLocation($start));
	}
	;

empty_statement returns [Statement value]
	: SEMI
	{
		$value = new EmptyStatement();
	}
	;

expression_statement returns [Statement value]
	: expression SEMI
	{
		if(!($expression.value is StatementExpression))
			Report.Error.InvalidStatement($expression.value.Location);
		$value = new ExpressionStatement((StatementExpression)$expression.value);
	}
	;

expression returns [Expression value]
	: lhs=null_coalescing_expression
	{
		$value = $lhs.value;
	}
	;

null_coalescing_expression returns [Expression value]
	: lhs=conditional_or_expression { $value = $lhs.value; }
		('??' rhs=conditional_or_expression { $value = new BinaryExpression(Operator.Binary.NullCoalescing, $null_coalescing_expression.value, $rhs.value); })*
	;

conditional_or_expression returns [Expression value]
	: lhs=conditional_and_expression { $value = $lhs.value; }
		('||' rhs=conditional_and_expression { $value = new BinaryExpression(Operator.Binary.LogicalOr, $conditional_or_expression.value, $rhs.value); })*
	;

conditional_and_expression returns [Expression value]
	: lhs=inclusive_or_expression { $value = $lhs.value; }
		('&&' rhs=inclusive_or_expression { $value = new BinaryExpression(Operator.Binary.LogicalAnd, $conditional_and_expression.value, $rhs.value); })*
	;

inclusive_or_expression returns [Expression value]
	: lhs=exclusive_or_expression { $value = $lhs.value; }
		('|' rhs=exclusive_or_expression { $value = new BinaryExpression(Operator.Binary.BitwiseOr, $inclusive_or_expression.value, $rhs.value); })*
	;

exclusive_or_expression returns [Expression value]
	: lhs=and_expression { $value = $lhs.value; }
		('^' rhs=and_expression { $value = new BinaryExpression(Operator.Binary.ExclusiveOr, $exclusive_or_expression.value, $rhs.value); })*
	;

and_expression returns [Expression value]
	: lhs=equality_expression { $value = $lhs.value; }
		('&' rhs=equality_expression { $value = new BinaryExpression(Operator.Binary.BitwiseAnd, $and_expression.value, $rhs.value); })*
	;

equality_expression returns [Expression value]
	: lhs=relational_expression { $value = $lhs.value; }
		(op=equality_operator rhs=relational_expression { $value = new BinaryExpression($op.value, $equality_expression.value, $rhs.value); })*
	;

equality_operator returns [Operator.Binary value]
	: '==' { $value = Operator.Binary.Equality; }
	| '!=' { $value = Operator.Binary.Inequality; }
	;
	
relational_expression returns [Expression value]
	: lhs=shift_expression { $value = $lhs.value; }
		(
			(op=relational_operator rhs=shift_expression { $value = new BinaryExpression($op.value, $relational_expression.value, $rhs.value); })+
			| KW_IS a=type { $value = new IsExpression($relational_expression.value, $a.value); }
			| KW_AS b=type { $value = new AsExpression($relational_expression.value, $b.value); }
			| /* empty */
		)
	;

relational_operator returns [Operator.Binary value]
	: '<'		{ $value = Operator.Binary.LessThan; }
	| '>'		{ $value = Operator.Binary.GreaterThan; }
	| '<='		{ $value = Operator.Binary.LessThanOrEqual; }
	| '>='		{ $value = Operator.Binary.GreaterThanOrEqual; }
	;

shift_expression returns [Expression value]
	: lhs=additive_expression { $value = $lhs.value; }
		(op=shift_operator rhs=additive_expression { $value = new BinaryExpression($op.value, $shift_expression.value, $rhs.value); })*
	;

shift_operator returns [Operator.Binary value]
	: '<<'		{ $value = Operator.Binary.LeftShift; }
	| '>>'		{ $value = Operator.Binary.RightShift; }
	;

additive_expression returns [Expression value]
	: lhs=multiplicative_expression { $value = $lhs.value; }
		(op=additive_operator rhs=multiplicative_expression { $value = new BinaryExpression($op.value, $additive_expression.value, $rhs.value); })*
	;

additive_operator returns [Operator.Binary value]
	: '+'	{ $value = Operator.Binary.Addition; }
	| '-'	{ $value = Operator.Binary.Subtraction; }
	;
	
multiplicative_expression returns [Expression value]
	: lhs=unary_expression { $value = $lhs.value; }
		(op=multiplicative_operator rhs=unary_expression { $value = new BinaryExpression($op.value, $multiplicative_expression.value, $rhs.value); })*
	;

multiplicative_operator returns [Operator.Binary value]
	: '*'	{ $value = Operator.Binary.Multiply; }
	| '/'	{ $value = Operator.Binary.Division; }
	| '%'	{ $value = Operator.Binary.Modulus; }
	;

assignment_operator
	: '='
	;
	
complex_assignment_operator returns [Operator.Binary value]
	: '+='		{ $value = Operator.Binary.Addition; }
	| '-='		{ $value = Operator.Binary.Subtraction; }
	| '*='		{ $value = Operator.Binary.Multiply; }
	| '/='		{ $value = Operator.Binary.Division; }
	| '%='		{ $value = Operator.Binary.Modulus; }
	| '&='		{ $value = Operator.Binary.BitwiseAnd; }
	| '|='		{ $value = Operator.Binary.BitwiseOr; }
	| '^='		{ $value = Operator.Binary.ExclusiveOr; }
	| '<<='		{ $value = Operator.Binary.LeftShift; }
	| '>>='		{ $value = Operator.Binary.RightShift; }
	;

unary_expression returns [Expression value]
	: (cast_expression) => cast_expression
	{
		$value = $cast_expression.value;
	}
	| postfix_expression	
		(
			assignment_operator r1=expression
			{
				$value = new Assignment($postfix_expression.value, $r1.value);
			}
			| op=complex_assignment_operator r2=expression
			{
				$value = new ComplexAssignment(
					$op.value,
					$postfix_expression.value,
					$r2.value
				);
			}
			| /* empty */
			{
				$value = $postfix_expression.value;
			}
		)
	| '+' a=postfix_expression
	{
		$value = new UnaryExpression(Operator.Unary.Plus, $a.value);
	}
	| '-' b=postfix_expression
	{
		$value = new UnaryExpression(Operator.Unary.Negation, $b.value);
	}
	| '!' c=postfix_expression
	{
		$value = new UnaryExpression(Operator.Unary.LogicalNot, $c.value);
	}
	| '~' d=postfix_expression
	{
		$value = new UnaryExpression(Operator.Unary.OnesComplement, $d.value);
	}
	| '++' e=postfix_expression
	{
		$value = new Assignment(
			$e.value,
			new BinaryExpression(
				Operator.Binary.Addition,
				$e.value,
				new IntLiteral(1, GetLocation($start))
			)
		);
	}
	| '--' f=postfix_expression
	{
		$value = new Assignment(
			$f.value,
			new BinaryExpression(
				Operator.Binary.Subtraction,
				$f.value,
				new IntLiteral(1, GetLocation($start))
			)
		);
	}
	;

cast_expression returns [Expression value]
	: '(' type ')' unary_expression
	{
		$value = new ExplicitCastExpression($type.value, $unary_expression.value);
	}
	;

postfix_expression returns [Expression value]
	: primary_expression
	{
		$value = $primary_expression.value;
	}
		( options { backtrack = true; } :
			'.' a=identifier
				(
					('(') => '(' b=expressions_list? ')'
					{
						$value = new MethodCallExpression($postfix_expression.value, $a.value, $b.value);
					}
					| /* empty */
					{
						$value = new DottedExpression($postfix_expression.value, $a.value);
					}
				)
			| '[' c=expressions_list ']'
			{
				$value = new ArrayAccessExpression($postfix_expression.value, $c.value);
			}
			/*
			| '(' d=expressions_list ')'
			{
				$value = new InvocationExpression($postfix_expression.value, $d.value);
			}
			*/
		)*
	;

primary_expression returns [Expression value]
	: array_creation_expression
	{
		$value = $array_creation_expression.value;
	}

	| object_creation_expression
	{
		$value = $object_creation_expression.value;
	}

	| KW_THIS
	{
		$value = new AnyExpression($start.Text, GetLocation($start));
	}

	| KW_BASE
	{
		$value = new AnyExpression($start.Text, GetLocation($start));
	}

	| KW_GLOBAL
	{
		$value = new AnyExpression($start.Text, GetLocation($start));
	}

	| identifier
		(
			('(')=> '(' f=expressions_list? ')'
			{
				$value = new MethodCallExpression(null, $identifier.value, $f.value);
			}
			| /* empty */
			{
				$value = new AnyExpression($identifier.value);
			}
		)

	| literal
	{
		$value = $literal.value;
	}

	| typeof_expression
	{
		$value = $typeof_expression.value;
	}

	| '(' expression ')'
	{
		$value = $expression.value;
	}
	;

typeof_expression returns [Expression value]
	: KW_TYPEOF '(' type ')'
	{
		$value = new TypeOfExpression($type.value);
	}

	| KW_TYPEOF '(' KW_VOID ')'
	{
		$value = new TypeOfExpression(new ResolvedType(Types.GetType("Void")));
	}
	;

typename_expression returns [Expression value]
	: a=identifier
	{
		$value = new AnyExpression($a.value);
	}
		('.' b=identifier
		{
			$value = new DottedExpression($typename_expression.value, $b.value);
		})*
	;

object_creation_expression returns [Expression value]
	: KW_NEW type '(' expressions_list? ')'
	{
		$value = new NewObjectExpression($type.value, $expressions_list.value);
	}
	;

array_creation_expression returns [Expression value]
	: KW_NEW type '[' expressions_list ']'
	{
		$value = new NewArrayExpression($type.value, $expressions_list.value);
	}
	;

expressions_list returns [IList<Expression> value]
@init {
	$value = new List<Expression>();
}
	: head=expression { $value.Add($head.value); }
	(COMMA tail=expression { $value.Add($tail.value); } )*
	;

access_modifier returns [AccessModifier value]
	: KW_PUBLIC		{ $value = AccessModifier.PUBLIC; }
	| KW_FAMILY		{ $value = AccessModifier.FAMILY; }
	| KW_PRIVATE	{ $value = AccessModifier.PRIVATE; }
	| KW_INTERNAL	{ $value = AccessModifier.ASSEMBLY; }
	;

access_scope_directive
	: access_modifier ':'
	{
		access_scope.Set($access_modifier.value);
	}
	;

identifier returns [Identifier value]
	: ID
	{	
		$value = new Identifier($ID.text, GetLocation($start));
	}
	;

type returns [TypeSignature value]
	: primitive_type array_specifier?
	{
		if ($array_specifier.value != null)
			$value = new ArrayType($primitive_type.value, (int)$array_specifier.value);
		else
			$value = $primitive_type.value;
	}

	| t=typename_expression array_specifier?
	{
		TypeSignature base_type = new TypeName($t.value);
		if ($array_specifier.value != null)
			$value = new ArrayType(base_type, (int)$array_specifier.value);
		else
			$value = base_type;
	}
	;

array_specifier returns [object value]
	: '[' array_rank_declaration? ']'
	{
		if ($array_rank_declaration.value != null)
			$value = $array_rank_declaration.value;
		else
			$value = 1;
	}
	;

array_rank_declaration returns [object value]
@init {
	int rank = 1;
}
	: (COMMA { ++rank; })+
	{
		$value = rank;
	}
	;

primitive_type returns [TypeSignature value]
@init {
	Location loc = GetLocation($start);
}
	: primitive_integral_type { $value = $primitive_integral_type.value; }
	| KW_CHAR		{ $value = new ResolvedType(Types.GetType("Char"), loc); }
	| KW_BOOL		{ $value = new ResolvedType(Types.GetType("Boolean"), loc); }
	| KW_FLOAT		{ $value = new ResolvedType(Types.GetType("Single"), loc); }
	| KW_DOUBLE		{ $value = new ResolvedType(Types.GetType("Double"), loc); }
	| KW_STRING		{ $value = new ResolvedType(Types.GetType("String"), loc); }
	| KW_OBJECT		{ $value = new ResolvedType(Types.GetType("Object"), loc); }
	;

primitive_integral_type returns [TypeSignature value]
@init {
	Location loc = GetLocation($start);
}
	: KW_BYTE		{ $value = new ResolvedType(Types.GetType("Byte"), loc); }
	| KW_SBYTE		{ $value = new ResolvedType(Types.GetType("SByte"), loc); }
	| KW_SHORT		{ $value = new ResolvedType(Types.GetType("Int16"), loc); }
	| KW_USHORT		{ $value = new ResolvedType(Types.GetType("UInt16"), loc); }
	| KW_INT		{ $value = new ResolvedType(Types.GetType("Int32"), loc); }
	| KW_UINT		{ $value = new ResolvedType(Types.GetType("UInt32"), loc); }
	| KW_LONG		{ $value = new ResolvedType(Types.GetType("Int64"), loc); }
	| KW_ULONG		{ $value = new ResolvedType(Types.GetType("UInt64"), loc); }
	;

literal returns [Expression value]
@init {
	IToken token = $start;
	Location loc = GetLocation(token);
	string text = token.Text;
}
	: LITERAL_INTEGER
	{
		System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;

		System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Integer;

		StringComparison strComp = StringComparison.InvariantCultureIgnoreCase;

		if (text.StartsWith("0x", strComp))
		{
			text = text.Substring(2, text.Length - 2);
			style = System.Globalization.NumberStyles.HexNumber;
		}

		bool isUnsigned = false;
		bool isLong = false;

		if (text.EndsWith("ul", strComp) || text.EndsWith("lu", strComp))
		{
			isUnsigned = true;
			isLong = true;
		}
		else if (text.EndsWith("u", strComp))
		{
			isUnsigned = true;
		}
		else if (text.EndsWith("l"))
		{
			isLong = true;
		}

		text = text.TrimEnd('u', 'U', 'l', 'L');

		if (isUnsigned)
		{
			ulong literal_value;
			if (!ulong.TryParse(text, style, culture, out literal_value))
			{
				Report.Error.IntegralConstantTooLarge(loc);
			}

			if (isLong)
			{
				$value = new ULongLiteral(literal_value, loc);
			}
			else
			{
				if (literal_value >= byte.MinValue && literal_value <= byte.MaxValue)
				{
					$value = new ByteLiteral((byte)literal_value, loc);
				}
				else if (literal_value >= ushort.MinValue && literal_value <= ushort.MaxValue)
				{
					$value = new UShortLiteral((ushort)literal_value, loc);
				}
				else if (literal_value >= uint.MinValue && literal_value <= uint.MaxValue)
				{
					$value = new UIntLiteral((uint)literal_value, loc);
				}
				else if (literal_value >= ulong.MinValue && literal_value <= ulong.MaxValue)
				{
					$value = new ULongLiteral((ulong)literal_value, loc);
				}
			}
		}
		else
		{
			long literal_value;
			if (!long.TryParse(text, style, culture, out literal_value))
			{
				Report.Error.IntegralConstantTooLarge(loc);
			}

			if (isLong)
			{
				$value = new LongLiteral(literal_value, loc);
			}
			else
			{
				if (literal_value >= sbyte.MinValue && literal_value <= sbyte.MaxValue)
				{
					$value = new SByteLiteral((sbyte)literal_value, loc);
				}
				else if (literal_value >= short.MinValue && literal_value <= short.MaxValue)
				{
					$value = new ShortLiteral((short)literal_value, loc);
				}
				else if (literal_value >= int.MinValue && literal_value <= int.MaxValue)
				{
					$value = new IntLiteral((int)literal_value, loc);
				}
				else if (literal_value >= long.MinValue && literal_value <= long.MaxValue)
				{
					$value = new LongLiteral((long)literal_value, loc);
				}
			}
		}
	}

	| LITERAL_REAL
	{
		System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;

		System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Float;

		StringComparison strComp = StringComparison.InvariantCultureIgnoreCase;

		if (text.EndsWith("d", strComp))
		{
			text = text.TrimEnd('d');
			double literal_value;
			if (!double.TryParse(text, style, culture, out literal_value))
			{
				Report.Error.FloatingPointConstantTooLarge(Types.GetType("Double").GetQualifiedName(), loc);
			}
			$value = new DoubleLiteral(literal_value, loc);
		}
		else
		{
			if (text.EndsWith("f", strComp))
			{
				text = text.TrimEnd('f');
			}
			float literal_value;
			if (!float.TryParse(text, style, culture, out literal_value))
			{
				Report.Error.FloatingPointConstantTooLarge(Types.GetType("Single").GetQualifiedName(), loc);
			}
			$value = new FloatLiteral(literal_value, loc);
		}
	}

	| LITERAL_CHAR
	{
		text = text.TrimStart('\'');
		text = text.TrimEnd('\'');
		$value = new CharLiteral(Char.Parse(text), loc);
	}

	| LITERAL_STRING
	{
		text = text.TrimStart('"');
		text = text.TrimEnd('"');
		$value = new StringLiteral(text, loc);
	}

	| KW_TRUE
	{
		$value = new BoolLiteral(true, loc);
	}

	| KW_FALSE
	{
		$value = new BoolLiteral(false, loc);
	}

	| KW_NULL
	{
		$value = new NullLiteral(loc);
	}
	;


/* T O K E N S */

KW_CLASS : 'class' ;

KW_STRUCT : 'struct' ;

KW_ENUM : 'enum' ;

KW_INTERFACE : 'interface' ;

KW_NAMESPACE : 'namespace' ;

KW_THIS : 'this' ;

KW_BASE : 'base' ;

KW_GLOBAL : 'global' ;

KW_NULL : 'null' ;

KW_TRUE : 'true' ;

KW_FALSE : 'false' ;

KW_IF : 'if' ;

KW_ELSE : 'else' ;

KW_FOR : 'for' ;

KW_FOREACH : 'foreach' ;

KW_IN : 'in' ;

KW_WHILE : 'while' ;

KW_DO : 'do' ;

KW_BREAK : 'break' ;

KW_CONTINUE : 'continue' ;

KW_GOTO : 'goto' ;

KW_RETURN : 'return' ;

KW_TRY : 'try' ;

KW_CATCH : 'catch' ;

KW_FINALLY : 'finally' ;

KW_THROW : 'raise' ;

KW_USING : 'using' ;

KW_TYPEDEF : 'typedef' ;

KW_PRIVATE : 'private' ;

KW_FAMILY : 'family' ;

KW_PUBLIC : 'public' ;

KW_INTERNAL : 'internal' ;

KW_ABSTRACT : 'abstract' ;

KW_VIRTUAL : 'virtual' ;

KW_FINAL : 'final' ;

KW_STATIC : 'shared' ;

KW_AUTO : 'auto' ;

KW_VAR : 'var' ;

KW_NEW : 'new' ;

KW_TYPEOF : 'typeof' ;

KW_IS : 'is' ;

KW_AS : 'as' ;

KW_SIGNAL : 'signal' ;

KW_DELEGATE : 'function' ;

KW_GET : 'get' ;

KW_SET : 'set' ;

KW_CHAR : 'char' ;

KW_BYTE : 'byte' ;

KW_SBYTE : 'sbyte' ;

KW_SHORT : 'short' ;

KW_USHORT : 'ushort' ;

KW_INT : 'int' ;

KW_UINT : 'uint' ;

KW_LONG : 'long' ;

KW_ULONG : 'ulong' ;

KW_FLOAT : 'float' ;

KW_DOUBLE : 'double' ;

KW_DECIMAL : 'decimal' ;

KW_STRING : 'string' ;

KW_OBJECT : 'object' ;

KW_BOOL : 'bool' ;

KW_VOID : 'void' ;


SEMI : ';' ;

COMMA : ',' ;


ID : IdHead IdTail* ;

fragment IdHead
	: NotAKeywordPrefix IdTail+
	| '_'
	| Letter
	;

fragment NotAKeywordPrefix
	: '$'
	;

fragment IdTail
	: Letter
	| Digit
	| '_'
	;

fragment Letter
	: 'A'..'Z'
	| 'a'..'z'
	;

fragment Digit
	: '0'..'9'
	;

fragment Digits
	: Digit+
	;

fragment HexDigit
	: Digit
	| 'A'..'F'
	| 'a'..'f'
	;

fragment HexDigits
	: HexDigit+
	;

fragment OctalDigit
	: '0'..'7'
	;

fragment OctalDigits
	: OctalDigit+
	;

fragment Exponent
	: ('E' | 'e') Sign? Digits
	;

fragment Sign
	: '+' | '-'
	;

fragment IntegerSuffix
	: 'u' | 'U' | 'l' | 'L' | 'ul' | 'UL' | 'Ul' | 'uL' | 'LU' | 'Lu' | 'lU'
	;

fragment RealSuffix
	: 'd' | 'f' | 'D' | 'F' // | 'm' | 'M'
	;

LITERAL_INTEGER
	: (Digits
	| '0' ('x' | 'X') HexDigits
	//| '0' OctalDigits
	)
	IntegerSuffix?
	;

LITERAL_REAL
	: Digits '.' Digits Exponent? RealSuffix?
	| '.' Digits Exponent? RealSuffix?
	| Digits Exponent RealSuffix?
	| Digits RealSuffix
	;

LITERAL_STRING
	: '"' (EscapeSequence | ~('"' | '\\'))* '"'
	;

LITERAL_CHAR
	: '\''
	(EscapeSequence
	| ~('\\' | '\'' | '\r' | '\n')
	| ~('\\' | '\'' | '\r' | '\n') ~('\\' | '\'' | '\r' | '\n')
	| ~('\\' | '\'' | '\r' | '\n') ~('\\' | '\'' | '\r' | '\n') ~('\\' | '\'' | '\r' | '\n')
	)
	'\''
	;

fragment EscapeSequence
	: '\\'
	('a'
	| 'b'
	| 'f'
	| 'n'
	| 'r'
	| 't'
	| 'v'
	| '\"'
	| '\''
	| '\\'
	| ('0'..'3') ('0'..'7') ('0'..'7')
	| ('0'..'7') ('0'..'7')
	| ('0'..'7')
	| 'x' HexDigit
	| 'x' HexDigit HexDigit
	| 'x' HexDigit HexDigit HexDigit
	| 'x' HexDigit HexDigit HexDigit HexDigit
	| 'u' HexDigit HexDigit HexDigit
	| 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
	)
	;

WHITE_SPACE
	: (' '
	| '\r'
	| '\t'
	| '\n'
	)
	{ $channel = HIDDEN; }
	;

COMMENT_LINE
	: ('//' ~('\n' | '\r')* ('\r' | '\n')+) { Skip(); }
	;

COMMENT_MULTILINE
	: '/*' (options { greedy = false; } : .)* '*/' { Skip(); }
	;
	