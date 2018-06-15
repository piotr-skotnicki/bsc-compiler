// $ANTLR 3.2 Sep 23, 2009 12:02:23 D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g 2011-01-01 16:34:32

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


	using System;
	using System.Collections.Generic;

	using Compiler.AST;
	using Compiler.Driver;
	using Compiler.Symbols;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;
namespace 
	Compiler.Grammar

{
public partial class GrammarParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"KW_USING", 
		"SEMI", 
		"KW_TYPEDEF", 
		"KW_NAMESPACE", 
		"KW_CLASS", 
		"KW_ABSTRACT", 
		"KW_FINAL", 
		"COMMA", 
		"KW_STRUCT", 
		"KW_ENUM", 
		"KW_INTERFACE", 
		"KW_DELEGATE", 
		"KW_SIGNAL", 
		"KW_GET", 
		"KW_SET", 
		"KW_STATIC", 
		"KW_VOID", 
		"KW_VIRTUAL", 
		"KW_NEW", 
		"KW_THIS", 
		"KW_BASE", 
		"KW_VAR", 
		"KW_IF", 
		"KW_ELSE", 
		"KW_FOR", 
		"KW_WHILE", 
		"KW_DO", 
		"KW_GOTO", 
		"KW_BREAK", 
		"KW_CONTINUE", 
		"KW_RETURN", 
		"KW_TRY", 
		"KW_CATCH", 
		"KW_FINALLY", 
		"KW_THROW", 
		"KW_IS", 
		"KW_AS", 
		"KW_GLOBAL", 
		"KW_TYPEOF", 
		"KW_PUBLIC", 
		"KW_FAMILY", 
		"KW_PRIVATE", 
		"KW_INTERNAL", 
		"ID", 
		"KW_CHAR", 
		"KW_BOOL", 
		"KW_FLOAT", 
		"KW_DOUBLE", 
		"KW_STRING", 
		"KW_OBJECT", 
		"KW_BYTE", 
		"KW_SBYTE", 
		"KW_SHORT", 
		"KW_USHORT", 
		"KW_INT", 
		"KW_UINT", 
		"KW_LONG", 
		"KW_ULONG", 
		"LITERAL_INTEGER", 
		"LITERAL_REAL", 
		"LITERAL_CHAR", 
		"LITERAL_STRING", 
		"KW_TRUE", 
		"KW_FALSE", 
		"KW_NULL", 
		"KW_FOREACH", 
		"KW_IN", 
		"KW_AUTO", 
		"KW_DECIMAL", 
		"IdHead", 
		"IdTail", 
		"NotAKeywordPrefix", 
		"Letter", 
		"Digit", 
		"Digits", 
		"HexDigit", 
		"HexDigits", 
		"OctalDigit", 
		"OctalDigits", 
		"Sign", 
		"Exponent", 
		"IntegerSuffix", 
		"RealSuffix", 
		"EscapeSequence", 
		"WHITE_SPACE", 
		"COMMENT_LINE", 
		"COMMENT_MULTILINE", 
		"'='", 
		"'{'", 
		"'}'", 
		"'('", 
		"')'", 
		"':'", 
		"'??'", 
		"'||'", 
		"'&&'", 
		"'|'", 
		"'^'", 
		"'&'", 
		"'=='", 
		"'!='", 
		"'<'", 
		"'>'", 
		"'<='", 
		"'>='", 
		"'<<'", 
		"'>>'", 
		"'+'", 
		"'-'", 
		"'*'", 
		"'/'", 
		"'%'", 
		"'+='", 
		"'-='", 
		"'*='", 
		"'/='", 
		"'%='", 
		"'&='", 
		"'|='", 
		"'^='", 
		"'<<='", 
		"'>>='", 
		"'!'", 
		"'~'", 
		"'++'", 
		"'--'", 
		"'.'", 
		"'['", 
		"']'"
    };

    public const int KW_STRING = 52;
    public const int KW_CHAR = 48;
    public const int KW_LONG = 60;
    public const int KW_SBYTE = 55;
    public const int KW_FLOAT = 50;
    public const int EOF = -1;
    public const int IdHead = 73;
    public const int NotAKeywordPrefix = 75;
    public const int KW_VAR = 25;
    public const int KW_PUBLIC = 43;
    public const int T__93 = 93;
    public const int T__94 = 94;
    public const int T__91 = 91;
    public const int KW_GLOBAL = 41;
    public const int T__92 = 92;
    public const int KW_NEW = 22;
    public const int KW_INTERFACE = 14;
    public const int KW_BREAK = 32;
    public const int OctalDigits = 82;
    public const int Digits = 78;
    public const int OctalDigit = 81;
    public const int KW_FOREACH = 69;
    public const int Sign = 83;
    public const int T__99 = 99;
    public const int T__98 = 98;
    public const int T__97 = 97;
    public const int T__96 = 96;
    public const int T__95 = 95;
    public const int KW_FAMILY = 44;
    public const int KW_USHORT = 57;
    public const int KW_INT = 58;
    public const int KW_DECIMAL = 72;
    public const int KW_CATCH = 36;
    public const int RealSuffix = 86;
    public const int KW_TYPEOF = 42;
    public const int KW_DO = 30;
    public const int KW_DOUBLE = 51;
    public const int KW_SIGNAL = 16;
    public const int T__126 = 126;
    public const int KW_FINALLY = 37;
    public const int T__125 = 125;
    public const int T__128 = 128;
    public const int T__127 = 127;
    public const int KW_THROW = 38;
    public const int T__129 = 129;
    public const int KW_STATIC = 19;
    public const int IntegerSuffix = 85;
    public const int KW_BASE = 24;
    public const int KW_GET = 17;
    public const int T__130 = 130;
    public const int KW_GOTO = 31;
    public const int EscapeSequence = 87;
    public const int Letter = 76;
    public const int T__131 = 131;
    public const int T__132 = 132;
    public const int KW_ELSE = 27;
    public const int KW_BOOL = 49;
    public const int LITERAL_INTEGER = 62;
    public const int KW_BYTE = 54;
    public const int T__118 = 118;
    public const int T__119 = 119;
    public const int T__116 = 116;
    public const int T__117 = 117;
    public const int T__114 = 114;
    public const int KW_ABSTRACT = 9;
    public const int T__115 = 115;
    public const int T__124 = 124;
    public const int T__123 = 123;
    public const int Exponent = 84;
    public const int T__122 = 122;
    public const int T__121 = 121;
    public const int T__120 = 120;
    public const int KW_TRUE = 66;
    public const int ID = 47;
    public const int HexDigit = 79;
    public const int WHITE_SPACE = 88;
    public const int KW_VIRTUAL = 21;
    public const int KW_STRUCT = 12;
    public const int T__107 = 107;
    public const int T__108 = 108;
    public const int COMMA = 11;
    public const int T__109 = 109;
    public const int KW_FOR = 28;
    public const int KW_WHILE = 29;
    public const int T__103 = 103;
    public const int KW_SHORT = 56;
    public const int T__104 = 104;
    public const int T__105 = 105;
    public const int KW_DELEGATE = 15;
    public const int KW_SET = 18;
    public const int KW_RETURN = 34;
    public const int T__106 = 106;
    public const int T__111 = 111;
    public const int KW_IN = 70;
    public const int T__110 = 110;
    public const int T__113 = 113;
    public const int T__112 = 112;
    public const int IdTail = 74;
    public const int KW_IS = 39;
    public const int KW_TRY = 35;
    public const int KW_TYPEDEF = 6;
    public const int KW_THIS = 23;
    public const int KW_IF = 26;
    public const int HexDigits = 80;
    public const int KW_FALSE = 67;
    public const int KW_FINAL = 10;
    public const int KW_INTERNAL = 46;
    public const int KW_CONTINUE = 33;
    public const int LITERAL_CHAR = 64;
    public const int KW_PRIVATE = 45;
    public const int T__102 = 102;
    public const int T__101 = 101;
    public const int KW_ENUM = 13;
    public const int KW_UINT = 59;
    public const int T__100 = 100;
    public const int Digit = 77;
    public const int KW_ULONG = 61;
    public const int SEMI = 5;
    public const int COMMENT_LINE = 89;
    public const int LITERAL_STRING = 65;
    public const int LITERAL_REAL = 63;
    public const int KW_VOID = 20;
    public const int KW_CLASS = 8;
    public const int KW_NAMESPACE = 7;
    public const int KW_AS = 40;
    public const int KW_USING = 4;
    public const int KW_AUTO = 71;
    public const int KW_NULL = 68;
    public const int KW_OBJECT = 53;
    public const int COMMENT_MULTILINE = 90;

    // delegates
    // delegators



        public GrammarParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public GrammarParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        

    override public string[] TokenNames {
		get { return GrammarParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g"; }
    }


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



    // $ANTLR start "program"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:52:1: program returns [CompilationUnit value] : ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )* EOF ;
    public CompilationUnit program() // throws RecognitionException [1]
    {   
        CompilationUnit value = default(CompilationUnit);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:53:2: ( ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )* EOF )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:54:2: ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )* EOF
            {
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new CompilationUnit();
            	  		PushDeclSpace(value);
            	  	
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:58:2: ( using_directives )?
            	int alt1 = 2;
            	int LA1_0 = input.LA(1);

            	if ( (LA1_0 == KW_USING) )
            	{
            	    alt1 = 1;
            	}
            	switch (alt1) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:58:2: using_directives
            	        {
            	        	PushFollow(FOLLOW_using_directives_in_program71);
            	        	using_directives();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:59:2: ( typedef_directives )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);

            	if ( (LA2_0 == KW_TYPEDEF) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:59:2: typedef_directives
            	        {
            	        	PushFollow(FOLLOW_typedef_directives_in_program75);
            	        	typedef_directives();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:60:2: ( namespace_definition | type_definition )*
            	do 
            	{
            	    int alt3 = 3;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == KW_NAMESPACE) )
            	    {
            	        alt3 = 1;
            	    }
            	    else if ( ((LA3_0 >= KW_CLASS && LA3_0 <= KW_FINAL) || (LA3_0 >= KW_STRUCT && LA3_0 <= KW_DELEGATE) || (LA3_0 >= KW_PUBLIC && LA3_0 <= KW_INTERNAL)) )
            	    {
            	        alt3 = 2;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:60:3: namespace_definition
            			    {
            			    	PushFollow(FOLLOW_namespace_definition_in_program80);
            			    	namespace_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;

            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:61:4: type_definition
            			    {
            			    	PushFollow(FOLLOW_type_definition_in_program85);
            			    	type_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements

            	Match(input,EOF,FOLLOW_EOF_in_program90); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		PopDeclSpace();
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "program"


    // $ANTLR start "using_directives"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:68:1: using_directives : ( using_directive )+ ;
    public void using_directives() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:69:2: ( ( using_directive )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:69:4: ( using_directive )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:69:4: ( using_directive )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0 == KW_USING) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:69:4: using_directive
            			    {
            			    	PushFollow(FOLLOW_using_directive_in_using_directives104);
            			    	using_directive();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt4 >= 1 ) goto loop4;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee4 =
            		                new EarlyExitException(4, input);
            		            throw eee4;
            	    }
            	    cnt4++;
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "using_directives"


    // $ANTLR start "using_directive"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:72:1: using_directive returns [UsingDirective value] : KW_USING typename_expression SEMI ;
    public UsingDirective using_directive() // throws RecognitionException [1]
    {   
        UsingDirective value = default(UsingDirective);

        Expression typename_expression1 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:73:2: ( KW_USING typename_expression SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:73:4: KW_USING typename_expression SEMI
            {
            	Match(input,KW_USING,FOLLOW_KW_USING_in_using_directive121); if (state.failed) return value;
            	PushFollow(FOLLOW_typename_expression_in_using_directive123);
            	typename_expression1 = typename_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_using_directive125); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new UsingDirective(typename_expression1);
            	  		CurrentDeclSpace.AddImport(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "using_directive"


    // $ANTLR start "typedef_directives"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:80:1: typedef_directives : ( typedef_directive )+ ;
    public void typedef_directives() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:81:2: ( ( typedef_directive )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:81:4: ( typedef_directive )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:81:4: ( typedef_directive )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == KW_TYPEDEF) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:81:4: typedef_directive
            			    {
            			    	PushFollow(FOLLOW_typedef_directive_in_typedef_directives139);
            			    	typedef_directive();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee5 =
            		                new EarlyExitException(5, input);
            		            throw eee5;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "typedef_directives"


    // $ANTLR start "typedef_directive"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:84:1: typedef_directive returns [TypedefDirective value] : KW_TYPEDEF identifier '=' typename_expression SEMI ;
    public TypedefDirective typedef_directive() // throws RecognitionException [1]
    {   
        TypedefDirective value = default(TypedefDirective);

        GrammarParser.identifier_return identifier2 = default(GrammarParser.identifier_return);

        Expression typename_expression3 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:85:2: ( KW_TYPEDEF identifier '=' typename_expression SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:85:4: KW_TYPEDEF identifier '=' typename_expression SEMI
            {
            	Match(input,KW_TYPEDEF,FOLLOW_KW_TYPEDEF_in_typedef_directive155); if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_typedef_directive157);
            	identifier2 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,91,FOLLOW_91_in_typedef_directive159); if (state.failed) return value;
            	PushFollow(FOLLOW_typename_expression_in_typedef_directive161);
            	typename_expression3 = typename_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_typedef_directive163); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new TypedefDirective(((identifier2 != null) ? identifier2.value : default(Identifier)), typename_expression3);
            	  		CurrentDeclSpace.AddTypedef(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "typedef_directive"


    // $ANTLR start "namespace_definition"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:92:1: namespace_definition returns [NamespaceDecl value] : KW_NAMESPACE identifier namespace_block ( SEMI )? ;
    public NamespaceDecl namespace_definition() // throws RecognitionException [1]
    {   
        NamespaceDecl value = default(NamespaceDecl);

        GrammarParser.identifier_return identifier4 = default(GrammarParser.identifier_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:93:2: ( KW_NAMESPACE identifier namespace_block ( SEMI )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:93:4: KW_NAMESPACE identifier namespace_block ( SEMI )?
            {
            	Match(input,KW_NAMESPACE,FOLLOW_KW_NAMESPACE_in_namespace_definition182); if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_namespace_definition184);
            	identifier4 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new NamespaceDecl(((identifier4 != null) ? identifier4.value : default(Identifier)));
            	  		CurrentDeclSpace.AddNamespace(value);
            	  		PushDeclSpace(value);
            	  	
            	}
            	PushFollow(FOLLOW_namespace_block_in_namespace_definition190);
            	namespace_block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:99:18: ( SEMI )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);

            	if ( (LA6_0 == SEMI) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:99:18: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_namespace_definition192); if (state.failed) return value;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		PopDeclSpace();
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "namespace_definition"


    // $ANTLR start "namespace_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:105:1: namespace_block : '{' ( namespace_body )? '}' ;
    public void namespace_block() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:106:2: ( '{' ( namespace_body )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:106:4: '{' ( namespace_body )? '}'
            {
            	Match(input,92,FOLLOW_92_in_namespace_block207); if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:106:8: ( namespace_body )?
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == KW_USING || (LA7_0 >= KW_TYPEDEF && LA7_0 <= KW_FINAL) || (LA7_0 >= KW_STRUCT && LA7_0 <= KW_DELEGATE) || (LA7_0 >= KW_PUBLIC && LA7_0 <= KW_INTERNAL)) )
            	{
            	    alt7 = 1;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:106:8: namespace_body
            	        {
            	        	PushFollow(FOLLOW_namespace_body_in_namespace_block209);
            	        	namespace_body();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_namespace_block212); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "namespace_block"


    // $ANTLR start "namespace_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:109:1: namespace_body : ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )+ ;
    public void namespace_body() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:110:2: ( ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:110:4: ( using_directives )? ( typedef_directives )? ( namespace_definition | type_definition )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:110:4: ( using_directives )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == KW_USING) )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:110:4: using_directives
            	        {
            	        	PushFollow(FOLLOW_using_directives_in_namespace_body223);
            	        	using_directives();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:111:2: ( typedef_directives )?
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( (LA9_0 == KW_TYPEDEF) )
            	{
            	    alt9 = 1;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:111:2: typedef_directives
            	        {
            	        	PushFollow(FOLLOW_typedef_directives_in_namespace_body227);
            	        	typedef_directives();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:112:2: ( namespace_definition | type_definition )+
            	int cnt10 = 0;
            	do 
            	{
            	    int alt10 = 3;
            	    int LA10_0 = input.LA(1);

            	    if ( (LA10_0 == KW_NAMESPACE) )
            	    {
            	        alt10 = 1;
            	    }
            	    else if ( ((LA10_0 >= KW_CLASS && LA10_0 <= KW_FINAL) || (LA10_0 >= KW_STRUCT && LA10_0 <= KW_DELEGATE) || (LA10_0 >= KW_PUBLIC && LA10_0 <= KW_INTERNAL)) )
            	    {
            	        alt10 = 2;
            	    }


            	    switch (alt10) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:112:3: namespace_definition
            			    {
            			    	PushFollow(FOLLOW_namespace_definition_in_namespace_body232);
            			    	namespace_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:113:4: type_definition
            			    {
            			    	PushFollow(FOLLOW_type_definition_in_namespace_body237);
            			    	type_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt10 >= 1 ) goto loop10;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee10 =
            		                new EarlyExitException(10, input);
            		            throw eee10;
            	    }
            	    cnt10++;
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "namespace_body"


    // $ANTLR start "type_definition"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:116:1: type_definition : ( class_declaration | struct_declaration | enum_declaration | interface_declaration | delegate_declaration );
    public void type_definition() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:117:2: ( class_declaration | struct_declaration | enum_declaration | interface_declaration | delegate_declaration )
            int alt11 = 5;
            alt11 = dfa11.Predict(input);
            switch (alt11) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:117:4: class_declaration
                    {
                    	PushFollow(FOLLOW_class_declaration_in_type_definition250);
                    	class_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:118:4: struct_declaration
                    {
                    	PushFollow(FOLLOW_struct_declaration_in_type_definition255);
                    	struct_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:119:4: enum_declaration
                    {
                    	PushFollow(FOLLOW_enum_declaration_in_type_definition260);
                    	enum_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:120:4: interface_declaration
                    {
                    	PushFollow(FOLLOW_interface_declaration_in_type_definition265);
                    	interface_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:121:4: delegate_declaration
                    {
                    	PushFollow(FOLLOW_delegate_declaration_in_type_definition270);
                    	delegate_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "type_definition"

    public class class_declaration_return : ParserRuleReturnScope
    {
        public ClassDecl value;
    };

    // $ANTLR start "class_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:124:1: class_declaration returns [ClassDecl value] : ( access_modifier )? ( class_specifiers )? KW_CLASS identifier ( class_base )? ( base_interfaces )? class_block ( SEMI )? ;
    public GrammarParser.class_declaration_return class_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.class_declaration_return retval = new GrammarParser.class_declaration_return();
        retval.Start = input.LT(1);

        AccessModifier access_modifier5 = default(AccessModifier);

        GrammarParser.identifier_return identifier6 = default(GrammarParser.identifier_return);

        ClassSpecifier class_specifiers7 = default(ClassSpecifier);

        TypeSignature class_base8 = default(TypeSignature);

        IList<TypeSignature> base_interfaces9 = default(IList<TypeSignature>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:2: ( ( access_modifier )? ( class_specifiers )? KW_CLASS identifier ( class_base )? ( base_interfaces )? class_block ( SEMI )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:4: ( access_modifier )? ( class_specifiers )? KW_CLASS identifier ( class_base )? ( base_interfaces )? class_block ( SEMI )?
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:4: ( access_modifier )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);

            	if ( ((LA12_0 >= KW_PUBLIC && LA12_0 <= KW_INTERNAL)) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:4: access_modifier
            	        {
            	        	PushFollow(FOLLOW_access_modifier_in_class_declaration285);
            	        	access_modifier5 = access_modifier();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:21: ( class_specifiers )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( ((LA13_0 >= KW_ABSTRACT && LA13_0 <= KW_FINAL)) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:21: class_specifiers
            	        {
            	        	PushFollow(FOLLOW_class_specifiers_in_class_declaration288);
            	        	class_specifiers7 = class_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,KW_CLASS,FOLLOW_KW_CLASS_in_class_declaration291); if (state.failed) return retval;
            	PushFollow(FOLLOW_identifier_in_class_declaration293);
            	identifier6 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:59: ( class_base )?
            	int alt14 = 2;
            	int LA14_0 = input.LA(1);

            	if ( (LA14_0 == 94) )
            	{
            	    alt14 = 1;
            	}
            	switch (alt14) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:59: class_base
            	        {
            	        	PushFollow(FOLLOW_class_base_in_class_declaration295);
            	        	class_base8 = class_base();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:71: ( base_interfaces )?
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);

            	if ( (LA15_0 == 96) )
            	{
            	    alt15 = 1;
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:125:71: base_interfaces
            	        {
            	        	PushFollow(FOLLOW_base_interfaces_in_class_declaration298);
            	        	base_interfaces9 = base_interfaces();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		AccessModifier am = new AccessModifier();
            	  		if (access_modifier5.IsEmpty)
            	  			am = access_scope.CurrentAccess;
            	  		else
            	  			if(access_scope.IsEmpty)
            	  				am = access_modifier5;
            	  			else // IsNested
            	  				Report.Error.NestedAccessModifier(GetLocation(((IToken)retval.Start)));

            	  		retval.value =  new ClassDecl(
            	  			((identifier6 != null) ? identifier6.value : default(Identifier)),
            	  			am,
            	  			class_specifiers7,
            	  			class_base8,
            	  			base_interfaces9
            	  		);
            	  		CurrentDeclSpace.AddType(retval.value);
            	  		PushDeclSpace(retval.value);
            	  		access_scope.Push(AccessScopeStack.DefaultClassAccess);
            	  	
            	}
            	PushFollow(FOLLOW_class_block_in_class_declaration305);
            	class_block();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:147:14: ( SEMI )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);

            	if ( (LA16_0 == SEMI) )
            	{
            	    alt16 = 1;
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:147:14: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_class_declaration307); if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		access_scope.Pop();
            	  		PopDeclSpace();
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "class_declaration"


    // $ANTLR start "class_specifiers"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:154:1: class_specifiers returns [ClassSpecifier value] : ( class_specifier )+ ;
    public ClassSpecifier class_specifiers() // throws RecognitionException [1]
    {   
        ClassSpecifier value = default(ClassSpecifier);

        GrammarParser.class_specifier_return class_specifier10 = default(GrammarParser.class_specifier_return);



        	value =  new ClassSpecifier();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:158:2: ( ( class_specifier )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:158:4: ( class_specifier )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:158:4: ( class_specifier )+
            	int cnt17 = 0;
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( ((LA17_0 >= KW_ABSTRACT && LA17_0 <= KW_FINAL)) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:158:5: class_specifier
            			    {
            			    	PushFollow(FOLLOW_class_specifier_in_class_specifiers332);
            			    	class_specifier10 = class_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  		if (value.IsSet(((class_specifier10 != null) ? class_specifier10.value : default(ClassSpecifier))))
            			    	  			Report.Error.DuplicateModifier(GetLocation(((class_specifier10 != null) ? ((IToken)class_specifier10.Start) : null)));
            			    	  		value.Add(((class_specifier10 != null) ? class_specifier10.value : default(ClassSpecifier)));
            			    	  	
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt17 >= 1 ) goto loop17;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee17 =
            		                new EarlyExitException(17, input);
            		            throw eee17;
            	    }
            	    cnt17++;
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "class_specifiers"

    public class class_specifier_return : ParserRuleReturnScope
    {
        public ClassSpecifier value;
    };

    // $ANTLR start "class_specifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:166:1: class_specifier returns [ClassSpecifier value] : ( KW_ABSTRACT | KW_FINAL );
    public GrammarParser.class_specifier_return class_specifier() // throws RecognitionException [1]
    {   
        GrammarParser.class_specifier_return retval = new GrammarParser.class_specifier_return();
        retval.Start = input.LT(1);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:167:2: ( KW_ABSTRACT | KW_FINAL )
            int alt18 = 2;
            int LA18_0 = input.LA(1);

            if ( (LA18_0 == KW_ABSTRACT) )
            {
                alt18 = 1;
            }
            else if ( (LA18_0 == KW_FINAL) )
            {
                alt18 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d18s0 =
                    new NoViableAltException("", 18, 0, input);

                throw nvae_d18s0;
            }
            switch (alt18) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:167:4: KW_ABSTRACT
                    {
                    	Match(input,KW_ABSTRACT,FOLLOW_KW_ABSTRACT_in_class_specifier354); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  ClassSpecifier.ABSTRACT; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:168:4: KW_FINAL
                    {
                    	Match(input,KW_FINAL,FOLLOW_KW_FINAL_in_class_specifier361); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  ClassSpecifier.FINAL; 
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "class_specifier"


    // $ANTLR start "class_base"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:171:1: class_base returns [TypeSignature value] : '(' type ')' ;
    public TypeSignature class_base() // throws RecognitionException [1]
    {   
        TypeSignature value = default(TypeSignature);

        TypeSignature type11 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:172:2: ( '(' type ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:172:4: '(' type ')'
            {
            	Match(input,94,FOLLOW_94_in_class_base379); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_class_base381);
            	type11 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_class_base383); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  type11;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "class_base"


    // $ANTLR start "base_interfaces"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:178:1: base_interfaces returns [IList<TypeSignature> value] : ':' head= type ( COMMA tail= type )* ;
    public IList<TypeSignature> base_interfaces() // throws RecognitionException [1]
    {   
        IList<TypeSignature> value = default(IList<TypeSignature>);

        TypeSignature head = default(TypeSignature);

        TypeSignature tail = default(TypeSignature);



        	value =  new List<TypeSignature>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:182:2: ( ':' head= type ( COMMA tail= type )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:182:4: ':' head= type ( COMMA tail= type )*
            {
            	Match(input,96,FOLLOW_96_in_base_interfaces407); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_base_interfaces411);
            	head = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value.Add(head); 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:183:2: ( COMMA tail= type )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( (LA19_0 == COMMA) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:183:3: COMMA tail= type
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_base_interfaces417); if (state.failed) return value;
            			    	PushFollow(FOLLOW_type_in_base_interfaces421);
            			    	tail = type();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(tail); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "base_interfaces"


    // $ANTLR start "class_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:186:1: class_block : '{' ( class_body )? '}' ;
    public void class_block() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:187:2: ( '{' ( class_body )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:187:4: '{' ( class_body )? '}'
            {
            	Match(input,92,FOLLOW_92_in_class_block437); if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:187:8: ( class_body )?
            	int alt20 = 2;
            	int LA20_0 = input.LA(1);

            	if ( ((LA20_0 >= KW_CLASS && LA20_0 <= KW_FINAL) || (LA20_0 >= KW_STRUCT && LA20_0 <= KW_SIGNAL) || (LA20_0 >= KW_STATIC && LA20_0 <= KW_THIS) || (LA20_0 >= KW_PUBLIC && LA20_0 <= KW_ULONG)) )
            	{
            	    alt20 = 1;
            	}
            	switch (alt20) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:187:8: class_body
            	        {
            	        	PushFollow(FOLLOW_class_body_in_class_block439);
            	        	class_body();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_class_block442); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "class_block"


    // $ANTLR start "class_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:190:1: class_body : ( class_member | type_definition )+ ;
    public void class_body() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:191:2: ( ( class_member | type_definition )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:191:4: ( class_member | type_definition )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:191:4: ( class_member | type_definition )+
            	int cnt21 = 0;
            	do 
            	{
            	    int alt21 = 3;
            	    alt21 = dfa21.Predict(input);
            	    switch (alt21) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:191:5: class_member
            			    {
            			    	PushFollow(FOLLOW_class_member_in_class_body454);
            			    	class_member();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:192:4: type_definition
            			    {
            			    	PushFollow(FOLLOW_type_definition_in_class_body459);
            			    	type_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt21 >= 1 ) goto loop21;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee21 =
            		                new EarlyExitException(21, input);
            		            throw eee21;
            	    }
            	    cnt21++;
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "class_body"


    // $ANTLR start "class_member"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:195:1: class_member options {backtrack=true; } : ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | access_scope_directive | signal_declaration | property_declaration );
    public void class_member() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:199:2: ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | access_scope_directive | signal_declaration | property_declaration )
            int alt22 = 7;
            alt22 = dfa22.Predict(input);
            switch (alt22) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:199:4: field_declaration
                    {
                    	PushFollow(FOLLOW_field_declaration_in_class_member485);
                    	field_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:200:4: method_declaration
                    {
                    	PushFollow(FOLLOW_method_declaration_in_class_member490);
                    	method_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:201:4: constructor_declaration
                    {
                    	PushFollow(FOLLOW_constructor_declaration_in_class_member495);
                    	constructor_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:202:4: static_constructor_declaration
                    {
                    	PushFollow(FOLLOW_static_constructor_declaration_in_class_member500);
                    	static_constructor_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:203:4: access_scope_directive
                    {
                    	PushFollow(FOLLOW_access_scope_directive_in_class_member505);
                    	access_scope_directive();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:204:4: signal_declaration
                    {
                    	PushFollow(FOLLOW_signal_declaration_in_class_member510);
                    	signal_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:205:4: property_declaration
                    {
                    	PushFollow(FOLLOW_property_declaration_in_class_member515);
                    	property_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "class_member"

    public class struct_declaration_return : ParserRuleReturnScope
    {
        public StructDecl value;
    };

    // $ANTLR start "struct_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:209:1: struct_declaration returns [StructDecl value] : ( access_modifier )? KW_STRUCT identifier ( base_interfaces )? struct_block ( SEMI )? ;
    public GrammarParser.struct_declaration_return struct_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.struct_declaration_return retval = new GrammarParser.struct_declaration_return();
        retval.Start = input.LT(1);

        AccessModifier access_modifier12 = default(AccessModifier);

        GrammarParser.identifier_return identifier13 = default(GrammarParser.identifier_return);

        IList<TypeSignature> base_interfaces14 = default(IList<TypeSignature>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:2: ( ( access_modifier )? KW_STRUCT identifier ( base_interfaces )? struct_block ( SEMI )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:4: ( access_modifier )? KW_STRUCT identifier ( base_interfaces )? struct_block ( SEMI )?
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:4: ( access_modifier )?
            	int alt23 = 2;
            	int LA23_0 = input.LA(1);

            	if ( ((LA23_0 >= KW_PUBLIC && LA23_0 <= KW_INTERNAL)) )
            	{
            	    alt23 = 1;
            	}
            	switch (alt23) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:4: access_modifier
            	        {
            	        	PushFollow(FOLLOW_access_modifier_in_struct_declaration532);
            	        	access_modifier12 = access_modifier();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,KW_STRUCT,FOLLOW_KW_STRUCT_in_struct_declaration535); if (state.failed) return retval;
            	PushFollow(FOLLOW_identifier_in_struct_declaration537);
            	identifier13 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:42: ( base_interfaces )?
            	int alt24 = 2;
            	int LA24_0 = input.LA(1);

            	if ( (LA24_0 == 96) )
            	{
            	    alt24 = 1;
            	}
            	switch (alt24) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:210:42: base_interfaces
            	        {
            	        	PushFollow(FOLLOW_base_interfaces_in_struct_declaration539);
            	        	base_interfaces14 = base_interfaces();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		AccessModifier am = new AccessModifier();
            	  		if (access_modifier12.IsEmpty)
            	  			am = access_scope.CurrentAccess;
            	  		else
            	  			if(access_scope.IsEmpty)
            	  				am = access_modifier12;
            	  			else // IsNested
            	  				Report.Error.NestedAccessModifier(GetLocation(((IToken)retval.Start)));

            	  		retval.value =  new StructDecl(
            	  			((identifier13 != null) ? identifier13.value : default(Identifier)),
            	  			am,
            	  			base_interfaces14
            	  		);
            	  		CurrentDeclSpace.AddType(retval.value);
            	  		PushDeclSpace(retval.value);
            	  		access_scope.Push(AccessScopeStack.DefaultStructAccess);
            	  	
            	}
            	PushFollow(FOLLOW_struct_block_in_struct_declaration546);
            	struct_block();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:230:15: ( SEMI )?
            	int alt25 = 2;
            	int LA25_0 = input.LA(1);

            	if ( (LA25_0 == SEMI) )
            	{
            	    alt25 = 1;
            	}
            	switch (alt25) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:230:15: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_struct_declaration548); if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		access_scope.Pop();
            	  		PopDeclSpace();
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "struct_declaration"


    // $ANTLR start "struct_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:237:1: struct_block : '{' ( struct_body )? '}' ;
    public void struct_block() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:238:2: ( '{' ( struct_body )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:238:4: '{' ( struct_body )? '}'
            {
            	Match(input,92,FOLLOW_92_in_struct_block563); if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:238:8: ( struct_body )?
            	int alt26 = 2;
            	int LA26_0 = input.LA(1);

            	if ( ((LA26_0 >= KW_CLASS && LA26_0 <= KW_FINAL) || (LA26_0 >= KW_STRUCT && LA26_0 <= KW_SIGNAL) || (LA26_0 >= KW_STATIC && LA26_0 <= KW_THIS) || (LA26_0 >= KW_PUBLIC && LA26_0 <= KW_ULONG)) )
            	{
            	    alt26 = 1;
            	}
            	switch (alt26) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:238:8: struct_body
            	        {
            	        	PushFollow(FOLLOW_struct_body_in_struct_block565);
            	        	struct_body();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_struct_block568); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "struct_block"


    // $ANTLR start "struct_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:241:1: struct_body : ( struct_member | type_definition )+ ;
    public void struct_body() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:242:2: ( ( struct_member | type_definition )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:242:4: ( struct_member | type_definition )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:242:4: ( struct_member | type_definition )+
            	int cnt27 = 0;
            	do 
            	{
            	    int alt27 = 3;
            	    alt27 = dfa27.Predict(input);
            	    switch (alt27) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:242:5: struct_member
            			    {
            			    	PushFollow(FOLLOW_struct_member_in_struct_body580);
            			    	struct_member();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:243:4: type_definition
            			    {
            			    	PushFollow(FOLLOW_type_definition_in_struct_body585);
            			    	type_definition();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt27 >= 1 ) goto loop27;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee27 =
            		                new EarlyExitException(27, input);
            		            throw eee27;
            	    }
            	    cnt27++;
            	} while (true);

            	loop27:
            		;	// Stops C# compiler whining that label 'loop27' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "struct_body"


    // $ANTLR start "struct_member"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:246:1: struct_member options {backtrack=true; } : ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | signal_declaration | property_declaration );
    public void struct_member() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:250:2: ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | signal_declaration | property_declaration )
            int alt28 = 6;
            alt28 = dfa28.Predict(input);
            switch (alt28) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:250:4: field_declaration
                    {
                    	PushFollow(FOLLOW_field_declaration_in_struct_member610);
                    	field_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:251:4: method_declaration
                    {
                    	PushFollow(FOLLOW_method_declaration_in_struct_member615);
                    	method_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:252:4: constructor_declaration
                    {
                    	PushFollow(FOLLOW_constructor_declaration_in_struct_member620);
                    	constructor_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:253:4: static_constructor_declaration
                    {
                    	PushFollow(FOLLOW_static_constructor_declaration_in_struct_member625);
                    	static_constructor_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:254:4: signal_declaration
                    {
                    	PushFollow(FOLLOW_signal_declaration_in_struct_member630);
                    	signal_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:255:4: property_declaration
                    {
                    	PushFollow(FOLLOW_property_declaration_in_struct_member635);
                    	property_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return ;

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "struct_member"

    public class enum_declaration_return : ParserRuleReturnScope
    {
        public EnumDecl value;
    };

    // $ANTLR start "enum_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:259:1: enum_declaration returns [EnumDecl value] : ( access_modifier )? KW_ENUM identifier ( enum_base )? enum_block ( SEMI )? ;
    public GrammarParser.enum_declaration_return enum_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.enum_declaration_return retval = new GrammarParser.enum_declaration_return();
        retval.Start = input.LT(1);

        AccessModifier access_modifier15 = default(AccessModifier);

        GrammarParser.identifier_return identifier16 = default(GrammarParser.identifier_return);

        TypeSignature enum_base17 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:2: ( ( access_modifier )? KW_ENUM identifier ( enum_base )? enum_block ( SEMI )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:4: ( access_modifier )? KW_ENUM identifier ( enum_base )? enum_block ( SEMI )?
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:4: ( access_modifier )?
            	int alt29 = 2;
            	int LA29_0 = input.LA(1);

            	if ( ((LA29_0 >= KW_PUBLIC && LA29_0 <= KW_INTERNAL)) )
            	{
            	    alt29 = 1;
            	}
            	switch (alt29) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:4: access_modifier
            	        {
            	        	PushFollow(FOLLOW_access_modifier_in_enum_declaration652);
            	        	access_modifier15 = access_modifier();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,KW_ENUM,FOLLOW_KW_ENUM_in_enum_declaration655); if (state.failed) return retval;
            	PushFollow(FOLLOW_identifier_in_enum_declaration657);
            	identifier16 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:40: ( enum_base )?
            	int alt30 = 2;
            	int LA30_0 = input.LA(1);

            	if ( (LA30_0 == 94) )
            	{
            	    alt30 = 1;
            	}
            	switch (alt30) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:260:40: enum_base
            	        {
            	        	PushFollow(FOLLOW_enum_base_in_enum_declaration659);
            	        	enum_base17 = enum_base();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		AccessModifier am = new AccessModifier();
            	  		if (access_modifier15.IsEmpty)
            	  			am = access_scope.CurrentAccess;
            	  		else
            	  			if(access_scope.IsEmpty)
            	  				am = access_modifier15;
            	  			else // IsNested
            	  				Report.Error.NestedAccessModifier(GetLocation(((IToken)retval.Start)));

            	  		retval.value =  new EnumDecl(
            	  			((identifier16 != null) ? identifier16.value : default(Identifier)),
            	  			am,
            	  			enum_base17
            	  		);
            	  		CurrentDeclSpace.AddType(retval.value);
            	  		PushDeclSpace(retval.value);
            	  	
            	}
            	PushFollow(FOLLOW_enum_block_in_enum_declaration666);
            	enum_block();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:279:13: ( SEMI )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);

            	if ( (LA31_0 == SEMI) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:279:13: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_enum_declaration668); if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		PopDeclSpace();
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "enum_declaration"


    // $ANTLR start "enum_base"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:285:1: enum_base returns [TypeSignature value] : '(' primitive_integral_type ')' ;
    public TypeSignature enum_base() // throws RecognitionException [1]
    {   
        TypeSignature value = default(TypeSignature);

        GrammarParser.primitive_integral_type_return primitive_integral_type18 = default(GrammarParser.primitive_integral_type_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:286:2: ( '(' primitive_integral_type ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:286:4: '(' primitive_integral_type ')'
            {
            	Match(input,94,FOLLOW_94_in_enum_base687); if (state.failed) return value;
            	PushFollow(FOLLOW_primitive_integral_type_in_enum_base689);
            	primitive_integral_type18 = primitive_integral_type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_enum_base691); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  ((primitive_integral_type18 != null) ? primitive_integral_type18.value : default(TypeSignature));
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "enum_base"


    // $ANTLR start "enum_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:292:1: enum_block : '{' ( enum_body )? '}' ;
    public void enum_block() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:293:2: ( '{' ( enum_body )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:293:4: '{' ( enum_body )? '}'
            {
            	Match(input,92,FOLLOW_92_in_enum_block705); if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:293:8: ( enum_body )?
            	int alt32 = 2;
            	int LA32_0 = input.LA(1);

            	if ( (LA32_0 == ID) )
            	{
            	    alt32 = 1;
            	}
            	switch (alt32) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:293:8: enum_body
            	        {
            	        	PushFollow(FOLLOW_enum_body_in_enum_block707);
            	        	enum_body();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_enum_block710); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "enum_block"


    // $ANTLR start "enum_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:296:1: enum_body : enum_member ( COMMA enum_member )* ;
    public void enum_body() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:297:2: ( enum_member ( COMMA enum_member )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:297:4: enum_member ( COMMA enum_member )*
            {
            	PushFollow(FOLLOW_enum_member_in_enum_body721);
            	enum_member();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:297:16: ( COMMA enum_member )*
            	do 
            	{
            	    int alt33 = 2;
            	    int LA33_0 = input.LA(1);

            	    if ( (LA33_0 == COMMA) )
            	    {
            	        alt33 = 1;
            	    }


            	    switch (alt33) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:297:17: COMMA enum_member
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_enum_body724); if (state.failed) return ;
            			    	PushFollow(FOLLOW_enum_member_in_enum_body726);
            			    	enum_member();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    goto loop33;
            	    }
            	} while (true);

            	loop33:
            		;	// Stops C# compiler whining that label 'loop33' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "enum_body"


    // $ANTLR start "enum_member"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:300:1: enum_member returns [LiteralFieldDecl value] : identifier '=' literal ;
    public LiteralFieldDecl enum_member() // throws RecognitionException [1]
    {   
        LiteralFieldDecl value = default(LiteralFieldDecl);

        GrammarParser.identifier_return identifier19 = default(GrammarParser.identifier_return);

        GrammarParser.literal_return literal20 = default(GrammarParser.literal_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:301:2: ( identifier '=' literal )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:301:4: identifier '=' literal
            {
            	PushFollow(FOLLOW_identifier_in_enum_member743);
            	identifier19 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,91,FOLLOW_91_in_enum_member745); if (state.failed) return value;
            	PushFollow(FOLLOW_literal_in_enum_member747);
            	literal20 = literal();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new LiteralFieldDecl(
            	  			((identifier19 != null) ? identifier19.value : default(Identifier)),
            	  			FieldSpecifier.STATIC,
            	  			AccessModifier.PUBLIC,
            	  			new ResolvedType(Types.GetType("Int64")),
            	  			((literal20 != null) ? literal20.value : default(Expression))
            	  		);
            	  		CurrentDeclSpace.AddField(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "enum_member"

    public class interface_declaration_return : ParserRuleReturnScope
    {
        public InterfaceDecl value;
    };

    // $ANTLR start "interface_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:314:1: interface_declaration returns [InterfaceDecl value] : ( access_modifier )? KW_INTERFACE identifier ( base_interfaces )? interface_block ( SEMI )? ;
    public GrammarParser.interface_declaration_return interface_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.interface_declaration_return retval = new GrammarParser.interface_declaration_return();
        retval.Start = input.LT(1);

        AccessModifier access_modifier21 = default(AccessModifier);

        GrammarParser.identifier_return identifier22 = default(GrammarParser.identifier_return);

        IList<TypeSignature> base_interfaces23 = default(IList<TypeSignature>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:2: ( ( access_modifier )? KW_INTERFACE identifier ( base_interfaces )? interface_block ( SEMI )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:4: ( access_modifier )? KW_INTERFACE identifier ( base_interfaces )? interface_block ( SEMI )?
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:4: ( access_modifier )?
            	int alt34 = 2;
            	int LA34_0 = input.LA(1);

            	if ( ((LA34_0 >= KW_PUBLIC && LA34_0 <= KW_INTERNAL)) )
            	{
            	    alt34 = 1;
            	}
            	switch (alt34) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:4: access_modifier
            	        {
            	        	PushFollow(FOLLOW_access_modifier_in_interface_declaration765);
            	        	access_modifier21 = access_modifier();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,KW_INTERFACE,FOLLOW_KW_INTERFACE_in_interface_declaration768); if (state.failed) return retval;
            	PushFollow(FOLLOW_identifier_in_interface_declaration770);
            	identifier22 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:45: ( base_interfaces )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);

            	if ( (LA35_0 == 96) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:315:45: base_interfaces
            	        {
            	        	PushFollow(FOLLOW_base_interfaces_in_interface_declaration772);
            	        	base_interfaces23 = base_interfaces();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		AccessModifier am = new AccessModifier();
            	  		if (access_modifier21.IsEmpty)
            	  			am = access_scope.CurrentAccess;
            	  		else
            	  			if(access_scope.IsEmpty)
            	  				am = access_modifier21;
            	  			else // IsNested
            	  				Report.Error.NestedAccessModifier(GetLocation(((IToken)retval.Start)));

            	  		retval.value =  new InterfaceDecl(
            	  			((identifier22 != null) ? identifier22.value : default(Identifier)),
            	  			am,
            	  			base_interfaces23
            	  		);
            	  		CurrentDeclSpace.AddType(retval.value);
            	  		PushDeclSpace(retval.value);
            	  		access_scope.Push(AccessScopeStack.DefaultInterfaceAccess);
            	  	
            	}
            	PushFollow(FOLLOW_interface_block_in_interface_declaration779);
            	interface_block();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:335:18: ( SEMI )?
            	int alt36 = 2;
            	int LA36_0 = input.LA(1);

            	if ( (LA36_0 == SEMI) )
            	{
            	    alt36 = 1;
            	}
            	switch (alt36) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:335:18: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_interface_declaration781); if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		access_scope.Pop();
            	  		PopDeclSpace();
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "interface_declaration"


    // $ANTLR start "interface_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:342:1: interface_block : '{' ( interface_body )? '}' ;
    public void interface_block() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:343:2: ( '{' ( interface_body )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:343:4: '{' ( interface_body )? '}'
            {
            	Match(input,92,FOLLOW_92_in_interface_block796); if (state.failed) return ;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:343:8: ( interface_body )?
            	int alt37 = 2;
            	int LA37_0 = input.LA(1);

            	if ( (LA37_0 == KW_VOID || (LA37_0 >= ID && LA37_0 <= KW_ULONG)) )
            	{
            	    alt37 = 1;
            	}
            	switch (alt37) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:343:8: interface_body
            	        {
            	        	PushFollow(FOLLOW_interface_body_in_interface_block798);
            	        	interface_body();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return ;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_interface_block801); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "interface_block"


    // $ANTLR start "interface_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:346:1: interface_body : ( interface_member )+ ;
    public void interface_body() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:347:2: ( ( interface_member )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:347:4: ( interface_member )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:347:4: ( interface_member )+
            	int cnt38 = 0;
            	do 
            	{
            	    int alt38 = 2;
            	    int LA38_0 = input.LA(1);

            	    if ( (LA38_0 == KW_VOID || (LA38_0 >= ID && LA38_0 <= KW_ULONG)) )
            	    {
            	        alt38 = 1;
            	    }


            	    switch (alt38) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:347:4: interface_member
            			    {
            			    	PushFollow(FOLLOW_interface_member_in_interface_body812);
            			    	interface_member();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return ;

            			    }
            			    break;

            			default:
            			    if ( cnt38 >= 1 ) goto loop38;
            			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
            		            EarlyExitException eee38 =
            		                new EarlyExitException(38, input);
            		            throw eee38;
            	    }
            	    cnt38++;
            	} while (true);

            	loop38:
            		;	// Stops C# compiler whining that label 'loop38' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "interface_body"

    public class interface_member_return : ParserRuleReturnScope
    {
    };

    // $ANTLR start "interface_member"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:350:1: interface_member : method_signature ( method_block | SEMI ) ;
    public GrammarParser.interface_member_return interface_member() // throws RecognitionException [1]
    {   
        GrammarParser.interface_member_return retval = new GrammarParser.interface_member_return();
        retval.Start = input.LT(1);

        BlockStatement method_block24 = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:351:2: ( method_signature ( method_block | SEMI ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:351:4: method_signature ( method_block | SEMI )
            {
            	PushFollow(FOLLOW_method_signature_in_interface_member824);
            	method_signature();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:351:21: ( method_block | SEMI )
            	int alt39 = 2;
            	int LA39_0 = input.LA(1);

            	if ( (LA39_0 == 92) )
            	{
            	    alt39 = 1;
            	}
            	else if ( (LA39_0 == SEMI) )
            	{
            	    alt39 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d39s0 =
            	        new NoViableAltException("", 39, 0, input);

            	    throw nvae_d39s0;
            	}
            	switch (alt39) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:351:22: method_block
            	        {
            	        	PushFollow(FOLLOW_method_block_in_interface_member827);
            	        	method_block24 = method_block();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:351:37: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_interface_member831); if (state.failed) return retval;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		if (method_block24 != null)
            	  			Report.Error.InterfaceMemberDefinition(GetLocation(((IToken)retval.Start)));
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "interface_member"

    public class delegate_declaration_return : ParserRuleReturnScope
    {
        public DelegateDecl value;
    };

    // $ANTLR start "delegate_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:359:1: delegate_declaration returns [DelegateDecl value] : ( access_modifier )? KW_DELEGATE return_type identifier '(' ( formal_arguments )? ')' SEMI ;
    public GrammarParser.delegate_declaration_return delegate_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.delegate_declaration_return retval = new GrammarParser.delegate_declaration_return();
        retval.Start = input.LT(1);

        AccessModifier access_modifier25 = default(AccessModifier);

        GrammarParser.identifier_return identifier26 = default(GrammarParser.identifier_return);

        TypeSignature return_type27 = default(TypeSignature);

        IList<ArgumentDecl> formal_arguments28 = default(IList<ArgumentDecl>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:2: ( ( access_modifier )? KW_DELEGATE return_type identifier '(' ( formal_arguments )? ')' SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:4: ( access_modifier )? KW_DELEGATE return_type identifier '(' ( formal_arguments )? ')' SEMI
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:4: ( access_modifier )?
            	int alt40 = 2;
            	int LA40_0 = input.LA(1);

            	if ( ((LA40_0 >= KW_PUBLIC && LA40_0 <= KW_INTERNAL)) )
            	{
            	    alt40 = 1;
            	}
            	switch (alt40) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:4: access_modifier
            	        {
            	        	PushFollow(FOLLOW_access_modifier_in_delegate_declaration852);
            	        	access_modifier25 = access_modifier();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,KW_DELEGATE,FOLLOW_KW_DELEGATE_in_delegate_declaration855); if (state.failed) return retval;
            	PushFollow(FOLLOW_return_type_in_delegate_declaration857);
            	return_type27 = return_type();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	PushFollow(FOLLOW_identifier_in_delegate_declaration859);
            	identifier26 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	Match(input,94,FOLLOW_94_in_delegate_declaration861); if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:60: ( formal_arguments )?
            	int alt41 = 2;
            	int LA41_0 = input.LA(1);

            	if ( ((LA41_0 >= ID && LA41_0 <= KW_ULONG)) )
            	{
            	    alt41 = 1;
            	}
            	switch (alt41) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:360:60: formal_arguments
            	        {
            	        	PushFollow(FOLLOW_formal_arguments_in_delegate_declaration863);
            	        	formal_arguments28 = formal_arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_delegate_declaration866); if (state.failed) return retval;
            	Match(input,SEMI,FOLLOW_SEMI_in_delegate_declaration868); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{

            	  		AccessModifier am = new AccessModifier();
            	  		if (access_modifier25.IsEmpty)
            	  			am = access_scope.CurrentAccess;
            	  		else
            	  			if(access_scope.IsEmpty)
            	  				am = access_modifier25;
            	  			else // IsNested
            	  				Report.Error.NestedAccessModifier(GetLocation(((IToken)retval.Start)));

            	  		retval.value =  new DelegateDecl(
            	  			((identifier26 != null) ? identifier26.value : default(Identifier)),
            	  			am,
            	  			return_type27,
            	  			formal_arguments28
            	  		);
            	  		CurrentDeclSpace.AddType(retval.value);
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "delegate_declaration"


    // $ANTLR start "signal_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:381:1: signal_declaration returns [SignalDecl value] : ( method_specifiers )? KW_SIGNAL type identifier SEMI ;
    public SignalDecl signal_declaration() // throws RecognitionException [1]
    {   
        SignalDecl value = default(SignalDecl);

        GrammarParser.identifier_return identifier29 = default(GrammarParser.identifier_return);

        MethodSpecifier method_specifiers30 = default(MethodSpecifier);

        TypeSignature type31 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:382:2: ( ( method_specifiers )? KW_SIGNAL type identifier SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:382:4: ( method_specifiers )? KW_SIGNAL type identifier SEMI
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:382:4: ( method_specifiers )?
            	int alt42 = 2;
            	int LA42_0 = input.LA(1);

            	if ( ((LA42_0 >= KW_ABSTRACT && LA42_0 <= KW_FINAL) || LA42_0 == KW_STATIC || (LA42_0 >= KW_VIRTUAL && LA42_0 <= KW_NEW)) )
            	{
            	    alt42 = 1;
            	}
            	switch (alt42) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:382:4: method_specifiers
            	        {
            	        	PushFollow(FOLLOW_method_specifiers_in_signal_declaration886);
            	        	method_specifiers30 = method_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,KW_SIGNAL,FOLLOW_KW_SIGNAL_in_signal_declaration889); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_signal_declaration891);
            	type31 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_signal_declaration893);
            	identifier29 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_signal_declaration895); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new SignalDecl(
            	  			((identifier29 != null) ? identifier29.value : default(Identifier)),
            	  			method_specifiers30,
            	  			access_scope.CurrentAccess,
            	  			type31
            	  		);
            	  		CurrentDeclSpace.AddSignal(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "signal_declaration"


    // $ANTLR start "property_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:394:1: property_declaration returns [PropertyDecl value] : ( method_specifiers )? type identifier '{' accessor_declarations '}' ;
    public PropertyDecl property_declaration() // throws RecognitionException [1]
    {   
        PropertyDecl value = default(PropertyDecl);

        GrammarParser.identifier_return identifier32 = default(GrammarParser.identifier_return);

        MethodSpecifier method_specifiers33 = default(MethodSpecifier);

        TypeSignature type34 = default(TypeSignature);

        GrammarParser.accessor_declarations_return accessor_declarations35 = default(GrammarParser.accessor_declarations_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:395:2: ( ( method_specifiers )? type identifier '{' accessor_declarations '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:395:4: ( method_specifiers )? type identifier '{' accessor_declarations '}'
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:395:4: ( method_specifiers )?
            	int alt43 = 2;
            	int LA43_0 = input.LA(1);

            	if ( ((LA43_0 >= KW_ABSTRACT && LA43_0 <= KW_FINAL) || LA43_0 == KW_STATIC || (LA43_0 >= KW_VIRTUAL && LA43_0 <= KW_NEW)) )
            	{
            	    alt43 = 1;
            	}
            	switch (alt43) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:395:4: method_specifiers
            	        {
            	        	PushFollow(FOLLOW_method_specifiers_in_property_declaration913);
            	        	method_specifiers33 = method_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_type_in_property_declaration916);
            	type34 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_property_declaration918);
            	identifier32 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,92,FOLLOW_92_in_property_declaration920); if (state.failed) return value;
            	PushFollow(FOLLOW_accessor_declarations_in_property_declaration922);
            	accessor_declarations35 = accessor_declarations();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,93,FOLLOW_93_in_property_declaration924); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new PropertyDecl(
            	  			((identifier32 != null) ? identifier32.value : default(Identifier)),
            	  			method_specifiers33,
            	  			access_scope.CurrentAccess,
            	  			type34,
            	  			((accessor_declarations35 != null) ? accessor_declarations35.setter : default(BlockStatement)),
            	  			((accessor_declarations35 != null) ? accessor_declarations35.getter : default(BlockStatement))
            	  		);
            	  		CurrentDeclSpace.AddProperty(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "property_declaration"

    public class accessor_declarations_return : ParserRuleReturnScope
    {
        public BlockStatement setter;
        public BlockStatement getter;
    };

    // $ANTLR start "accessor_declarations"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:409:1: accessor_declarations returns [BlockStatement setter, BlockStatement getter] : (a= get_accessor (b= set_accessor )? | c= set_accessor (d= get_accessor )? );
    public GrammarParser.accessor_declarations_return accessor_declarations() // throws RecognitionException [1]
    {   
        GrammarParser.accessor_declarations_return retval = new GrammarParser.accessor_declarations_return();
        retval.Start = input.LT(1);

        BlockStatement a = default(BlockStatement);

        BlockStatement b = default(BlockStatement);

        BlockStatement c = default(BlockStatement);

        BlockStatement d = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:410:2: (a= get_accessor (b= set_accessor )? | c= set_accessor (d= get_accessor )? )
            int alt46 = 2;
            int LA46_0 = input.LA(1);

            if ( (LA46_0 == KW_GET) )
            {
                alt46 = 1;
            }
            else if ( (LA46_0 == KW_SET) )
            {
                alt46 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d46s0 =
                    new NoViableAltException("", 46, 0, input);

                throw nvae_d46s0;
            }
            switch (alt46) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:410:4: a= get_accessor (b= set_accessor )?
                    {
                    	PushFollow(FOLLOW_get_accessor_in_accessor_declarations944);
                    	a = get_accessor();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:410:20: (b= set_accessor )?
                    	int alt44 = 2;
                    	int LA44_0 = input.LA(1);

                    	if ( (LA44_0 == KW_SET) )
                    	{
                    	    alt44 = 1;
                    	}
                    	switch (alt44) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:410:20: b= set_accessor
                    	        {
                    	        	PushFollow(FOLLOW_set_accessor_in_accessor_declarations948);
                    	        	b = set_accessor();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.setter =  b; retval.getter =  a; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:411:4: c= set_accessor (d= get_accessor )?
                    {
                    	PushFollow(FOLLOW_set_accessor_in_accessor_declarations958);
                    	c = set_accessor();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:411:20: (d= get_accessor )?
                    	int alt45 = 2;
                    	int LA45_0 = input.LA(1);

                    	if ( (LA45_0 == KW_GET) )
                    	{
                    	    alt45 = 1;
                    	}
                    	switch (alt45) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:411:20: d= get_accessor
                    	        {
                    	        	PushFollow(FOLLOW_get_accessor_in_accessor_declarations962);
                    	        	d = get_accessor();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.setter =  c; retval.getter =  d; 
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "accessor_declarations"


    // $ANTLR start "get_accessor"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:414:1: get_accessor returns [BlockStatement value] : KW_GET method_block ;
    public BlockStatement get_accessor() // throws RecognitionException [1]
    {   
        BlockStatement value = default(BlockStatement);

        BlockStatement method_block36 = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:415:2: ( KW_GET method_block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:415:4: KW_GET method_block
            {
            	Match(input,KW_GET,FOLLOW_KW_GET_in_get_accessor980); if (state.failed) return value;
            	PushFollow(FOLLOW_method_block_in_get_accessor982);
            	method_block36 = method_block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  method_block36;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "get_accessor"


    // $ANTLR start "set_accessor"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:421:1: set_accessor returns [BlockStatement value] : KW_SET method_block ;
    public BlockStatement set_accessor() // throws RecognitionException [1]
    {   
        BlockStatement value = default(BlockStatement);

        BlockStatement method_block37 = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:422:2: ( KW_SET method_block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:422:4: KW_SET method_block
            {
            	Match(input,KW_SET,FOLLOW_KW_SET_in_set_accessor1000); if (state.failed) return value;
            	PushFollow(FOLLOW_method_block_in_set_accessor1002);
            	method_block37 = method_block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  method_block37;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "set_accessor"


    // $ANTLR start "field_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:428:1: field_declaration returns [FieldDecl value] : ( field_specifiers )? type identifier SEMI ;
    public FieldDecl field_declaration() // throws RecognitionException [1]
    {   
        FieldDecl value = default(FieldDecl);

        GrammarParser.identifier_return identifier38 = default(GrammarParser.identifier_return);

        FieldSpecifier field_specifiers39 = default(FieldSpecifier);

        TypeSignature type40 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:429:2: ( ( field_specifiers )? type identifier SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:429:4: ( field_specifiers )? type identifier SEMI
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:429:4: ( field_specifiers )?
            	int alt47 = 2;
            	int LA47_0 = input.LA(1);

            	if ( (LA47_0 == KW_STATIC) )
            	{
            	    alt47 = 1;
            	}
            	switch (alt47) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:429:4: field_specifiers
            	        {
            	        	PushFollow(FOLLOW_field_specifiers_in_field_declaration1020);
            	        	field_specifiers39 = field_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_type_in_field_declaration1023);
            	type40 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_field_declaration1025);
            	identifier38 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_field_declaration1027); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new FieldDecl(
            	  			((identifier38 != null) ? identifier38.value : default(Identifier)),
            	  			field_specifiers39,
            	  			access_scope.CurrentAccess,
            	  			type40
            	  		);
            	  		CurrentDeclSpace.AddField(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "field_declaration"


    // $ANTLR start "field_specifiers"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:441:1: field_specifiers returns [FieldSpecifier value] : ( field_specifier )+ ;
    public FieldSpecifier field_specifiers() // throws RecognitionException [1]
    {   
        FieldSpecifier value = default(FieldSpecifier);

        GrammarParser.field_specifier_return field_specifier41 = default(GrammarParser.field_specifier_return);



        	value =  new FieldSpecifier();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:445:2: ( ( field_specifier )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:445:4: ( field_specifier )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:445:4: ( field_specifier )+
            	int cnt48 = 0;
            	do 
            	{
            	    int alt48 = 2;
            	    int LA48_0 = input.LA(1);

            	    if ( (LA48_0 == KW_STATIC) )
            	    {
            	        alt48 = 1;
            	    }


            	    switch (alt48) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:445:5: field_specifier
            			    {
            			    	PushFollow(FOLLOW_field_specifier_in_field_specifiers1051);
            			    	field_specifier41 = field_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  		if (value.IsSet(((field_specifier41 != null) ? field_specifier41.value : default(FieldSpecifier))))
            			    	  			Report.Error.DuplicateModifier(GetLocation(((field_specifier41 != null) ? ((IToken)field_specifier41.Start) : null)));
            			    	  		value.Add(((field_specifier41 != null) ? field_specifier41.value : default(FieldSpecifier)));
            			    	  	
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt48 >= 1 ) goto loop48;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee48 =
            		                new EarlyExitException(48, input);
            		            throw eee48;
            	    }
            	    cnt48++;
            	} while (true);

            	loop48:
            		;	// Stops C# compiler whining that label 'loop48' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "field_specifiers"

    public class field_specifier_return : ParserRuleReturnScope
    {
        public FieldSpecifier value;
    };

    // $ANTLR start "field_specifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:453:1: field_specifier returns [FieldSpecifier value] : KW_STATIC ;
    public GrammarParser.field_specifier_return field_specifier() // throws RecognitionException [1]
    {   
        GrammarParser.field_specifier_return retval = new GrammarParser.field_specifier_return();
        retval.Start = input.LT(1);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:454:2: ( KW_STATIC )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:454:4: KW_STATIC
            {
            	Match(input,KW_STATIC,FOLLOW_KW_STATIC_in_field_specifier1072); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{
            	   retval.value =  FieldSpecifier.STATIC; 
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "field_specifier"


    // $ANTLR start "return_type"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:457:1: return_type returns [TypeSignature value] : ( type | KW_VOID );
    public TypeSignature return_type() // throws RecognitionException [1]
    {   
        TypeSignature value = default(TypeSignature);

        TypeSignature type42 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:458:2: ( type | KW_VOID )
            int alt49 = 2;
            int LA49_0 = input.LA(1);

            if ( ((LA49_0 >= ID && LA49_0 <= KW_ULONG)) )
            {
                alt49 = 1;
            }
            else if ( (LA49_0 == KW_VOID) )
            {
                alt49 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d49s0 =
                    new NoViableAltException("", 49, 0, input);

                throw nvae_d49s0;
            }
            switch (alt49) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:458:4: type
                    {
                    	PushFollow(FOLLOW_type_in_return_type1089);
                    	type42 = type();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  type42; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:459:4: KW_VOID
                    {
                    	Match(input,KW_VOID,FOLLOW_KW_VOID_in_return_type1097); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  new ResolvedType(Types.GetType("Void")); 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "return_type"


    // $ANTLR start "method_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:462:1: method_declaration returns [MethodDecl value] : ( method_specifiers )? return_type identifier '(' ( formal_arguments )? ')' ( method_block | SEMI ) ;
    public MethodDecl method_declaration() // throws RecognitionException [1]
    {   
        MethodDecl value = default(MethodDecl);

        GrammarParser.identifier_return identifier43 = default(GrammarParser.identifier_return);

        MethodSpecifier method_specifiers44 = default(MethodSpecifier);

        TypeSignature return_type45 = default(TypeSignature);

        IList<ArgumentDecl> formal_arguments46 = default(IList<ArgumentDecl>);

        BlockStatement method_block47 = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:2: ( ( method_specifiers )? return_type identifier '(' ( formal_arguments )? ')' ( method_block | SEMI ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:4: ( method_specifiers )? return_type identifier '(' ( formal_arguments )? ')' ( method_block | SEMI )
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:4: ( method_specifiers )?
            	int alt50 = 2;
            	int LA50_0 = input.LA(1);

            	if ( ((LA50_0 >= KW_ABSTRACT && LA50_0 <= KW_FINAL) || LA50_0 == KW_STATIC || (LA50_0 >= KW_VIRTUAL && LA50_0 <= KW_NEW)) )
            	{
            	    alt50 = 1;
            	}
            	switch (alt50) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:4: method_specifiers
            	        {
            	        	PushFollow(FOLLOW_method_specifiers_in_method_declaration1114);
            	        	method_specifiers44 = method_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_return_type_in_method_declaration1117);
            	return_type45 = return_type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_method_declaration1119);
            	identifier43 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_method_declaration1121); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:50: ( formal_arguments )?
            	int alt51 = 2;
            	int LA51_0 = input.LA(1);

            	if ( ((LA51_0 >= ID && LA51_0 <= KW_ULONG)) )
            	{
            	    alt51 = 1;
            	}
            	switch (alt51) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:50: formal_arguments
            	        {
            	        	PushFollow(FOLLOW_formal_arguments_in_method_declaration1123);
            	        	formal_arguments46 = formal_arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_method_declaration1126); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:72: ( method_block | SEMI )
            	int alt52 = 2;
            	int LA52_0 = input.LA(1);

            	if ( (LA52_0 == 92) )
            	{
            	    alt52 = 1;
            	}
            	else if ( (LA52_0 == SEMI) )
            	{
            	    alt52 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d52s0 =
            	        new NoViableAltException("", 52, 0, input);

            	    throw nvae_d52s0;
            	}
            	switch (alt52) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:73: method_block
            	        {
            	        	PushFollow(FOLLOW_method_block_in_method_declaration1129);
            	        	method_block47 = method_block();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:463:88: SEMI
            	        {
            	        	Match(input,SEMI,FOLLOW_SEMI_in_method_declaration1133); if (state.failed) return value;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		value =  new MethodDecl(
            	  			((identifier43 != null) ? identifier43.value : default(Identifier)),
            	  			method_specifiers44,
            	  			access_scope.CurrentAccess,
            	  			return_type45,
            	  			formal_arguments46,
            	  			method_block47
            	  		);
            	  		CurrentDeclSpace.AddMethod(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "method_declaration"


    // $ANTLR start "method_signature"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:477:1: method_signature returns [MethodDecl value] : return_type identifier '(' ( formal_arguments )? ')' ;
    public MethodDecl method_signature() // throws RecognitionException [1]
    {   
        MethodDecl value = default(MethodDecl);

        GrammarParser.identifier_return identifier48 = default(GrammarParser.identifier_return);

        TypeSignature return_type49 = default(TypeSignature);

        IList<ArgumentDecl> formal_arguments50 = default(IList<ArgumentDecl>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:478:2: ( return_type identifier '(' ( formal_arguments )? ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:478:4: return_type identifier '(' ( formal_arguments )? ')'
            {
            	PushFollow(FOLLOW_return_type_in_method_signature1153);
            	return_type49 = return_type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_method_signature1155);
            	identifier48 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_method_signature1157); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:478:31: ( formal_arguments )?
            	int alt53 = 2;
            	int LA53_0 = input.LA(1);

            	if ( ((LA53_0 >= ID && LA53_0 <= KW_ULONG)) )
            	{
            	    alt53 = 1;
            	}
            	switch (alt53) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:478:31: formal_arguments
            	        {
            	        	PushFollow(FOLLOW_formal_arguments_in_method_signature1159);
            	        	formal_arguments50 = formal_arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_method_signature1162); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new MethodDecl(
            	  			((identifier48 != null) ? identifier48.value : default(Identifier)),
            	  			MethodSpecifier.ABSTRACT | MethodSpecifier.VIRTUAL,
            	  			access_scope.CurrentAccess,
            	  			return_type49,
            	  			formal_arguments50,
            	  			null
            	  		);
            	  		CurrentDeclSpace.AddMethod(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "method_signature"


    // $ANTLR start "method_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:492:1: method_block returns [BlockStatement value] : block ;
    public BlockStatement method_block() // throws RecognitionException [1]
    {   
        BlockStatement value = default(BlockStatement);

        Statement block51 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:493:2: ( block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:493:4: block
            {
            	PushFollow(FOLLOW_block_in_method_block1180);
            	block51 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  block51 as BlockStatement;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "method_block"


    // $ANTLR start "formal_arguments"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:499:1: formal_arguments returns [IList<ArgumentDecl> value] : head= formal_argument ( COMMA tail= formal_argument )* ;
    public IList<ArgumentDecl> formal_arguments() // throws RecognitionException [1]
    {   
        IList<ArgumentDecl> value = default(IList<ArgumentDecl>);

        ArgumentDecl head = default(ArgumentDecl);

        ArgumentDecl tail = default(ArgumentDecl);



        	value =  new List<ArgumentDecl>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:503:2: (head= formal_argument ( COMMA tail= formal_argument )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:503:4: head= formal_argument ( COMMA tail= formal_argument )*
            {
            	PushFollow(FOLLOW_formal_argument_in_formal_arguments1205);
            	head = formal_argument();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value.Add(head); 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:504:2: ( COMMA tail= formal_argument )*
            	do 
            	{
            	    int alt54 = 2;
            	    int LA54_0 = input.LA(1);

            	    if ( (LA54_0 == COMMA) )
            	    {
            	        alt54 = 1;
            	    }


            	    switch (alt54) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:504:3: COMMA tail= formal_argument
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_formal_arguments1211); if (state.failed) return value;
            			    	PushFollow(FOLLOW_formal_argument_in_formal_arguments1215);
            			    	tail = formal_argument();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(tail); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop54;
            	    }
            	} while (true);

            	loop54:
            		;	// Stops C# compiler whining that label 'loop54' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "formal_arguments"


    // $ANTLR start "formal_argument"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:507:1: formal_argument returns [ArgumentDecl value] : type identifier ;
    public ArgumentDecl formal_argument() // throws RecognitionException [1]
    {   
        ArgumentDecl value = default(ArgumentDecl);

        GrammarParser.identifier_return identifier52 = default(GrammarParser.identifier_return);

        TypeSignature type53 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:508:2: ( type identifier )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:508:4: type identifier
            {
            	PushFollow(FOLLOW_type_in_formal_argument1235);
            	type53 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_formal_argument1237);
            	identifier52 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new ArgumentDecl(((identifier52 != null) ? identifier52.value : default(Identifier)), type53);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "formal_argument"


    // $ANTLR start "method_specifiers"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:514:1: method_specifiers returns [MethodSpecifier value] : ( method_specifier )+ ;
    public MethodSpecifier method_specifiers() // throws RecognitionException [1]
    {   
        MethodSpecifier value = default(MethodSpecifier);

        GrammarParser.method_specifier_return method_specifier54 = default(GrammarParser.method_specifier_return);



        	value =  new MethodSpecifier();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:518:2: ( ( method_specifier )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:518:4: ( method_specifier )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:518:4: ( method_specifier )+
            	int cnt55 = 0;
            	do 
            	{
            	    int alt55 = 2;
            	    int LA55_0 = input.LA(1);

            	    if ( ((LA55_0 >= KW_ABSTRACT && LA55_0 <= KW_FINAL) || LA55_0 == KW_STATIC || (LA55_0 >= KW_VIRTUAL && LA55_0 <= KW_NEW)) )
            	    {
            	        alt55 = 1;
            	    }


            	    switch (alt55) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:518:5: method_specifier
            			    {
            			    	PushFollow(FOLLOW_method_specifier_in_method_specifiers1261);
            			    	method_specifier54 = method_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  		if (value.IsSet(((method_specifier54 != null) ? method_specifier54.value : default(MethodSpecifier))))
            			    	  			Report.Error.DuplicateModifier(GetLocation(((method_specifier54 != null) ? ((IToken)method_specifier54.Start) : null)));
            			    	  		value.Add(((method_specifier54 != null) ? method_specifier54.value : default(MethodSpecifier)));
            			    	  	
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt55 >= 1 ) goto loop55;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee55 =
            		                new EarlyExitException(55, input);
            		            throw eee55;
            	    }
            	    cnt55++;
            	} while (true);

            	loop55:
            		;	// Stops C# compiler whining that label 'loop55' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "method_specifiers"

    public class method_specifier_return : ParserRuleReturnScope
    {
        public MethodSpecifier value;
    };

    // $ANTLR start "method_specifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:526:1: method_specifier returns [MethodSpecifier value] : ( KW_ABSTRACT | KW_FINAL | KW_STATIC | KW_VIRTUAL | KW_NEW );
    public GrammarParser.method_specifier_return method_specifier() // throws RecognitionException [1]
    {   
        GrammarParser.method_specifier_return retval = new GrammarParser.method_specifier_return();
        retval.Start = input.LT(1);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:527:2: ( KW_ABSTRACT | KW_FINAL | KW_STATIC | KW_VIRTUAL | KW_NEW )
            int alt56 = 5;
            switch ( input.LA(1) ) 
            {
            case KW_ABSTRACT:
            	{
                alt56 = 1;
                }
                break;
            case KW_FINAL:
            	{
                alt56 = 2;
                }
                break;
            case KW_STATIC:
            	{
                alt56 = 3;
                }
                break;
            case KW_VIRTUAL:
            	{
                alt56 = 4;
                }
                break;
            case KW_NEW:
            	{
                alt56 = 5;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d56s0 =
            	        new NoViableAltException("", 56, 0, input);

            	    throw nvae_d56s0;
            }

            switch (alt56) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:527:4: KW_ABSTRACT
                    {
                    	Match(input,KW_ABSTRACT,FOLLOW_KW_ABSTRACT_in_method_specifier1282); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  MethodSpecifier.ABSTRACT; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:528:4: KW_FINAL
                    {
                    	Match(input,KW_FINAL,FOLLOW_KW_FINAL_in_method_specifier1289); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  MethodSpecifier.FINAL; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:529:4: KW_STATIC
                    {
                    	Match(input,KW_STATIC,FOLLOW_KW_STATIC_in_method_specifier1297); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  MethodSpecifier.STATIC; 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:530:4: KW_VIRTUAL
                    {
                    	Match(input,KW_VIRTUAL,FOLLOW_KW_VIRTUAL_in_method_specifier1305); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  MethodSpecifier.VIRTUAL; 
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:531:4: KW_NEW
                    {
                    	Match(input,KW_NEW,FOLLOW_KW_NEW_in_method_specifier1312); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  MethodSpecifier.NEW; 
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "method_specifier"


    // $ANTLR start "constructor_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:534:1: constructor_declaration returns [CtorDecl value] : KW_THIS '(' ( formal_arguments )? ')' ( constructor_initializer )? constructor_block ;
    public CtorDecl constructor_declaration() // throws RecognitionException [1]
    {   
        CtorDecl value = default(CtorDecl);

        IList<ArgumentDecl> formal_arguments55 = default(IList<ArgumentDecl>);

        BlockStatement constructor_block56 = default(BlockStatement);

        MethodCallExpression constructor_initializer57 = default(MethodCallExpression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:2: ( KW_THIS '(' ( formal_arguments )? ')' ( constructor_initializer )? constructor_block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:4: KW_THIS '(' ( formal_arguments )? ')' ( constructor_initializer )? constructor_block
            {
            	Match(input,KW_THIS,FOLLOW_KW_THIS_in_constructor_declaration1330); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_constructor_declaration1332); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:16: ( formal_arguments )?
            	int alt57 = 2;
            	int LA57_0 = input.LA(1);

            	if ( ((LA57_0 >= ID && LA57_0 <= KW_ULONG)) )
            	{
            	    alt57 = 1;
            	}
            	switch (alt57) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:16: formal_arguments
            	        {
            	        	PushFollow(FOLLOW_formal_arguments_in_constructor_declaration1334);
            	        	formal_arguments55 = formal_arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_constructor_declaration1337); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:38: ( constructor_initializer )?
            	int alt58 = 2;
            	int LA58_0 = input.LA(1);

            	if ( (LA58_0 == 96) )
            	{
            	    alt58 = 1;
            	}
            	switch (alt58) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:535:38: constructor_initializer
            	        {
            	        	PushFollow(FOLLOW_constructor_initializer_in_constructor_declaration1339);
            	        	constructor_initializer57 = constructor_initializer();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_constructor_block_in_constructor_declaration1342);
            	constructor_block56 = constructor_block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new CtorDecl(
            	  			access_scope.CurrentAccess,
            	  			MethodSpecifier.CONSTRUCTOR,
            	  			formal_arguments55,
            	  			constructor_block56,
            	  			constructor_initializer57
            	  		);
            	  		CurrentDeclSpace.AddMethod(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "constructor_declaration"


    // $ANTLR start "constructor_initializer"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:548:1: constructor_initializer returns [MethodCallExpression value] : ':' (e= KW_THIS | e= KW_BASE ) '(' ( expressions_list )? ')' ;
    public MethodCallExpression constructor_initializer() // throws RecognitionException [1]
    {   
        MethodCallExpression value = default(MethodCallExpression);

        IToken e = null;
        IList<Expression> expressions_list58 = default(IList<Expression>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:2: ( ':' (e= KW_THIS | e= KW_BASE ) '(' ( expressions_list )? ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:4: ':' (e= KW_THIS | e= KW_BASE ) '(' ( expressions_list )? ')'
            {
            	Match(input,96,FOLLOW_96_in_constructor_initializer1360); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:8: (e= KW_THIS | e= KW_BASE )
            	int alt59 = 2;
            	int LA59_0 = input.LA(1);

            	if ( (LA59_0 == KW_THIS) )
            	{
            	    alt59 = 1;
            	}
            	else if ( (LA59_0 == KW_BASE) )
            	{
            	    alt59 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d59s0 =
            	        new NoViableAltException("", 59, 0, input);

            	    throw nvae_d59s0;
            	}
            	switch (alt59) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:9: e= KW_THIS
            	        {
            	        	e=(IToken)Match(input,KW_THIS,FOLLOW_KW_THIS_in_constructor_initializer1365); if (state.failed) return value;

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:21: e= KW_BASE
            	        {
            	        	e=(IToken)Match(input,KW_BASE,FOLLOW_KW_BASE_in_constructor_initializer1371); if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,94,FOLLOW_94_in_constructor_initializer1374); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:36: ( expressions_list )?
            	int alt60 = 2;
            	int LA60_0 = input.LA(1);

            	if ( ((LA60_0 >= KW_NEW && LA60_0 <= KW_BASE) || (LA60_0 >= KW_GLOBAL && LA60_0 <= KW_TYPEOF) || LA60_0 == ID || (LA60_0 >= LITERAL_INTEGER && LA60_0 <= KW_NULL) || LA60_0 == 94 || (LA60_0 >= 111 && LA60_0 <= 112) || (LA60_0 >= 126 && LA60_0 <= 129)) )
            	{
            	    alt60 = 1;
            	}
            	switch (alt60) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:549:36: expressions_list
            	        {
            	        	PushFollow(FOLLOW_expressions_list_in_constructor_initializer1376);
            	        	expressions_list58 = expressions_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_constructor_initializer1379); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new MethodCallExpression(
            	  			new AnyExpression(e.Text),
            	  			new Identifier(MethodSymbol.CTOR),
            	  			expressions_list58
            	  		);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "constructor_initializer"


    // $ANTLR start "constructor_block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:559:1: constructor_block returns [BlockStatement value] : block ;
    public BlockStatement constructor_block() // throws RecognitionException [1]
    {   
        BlockStatement value = default(BlockStatement);

        Statement block59 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:560:2: ( block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:560:4: block
            {
            	PushFollow(FOLLOW_block_in_constructor_block1397);
            	block59 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  block59 as BlockStatement;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "constructor_block"


    // $ANTLR start "static_constructor_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:566:1: static_constructor_declaration returns [CCtorDecl value] : KW_STATIC KW_THIS '(' ')' static_constructor_body ;
    public CCtorDecl static_constructor_declaration() // throws RecognitionException [1]
    {   
        CCtorDecl value = default(CCtorDecl);

        BlockStatement static_constructor_body60 = default(BlockStatement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:567:2: ( KW_STATIC KW_THIS '(' ')' static_constructor_body )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:567:4: KW_STATIC KW_THIS '(' ')' static_constructor_body
            {
            	Match(input,KW_STATIC,FOLLOW_KW_STATIC_in_static_constructor_declaration1415); if (state.failed) return value;
            	Match(input,KW_THIS,FOLLOW_KW_THIS_in_static_constructor_declaration1417); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_static_constructor_declaration1419); if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_static_constructor_declaration1421); if (state.failed) return value;
            	PushFollow(FOLLOW_static_constructor_body_in_static_constructor_declaration1423);
            	static_constructor_body60 = static_constructor_body();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new CCtorDecl(static_constructor_body60);
            	  		CurrentDeclSpace.AddMethod(value);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "static_constructor_declaration"


    // $ANTLR start "static_constructor_body"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:574:1: static_constructor_body returns [BlockStatement value] : block ;
    public BlockStatement static_constructor_body() // throws RecognitionException [1]
    {   
        BlockStatement value = default(BlockStatement);

        Statement block61 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:575:2: ( block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:575:4: block
            {
            	PushFollow(FOLLOW_block_in_static_constructor_body1441);
            	block61 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  block61 as BlockStatement;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "static_constructor_body"


    // $ANTLR start "statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:581:1: statement returns [Statement value] : ( embedded_statement | declaration_statement | labeled_statement );
    public Statement statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Statement embedded_statement62 = default(Statement);

        Statement declaration_statement63 = default(Statement);

        Statement labeled_statement64 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:585:2: ( embedded_statement | declaration_statement | labeled_statement )
            int alt61 = 3;
            alt61 = dfa61.Predict(input);
            switch (alt61) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:585:4: embedded_statement
                    {
                    	PushFollow(FOLLOW_embedded_statement_in_statement1461);
                    	embedded_statement62 = embedded_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  embedded_statement62; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:586:4: declaration_statement
                    {
                    	PushFollow(FOLLOW_declaration_statement_in_statement1469);
                    	declaration_statement63 = declaration_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  declaration_statement63; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:587:4: labeled_statement
                    {
                    	PushFollow(FOLLOW_labeled_statement_in_statement1477);
                    	labeled_statement64 = labeled_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  labeled_statement64; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "statement"


    // $ANTLR start "statements"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:590:1: statements returns [IList<Statement> value] : ( statement )+ ;
    public IList<Statement> statements() // throws RecognitionException [1]
    {   
        IList<Statement> value = default(IList<Statement>);

        Statement statement65 = default(Statement);



        	value =  new List<Statement>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:594:2: ( ( statement )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:594:4: ( statement )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:594:4: ( statement )+
            	int cnt62 = 0;
            	do 
            	{
            	    int alt62 = 2;
            	    int LA62_0 = input.LA(1);

            	    if ( (LA62_0 == SEMI || (LA62_0 >= KW_NEW && LA62_0 <= KW_IF) || (LA62_0 >= KW_FOR && LA62_0 <= KW_TRY) || LA62_0 == KW_THROW || (LA62_0 >= KW_GLOBAL && LA62_0 <= KW_TYPEOF) || (LA62_0 >= ID && LA62_0 <= KW_NULL) || LA62_0 == 92 || LA62_0 == 94 || (LA62_0 >= 111 && LA62_0 <= 112) || (LA62_0 >= 126 && LA62_0 <= 129)) )
            	    {
            	        alt62 = 1;
            	    }


            	    switch (alt62) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:594:5: statement
            			    {
            			    	PushFollow(FOLLOW_statement_in_statements1502);
            			    	statement65 = statement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(statement65); 
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt62 >= 1 ) goto loop62;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee62 =
            		                new EarlyExitException(62, input);
            		            throw eee62;
            	    }
            	    cnt62++;
            	} while (true);

            	loop62:
            		;	// Stops C# compiler whining that label 'loop62' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "statements"


    // $ANTLR start "block"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:597:1: block returns [Statement value] : '{' ( statements )? '}' ;
    public Statement block() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        IList<Statement> statements66 = default(IList<Statement>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:598:2: ( '{' ( statements )? '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:598:4: '{' ( statements )? '}'
            {
            	Match(input,92,FOLLOW_92_in_block1522); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:598:8: ( statements )?
            	int alt63 = 2;
            	int LA63_0 = input.LA(1);

            	if ( (LA63_0 == SEMI || (LA63_0 >= KW_NEW && LA63_0 <= KW_IF) || (LA63_0 >= KW_FOR && LA63_0 <= KW_TRY) || LA63_0 == KW_THROW || (LA63_0 >= KW_GLOBAL && LA63_0 <= KW_TYPEOF) || (LA63_0 >= ID && LA63_0 <= KW_NULL) || LA63_0 == 92 || LA63_0 == 94 || (LA63_0 >= 111 && LA63_0 <= 112) || (LA63_0 >= 126 && LA63_0 <= 129)) )
            	{
            	    alt63 = 1;
            	}
            	switch (alt63) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:598:8: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_block1524);
            	        	statements66 = statements();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,93,FOLLOW_93_in_block1527); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new BlockStatement(statements66);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "block"


    // $ANTLR start "labeled_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:604:1: labeled_statement returns [Statement value] : identifier ':' statement ;
    public Statement labeled_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        GrammarParser.identifier_return identifier67 = default(GrammarParser.identifier_return);

        Statement statement68 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:605:2: ( identifier ':' statement )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:605:4: identifier ':' statement
            {
            	PushFollow(FOLLOW_identifier_in_labeled_statement1545);
            	identifier67 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,96,FOLLOW_96_in_labeled_statement1547); if (state.failed) return value;
            	PushFollow(FOLLOW_statement_in_labeled_statement1549);
            	statement68 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new LabeledStatement(((identifier67 != null) ? identifier67.value : default(Identifier)), statement68);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "labeled_statement"


    // $ANTLR start "declaration_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:611:1: declaration_statement returns [Statement value] : variable_declaration_statement ;
    public Statement declaration_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Statement variable_declaration_statement69 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:612:2: ( variable_declaration_statement )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:612:4: variable_declaration_statement
            {
            	PushFollow(FOLLOW_variable_declaration_statement_in_declaration_statement1567);
            	variable_declaration_statement69 = variable_declaration_statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  variable_declaration_statement69;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "declaration_statement"


    // $ANTLR start "variable_declaration_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:618:1: variable_declaration_statement returns [Statement value] : local_declaration SEMI ;
    public Statement variable_declaration_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        GrammarParser.local_declaration_return local_declaration70 = default(GrammarParser.local_declaration_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:619:2: ( local_declaration SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:619:4: local_declaration SEMI
            {
            	PushFollow(FOLLOW_local_declaration_in_variable_declaration_statement1585);
            	local_declaration70 = local_declaration();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_variable_declaration_statement1587); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new LocalDeclStatement(((local_declaration70 != null) ? local_declaration70.value : default(LocalDecl)));
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "variable_declaration_statement"

    public class local_declaration_return : ParserRuleReturnScope
    {
        public LocalDecl value;
    };

    // $ANTLR start "local_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:625:1: local_declaration returns [LocalDecl value] : ( type variable_declarators | KW_VAR variable_declarators );
    public GrammarParser.local_declaration_return local_declaration() // throws RecognitionException [1]
    {   
        GrammarParser.local_declaration_return retval = new GrammarParser.local_declaration_return();
        retval.Start = input.LT(1);

        TypeSignature type71 = default(TypeSignature);

        IList<VariableDeclarator> variable_declarators72 = default(IList<VariableDeclarator>);

        IList<VariableDeclarator> variable_declarators73 = default(IList<VariableDeclarator>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:626:2: ( type variable_declarators | KW_VAR variable_declarators )
            int alt64 = 2;
            int LA64_0 = input.LA(1);

            if ( ((LA64_0 >= ID && LA64_0 <= KW_ULONG)) )
            {
                alt64 = 1;
            }
            else if ( (LA64_0 == KW_VAR) )
            {
                alt64 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d64s0 =
                    new NoViableAltException("", 64, 0, input);

                throw nvae_d64s0;
            }
            switch (alt64) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:626:4: type variable_declarators
                    {
                    	PushFollow(FOLLOW_type_in_local_declaration1605);
                    	type71 = type();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	PushFollow(FOLLOW_variable_declarators_in_local_declaration1607);
                    	variable_declarators72 = variable_declarators();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new ExplicitlyTypedLocalDecl(type71, variable_declarators72, GetLocation(((IToken)retval.Start)));
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:630:4: KW_VAR variable_declarators
                    {
                    	Match(input,KW_VAR,FOLLOW_KW_VAR_in_local_declaration1615); if (state.failed) return retval;
                    	PushFollow(FOLLOW_variable_declarators_in_local_declaration1617);
                    	variable_declarators73 = variable_declarators();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		if (variable_declarators73.Count > 1)
                    	  			Report.Error.VarLocalMultipleDeclarators(GetLocation(((IToken)retval.Start)));
                    	  		retval.value =  new ImplicitlyTypedLocalDecl(variable_declarators73[0], GetLocation(((IToken)retval.Start)));
                    	  	
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "local_declaration"


    // $ANTLR start "variable_declarators"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:638:1: variable_declarators returns [IList<VariableDeclarator> value] : head= variable_declarator ( COMMA tail= variable_declarator )* ;
    public IList<VariableDeclarator> variable_declarators() // throws RecognitionException [1]
    {   
        IList<VariableDeclarator> value = default(IList<VariableDeclarator>);

        VariableDeclarator head = default(VariableDeclarator);

        VariableDeclarator tail = default(VariableDeclarator);



        	value =  new List<VariableDeclarator>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:642:2: (head= variable_declarator ( COMMA tail= variable_declarator )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:642:4: head= variable_declarator ( COMMA tail= variable_declarator )*
            {
            	PushFollow(FOLLOW_variable_declarator_in_variable_declarators1642);
            	head = variable_declarator();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value.Add(head); 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:643:2: ( COMMA tail= variable_declarator )*
            	do 
            	{
            	    int alt65 = 2;
            	    int LA65_0 = input.LA(1);

            	    if ( (LA65_0 == COMMA) )
            	    {
            	        alt65 = 1;
            	    }


            	    switch (alt65) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:643:3: COMMA tail= variable_declarator
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_variable_declarators1648); if (state.failed) return value;
            			    	PushFollow(FOLLOW_variable_declarator_in_variable_declarators1652);
            			    	tail = variable_declarator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(tail); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop65;
            	    }
            	} while (true);

            	loop65:
            		;	// Stops C# compiler whining that label 'loop65' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "variable_declarators"


    // $ANTLR start "variable_declarator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:646:1: variable_declarator returns [VariableDeclarator value] : identifier ( '=' expression )? ;
    public VariableDeclarator variable_declarator() // throws RecognitionException [1]
    {   
        VariableDeclarator value = default(VariableDeclarator);

        GrammarParser.identifier_return identifier74 = default(GrammarParser.identifier_return);

        Expression expression75 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:647:2: ( identifier ( '=' expression )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:647:4: identifier ( '=' expression )?
            {
            	PushFollow(FOLLOW_identifier_in_variable_declarator1672);
            	identifier74 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:647:15: ( '=' expression )?
            	int alt66 = 2;
            	int LA66_0 = input.LA(1);

            	if ( (LA66_0 == 91) )
            	{
            	    alt66 = 1;
            	}
            	switch (alt66) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:647:16: '=' expression
            	        {
            	        	Match(input,91,FOLLOW_91_in_variable_declarator1675); if (state.failed) return value;
            	        	PushFollow(FOLLOW_expression_in_variable_declarator1677);
            	        	expression75 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		value =  new VariableDeclarator(((identifier74 != null) ? identifier74.value : default(Identifier)), expression75);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "variable_declarator"


    // $ANTLR start "embedded_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:653:1: embedded_statement returns [Statement value] : ( block | expression_statement | if_statement | loop_statement | jump_statement | try_statement | throw_statement | empty_statement );
    public Statement embedded_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Statement block76 = default(Statement);

        Statement expression_statement77 = default(Statement);

        Statement if_statement78 = default(Statement);

        Statement loop_statement79 = default(Statement);

        Statement jump_statement80 = default(Statement);

        Statement try_statement81 = default(Statement);

        GrammarParser.throw_statement_return throw_statement82 = default(GrammarParser.throw_statement_return);

        Statement empty_statement83 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:654:2: ( block | expression_statement | if_statement | loop_statement | jump_statement | try_statement | throw_statement | empty_statement )
            int alt67 = 8;
            switch ( input.LA(1) ) 
            {
            case 92:
            	{
                alt67 = 1;
                }
                break;
            case KW_NEW:
            case KW_THIS:
            case KW_BASE:
            case KW_GLOBAL:
            case KW_TYPEOF:
            case ID:
            case LITERAL_INTEGER:
            case LITERAL_REAL:
            case LITERAL_CHAR:
            case LITERAL_STRING:
            case KW_TRUE:
            case KW_FALSE:
            case KW_NULL:
            case 94:
            case 111:
            case 112:
            case 126:
            case 127:
            case 128:
            case 129:
            	{
                alt67 = 2;
                }
                break;
            case KW_IF:
            	{
                alt67 = 3;
                }
                break;
            case KW_FOR:
            case KW_WHILE:
            case KW_DO:
            	{
                alt67 = 4;
                }
                break;
            case KW_GOTO:
            case KW_BREAK:
            case KW_CONTINUE:
            case KW_RETURN:
            	{
                alt67 = 5;
                }
                break;
            case KW_TRY:
            	{
                alt67 = 6;
                }
                break;
            case KW_THROW:
            	{
                alt67 = 7;
                }
                break;
            case SEMI:
            	{
                alt67 = 8;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d67s0 =
            	        new NoViableAltException("", 67, 0, input);

            	    throw nvae_d67s0;
            }

            switch (alt67) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:654:4: block
                    {
                    	PushFollow(FOLLOW_block_in_embedded_statement1697);
                    	block76 = block();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  block76; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:655:4: expression_statement
                    {
                    	PushFollow(FOLLOW_expression_statement_in_embedded_statement1708);
                    	expression_statement77 = expression_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  expression_statement77; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:656:4: if_statement
                    {
                    	PushFollow(FOLLOW_if_statement_in_embedded_statement1715);
                    	if_statement78 = if_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  if_statement78; 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:657:4: loop_statement
                    {
                    	PushFollow(FOLLOW_loop_statement_in_embedded_statement1724);
                    	loop_statement79 = loop_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  loop_statement79; 
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:658:4: jump_statement
                    {
                    	PushFollow(FOLLOW_jump_statement_in_embedded_statement1732);
                    	jump_statement80 = jump_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  jump_statement80; 
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:659:4: try_statement
                    {
                    	PushFollow(FOLLOW_try_statement_in_embedded_statement1740);
                    	try_statement81 = try_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  try_statement81; 
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:660:4: throw_statement
                    {
                    	PushFollow(FOLLOW_throw_statement_in_embedded_statement1749);
                    	throw_statement82 = throw_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  ((throw_statement82 != null) ? throw_statement82.value : default(Statement)); 
                    	}

                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:661:4: empty_statement
                    {
                    	PushFollow(FOLLOW_empty_statement_in_embedded_statement1757);
                    	empty_statement83 = empty_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  empty_statement83; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "embedded_statement"


    // $ANTLR start "if_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:664:1: if_statement returns [Statement value] : KW_IF '(' expression ')' embedded_statement ( else_statement )? ;
    public Statement if_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Expression expression84 = default(Expression);

        Statement embedded_statement85 = default(Statement);

        Statement else_statement86 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:665:2: ( KW_IF '(' expression ')' embedded_statement ( else_statement )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:665:4: KW_IF '(' expression ')' embedded_statement ( else_statement )?
            {
            	Match(input,KW_IF,FOLLOW_KW_IF_in_if_statement1775); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_if_statement1777); if (state.failed) return value;
            	PushFollow(FOLLOW_expression_in_if_statement1779);
            	expression84 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_if_statement1781); if (state.failed) return value;
            	PushFollow(FOLLOW_embedded_statement_in_if_statement1783);
            	embedded_statement85 = embedded_statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:665:48: ( else_statement )?
            	int alt68 = 2;
            	int LA68_0 = input.LA(1);

            	if ( (LA68_0 == KW_ELSE) )
            	{
            	    alt68 = 1;
            	}
            	switch (alt68) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:665:48: else_statement
            	        {
            	        	PushFollow(FOLLOW_else_statement_in_if_statement1785);
            	        	else_statement86 = else_statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	if ( (state.backtracking==0) )
            	{

            	  		value =  new IfStatement(
            	  			expression84,
            	  			embedded_statement85,
            	  			else_statement86
            	  		);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "if_statement"


    // $ANTLR start "else_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:675:1: else_statement returns [Statement value] : KW_ELSE embedded_statement ;
    public Statement else_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Statement embedded_statement87 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:676:2: ( KW_ELSE embedded_statement )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:676:4: KW_ELSE embedded_statement
            {
            	Match(input,KW_ELSE,FOLLOW_KW_ELSE_in_else_statement1804); if (state.failed) return value;
            	PushFollow(FOLLOW_embedded_statement_in_else_statement1806);
            	embedded_statement87 = embedded_statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  embedded_statement87;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "else_statement"


    // $ANTLR start "loop_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:682:1: loop_statement returns [Statement value] : ( for_statement | while_statement | do_statement );
    public Statement loop_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        GrammarParser.for_statement_return for_statement88 = default(GrammarParser.for_statement_return);

        Statement while_statement89 = default(Statement);

        Statement do_statement90 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:683:2: ( for_statement | while_statement | do_statement )
            int alt69 = 3;
            switch ( input.LA(1) ) 
            {
            case KW_FOR:
            	{
                alt69 = 1;
                }
                break;
            case KW_WHILE:
            	{
                alt69 = 2;
                }
                break;
            case KW_DO:
            	{
                alt69 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d69s0 =
            	        new NoViableAltException("", 69, 0, input);

            	    throw nvae_d69s0;
            }

            switch (alt69) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:683:4: for_statement
                    {
                    	PushFollow(FOLLOW_for_statement_in_loop_statement1824);
                    	for_statement88 = for_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  ((for_statement88 != null) ? for_statement88.value : default(Statement)); 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:684:4: while_statement
                    {
                    	PushFollow(FOLLOW_while_statement_in_loop_statement1833);
                    	while_statement89 = while_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  while_statement89; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:685:4: do_statement
                    {
                    	PushFollow(FOLLOW_do_statement_in_loop_statement1841);
                    	do_statement90 = do_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  do_statement90; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "loop_statement"

    public class for_statement_return : ParserRuleReturnScope
    {
        public Statement value;
    };

    // $ANTLR start "for_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:689:1: for_statement returns [Statement value] : ( KW_FOR '(' (init= expression )? SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement | KW_FOR '(' decl= local_declaration SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement );
    public GrammarParser.for_statement_return for_statement() // throws RecognitionException [1]
    {   
        GrammarParser.for_statement_return retval = new GrammarParser.for_statement_return();
        retval.Start = input.LT(1);

        Expression init = default(Expression);

        Expression cond = default(Expression);

        Expression iter = default(Expression);

        GrammarParser.local_declaration_return decl = default(GrammarParser.local_declaration_return);

        Statement embedded_statement91 = default(Statement);

        Statement embedded_statement92 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:2: ( KW_FOR '(' (init= expression )? SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement | KW_FOR '(' decl= local_declaration SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement )
            int alt75 = 2;
            alt75 = dfa75.Predict(input);
            switch (alt75) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:4: KW_FOR '(' (init= expression )? SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement
                    {
                    	Match(input,KW_FOR,FOLLOW_KW_FOR_in_for_statement1862); if (state.failed) return retval;
                    	Match(input,94,FOLLOW_94_in_for_statement1864); if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:19: (init= expression )?
                    	int alt70 = 2;
                    	int LA70_0 = input.LA(1);

                    	if ( ((LA70_0 >= KW_NEW && LA70_0 <= KW_BASE) || (LA70_0 >= KW_GLOBAL && LA70_0 <= KW_TYPEOF) || LA70_0 == ID || (LA70_0 >= LITERAL_INTEGER && LA70_0 <= KW_NULL) || LA70_0 == 94 || (LA70_0 >= 111 && LA70_0 <= 112) || (LA70_0 >= 126 && LA70_0 <= 129)) )
                    	{
                    	    alt70 = 1;
                    	}
                    	switch (alt70) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:19: init= expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_for_statement1868);
                    	        	init = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	Match(input,SEMI,FOLLOW_SEMI_in_for_statement1871); if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:41: (cond= expression )?
                    	int alt71 = 2;
                    	int LA71_0 = input.LA(1);

                    	if ( ((LA71_0 >= KW_NEW && LA71_0 <= KW_BASE) || (LA71_0 >= KW_GLOBAL && LA71_0 <= KW_TYPEOF) || LA71_0 == ID || (LA71_0 >= LITERAL_INTEGER && LA71_0 <= KW_NULL) || LA71_0 == 94 || (LA71_0 >= 111 && LA71_0 <= 112) || (LA71_0 >= 126 && LA71_0 <= 129)) )
                    	{
                    	    alt71 = 1;
                    	}
                    	switch (alt71) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:41: cond= expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_for_statement1875);
                    	        	cond = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	Match(input,SEMI,FOLLOW_SEMI_in_for_statement1878); if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:63: (iter= expression )?
                    	int alt72 = 2;
                    	int LA72_0 = input.LA(1);

                    	if ( ((LA72_0 >= KW_NEW && LA72_0 <= KW_BASE) || (LA72_0 >= KW_GLOBAL && LA72_0 <= KW_TYPEOF) || LA72_0 == ID || (LA72_0 >= LITERAL_INTEGER && LA72_0 <= KW_NULL) || LA72_0 == 94 || (LA72_0 >= 111 && LA72_0 <= 112) || (LA72_0 >= 126 && LA72_0 <= 129)) )
                    	{
                    	    alt72 = 1;
                    	}
                    	switch (alt72) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:690:63: iter= expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_for_statement1882);
                    	        	iter = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	Match(input,95,FOLLOW_95_in_for_statement1885); if (state.failed) return retval;
                    	PushFollow(FOLLOW_embedded_statement_in_for_statement1887);
                    	embedded_statement91 = embedded_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		if (init != null && !(init is StatementExpression))
                    	  			Report.Error.InvalidStatement(GetLocation(((IToken)retval.Start)));

                    	  		if (iter != null && !(iter is StatementExpression))
                    	  			Report.Error.InvalidStatement(GetLocation(((IToken)retval.Start)));

                    	  		retval.value =  new ForStatement(
                    	  			(StatementExpression)init,
                    	  			cond,
                    	  			(StatementExpression)iter,
                    	  			embedded_statement91
                    	  		);
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:706:4: KW_FOR '(' decl= local_declaration SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement
                    {
                    	Match(input,KW_FOR,FOLLOW_KW_FOR_in_for_statement1896); if (state.failed) return retval;
                    	Match(input,94,FOLLOW_94_in_for_statement1898); if (state.failed) return retval;
                    	PushFollow(FOLLOW_local_declaration_in_for_statement1902);
                    	decl = local_declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	Match(input,SEMI,FOLLOW_SEMI_in_for_statement1904); if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:706:47: (cond= expression )?
                    	int alt73 = 2;
                    	int LA73_0 = input.LA(1);

                    	if ( ((LA73_0 >= KW_NEW && LA73_0 <= KW_BASE) || (LA73_0 >= KW_GLOBAL && LA73_0 <= KW_TYPEOF) || LA73_0 == ID || (LA73_0 >= LITERAL_INTEGER && LA73_0 <= KW_NULL) || LA73_0 == 94 || (LA73_0 >= 111 && LA73_0 <= 112) || (LA73_0 >= 126 && LA73_0 <= 129)) )
                    	{
                    	    alt73 = 1;
                    	}
                    	switch (alt73) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:706:47: cond= expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_for_statement1908);
                    	        	cond = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	Match(input,SEMI,FOLLOW_SEMI_in_for_statement1911); if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:706:69: (iter= expression )?
                    	int alt74 = 2;
                    	int LA74_0 = input.LA(1);

                    	if ( ((LA74_0 >= KW_NEW && LA74_0 <= KW_BASE) || (LA74_0 >= KW_GLOBAL && LA74_0 <= KW_TYPEOF) || LA74_0 == ID || (LA74_0 >= LITERAL_INTEGER && LA74_0 <= KW_NULL) || LA74_0 == 94 || (LA74_0 >= 111 && LA74_0 <= 112) || (LA74_0 >= 126 && LA74_0 <= 129)) )
                    	{
                    	    alt74 = 1;
                    	}
                    	switch (alt74) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:706:69: iter= expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_for_statement1915);
                    	        	iter = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;

                    	        }
                    	        break;

                    	}

                    	Match(input,95,FOLLOW_95_in_for_statement1918); if (state.failed) return retval;
                    	PushFollow(FOLLOW_embedded_statement_in_for_statement1920);
                    	embedded_statement92 = embedded_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		if (iter != null && !(iter is StatementExpression))
                    	  			Report.Error.InvalidStatement(GetLocation(((IToken)retval.Start)));
                    	  		
                    	  		retval.value =  new ForStatement(
                    	  			((decl != null) ? decl.value : default(LocalDecl)),
                    	  			cond,
                    	  			(StatementExpression)iter,
                    	  			embedded_statement92
                    	  		);
                    	  	
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "for_statement"


    // $ANTLR start "while_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:729:1: while_statement returns [Statement value] : KW_WHILE '(' expression ')' embedded_statement ;
    public Statement while_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Expression expression93 = default(Expression);

        Statement embedded_statement94 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:730:2: ( KW_WHILE '(' expression ')' embedded_statement )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:730:4: KW_WHILE '(' expression ')' embedded_statement
            {
            	Match(input,KW_WHILE,FOLLOW_KW_WHILE_in_while_statement1941); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_while_statement1943); if (state.failed) return value;
            	PushFollow(FOLLOW_expression_in_while_statement1945);
            	expression93 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_while_statement1947); if (state.failed) return value;
            	PushFollow(FOLLOW_embedded_statement_in_while_statement1949);
            	embedded_statement94 = embedded_statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new WhileStatement(
            	  			expression93,
            	  			embedded_statement94
            	  		);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "while_statement"


    // $ANTLR start "do_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:739:1: do_statement returns [Statement value] : KW_DO embedded_statement KW_WHILE '(' expression ')' SEMI ;
    public Statement do_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Expression expression95 = default(Expression);

        Statement embedded_statement96 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:740:2: ( KW_DO embedded_statement KW_WHILE '(' expression ')' SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:740:4: KW_DO embedded_statement KW_WHILE '(' expression ')' SEMI
            {
            	Match(input,KW_DO,FOLLOW_KW_DO_in_do_statement1967); if (state.failed) return value;
            	PushFollow(FOLLOW_embedded_statement_in_do_statement1969);
            	embedded_statement96 = embedded_statement();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,KW_WHILE,FOLLOW_KW_WHILE_in_do_statement1971); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_do_statement1973); if (state.failed) return value;
            	PushFollow(FOLLOW_expression_in_do_statement1975);
            	expression95 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_do_statement1977); if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_do_statement1979); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new DoStatement(
            	  			expression95,
            	  			embedded_statement96
            	  		);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "do_statement"


    // $ANTLR start "jump_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:749:1: jump_statement returns [Statement value] : ( break_statement | goto_statement | continue_statement | return_statement );
    public Statement jump_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        GrammarParser.break_statement_return break_statement97 = default(GrammarParser.break_statement_return);

        Statement goto_statement98 = default(Statement);

        GrammarParser.continue_statement_return continue_statement99 = default(GrammarParser.continue_statement_return);

        GrammarParser.return_statement_return return_statement100 = default(GrammarParser.return_statement_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:750:2: ( break_statement | goto_statement | continue_statement | return_statement )
            int alt76 = 4;
            switch ( input.LA(1) ) 
            {
            case KW_BREAK:
            	{
                alt76 = 1;
                }
                break;
            case KW_GOTO:
            	{
                alt76 = 2;
                }
                break;
            case KW_CONTINUE:
            	{
                alt76 = 3;
                }
                break;
            case KW_RETURN:
            	{
                alt76 = 4;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d76s0 =
            	        new NoViableAltException("", 76, 0, input);

            	    throw nvae_d76s0;
            }

            switch (alt76) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:750:4: break_statement
                    {
                    	PushFollow(FOLLOW_break_statement_in_jump_statement1997);
                    	break_statement97 = break_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  ((break_statement97 != null) ? break_statement97.value : default(Statement)); 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:751:4: goto_statement
                    {
                    	PushFollow(FOLLOW_goto_statement_in_jump_statement2005);
                    	goto_statement98 = goto_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  goto_statement98; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:752:4: continue_statement
                    {
                    	PushFollow(FOLLOW_continue_statement_in_jump_statement2013);
                    	continue_statement99 = continue_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  ((continue_statement99 != null) ? continue_statement99.value : default(Statement)); 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:753:4: return_statement
                    {
                    	PushFollow(FOLLOW_return_statement_in_jump_statement2020);
                    	return_statement100 = return_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  ((return_statement100 != null) ? return_statement100.value : default(Statement)); 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "jump_statement"


    // $ANTLR start "goto_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:756:1: goto_statement returns [Statement value] : KW_GOTO identifier SEMI ;
    public Statement goto_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        GrammarParser.identifier_return identifier101 = default(GrammarParser.identifier_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:757:2: ( KW_GOTO identifier SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:757:4: KW_GOTO identifier SEMI
            {
            	Match(input,KW_GOTO,FOLLOW_KW_GOTO_in_goto_statement2038); if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_goto_statement2040);
            	identifier101 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_goto_statement2042); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new GotoStatement(((identifier101 != null) ? identifier101.value : default(Identifier)));
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "goto_statement"

    public class break_statement_return : ParserRuleReturnScope
    {
        public Statement value;
    };

    // $ANTLR start "break_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:763:1: break_statement returns [Statement value] : KW_BREAK SEMI ;
    public GrammarParser.break_statement_return break_statement() // throws RecognitionException [1]
    {   
        GrammarParser.break_statement_return retval = new GrammarParser.break_statement_return();
        retval.Start = input.LT(1);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:764:2: ( KW_BREAK SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:764:4: KW_BREAK SEMI
            {
            	Match(input,KW_BREAK,FOLLOW_KW_BREAK_in_break_statement2060); if (state.failed) return retval;
            	Match(input,SEMI,FOLLOW_SEMI_in_break_statement2062); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{

            	  		retval.value =  new BreakStatement(GetLocation(((IToken)retval.Start)));
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "break_statement"

    public class continue_statement_return : ParserRuleReturnScope
    {
        public Statement value;
    };

    // $ANTLR start "continue_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:770:1: continue_statement returns [Statement value] : KW_CONTINUE SEMI ;
    public GrammarParser.continue_statement_return continue_statement() // throws RecognitionException [1]
    {   
        GrammarParser.continue_statement_return retval = new GrammarParser.continue_statement_return();
        retval.Start = input.LT(1);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:771:2: ( KW_CONTINUE SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:771:4: KW_CONTINUE SEMI
            {
            	Match(input,KW_CONTINUE,FOLLOW_KW_CONTINUE_in_continue_statement2080); if (state.failed) return retval;
            	Match(input,SEMI,FOLLOW_SEMI_in_continue_statement2082); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{

            	  		retval.value =  new ContinueStatement(GetLocation(((IToken)retval.Start)));
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "continue_statement"

    public class return_statement_return : ParserRuleReturnScope
    {
        public Statement value;
    };

    // $ANTLR start "return_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:777:1: return_statement returns [Statement value] : KW_RETURN ( expression )? SEMI ;
    public GrammarParser.return_statement_return return_statement() // throws RecognitionException [1]
    {   
        GrammarParser.return_statement_return retval = new GrammarParser.return_statement_return();
        retval.Start = input.LT(1);

        Expression expression102 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:778:2: ( KW_RETURN ( expression )? SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:778:4: KW_RETURN ( expression )? SEMI
            {
            	Match(input,KW_RETURN,FOLLOW_KW_RETURN_in_return_statement2100); if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:778:14: ( expression )?
            	int alt77 = 2;
            	int LA77_0 = input.LA(1);

            	if ( ((LA77_0 >= KW_NEW && LA77_0 <= KW_BASE) || (LA77_0 >= KW_GLOBAL && LA77_0 <= KW_TYPEOF) || LA77_0 == ID || (LA77_0 >= LITERAL_INTEGER && LA77_0 <= KW_NULL) || LA77_0 == 94 || (LA77_0 >= 111 && LA77_0 <= 112) || (LA77_0 >= 126 && LA77_0 <= 129)) )
            	{
            	    alt77 = 1;
            	}
            	switch (alt77) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:778:14: expression
            	        {
            	        	PushFollow(FOLLOW_expression_in_return_statement2102);
            	        	expression102 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,SEMI,FOLLOW_SEMI_in_return_statement2105); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{

            	  		retval.value =  new ReturnStatement(expression102, GetLocation(((IToken)retval.Start)));
            	  		// przydaloby sie dodac Location do niektorych statements, np. tutaj nie zawsze jest expression, a lokacje trzeba znac
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "return_statement"


    // $ANTLR start "try_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:785:1: try_statement returns [Statement value] : KW_TRY block ( catch_statements (a= finally_statement )? | b= finally_statement ) ;
    public Statement try_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        FinallyClause a = default(FinallyClause);

        FinallyClause b = default(FinallyClause);

        Statement block103 = default(Statement);

        IList<CatchClause> catch_statements104 = default(IList<CatchClause>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:786:2: ( KW_TRY block ( catch_statements (a= finally_statement )? | b= finally_statement ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:786:4: KW_TRY block ( catch_statements (a= finally_statement )? | b= finally_statement )
            {
            	Match(input,KW_TRY,FOLLOW_KW_TRY_in_try_statement2123); if (state.failed) return value;
            	PushFollow(FOLLOW_block_in_try_statement2125);
            	block103 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:787:3: ( catch_statements (a= finally_statement )? | b= finally_statement )
            	int alt79 = 2;
            	int LA79_0 = input.LA(1);

            	if ( (LA79_0 == KW_CATCH) )
            	{
            	    alt79 = 1;
            	}
            	else if ( (LA79_0 == KW_FINALLY) )
            	{
            	    alt79 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d79s0 =
            	        new NoViableAltException("", 79, 0, input);

            	    throw nvae_d79s0;
            	}
            	switch (alt79) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:787:4: catch_statements (a= finally_statement )?
            	        {
            	        	PushFollow(FOLLOW_catch_statements_in_try_statement2130);
            	        	catch_statements104 = catch_statements();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:787:22: (a= finally_statement )?
            	        	int alt78 = 2;
            	        	int LA78_0 = input.LA(1);

            	        	if ( (LA78_0 == KW_FINALLY) )
            	        	{
            	        	    alt78 = 1;
            	        	}
            	        	switch (alt78) 
            	        	{
            	        	    case 1 :
            	        	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:787:22: a= finally_statement
            	        	        {
            	        	        	PushFollow(FOLLOW_finally_statement_in_try_statement2134);
            	        	        	a = finally_statement();
            	        	        	state.followingStackPointer--;
            	        	        	if (state.failed) return value;

            	        	        }
            	        	        break;

            	        	}

            	        	if ( (state.backtracking==0) )
            	        	{

            	        	  			value =  new TryStatement(
            	        	  				block103,
            	        	  				catch_statements104,
            	        	  				a
            	        	  			);
            	        	  		
            	        	}

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:795:5: b= finally_statement
            	        {
            	        	PushFollow(FOLLOW_finally_statement_in_try_statement2147);
            	        	b = finally_statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;
            	        	if ( (state.backtracking==0) )
            	        	{

            	        	  			value =  new TryStatement(
            	        	  				block103,
            	        	  				null,
            	        	  				b
            	        	  			);
            	        	  		
            	        	}

            	        }
            	        break;

            	}


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "try_statement"


    // $ANTLR start "catch_statements"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:805:1: catch_statements returns [IList<CatchClause> value] : ( catch_statement )+ ;
    public IList<CatchClause> catch_statements() // throws RecognitionException [1]
    {   
        IList<CatchClause> value = default(IList<CatchClause>);

        CatchClause catch_statement105 = default(CatchClause);



        	value =  new List<CatchClause>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:809:2: ( ( catch_statement )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:809:4: ( catch_statement )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:809:4: ( catch_statement )+
            	int cnt80 = 0;
            	do 
            	{
            	    int alt80 = 2;
            	    int LA80_0 = input.LA(1);

            	    if ( (LA80_0 == KW_CATCH) )
            	    {
            	        alt80 = 1;
            	    }


            	    switch (alt80) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:809:5: catch_statement
            			    {
            			    	PushFollow(FOLLOW_catch_statement_in_catch_statements2173);
            			    	catch_statement105 = catch_statement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(catch_statement105); 
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt80 >= 1 ) goto loop80;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee80 =
            		                new EarlyExitException(80, input);
            		            throw eee80;
            	    }
            	    cnt80++;
            	} while (true);

            	loop80:
            		;	// Stops C# compiler whining that label 'loop80' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "catch_statements"


    // $ANTLR start "catch_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:812:1: catch_statement returns [CatchClause value] : KW_CATCH '(' type identifier ')' block ;
    public CatchClause catch_statement() // throws RecognitionException [1]
    {   
        CatchClause value = default(CatchClause);

        TypeSignature type106 = default(TypeSignature);

        GrammarParser.identifier_return identifier107 = default(GrammarParser.identifier_return);

        Statement block108 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:813:2: ( KW_CATCH '(' type identifier ')' block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:813:4: KW_CATCH '(' type identifier ')' block
            {
            	Match(input,KW_CATCH,FOLLOW_KW_CATCH_in_catch_statement2193); if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_catch_statement2195); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_catch_statement2197);
            	type106 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	PushFollow(FOLLOW_identifier_in_catch_statement2199);
            	identifier107 = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_catch_statement2201); if (state.failed) return value;
            	PushFollow(FOLLOW_block_in_catch_statement2203);
            	block108 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new CatchClause(
            	  			type106,
            	  			((identifier107 != null) ? identifier107.value : default(Identifier)),
            	  			block108
            	  		);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "catch_statement"


    // $ANTLR start "finally_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:823:1: finally_statement returns [FinallyClause value] : KW_FINALLY block ;
    public FinallyClause finally_statement() // throws RecognitionException [1]
    {   
        FinallyClause value = default(FinallyClause);

        Statement block109 = default(Statement);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:824:2: ( KW_FINALLY block )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:824:4: KW_FINALLY block
            {
            	Match(input,KW_FINALLY,FOLLOW_KW_FINALLY_in_finally_statement2222); if (state.failed) return value;
            	PushFollow(FOLLOW_block_in_finally_statement2224);
            	block109 = block();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new FinallyClause(block109);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "finally_statement"

    public class throw_statement_return : ParserRuleReturnScope
    {
        public Statement value;
    };

    // $ANTLR start "throw_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:830:1: throw_statement returns [Statement value] : KW_THROW ( expression )? SEMI ;
    public GrammarParser.throw_statement_return throw_statement() // throws RecognitionException [1]
    {   
        GrammarParser.throw_statement_return retval = new GrammarParser.throw_statement_return();
        retval.Start = input.LT(1);

        Expression expression110 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:831:2: ( KW_THROW ( expression )? SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:831:4: KW_THROW ( expression )? SEMI
            {
            	Match(input,KW_THROW,FOLLOW_KW_THROW_in_throw_statement2242); if (state.failed) return retval;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:831:13: ( expression )?
            	int alt81 = 2;
            	int LA81_0 = input.LA(1);

            	if ( ((LA81_0 >= KW_NEW && LA81_0 <= KW_BASE) || (LA81_0 >= KW_GLOBAL && LA81_0 <= KW_TYPEOF) || LA81_0 == ID || (LA81_0 >= LITERAL_INTEGER && LA81_0 <= KW_NULL) || LA81_0 == 94 || (LA81_0 >= 111 && LA81_0 <= 112) || (LA81_0 >= 126 && LA81_0 <= 129)) )
            	{
            	    alt81 = 1;
            	}
            	switch (alt81) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:831:13: expression
            	        {
            	        	PushFollow(FOLLOW_expression_in_throw_statement2244);
            	        	expression110 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;

            	        }
            	        break;

            	}

            	Match(input,SEMI,FOLLOW_SEMI_in_throw_statement2247); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{

            	  		retval.value =  new ThrowStatement(expression110, GetLocation(((IToken)retval.Start)));
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "throw_statement"


    // $ANTLR start "empty_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:837:1: empty_statement returns [Statement value] : SEMI ;
    public Statement empty_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:838:2: ( SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:838:4: SEMI
            {
            	Match(input,SEMI,FOLLOW_SEMI_in_empty_statement2265); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new EmptyStatement();
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "empty_statement"


    // $ANTLR start "expression_statement"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:844:1: expression_statement returns [Statement value] : expression SEMI ;
    public Statement expression_statement() // throws RecognitionException [1]
    {   
        Statement value = default(Statement);

        Expression expression111 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:845:2: ( expression SEMI )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:845:4: expression SEMI
            {
            	PushFollow(FOLLOW_expression_in_expression_statement2283);
            	expression111 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,SEMI,FOLLOW_SEMI_in_expression_statement2285); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		if(!(expression111 is StatementExpression))
            	  			Report.Error.InvalidStatement(expression111.Location);
            	  		value =  new ExpressionStatement((StatementExpression)expression111);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "expression_statement"


    // $ANTLR start "expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:853:1: expression returns [Expression value] : lhs= null_coalescing_expression ;
    public Expression expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:854:2: (lhs= null_coalescing_expression )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:854:4: lhs= null_coalescing_expression
            {
            	PushFollow(FOLLOW_null_coalescing_expression_in_expression2305);
            	lhs = null_coalescing_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  lhs;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "expression"


    // $ANTLR start "null_coalescing_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:860:1: null_coalescing_expression returns [Expression value] : lhs= conditional_or_expression ( '??' rhs= conditional_or_expression )* ;
    public Expression null_coalescing_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:861:2: (lhs= conditional_or_expression ( '??' rhs= conditional_or_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:861:4: lhs= conditional_or_expression ( '??' rhs= conditional_or_expression )*
            {
            	PushFollow(FOLLOW_conditional_or_expression_in_null_coalescing_expression2325);
            	lhs = conditional_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:862:3: ( '??' rhs= conditional_or_expression )*
            	do 
            	{
            	    int alt82 = 2;
            	    int LA82_0 = input.LA(1);

            	    if ( (LA82_0 == 97) )
            	    {
            	        alt82 = 1;
            	    }


            	    switch (alt82) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:862:4: '??' rhs= conditional_or_expression
            			    {
            			    	Match(input,97,FOLLOW_97_in_null_coalescing_expression2332); if (state.failed) return value;
            			    	PushFollow(FOLLOW_conditional_or_expression_in_null_coalescing_expression2336);
            			    	rhs = conditional_or_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.NullCoalescing, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop82;
            	    }
            	} while (true);

            	loop82:
            		;	// Stops C# compiler whining that label 'loop82' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "null_coalescing_expression"


    // $ANTLR start "conditional_or_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:865:1: conditional_or_expression returns [Expression value] : lhs= conditional_and_expression ( '||' rhs= conditional_and_expression )* ;
    public Expression conditional_or_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:866:2: (lhs= conditional_and_expression ( '||' rhs= conditional_and_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:866:4: lhs= conditional_and_expression ( '||' rhs= conditional_and_expression )*
            {
            	PushFollow(FOLLOW_conditional_and_expression_in_conditional_or_expression2357);
            	lhs = conditional_and_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:867:3: ( '||' rhs= conditional_and_expression )*
            	do 
            	{
            	    int alt83 = 2;
            	    int LA83_0 = input.LA(1);

            	    if ( (LA83_0 == 98) )
            	    {
            	        alt83 = 1;
            	    }


            	    switch (alt83) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:867:4: '||' rhs= conditional_and_expression
            			    {
            			    	Match(input,98,FOLLOW_98_in_conditional_or_expression2364); if (state.failed) return value;
            			    	PushFollow(FOLLOW_conditional_and_expression_in_conditional_or_expression2368);
            			    	rhs = conditional_and_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.LogicalOr, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop83;
            	    }
            	} while (true);

            	loop83:
            		;	// Stops C# compiler whining that label 'loop83' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "conditional_or_expression"


    // $ANTLR start "conditional_and_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:870:1: conditional_and_expression returns [Expression value] : lhs= inclusive_or_expression ( '&&' rhs= inclusive_or_expression )* ;
    public Expression conditional_and_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:871:2: (lhs= inclusive_or_expression ( '&&' rhs= inclusive_or_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:871:4: lhs= inclusive_or_expression ( '&&' rhs= inclusive_or_expression )*
            {
            	PushFollow(FOLLOW_inclusive_or_expression_in_conditional_and_expression2389);
            	lhs = inclusive_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:872:3: ( '&&' rhs= inclusive_or_expression )*
            	do 
            	{
            	    int alt84 = 2;
            	    int LA84_0 = input.LA(1);

            	    if ( (LA84_0 == 99) )
            	    {
            	        alt84 = 1;
            	    }


            	    switch (alt84) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:872:4: '&&' rhs= inclusive_or_expression
            			    {
            			    	Match(input,99,FOLLOW_99_in_conditional_and_expression2396); if (state.failed) return value;
            			    	PushFollow(FOLLOW_inclusive_or_expression_in_conditional_and_expression2400);
            			    	rhs = inclusive_or_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.LogicalAnd, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop84;
            	    }
            	} while (true);

            	loop84:
            		;	// Stops C# compiler whining that label 'loop84' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "conditional_and_expression"


    // $ANTLR start "inclusive_or_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:875:1: inclusive_or_expression returns [Expression value] : lhs= exclusive_or_expression ( '|' rhs= exclusive_or_expression )* ;
    public Expression inclusive_or_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:876:2: (lhs= exclusive_or_expression ( '|' rhs= exclusive_or_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:876:4: lhs= exclusive_or_expression ( '|' rhs= exclusive_or_expression )*
            {
            	PushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression2421);
            	lhs = exclusive_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:877:3: ( '|' rhs= exclusive_or_expression )*
            	do 
            	{
            	    int alt85 = 2;
            	    int LA85_0 = input.LA(1);

            	    if ( (LA85_0 == 100) )
            	    {
            	        alt85 = 1;
            	    }


            	    switch (alt85) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:877:4: '|' rhs= exclusive_or_expression
            			    {
            			    	Match(input,100,FOLLOW_100_in_inclusive_or_expression2428); if (state.failed) return value;
            			    	PushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression2432);
            			    	rhs = exclusive_or_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.BitwiseOr, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop85;
            	    }
            	} while (true);

            	loop85:
            		;	// Stops C# compiler whining that label 'loop85' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "inclusive_or_expression"


    // $ANTLR start "exclusive_or_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:880:1: exclusive_or_expression returns [Expression value] : lhs= and_expression ( '^' rhs= and_expression )* ;
    public Expression exclusive_or_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:881:2: (lhs= and_expression ( '^' rhs= and_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:881:4: lhs= and_expression ( '^' rhs= and_expression )*
            {
            	PushFollow(FOLLOW_and_expression_in_exclusive_or_expression2453);
            	lhs = and_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:882:3: ( '^' rhs= and_expression )*
            	do 
            	{
            	    int alt86 = 2;
            	    int LA86_0 = input.LA(1);

            	    if ( (LA86_0 == 101) )
            	    {
            	        alt86 = 1;
            	    }


            	    switch (alt86) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:882:4: '^' rhs= and_expression
            			    {
            			    	Match(input,101,FOLLOW_101_in_exclusive_or_expression2460); if (state.failed) return value;
            			    	PushFollow(FOLLOW_and_expression_in_exclusive_or_expression2464);
            			    	rhs = and_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.ExclusiveOr, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop86;
            	    }
            	} while (true);

            	loop86:
            		;	// Stops C# compiler whining that label 'loop86' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "exclusive_or_expression"


    // $ANTLR start "and_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:885:1: and_expression returns [Expression value] : lhs= equality_expression ( '&' rhs= equality_expression )* ;
    public Expression and_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:886:2: (lhs= equality_expression ( '&' rhs= equality_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:886:4: lhs= equality_expression ( '&' rhs= equality_expression )*
            {
            	PushFollow(FOLLOW_equality_expression_in_and_expression2485);
            	lhs = equality_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:887:3: ( '&' rhs= equality_expression )*
            	do 
            	{
            	    int alt87 = 2;
            	    int LA87_0 = input.LA(1);

            	    if ( (LA87_0 == 102) )
            	    {
            	        alt87 = 1;
            	    }


            	    switch (alt87) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:887:4: '&' rhs= equality_expression
            			    {
            			    	Match(input,102,FOLLOW_102_in_and_expression2492); if (state.failed) return value;
            			    	PushFollow(FOLLOW_equality_expression_in_and_expression2496);
            			    	rhs = equality_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(Operator.Binary.BitwiseAnd, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop87;
            	    }
            	} while (true);

            	loop87:
            		;	// Stops C# compiler whining that label 'loop87' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "and_expression"


    // $ANTLR start "equality_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:890:1: equality_expression returns [Expression value] : lhs= relational_expression (op= equality_operator rhs= relational_expression )* ;
    public Expression equality_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Operator.Binary op = default(Operator.Binary);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:891:2: (lhs= relational_expression (op= equality_operator rhs= relational_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:891:4: lhs= relational_expression (op= equality_operator rhs= relational_expression )*
            {
            	PushFollow(FOLLOW_relational_expression_in_equality_expression2517);
            	lhs = relational_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:892:3: (op= equality_operator rhs= relational_expression )*
            	do 
            	{
            	    int alt88 = 2;
            	    int LA88_0 = input.LA(1);

            	    if ( (LA88_0 == 103) )
            	    {
            	        alt88 = 1;
            	    }
            	    else if ( (LA88_0 == 104) )
            	    {
            	        alt88 = 1;
            	    }


            	    switch (alt88) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:892:4: op= equality_operator rhs= relational_expression
            			    {
            			    	PushFollow(FOLLOW_equality_operator_in_equality_expression2526);
            			    	op = equality_operator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	PushFollow(FOLLOW_relational_expression_in_equality_expression2530);
            			    	rhs = relational_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(op, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop88;
            	    }
            	} while (true);

            	loop88:
            		;	// Stops C# compiler whining that label 'loop88' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "equality_expression"


    // $ANTLR start "equality_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:895:1: equality_operator returns [Operator.Binary value] : ( '==' | '!=' );
    public Operator.Binary equality_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:896:2: ( '==' | '!=' )
            int alt89 = 2;
            int LA89_0 = input.LA(1);

            if ( (LA89_0 == 103) )
            {
                alt89 = 1;
            }
            else if ( (LA89_0 == 104) )
            {
                alt89 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d89s0 =
                    new NoViableAltException("", 89, 0, input);

                throw nvae_d89s0;
            }
            switch (alt89) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:896:4: '=='
                    {
                    	Match(input,103,FOLLOW_103_in_equality_operator2549); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Equality; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:897:4: '!='
                    {
                    	Match(input,104,FOLLOW_104_in_equality_operator2556); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Inequality; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "equality_operator"


    // $ANTLR start "relational_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:900:1: relational_expression returns [Expression value] : lhs= shift_expression ( (op= relational_operator rhs= shift_expression )+ | KW_IS a= type | KW_AS b= type | ) ;
    public Expression relational_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Operator.Binary op = default(Operator.Binary);

        Expression rhs = default(Expression);

        TypeSignature a = default(TypeSignature);

        TypeSignature b = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:901:2: (lhs= shift_expression ( (op= relational_operator rhs= shift_expression )+ | KW_IS a= type | KW_AS b= type | ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:901:4: lhs= shift_expression ( (op= relational_operator rhs= shift_expression )+ | KW_IS a= type | KW_AS b= type | )
            {
            	PushFollow(FOLLOW_shift_expression_in_relational_expression2576);
            	lhs = shift_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:902:3: ( (op= relational_operator rhs= shift_expression )+ | KW_IS a= type | KW_AS b= type | )
            	int alt91 = 4;
            	switch ( input.LA(1) ) 
            	{
            	case 105:
            		{
            	    alt91 = 1;
            	    }
            	    break;
            	case 106:
            		{
            	    alt91 = 1;
            	    }
            	    break;
            	case 107:
            		{
            	    alt91 = 1;
            	    }
            	    break;
            	case 108:
            		{
            	    alt91 = 1;
            	    }
            	    break;
            	case KW_IS:
            		{
            	    alt91 = 2;
            	    }
            	    break;
            	case KW_AS:
            		{
            	    alt91 = 3;
            	    }
            	    break;
            	case EOF:
            	case SEMI:
            	case COMMA:
            	case 95:
            	case 97:
            	case 98:
            	case 99:
            	case 100:
            	case 101:
            	case 102:
            	case 103:
            	case 104:
            	case 109:
            	case 110:
            	case 111:
            	case 112:
            	case 113:
            	case 114:
            	case 115:
            	case 132:
            		{
            	    alt91 = 4;
            	    }
            	    break;
            		default:
            		    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		    NoViableAltException nvae_d91s0 =
            		        new NoViableAltException("", 91, 0, input);

            		    throw nvae_d91s0;
            	}

            	switch (alt91) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:903:4: (op= relational_operator rhs= shift_expression )+
            	        {
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:903:4: (op= relational_operator rhs= shift_expression )+
            	        	int cnt90 = 0;
            	        	do 
            	        	{
            	        	    int alt90 = 2;
            	        	    switch ( input.LA(1) ) 
            	        	    {
            	        	    case 105:
            	        	    	{
            	        	        alt90 = 1;
            	        	        }
            	        	        break;
            	        	    case 106:
            	        	    	{
            	        	        alt90 = 1;
            	        	        }
            	        	        break;
            	        	    case 107:
            	        	    	{
            	        	        alt90 = 1;
            	        	        }
            	        	        break;
            	        	    case 108:
            	        	    	{
            	        	        alt90 = 1;
            	        	        }
            	        	        break;

            	        	    }

            	        	    switch (alt90) 
            	        		{
            	        			case 1 :
            	        			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:903:5: op= relational_operator rhs= shift_expression
            	        			    {
            	        			    	PushFollow(FOLLOW_relational_operator_in_relational_expression2590);
            	        			    	op = relational_operator();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return value;
            	        			    	PushFollow(FOLLOW_shift_expression_in_relational_expression2594);
            	        			    	rhs = shift_expression();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return value;
            	        			    	if ( (state.backtracking==0) )
            	        			    	{
            	        			    	   value =  new BinaryExpression(op, value, rhs); 
            	        			    	}

            	        			    }
            	        			    break;

            	        			default:
            	        			    if ( cnt90 >= 1 ) goto loop90;
            	        			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	        		            EarlyExitException eee90 =
            	        		                new EarlyExitException(90, input);
            	        		            throw eee90;
            	        	    }
            	        	    cnt90++;
            	        	} while (true);

            	        	loop90:
            	        		;	// Stops C# compiler whining that label 'loop90' has no statements


            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:904:6: KW_IS a= type
            	        {
            	        	Match(input,KW_IS,FOLLOW_KW_IS_in_relational_expression2605); if (state.failed) return value;
            	        	PushFollow(FOLLOW_type_in_relational_expression2609);
            	        	a = type();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	   value =  new IsExpression(value, a); 
            	        	}

            	        }
            	        break;
            	    case 3 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:905:6: KW_AS b= type
            	        {
            	        	Match(input,KW_AS,FOLLOW_KW_AS_in_relational_expression2618); if (state.failed) return value;
            	        	PushFollow(FOLLOW_type_in_relational_expression2622);
            	        	b = type();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;
            	        	if ( (state.backtracking==0) )
            	        	{
            	        	   value =  new AsExpression(value, b); 
            	        	}

            	        }
            	        break;
            	    case 4 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:907:3: 
            	        {
            	        }
            	        break;

            	}


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "relational_expression"


    // $ANTLR start "relational_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:910:1: relational_operator returns [Operator.Binary value] : ( '<' | '>' | '<=' | '>=' );
    public Operator.Binary relational_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:911:2: ( '<' | '>' | '<=' | '>=' )
            int alt92 = 4;
            switch ( input.LA(1) ) 
            {
            case 105:
            	{
                alt92 = 1;
                }
                break;
            case 106:
            	{
                alt92 = 2;
                }
                break;
            case 107:
            	{
                alt92 = 3;
                }
                break;
            case 108:
            	{
                alt92 = 4;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d92s0 =
            	        new NoViableAltException("", 92, 0, input);

            	    throw nvae_d92s0;
            }

            switch (alt92) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:911:4: '<'
                    {
                    	Match(input,105,FOLLOW_105_in_relational_operator2650); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.LessThan; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:912:4: '>'
                    {
                    	Match(input,106,FOLLOW_106_in_relational_operator2658); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.GreaterThan; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:913:4: '<='
                    {
                    	Match(input,107,FOLLOW_107_in_relational_operator2666); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.LessThanOrEqual; 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:914:4: '>='
                    {
                    	Match(input,108,FOLLOW_108_in_relational_operator2674); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.GreaterThanOrEqual; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "relational_operator"


    // $ANTLR start "shift_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:917:1: shift_expression returns [Expression value] : lhs= additive_expression (op= shift_operator rhs= additive_expression )* ;
    public Expression shift_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Operator.Binary op = default(Operator.Binary);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:918:2: (lhs= additive_expression (op= shift_operator rhs= additive_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:918:4: lhs= additive_expression (op= shift_operator rhs= additive_expression )*
            {
            	PushFollow(FOLLOW_additive_expression_in_shift_expression2694);
            	lhs = additive_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:919:3: (op= shift_operator rhs= additive_expression )*
            	do 
            	{
            	    int alt93 = 2;
            	    int LA93_0 = input.LA(1);

            	    if ( (LA93_0 == 109) )
            	    {
            	        alt93 = 1;
            	    }
            	    else if ( (LA93_0 == 110) )
            	    {
            	        alt93 = 1;
            	    }


            	    switch (alt93) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:919:4: op= shift_operator rhs= additive_expression
            			    {
            			    	PushFollow(FOLLOW_shift_operator_in_shift_expression2703);
            			    	op = shift_operator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	PushFollow(FOLLOW_additive_expression_in_shift_expression2707);
            			    	rhs = additive_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(op, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop93;
            	    }
            	} while (true);

            	loop93:
            		;	// Stops C# compiler whining that label 'loop93' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "shift_expression"


    // $ANTLR start "shift_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:922:1: shift_operator returns [Operator.Binary value] : ( '<<' | '>>' );
    public Operator.Binary shift_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:923:2: ( '<<' | '>>' )
            int alt94 = 2;
            int LA94_0 = input.LA(1);

            if ( (LA94_0 == 109) )
            {
                alt94 = 1;
            }
            else if ( (LA94_0 == 110) )
            {
                alt94 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d94s0 =
                    new NoViableAltException("", 94, 0, input);

                throw nvae_d94s0;
            }
            switch (alt94) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:923:4: '<<'
                    {
                    	Match(input,109,FOLLOW_109_in_shift_operator2726); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.LeftShift; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:924:4: '>>'
                    {
                    	Match(input,110,FOLLOW_110_in_shift_operator2734); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.RightShift; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "shift_operator"


    // $ANTLR start "additive_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:927:1: additive_expression returns [Expression value] : lhs= multiplicative_expression (op= additive_operator rhs= multiplicative_expression )* ;
    public Expression additive_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        Expression lhs = default(Expression);

        Operator.Binary op = default(Operator.Binary);

        Expression rhs = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:928:2: (lhs= multiplicative_expression (op= additive_operator rhs= multiplicative_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:928:4: lhs= multiplicative_expression (op= additive_operator rhs= multiplicative_expression )*
            {
            	PushFollow(FOLLOW_multiplicative_expression_in_additive_expression2754);
            	lhs = multiplicative_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  lhs; 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:929:3: (op= additive_operator rhs= multiplicative_expression )*
            	do 
            	{
            	    int alt95 = 2;
            	    int LA95_0 = input.LA(1);

            	    if ( (LA95_0 == 111) )
            	    {
            	        alt95 = 1;
            	    }
            	    else if ( (LA95_0 == 112) )
            	    {
            	        alt95 = 1;
            	    }


            	    switch (alt95) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:929:4: op= additive_operator rhs= multiplicative_expression
            			    {
            			    	PushFollow(FOLLOW_additive_operator_in_additive_expression2763);
            			    	op = additive_operator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	PushFollow(FOLLOW_multiplicative_expression_in_additive_expression2767);
            			    	rhs = multiplicative_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(op, value, rhs); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop95;
            	    }
            	} while (true);

            	loop95:
            		;	// Stops C# compiler whining that label 'loop95' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "additive_expression"


    // $ANTLR start "additive_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:932:1: additive_operator returns [Operator.Binary value] : ( '+' | '-' );
    public Operator.Binary additive_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:933:2: ( '+' | '-' )
            int alt96 = 2;
            int LA96_0 = input.LA(1);

            if ( (LA96_0 == 111) )
            {
                alt96 = 1;
            }
            else if ( (LA96_0 == 112) )
            {
                alt96 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d96s0 =
                    new NoViableAltException("", 96, 0, input);

                throw nvae_d96s0;
            }
            switch (alt96) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:933:4: '+'
                    {
                    	Match(input,111,FOLLOW_111_in_additive_operator2786); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Addition; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:934:4: '-'
                    {
                    	Match(input,112,FOLLOW_112_in_additive_operator2793); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Subtraction; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "additive_operator"


    // $ANTLR start "multiplicative_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:937:1: multiplicative_expression returns [Expression value] : lhs= unary_expression (op= multiplicative_operator rhs= unary_expression )* ;
    public Expression multiplicative_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        GrammarParser.unary_expression_return lhs = default(GrammarParser.unary_expression_return);

        Operator.Binary op = default(Operator.Binary);

        GrammarParser.unary_expression_return rhs = default(GrammarParser.unary_expression_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:938:2: (lhs= unary_expression (op= multiplicative_operator rhs= unary_expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:938:4: lhs= unary_expression (op= multiplicative_operator rhs= unary_expression )*
            {
            	PushFollow(FOLLOW_unary_expression_in_multiplicative_expression2813);
            	lhs = unary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value =  ((lhs != null) ? lhs.value : default(Expression)); 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:939:3: (op= multiplicative_operator rhs= unary_expression )*
            	do 
            	{
            	    int alt97 = 2;
            	    switch ( input.LA(1) ) 
            	    {
            	    case 113:
            	    	{
            	        alt97 = 1;
            	        }
            	        break;
            	    case 114:
            	    	{
            	        alt97 = 1;
            	        }
            	        break;
            	    case 115:
            	    	{
            	        alt97 = 1;
            	        }
            	        break;

            	    }

            	    switch (alt97) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:939:4: op= multiplicative_operator rhs= unary_expression
            			    {
            			    	PushFollow(FOLLOW_multiplicative_operator_in_multiplicative_expression2822);
            			    	op = multiplicative_operator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	PushFollow(FOLLOW_unary_expression_in_multiplicative_expression2826);
            			    	rhs = unary_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value =  new BinaryExpression(op, value, ((rhs != null) ? rhs.value : default(Expression))); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop97;
            	    }
            	} while (true);

            	loop97:
            		;	// Stops C# compiler whining that label 'loop97' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "multiplicative_expression"


    // $ANTLR start "multiplicative_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:942:1: multiplicative_operator returns [Operator.Binary value] : ( '*' | '/' | '%' );
    public Operator.Binary multiplicative_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:943:2: ( '*' | '/' | '%' )
            int alt98 = 3;
            switch ( input.LA(1) ) 
            {
            case 113:
            	{
                alt98 = 1;
                }
                break;
            case 114:
            	{
                alt98 = 2;
                }
                break;
            case 115:
            	{
                alt98 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d98s0 =
            	        new NoViableAltException("", 98, 0, input);

            	    throw nvae_d98s0;
            }

            switch (alt98) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:943:4: '*'
                    {
                    	Match(input,113,FOLLOW_113_in_multiplicative_operator2845); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Multiply; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:944:4: '/'
                    {
                    	Match(input,114,FOLLOW_114_in_multiplicative_operator2852); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Division; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:945:4: '%'
                    {
                    	Match(input,115,FOLLOW_115_in_multiplicative_operator2859); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Modulus; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "multiplicative_operator"


    // $ANTLR start "assignment_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:948:1: assignment_operator : '=' ;
    public void assignment_operator() // throws RecognitionException [1]
    {   
        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:949:2: ( '=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:949:4: '='
            {
            	Match(input,91,FOLLOW_91_in_assignment_operator2872); if (state.failed) return ;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "assignment_operator"


    // $ANTLR start "complex_assignment_operator"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:952:1: complex_assignment_operator returns [Operator.Binary value] : ( '+=' | '-=' | '*=' | '/=' | '%=' | '&=' | '|=' | '^=' | '<<=' | '>>=' );
    public Operator.Binary complex_assignment_operator() // throws RecognitionException [1]
    {   
        Operator.Binary value = default(Operator.Binary);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:953:2: ( '+=' | '-=' | '*=' | '/=' | '%=' | '&=' | '|=' | '^=' | '<<=' | '>>=' )
            int alt99 = 10;
            switch ( input.LA(1) ) 
            {
            case 116:
            	{
                alt99 = 1;
                }
                break;
            case 117:
            	{
                alt99 = 2;
                }
                break;
            case 118:
            	{
                alt99 = 3;
                }
                break;
            case 119:
            	{
                alt99 = 4;
                }
                break;
            case 120:
            	{
                alt99 = 5;
                }
                break;
            case 121:
            	{
                alt99 = 6;
                }
                break;
            case 122:
            	{
                alt99 = 7;
                }
                break;
            case 123:
            	{
                alt99 = 8;
                }
                break;
            case 124:
            	{
                alt99 = 9;
                }
                break;
            case 125:
            	{
                alt99 = 10;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d99s0 =
            	        new NoViableAltException("", 99, 0, input);

            	    throw nvae_d99s0;
            }

            switch (alt99) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:953:4: '+='
                    {
                    	Match(input,116,FOLLOW_116_in_complex_assignment_operator2888); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Addition; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:954:4: '-='
                    {
                    	Match(input,117,FOLLOW_117_in_complex_assignment_operator2896); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Subtraction; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:955:4: '*='
                    {
                    	Match(input,118,FOLLOW_118_in_complex_assignment_operator2904); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Multiply; 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:956:4: '/='
                    {
                    	Match(input,119,FOLLOW_119_in_complex_assignment_operator2912); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Division; 
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:957:4: '%='
                    {
                    	Match(input,120,FOLLOW_120_in_complex_assignment_operator2920); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.Modulus; 
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:958:4: '&='
                    {
                    	Match(input,121,FOLLOW_121_in_complex_assignment_operator2928); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.BitwiseAnd; 
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:959:4: '|='
                    {
                    	Match(input,122,FOLLOW_122_in_complex_assignment_operator2936); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.BitwiseOr; 
                    	}

                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:960:4: '^='
                    {
                    	Match(input,123,FOLLOW_123_in_complex_assignment_operator2944); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.ExclusiveOr; 
                    	}

                    }
                    break;
                case 9 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:961:4: '<<='
                    {
                    	Match(input,124,FOLLOW_124_in_complex_assignment_operator2952); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.LeftShift; 
                    	}

                    }
                    break;
                case 10 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:962:4: '>>='
                    {
                    	Match(input,125,FOLLOW_125_in_complex_assignment_operator2960); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  Operator.Binary.RightShift; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "complex_assignment_operator"

    public class unary_expression_return : ParserRuleReturnScope
    {
        public Expression value;
    };

    // $ANTLR start "unary_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:965:1: unary_expression returns [Expression value] : ( ( cast_expression )=> cast_expression | postfix_expression ( assignment_operator r1= expression | op= complex_assignment_operator r2= expression | ) | '+' a= postfix_expression | '-' b= postfix_expression | '!' c= postfix_expression | '~' d= postfix_expression | '++' e= postfix_expression | '--' f= postfix_expression );
    public GrammarParser.unary_expression_return unary_expression() // throws RecognitionException [1]
    {   
        GrammarParser.unary_expression_return retval = new GrammarParser.unary_expression_return();
        retval.Start = input.LT(1);

        Expression r1 = default(Expression);

        Operator.Binary op = default(Operator.Binary);

        Expression r2 = default(Expression);

        Expression a = default(Expression);

        Expression b = default(Expression);

        Expression c = default(Expression);

        Expression d = default(Expression);

        Expression e = default(Expression);

        Expression f = default(Expression);

        Expression cast_expression112 = default(Expression);

        Expression postfix_expression113 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:966:2: ( ( cast_expression )=> cast_expression | postfix_expression ( assignment_operator r1= expression | op= complex_assignment_operator r2= expression | ) | '+' a= postfix_expression | '-' b= postfix_expression | '!' c= postfix_expression | '~' d= postfix_expression | '++' e= postfix_expression | '--' f= postfix_expression )
            int alt101 = 8;
            alt101 = dfa101.Predict(input);
            switch (alt101) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:966:4: ( cast_expression )=> cast_expression
                    {
                    	PushFollow(FOLLOW_cast_expression_in_unary_expression2984);
                    	cast_expression112 = cast_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  cast_expression112;
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:970:4: postfix_expression ( assignment_operator r1= expression | op= complex_assignment_operator r2= expression | )
                    {
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression2992);
                    	postfix_expression113 = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:971:3: ( assignment_operator r1= expression | op= complex_assignment_operator r2= expression | )
                    	int alt100 = 3;
                    	switch ( input.LA(1) ) 
                    	{
                    	case 91:
                    		{
                    	    alt100 = 1;
                    	    }
                    	    break;
                    	case 116:
                    	case 117:
                    	case 118:
                    	case 119:
                    	case 120:
                    	case 121:
                    	case 122:
                    	case 123:
                    	case 124:
                    	case 125:
                    		{
                    	    alt100 = 2;
                    	    }
                    	    break;
                    	case EOF:
                    	case SEMI:
                    	case COMMA:
                    	case KW_IS:
                    	case KW_AS:
                    	case 95:
                    	case 97:
                    	case 98:
                    	case 99:
                    	case 100:
                    	case 101:
                    	case 102:
                    	case 103:
                    	case 104:
                    	case 105:
                    	case 106:
                    	case 107:
                    	case 108:
                    	case 109:
                    	case 110:
                    	case 111:
                    	case 112:
                    	case 113:
                    	case 114:
                    	case 115:
                    	case 132:
                    		{
                    	    alt100 = 3;
                    	    }
                    	    break;
                    		default:
                    		    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    		    NoViableAltException nvae_d100s0 =
                    		        new NoViableAltException("", 100, 0, input);

                    		    throw nvae_d100s0;
                    	}

                    	switch (alt100) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:972:4: assignment_operator r1= expression
                    	        {
                    	        	PushFollow(FOLLOW_assignment_operator_in_unary_expression3002);
                    	        	assignment_operator();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	PushFollow(FOLLOW_expression_in_unary_expression3006);
                    	        	r1 = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( (state.backtracking==0) )
                    	        	{

                    	        	  				retval.value =  new Assignment(postfix_expression113, r1);
                    	        	  			
                    	        	}

                    	        }
                    	        break;
                    	    case 2 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:976:6: op= complex_assignment_operator r2= expression
                    	        {
                    	        	PushFollow(FOLLOW_complex_assignment_operator_in_unary_expression3020);
                    	        	op = complex_assignment_operator();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	PushFollow(FOLLOW_expression_in_unary_expression3024);
                    	        	r2 = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( (state.backtracking==0) )
                    	        	{

                    	        	  				retval.value =  new ComplexAssignment(
                    	        	  					op,
                    	        	  					postfix_expression113,
                    	        	  					r2
                    	        	  				);
                    	        	  			
                    	        	}

                    	        }
                    	        break;
                    	    case 3 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:985:4: 
                    	        {
                    	        	if ( (state.backtracking==0) )
                    	        	{

                    	        	  				retval.value =  postfix_expression113;
                    	        	  			
                    	        	}

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:989:4: '+' a= postfix_expression
                    {
                    	Match(input,111,FOLLOW_111_in_unary_expression3050); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3054);
                    	a = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new UnaryExpression(Operator.Unary.Plus, a);
                    	  	
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:993:4: '-' b= postfix_expression
                    {
                    	Match(input,112,FOLLOW_112_in_unary_expression3062); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3066);
                    	b = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new UnaryExpression(Operator.Unary.Negation, b);
                    	  	
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:997:4: '!' c= postfix_expression
                    {
                    	Match(input,126,FOLLOW_126_in_unary_expression3074); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3078);
                    	c = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new UnaryExpression(Operator.Unary.LogicalNot, c);
                    	  	
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1001:4: '~' d= postfix_expression
                    {
                    	Match(input,127,FOLLOW_127_in_unary_expression3086); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3090);
                    	d = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new UnaryExpression(Operator.Unary.OnesComplement, d);
                    	  	
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1005:4: '++' e= postfix_expression
                    {
                    	Match(input,128,FOLLOW_128_in_unary_expression3098); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3102);
                    	e = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new Assignment(
                    	  			e,
                    	  			new BinaryExpression(
                    	  				Operator.Binary.Addition,
                    	  				e,
                    	  				new IntLiteral(1, GetLocation(((IToken)retval.Start)))
                    	  			)
                    	  		);
                    	  	
                    	}

                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1016:4: '--' f= postfix_expression
                    {
                    	Match(input,129,FOLLOW_129_in_unary_expression3110); if (state.failed) return retval;
                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression3114);
                    	f = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new Assignment(
                    	  			f,
                    	  			new BinaryExpression(
                    	  				Operator.Binary.Subtraction,
                    	  				f,
                    	  				new IntLiteral(1, GetLocation(((IToken)retval.Start)))
                    	  			)
                    	  		);
                    	  	
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "unary_expression"


    // $ANTLR start "cast_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1029:1: cast_expression returns [Expression value] : '(' type ')' unary_expression ;
    public Expression cast_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        TypeSignature type114 = default(TypeSignature);

        GrammarParser.unary_expression_return unary_expression115 = default(GrammarParser.unary_expression_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1030:2: ( '(' type ')' unary_expression )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1030:4: '(' type ')' unary_expression
            {
            	Match(input,94,FOLLOW_94_in_cast_expression3132); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_cast_expression3134);
            	type114 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,95,FOLLOW_95_in_cast_expression3136); if (state.failed) return value;
            	PushFollow(FOLLOW_unary_expression_in_cast_expression3138);
            	unary_expression115 = unary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new ExplicitCastExpression(type114, ((unary_expression115 != null) ? unary_expression115.value : default(Expression)));
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "cast_expression"


    // $ANTLR start "postfix_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1036:1: postfix_expression returns [Expression value] : primary_expression ( options {backtrack=true; } : '.' a= identifier ( ( '(' )=> '(' (b= expressions_list )? ')' | ) | '[' c= expressions_list ']' )* ;
    public Expression postfix_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        GrammarParser.identifier_return a = default(GrammarParser.identifier_return);

        IList<Expression> b = default(IList<Expression>);

        IList<Expression> c = default(IList<Expression>);

        GrammarParser.primary_expression_return primary_expression116 = default(GrammarParser.primary_expression_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1037:2: ( primary_expression ( options {backtrack=true; } : '.' a= identifier ( ( '(' )=> '(' (b= expressions_list )? ')' | ) | '[' c= expressions_list ']' )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1037:4: primary_expression ( options {backtrack=true; } : '.' a= identifier ( ( '(' )=> '(' (b= expressions_list )? ')' | ) | '[' c= expressions_list ']' )*
            {
            	PushFollow(FOLLOW_primary_expression_in_postfix_expression3156);
            	primary_expression116 = primary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  ((primary_expression116 != null) ? primary_expression116.value : default(Expression));
            	  	
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1041:3: ( options {backtrack=true; } : '.' a= identifier ( ( '(' )=> '(' (b= expressions_list )? ')' | ) | '[' c= expressions_list ']' )*
            	do 
            	{
            	    int alt104 = 3;
            	    int LA104_0 = input.LA(1);

            	    if ( (LA104_0 == 130) )
            	    {
            	        alt104 = 1;
            	    }
            	    else if ( (LA104_0 == 131) )
            	    {
            	        alt104 = 2;
            	    }


            	    switch (alt104) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1042:4: '.' a= identifier ( ( '(' )=> '(' (b= expressions_list )? ')' | )
            			    {
            			    	Match(input,130,FOLLOW_130_in_postfix_expression3181); if (state.failed) return value;
            			    	PushFollow(FOLLOW_identifier_in_postfix_expression3185);
            			    	a = identifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1043:5: ( ( '(' )=> '(' (b= expressions_list )? ')' | )
            			    	int alt103 = 2;
            			    	int LA103_0 = input.LA(1);

            			    	if ( (LA103_0 == 94) && (synpred13_Grammar()) )
            			    	{
            			    	    alt103 = 1;
            			    	}
            			    	else if ( (LA103_0 == EOF || LA103_0 == SEMI || LA103_0 == COMMA || (LA103_0 >= KW_IS && LA103_0 <= KW_AS) || LA103_0 == 91 || LA103_0 == 95 || (LA103_0 >= 97 && LA103_0 <= 125) || (LA103_0 >= 130 && LA103_0 <= 132)) )
            			    	{
            			    	    alt103 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            			    	    NoViableAltException nvae_d103s0 =
            			    	        new NoViableAltException("", 103, 0, input);

            			    	    throw nvae_d103s0;
            			    	}
            			    	switch (alt103) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1044:6: ( '(' )=> '(' (b= expressions_list )? ')'
            			    	        {
            			    	        	Match(input,94,FOLLOW_94_in_postfix_expression3204); if (state.failed) return value;
            			    	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1044:20: (b= expressions_list )?
            			    	        	int alt102 = 2;
            			    	        	int LA102_0 = input.LA(1);

            			    	        	if ( ((LA102_0 >= KW_NEW && LA102_0 <= KW_BASE) || (LA102_0 >= KW_GLOBAL && LA102_0 <= KW_TYPEOF) || LA102_0 == ID || (LA102_0 >= LITERAL_INTEGER && LA102_0 <= KW_NULL) || LA102_0 == 94 || (LA102_0 >= 111 && LA102_0 <= 112) || (LA102_0 >= 126 && LA102_0 <= 129)) )
            			    	        	{
            			    	        	    alt102 = 1;
            			    	        	}
            			    	        	switch (alt102) 
            			    	        	{
            			    	        	    case 1 :
            			    	        	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1044:20: b= expressions_list
            			    	        	        {
            			    	        	        	PushFollow(FOLLOW_expressions_list_in_postfix_expression3208);
            			    	        	        	b = expressions_list();
            			    	        	        	state.followingStackPointer--;
            			    	        	        	if (state.failed) return value;

            			    	        	        }
            			    	        	        break;

            			    	        	}

            			    	        	Match(input,95,FOLLOW_95_in_postfix_expression3211); if (state.failed) return value;
            			    	        	if ( (state.backtracking==0) )
            			    	        	{

            			    	        	  						value =  new MethodCallExpression(value, ((a != null) ? a.value : default(Identifier)), b);
            			    	        	  					
            			    	        	}

            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1049:6: 
            			    	        {
            			    	        	if ( (state.backtracking==0) )
            			    	        	{

            			    	        	  						value =  new DottedExpression(value, ((a != null) ? a.value : default(Identifier)));
            			    	        	  					
            			    	        	}

            			    	        }
            			    	        break;

            			    	}


            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1053:6: '[' c= expressions_list ']'
            			    {
            			    	Match(input,131,FOLLOW_131_in_postfix_expression3248); if (state.failed) return value;
            			    	PushFollow(FOLLOW_expressions_list_in_postfix_expression3252);
            			    	c = expressions_list();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	Match(input,132,FOLLOW_132_in_postfix_expression3254); if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  				value =  new ArrayAccessExpression(value, c);
            			    	  			
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop104;
            	    }
            	} while (true);

            	loop104:
            		;	// Stops C# compiler whining that label 'loop104' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "postfix_expression"

    public class primary_expression_return : ParserRuleReturnScope
    {
        public Expression value;
    };

    // $ANTLR start "primary_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1066:1: primary_expression returns [Expression value] : ( array_creation_expression | object_creation_expression | KW_THIS | KW_BASE | KW_GLOBAL | identifier ( ( '(' )=> '(' (f= expressions_list )? ')' | ) | literal | typeof_expression | '(' expression ')' );
    public GrammarParser.primary_expression_return primary_expression() // throws RecognitionException [1]
    {   
        GrammarParser.primary_expression_return retval = new GrammarParser.primary_expression_return();
        retval.Start = input.LT(1);

        IList<Expression> f = default(IList<Expression>);

        Expression array_creation_expression117 = default(Expression);

        Expression object_creation_expression118 = default(Expression);

        GrammarParser.identifier_return identifier119 = default(GrammarParser.identifier_return);

        GrammarParser.literal_return literal120 = default(GrammarParser.literal_return);

        Expression typeof_expression121 = default(Expression);

        Expression expression122 = default(Expression);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1067:2: ( array_creation_expression | object_creation_expression | KW_THIS | KW_BASE | KW_GLOBAL | identifier ( ( '(' )=> '(' (f= expressions_list )? ')' | ) | literal | typeof_expression | '(' expression ')' )
            int alt107 = 9;
            alt107 = dfa107.Predict(input);
            switch (alt107) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1067:4: array_creation_expression
                    {
                    	PushFollow(FOLLOW_array_creation_expression_in_primary_expression3284);
                    	array_creation_expression117 = array_creation_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  array_creation_expression117;
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1072:4: object_creation_expression
                    {
                    	PushFollow(FOLLOW_object_creation_expression_in_primary_expression3294);
                    	object_creation_expression118 = object_creation_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  object_creation_expression118;
                    	  	
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1077:4: KW_THIS
                    {
                    	Match(input,KW_THIS,FOLLOW_KW_THIS_in_primary_expression3303); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new AnyExpression(((IToken)retval.Start).Text, GetLocation(((IToken)retval.Start)));
                    	  	
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1082:4: KW_BASE
                    {
                    	Match(input,KW_BASE,FOLLOW_KW_BASE_in_primary_expression3312); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new AnyExpression(((IToken)retval.Start).Text, GetLocation(((IToken)retval.Start)));
                    	  	
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1087:4: KW_GLOBAL
                    {
                    	Match(input,KW_GLOBAL,FOLLOW_KW_GLOBAL_in_primary_expression3321); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new AnyExpression(((IToken)retval.Start).Text, GetLocation(((IToken)retval.Start))); // do poprawy
                    	  	
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1092:4: identifier ( ( '(' )=> '(' (f= expressions_list )? ')' | )
                    {
                    	PushFollow(FOLLOW_identifier_in_primary_expression3330);
                    	identifier119 = identifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1093:3: ( ( '(' )=> '(' (f= expressions_list )? ')' | )
                    	int alt106 = 2;
                    	int LA106_0 = input.LA(1);

                    	if ( (LA106_0 == 94) && (synpred16_Grammar()) )
                    	{
                    	    alt106 = 1;
                    	}
                    	else if ( (LA106_0 == EOF || LA106_0 == SEMI || LA106_0 == COMMA || (LA106_0 >= KW_IS && LA106_0 <= KW_AS) || LA106_0 == 91 || LA106_0 == 95 || (LA106_0 >= 97 && LA106_0 <= 125) || (LA106_0 >= 130 && LA106_0 <= 132)) )
                    	{
                    	    alt106 = 2;
                    	}
                    	else 
                    	{
                    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    	    NoViableAltException nvae_d106s0 =
                    	        new NoViableAltException("", 106, 0, input);

                    	    throw nvae_d106s0;
                    	}
                    	switch (alt106) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1094:4: ( '(' )=> '(' (f= expressions_list )? ')'
                    	        {
                    	        	Match(input,94,FOLLOW_94_in_primary_expression3344); if (state.failed) return retval;
                    	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1094:17: (f= expressions_list )?
                    	        	int alt105 = 2;
                    	        	int LA105_0 = input.LA(1);

                    	        	if ( ((LA105_0 >= KW_NEW && LA105_0 <= KW_BASE) || (LA105_0 >= KW_GLOBAL && LA105_0 <= KW_TYPEOF) || LA105_0 == ID || (LA105_0 >= LITERAL_INTEGER && LA105_0 <= KW_NULL) || LA105_0 == 94 || (LA105_0 >= 111 && LA105_0 <= 112) || (LA105_0 >= 126 && LA105_0 <= 129)) )
                    	        	{
                    	        	    alt105 = 1;
                    	        	}
                    	        	switch (alt105) 
                    	        	{
                    	        	    case 1 :
                    	        	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1094:17: f= expressions_list
                    	        	        {
                    	        	        	PushFollow(FOLLOW_expressions_list_in_primary_expression3348);
                    	        	        	f = expressions_list();
                    	        	        	state.followingStackPointer--;
                    	        	        	if (state.failed) return retval;

                    	        	        }
                    	        	        break;

                    	        	}

                    	        	Match(input,95,FOLLOW_95_in_primary_expression3351); if (state.failed) return retval;
                    	        	if ( (state.backtracking==0) )
                    	        	{

                    	        	  				retval.value =  new MethodCallExpression(null, ((identifier119 != null) ? identifier119.value : default(Identifier)), f); // zeby wywolac metode musze znac jej nazwe, ta produkcja to jest wyjatek
                    	        	  			
                    	        	}

                    	        }
                    	        break;
                    	    case 2 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1099:4: 
                    	        {
                    	        	if ( (state.backtracking==0) )
                    	        	{

                    	        	  				retval.value =  new AnyExpression(((identifier119 != null) ? identifier119.value : default(Identifier)));
                    	        	  			
                    	        	}

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1104:4: literal
                    {
                    	PushFollow(FOLLOW_literal_in_primary_expression3379);
                    	literal120 = literal();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  ((literal120 != null) ? literal120.value : default(Expression));
                    	  	
                    	}

                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1109:4: typeof_expression
                    {
                    	PushFollow(FOLLOW_typeof_expression_in_primary_expression3388);
                    	typeof_expression121 = typeof_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  typeof_expression121;
                    	  	
                    	}

                    }
                    break;
                case 9 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1114:4: '(' expression ')'
                    {
                    	Match(input,94,FOLLOW_94_in_primary_expression3397); if (state.failed) return retval;
                    	PushFollow(FOLLOW_expression_in_primary_expression3399);
                    	expression122 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	Match(input,95,FOLLOW_95_in_primary_expression3401); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  expression122;
                    	  	
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "primary_expression"


    // $ANTLR start "typeof_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1120:1: typeof_expression returns [Expression value] : ( KW_TYPEOF '(' type ')' | KW_TYPEOF '(' KW_VOID ')' );
    public Expression typeof_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        TypeSignature type123 = default(TypeSignature);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1121:2: ( KW_TYPEOF '(' type ')' | KW_TYPEOF '(' KW_VOID ')' )
            int alt108 = 2;
            int LA108_0 = input.LA(1);

            if ( (LA108_0 == KW_TYPEOF) )
            {
                int LA108_1 = input.LA(2);

                if ( (LA108_1 == 94) )
                {
                    int LA108_2 = input.LA(3);

                    if ( (LA108_2 == KW_VOID) )
                    {
                        alt108 = 2;
                    }
                    else if ( ((LA108_2 >= ID && LA108_2 <= KW_ULONG)) )
                    {
                        alt108 = 1;
                    }
                    else 
                    {
                        if ( state.backtracking > 0 ) {state.failed = true; return value;}
                        NoViableAltException nvae_d108s2 =
                            new NoViableAltException("", 108, 2, input);

                        throw nvae_d108s2;
                    }
                }
                else 
                {
                    if ( state.backtracking > 0 ) {state.failed = true; return value;}
                    NoViableAltException nvae_d108s1 =
                        new NoViableAltException("", 108, 1, input);

                    throw nvae_d108s1;
                }
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d108s0 =
                    new NoViableAltException("", 108, 0, input);

                throw nvae_d108s0;
            }
            switch (alt108) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1121:4: KW_TYPEOF '(' type ')'
                    {
                    	Match(input,KW_TYPEOF,FOLLOW_KW_TYPEOF_in_typeof_expression3419); if (state.failed) return value;
                    	Match(input,94,FOLLOW_94_in_typeof_expression3421); if (state.failed) return value;
                    	PushFollow(FOLLOW_type_in_typeof_expression3423);
                    	type123 = type();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	Match(input,95,FOLLOW_95_in_typeof_expression3425); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		value =  new TypeOfExpression(type123);
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1126:4: KW_TYPEOF '(' KW_VOID ')'
                    {
                    	Match(input,KW_TYPEOF,FOLLOW_KW_TYPEOF_in_typeof_expression3434); if (state.failed) return value;
                    	Match(input,94,FOLLOW_94_in_typeof_expression3436); if (state.failed) return value;
                    	Match(input,KW_VOID,FOLLOW_KW_VOID_in_typeof_expression3438); if (state.failed) return value;
                    	Match(input,95,FOLLOW_95_in_typeof_expression3440); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		value =  new TypeOfExpression(new ResolvedType(Types.GetType("Void")));
                    	  	
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "typeof_expression"


    // $ANTLR start "typename_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1132:1: typename_expression returns [Expression value] : a= identifier ( '.' b= identifier )* ;
    public Expression typename_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        GrammarParser.identifier_return a = default(GrammarParser.identifier_return);

        GrammarParser.identifier_return b = default(GrammarParser.identifier_return);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1133:2: (a= identifier ( '.' b= identifier )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1133:4: a= identifier ( '.' b= identifier )*
            {
            	PushFollow(FOLLOW_identifier_in_typename_expression3460);
            	a = identifier();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new AnyExpression(((a != null) ? a.value : default(Identifier)));
            	  	
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1137:3: ( '.' b= identifier )*
            	do 
            	{
            	    int alt109 = 2;
            	    int LA109_0 = input.LA(1);

            	    if ( (LA109_0 == 130) )
            	    {
            	        alt109 = 1;
            	    }


            	    switch (alt109) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1137:4: '.' b= identifier
            			    {
            			    	Match(input,130,FOLLOW_130_in_typename_expression3468); if (state.failed) return value;
            			    	PushFollow(FOLLOW_identifier_in_typename_expression3472);
            			    	b = identifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{

            			    	  			value =  new DottedExpression(value, ((b != null) ? b.value : default(Identifier)));
            			    	  		
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop109;
            	    }
            	} while (true);

            	loop109:
            		;	// Stops C# compiler whining that label 'loop109' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "typename_expression"


    // $ANTLR start "object_creation_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1143:1: object_creation_expression returns [Expression value] : KW_NEW type '(' ( expressions_list )? ')' ;
    public Expression object_creation_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        TypeSignature type124 = default(TypeSignature);

        IList<Expression> expressions_list125 = default(IList<Expression>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1144:2: ( KW_NEW type '(' ( expressions_list )? ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1144:4: KW_NEW type '(' ( expressions_list )? ')'
            {
            	Match(input,KW_NEW,FOLLOW_KW_NEW_in_object_creation_expression3493); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_object_creation_expression3495);
            	type124 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,94,FOLLOW_94_in_object_creation_expression3497); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1144:20: ( expressions_list )?
            	int alt110 = 2;
            	int LA110_0 = input.LA(1);

            	if ( ((LA110_0 >= KW_NEW && LA110_0 <= KW_BASE) || (LA110_0 >= KW_GLOBAL && LA110_0 <= KW_TYPEOF) || LA110_0 == ID || (LA110_0 >= LITERAL_INTEGER && LA110_0 <= KW_NULL) || LA110_0 == 94 || (LA110_0 >= 111 && LA110_0 <= 112) || (LA110_0 >= 126 && LA110_0 <= 129)) )
            	{
            	    alt110 = 1;
            	}
            	switch (alt110) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1144:20: expressions_list
            	        {
            	        	PushFollow(FOLLOW_expressions_list_in_object_creation_expression3499);
            	        	expressions_list125 = expressions_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,95,FOLLOW_95_in_object_creation_expression3502); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new NewObjectExpression(type124, expressions_list125);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "object_creation_expression"


    // $ANTLR start "array_creation_expression"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1150:1: array_creation_expression returns [Expression value] : KW_NEW type '[' expressions_list ']' ;
    public Expression array_creation_expression() // throws RecognitionException [1]
    {   
        Expression value = default(Expression);

        TypeSignature type126 = default(TypeSignature);

        IList<Expression> expressions_list127 = default(IList<Expression>);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1151:2: ( KW_NEW type '[' expressions_list ']' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1151:4: KW_NEW type '[' expressions_list ']'
            {
            	Match(input,KW_NEW,FOLLOW_KW_NEW_in_array_creation_expression3520); if (state.failed) return value;
            	PushFollow(FOLLOW_type_in_array_creation_expression3522);
            	type126 = type();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,131,FOLLOW_131_in_array_creation_expression3524); if (state.failed) return value;
            	PushFollow(FOLLOW_expressions_list_in_array_creation_expression3526);
            	expressions_list127 = expressions_list();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	Match(input,132,FOLLOW_132_in_array_creation_expression3528); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		value =  new NewArrayExpression(type126, expressions_list127);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "array_creation_expression"


    // $ANTLR start "expressions_list"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1157:1: expressions_list returns [IList<Expression> value] : head= expression ( COMMA tail= expression )* ;
    public IList<Expression> expressions_list() // throws RecognitionException [1]
    {   
        IList<Expression> value = default(IList<Expression>);

        Expression head = default(Expression);

        Expression tail = default(Expression);



        	value =  new List<Expression>();

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1161:2: (head= expression ( COMMA tail= expression )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1161:4: head= expression ( COMMA tail= expression )*
            {
            	PushFollow(FOLLOW_expression_in_expressions_list3553);
            	head = expression();
            	state.followingStackPointer--;
            	if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{
            	   value.Add(head); 
            	}
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1162:2: ( COMMA tail= expression )*
            	do 
            	{
            	    int alt111 = 2;
            	    int LA111_0 = input.LA(1);

            	    if ( (LA111_0 == COMMA) )
            	    {
            	        alt111 = 1;
            	    }


            	    switch (alt111) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1162:3: COMMA tail= expression
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_expressions_list3559); if (state.failed) return value;
            			    	PushFollow(FOLLOW_expression_in_expressions_list3563);
            			    	tail = expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   value.Add(tail); 
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop111;
            	    }
            	} while (true);

            	loop111:
            		;	// Stops C# compiler whining that label 'loop111' has no statements


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "expressions_list"


    // $ANTLR start "access_modifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1165:1: access_modifier returns [AccessModifier value] : ( KW_PUBLIC | KW_FAMILY | KW_PRIVATE | KW_INTERNAL );
    public AccessModifier access_modifier() // throws RecognitionException [1]
    {   
        AccessModifier value = default(AccessModifier);

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1166:2: ( KW_PUBLIC | KW_FAMILY | KW_PRIVATE | KW_INTERNAL )
            int alt112 = 4;
            switch ( input.LA(1) ) 
            {
            case KW_PUBLIC:
            	{
                alt112 = 1;
                }
                break;
            case KW_FAMILY:
            	{
                alt112 = 2;
                }
                break;
            case KW_PRIVATE:
            	{
                alt112 = 3;
                }
                break;
            case KW_INTERNAL:
            	{
                alt112 = 4;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            	    NoViableAltException nvae_d112s0 =
            	        new NoViableAltException("", 112, 0, input);

            	    throw nvae_d112s0;
            }

            switch (alt112) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1166:4: KW_PUBLIC
                    {
                    	Match(input,KW_PUBLIC,FOLLOW_KW_PUBLIC_in_access_modifier3583); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  AccessModifier.PUBLIC; 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1167:4: KW_FAMILY
                    {
                    	Match(input,KW_FAMILY,FOLLOW_KW_FAMILY_in_access_modifier3591); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  AccessModifier.FAMILY; 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1168:4: KW_PRIVATE
                    {
                    	Match(input,KW_PRIVATE,FOLLOW_KW_PRIVATE_in_access_modifier3599); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  AccessModifier.PRIVATE; 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1169:4: KW_INTERNAL
                    {
                    	Match(input,KW_INTERNAL,FOLLOW_KW_INTERNAL_in_access_modifier3606); if (state.failed) return value;
                    	if ( (state.backtracking==0) )
                    	{
                    	   value =  AccessModifier.ASSEMBLY; 
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "access_modifier"


    // $ANTLR start "access_scope_directive"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1172:1: access_scope_directive : access_modifier ':' ;
    public void access_scope_directive() // throws RecognitionException [1]
    {   
        AccessModifier access_modifier128 = default(AccessModifier);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1173:2: ( access_modifier ':' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1173:4: access_modifier ':'
            {
            	PushFollow(FOLLOW_access_modifier_in_access_scope_directive3619);
            	access_modifier128 = access_modifier();
            	state.followingStackPointer--;
            	if (state.failed) return ;
            	Match(input,96,FOLLOW_96_in_access_scope_directive3621); if (state.failed) return ;
            	if ( (state.backtracking==0) )
            	{

            	  		access_scope.Set(access_modifier128);
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "access_scope_directive"

    public class identifier_return : ParserRuleReturnScope
    {
        public Identifier value;
    };

    // $ANTLR start "identifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1179:1: identifier returns [Identifier value] : ID ;
    public GrammarParser.identifier_return identifier() // throws RecognitionException [1]
    {   
        GrammarParser.identifier_return retval = new GrammarParser.identifier_return();
        retval.Start = input.LT(1);

        IToken ID129 = null;

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1180:2: ( ID )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1180:4: ID
            {
            	ID129=(IToken)Match(input,ID,FOLLOW_ID_in_identifier3639); if (state.failed) return retval;
            	if ( (state.backtracking==0) )
            	{
            	  	
            	  		retval.value =  new Identifier(((ID129 != null) ? ID129.Text : null), GetLocation(((IToken)retval.Start)));
            	  	
            	}

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "identifier"


    // $ANTLR start "type"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1186:1: type returns [TypeSignature value] : ( primitive_type ( array_specifier )? | t= typename_expression ( array_specifier )? );
    public TypeSignature type() // throws RecognitionException [1]
    {   
        TypeSignature value = default(TypeSignature);

        Expression t = default(Expression);

        object array_specifier130 = default(object);

        GrammarParser.primitive_type_return primitive_type131 = default(GrammarParser.primitive_type_return);

        object array_specifier132 = default(object);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1187:2: ( primitive_type ( array_specifier )? | t= typename_expression ( array_specifier )? )
            int alt115 = 2;
            int LA115_0 = input.LA(1);

            if ( ((LA115_0 >= KW_CHAR && LA115_0 <= KW_ULONG)) )
            {
                alt115 = 1;
            }
            else if ( (LA115_0 == ID) )
            {
                alt115 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return value;}
                NoViableAltException nvae_d115s0 =
                    new NoViableAltException("", 115, 0, input);

                throw nvae_d115s0;
            }
            switch (alt115) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1187:4: primitive_type ( array_specifier )?
                    {
                    	PushFollow(FOLLOW_primitive_type_in_type3657);
                    	primitive_type131 = primitive_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1187:19: ( array_specifier )?
                    	int alt113 = 2;
                    	int LA113_0 = input.LA(1);

                    	if ( (LA113_0 == 131) )
                    	{
                    	    int LA113_1 = input.LA(2);

                    	    if ( (LA113_1 == COMMA || LA113_1 == 132) )
                    	    {
                    	        alt113 = 1;
                    	    }
                    	}
                    	switch (alt113) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1187:19: array_specifier
                    	        {
                    	        	PushFollow(FOLLOW_array_specifier_in_type3659);
                    	        	array_specifier130 = array_specifier();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return value;

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{

                    	  		if (array_specifier130 != null)
                    	  			value =  new ArrayType(((primitive_type131 != null) ? primitive_type131.value : default(TypeSignature)), (int)array_specifier130);
                    	  		else
                    	  			value =  ((primitive_type131 != null) ? primitive_type131.value : default(TypeSignature));
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1195:4: t= typename_expression ( array_specifier )?
                    {
                    	PushFollow(FOLLOW_typename_expression_in_type3671);
                    	t = typename_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return value;
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1195:26: ( array_specifier )?
                    	int alt114 = 2;
                    	int LA114_0 = input.LA(1);

                    	if ( (LA114_0 == 131) )
                    	{
                    	    int LA114_1 = input.LA(2);

                    	    if ( (LA114_1 == COMMA || LA114_1 == 132) )
                    	    {
                    	        alt114 = 1;
                    	    }
                    	}
                    	switch (alt114) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1195:26: array_specifier
                    	        {
                    	        	PushFollow(FOLLOW_array_specifier_in_type3673);
                    	        	array_specifier132 = array_specifier();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return value;

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{

                    	  		TypeSignature base_type = new TypeName(t);
                    	  		if (array_specifier132 != null)
                    	  			value =  new ArrayType(base_type, (int)array_specifier132);
                    	  		else
                    	  			value =  base_type;
                    	  	
                    	}

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "type"


    // $ANTLR start "array_specifier"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1205:1: array_specifier returns [object value] : '[' ( array_rank_declaration )? ']' ;
    public object array_specifier() // throws RecognitionException [1]
    {   
        object value = default(object);

        object array_rank_declaration133 = default(object);


        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1206:2: ( '[' ( array_rank_declaration )? ']' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1206:4: '[' ( array_rank_declaration )? ']'
            {
            	Match(input,131,FOLLOW_131_in_array_specifier3693); if (state.failed) return value;
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1206:8: ( array_rank_declaration )?
            	int alt116 = 2;
            	int LA116_0 = input.LA(1);

            	if ( (LA116_0 == COMMA) )
            	{
            	    alt116 = 1;
            	}
            	switch (alt116) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1206:8: array_rank_declaration
            	        {
            	        	PushFollow(FOLLOW_array_rank_declaration_in_array_specifier3695);
            	        	array_rank_declaration133 = array_rank_declaration();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return value;

            	        }
            	        break;

            	}

            	Match(input,132,FOLLOW_132_in_array_specifier3698); if (state.failed) return value;
            	if ( (state.backtracking==0) )
            	{

            	  		if (array_rank_declaration133 != null)
            	  			value =  array_rank_declaration133;
            	  		else
            	  			value =  1; // dopasowano [], wiec jeden wymiar
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "array_specifier"


    // $ANTLR start "array_rank_declaration"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1215:1: array_rank_declaration returns [object value] : ( COMMA )+ ;
    public object array_rank_declaration() // throws RecognitionException [1]
    {   
        object value = default(object);


        	int rank = 1;

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1219:2: ( ( COMMA )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1219:4: ( COMMA )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1219:4: ( COMMA )+
            	int cnt117 = 0;
            	do 
            	{
            	    int alt117 = 2;
            	    int LA117_0 = input.LA(1);

            	    if ( (LA117_0 == COMMA) )
            	    {
            	        alt117 = 1;
            	    }


            	    switch (alt117) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1219:5: COMMA
            			    {
            			    	Match(input,COMMA,FOLLOW_COMMA_in_array_rank_declaration3722); if (state.failed) return value;
            			    	if ( (state.backtracking==0) )
            			    	{
            			    	   ++rank; 
            			    	}

            			    }
            			    break;

            			default:
            			    if ( cnt117 >= 1 ) goto loop117;
            			    if ( state.backtracking > 0 ) {state.failed = true; return value;}
            		            EarlyExitException eee117 =
            		                new EarlyExitException(117, input);
            		            throw eee117;
            	    }
            	    cnt117++;
            	} while (true);

            	loop117:
            		;	// Stops C# compiler whining that label 'loop117' has no statements

            	if ( (state.backtracking==0) )
            	{

            	  		value =  rank;
            	  	
            	}

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "array_rank_declaration"

    public class primitive_type_return : ParserRuleReturnScope
    {
        public TypeSignature value;
    };

    // $ANTLR start "primitive_type"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1225:1: primitive_type returns [TypeSignature value] : ( primitive_integral_type | KW_CHAR | KW_BOOL | KW_FLOAT | KW_DOUBLE | KW_STRING | KW_OBJECT );
    public GrammarParser.primitive_type_return primitive_type() // throws RecognitionException [1]
    {   
        GrammarParser.primitive_type_return retval = new GrammarParser.primitive_type_return();
        retval.Start = input.LT(1);

        GrammarParser.primitive_integral_type_return primitive_integral_type134 = default(GrammarParser.primitive_integral_type_return);



        	Location loc = GetLocation(((IToken)retval.Start));

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1229:2: ( primitive_integral_type | KW_CHAR | KW_BOOL | KW_FLOAT | KW_DOUBLE | KW_STRING | KW_OBJECT )
            int alt118 = 7;
            switch ( input.LA(1) ) 
            {
            case KW_BYTE:
            case KW_SBYTE:
            case KW_SHORT:
            case KW_USHORT:
            case KW_INT:
            case KW_UINT:
            case KW_LONG:
            case KW_ULONG:
            	{
                alt118 = 1;
                }
                break;
            case KW_CHAR:
            	{
                alt118 = 2;
                }
                break;
            case KW_BOOL:
            	{
                alt118 = 3;
                }
                break;
            case KW_FLOAT:
            	{
                alt118 = 4;
                }
                break;
            case KW_DOUBLE:
            	{
                alt118 = 5;
                }
                break;
            case KW_STRING:
            	{
                alt118 = 6;
                }
                break;
            case KW_OBJECT:
            	{
                alt118 = 7;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d118s0 =
            	        new NoViableAltException("", 118, 0, input);

            	    throw nvae_d118s0;
            }

            switch (alt118) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1229:4: primitive_integral_type
                    {
                    	PushFollow(FOLLOW_primitive_integral_type_in_primitive_type3749);
                    	primitive_integral_type134 = primitive_integral_type();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  ((primitive_integral_type134 != null) ? primitive_integral_type134.value : default(TypeSignature)); 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1230:4: KW_CHAR
                    {
                    	Match(input,KW_CHAR,FOLLOW_KW_CHAR_in_primitive_type3756); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Char"), loc); 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1231:4: KW_BOOL
                    {
                    	Match(input,KW_BOOL,FOLLOW_KW_BOOL_in_primitive_type3764); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Boolean"), loc); 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1232:4: KW_FLOAT
                    {
                    	Match(input,KW_FLOAT,FOLLOW_KW_FLOAT_in_primitive_type3772); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Single"), loc); 
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1233:4: KW_DOUBLE
                    {
                    	Match(input,KW_DOUBLE,FOLLOW_KW_DOUBLE_in_primitive_type3780); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Double"), loc); 
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1234:4: KW_STRING
                    {
                    	Match(input,KW_STRING,FOLLOW_KW_STRING_in_primitive_type3788); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("String"), loc); 
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1235:4: KW_OBJECT
                    {
                    	Match(input,KW_OBJECT,FOLLOW_KW_OBJECT_in_primitive_type3796); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Object"), loc); 
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "primitive_type"

    public class primitive_integral_type_return : ParserRuleReturnScope
    {
        public TypeSignature value;
    };

    // $ANTLR start "primitive_integral_type"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1238:1: primitive_integral_type returns [TypeSignature value] : ( KW_BYTE | KW_SBYTE | KW_SHORT | KW_USHORT | KW_INT | KW_UINT | KW_LONG | KW_ULONG );
    public GrammarParser.primitive_integral_type_return primitive_integral_type() // throws RecognitionException [1]
    {   
        GrammarParser.primitive_integral_type_return retval = new GrammarParser.primitive_integral_type_return();
        retval.Start = input.LT(1);


        	Location loc = GetLocation(((IToken)retval.Start));

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1242:2: ( KW_BYTE | KW_SBYTE | KW_SHORT | KW_USHORT | KW_INT | KW_UINT | KW_LONG | KW_ULONG )
            int alt119 = 8;
            switch ( input.LA(1) ) 
            {
            case KW_BYTE:
            	{
                alt119 = 1;
                }
                break;
            case KW_SBYTE:
            	{
                alt119 = 2;
                }
                break;
            case KW_SHORT:
            	{
                alt119 = 3;
                }
                break;
            case KW_USHORT:
            	{
                alt119 = 4;
                }
                break;
            case KW_INT:
            	{
                alt119 = 5;
                }
                break;
            case KW_UINT:
            	{
                alt119 = 6;
                }
                break;
            case KW_LONG:
            	{
                alt119 = 7;
                }
                break;
            case KW_ULONG:
            	{
                alt119 = 8;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d119s0 =
            	        new NoViableAltException("", 119, 0, input);

            	    throw nvae_d119s0;
            }

            switch (alt119) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1242:4: KW_BYTE
                    {
                    	Match(input,KW_BYTE,FOLLOW_KW_BYTE_in_primitive_integral_type3819); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Byte"), loc); 
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1243:4: KW_SBYTE
                    {
                    	Match(input,KW_SBYTE,FOLLOW_KW_SBYTE_in_primitive_integral_type3827); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("SByte"), loc); 
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1244:4: KW_SHORT
                    {
                    	Match(input,KW_SHORT,FOLLOW_KW_SHORT_in_primitive_integral_type3835); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Int16"), loc); 
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1245:4: KW_USHORT
                    {
                    	Match(input,KW_USHORT,FOLLOW_KW_USHORT_in_primitive_integral_type3843); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("UInt16"), loc); 
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1246:4: KW_INT
                    {
                    	Match(input,KW_INT,FOLLOW_KW_INT_in_primitive_integral_type3851); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Int32"), loc); 
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1247:4: KW_UINT
                    {
                    	Match(input,KW_UINT,FOLLOW_KW_UINT_in_primitive_integral_type3859); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("UInt32"), loc); 
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1248:4: KW_LONG
                    {
                    	Match(input,KW_LONG,FOLLOW_KW_LONG_in_primitive_integral_type3867); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("Int64"), loc); 
                    	}

                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1249:4: KW_ULONG
                    {
                    	Match(input,KW_ULONG,FOLLOW_KW_ULONG_in_primitive_integral_type3875); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{
                    	   retval.value =  new ResolvedType(Types.GetType("UInt64"), loc); 
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "primitive_integral_type"

    public class literal_return : ParserRuleReturnScope
    {
        public Expression value;
    };

    // $ANTLR start "literal"
    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1252:1: literal returns [Expression value] : ( LITERAL_INTEGER | LITERAL_REAL | LITERAL_CHAR | LITERAL_STRING | KW_TRUE | KW_FALSE | KW_NULL );
    public GrammarParser.literal_return literal() // throws RecognitionException [1]
    {   
        GrammarParser.literal_return retval = new GrammarParser.literal_return();
        retval.Start = input.LT(1);


        	IToken token = ((IToken)retval.Start);
        	Location loc = GetLocation(token);
        	string text = token.Text;

        try 
    	{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1258:2: ( LITERAL_INTEGER | LITERAL_REAL | LITERAL_CHAR | LITERAL_STRING | KW_TRUE | KW_FALSE | KW_NULL )
            int alt120 = 7;
            switch ( input.LA(1) ) 
            {
            case LITERAL_INTEGER:
            	{
                alt120 = 1;
                }
                break;
            case LITERAL_REAL:
            	{
                alt120 = 2;
                }
                break;
            case LITERAL_CHAR:
            	{
                alt120 = 3;
                }
                break;
            case LITERAL_STRING:
            	{
                alt120 = 4;
                }
                break;
            case KW_TRUE:
            	{
                alt120 = 5;
                }
                break;
            case KW_FALSE:
            	{
                alt120 = 6;
                }
                break;
            case KW_NULL:
            	{
                alt120 = 7;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d120s0 =
            	        new NoViableAltException("", 120, 0, input);

            	    throw nvae_d120s0;
            }

            switch (alt120) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1258:4: LITERAL_INTEGER
                    {
                    	Match(input,LITERAL_INTEGER,FOLLOW_LITERAL_INTEGER_in_literal3898); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
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
                    	  				retval.value =  new ULongLiteral(literal_value, loc);
                    	  			}
                    	  			else
                    	  			{
                    	  				if (literal_value >= byte.MinValue && literal_value <= byte.MaxValue)
                    	  				{
                    	  					retval.value =  new ByteLiteral((byte)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= ushort.MinValue && literal_value <= ushort.MaxValue)
                    	  				{
                    	  					retval.value =  new UShortLiteral((ushort)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= uint.MinValue && literal_value <= uint.MaxValue)
                    	  				{
                    	  					retval.value =  new UIntLiteral((uint)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= ulong.MinValue && literal_value <= ulong.MaxValue)
                    	  				{
                    	  					retval.value =  new ULongLiteral((ulong)literal_value, loc);
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
                    	  				retval.value =  new LongLiteral(literal_value, loc);
                    	  			}
                    	  			else
                    	  			{
                    	  				if (literal_value >= sbyte.MinValue && literal_value <= sbyte.MaxValue)
                    	  				{
                    	  					retval.value =  new SByteLiteral((sbyte)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= short.MinValue && literal_value <= short.MaxValue)
                    	  				{
                    	  					retval.value =  new ShortLiteral((short)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= int.MinValue && literal_value <= int.MaxValue)
                    	  				{
                    	  					retval.value =  new IntLiteral((int)literal_value, loc);
                    	  				}
                    	  				else if (literal_value >= long.MinValue && literal_value <= long.MaxValue)
                    	  				{
                    	  					retval.value =  new LongLiteral((long)literal_value, loc);
                    	  				}
                    	  			}
                    	  		}
                    	  	
                    	}

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1357:4: LITERAL_REAL
                    {
                    	Match(input,LITERAL_REAL,FOLLOW_LITERAL_REAL_in_literal3907); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
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
                    	  			retval.value =  new DoubleLiteral(literal_value, loc);
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
                    	  			retval.value =  new FloatLiteral(literal_value, loc);
                    	  		}
                    	  	
                    	}

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1390:4: LITERAL_CHAR
                    {
                    	Match(input,LITERAL_CHAR,FOLLOW_LITERAL_CHAR_in_literal3916); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		text = text.TrimStart('\'');
                    	  		text = text.TrimEnd('\'');
                    	  		retval.value =  new CharLiteral(Char.Parse(text), loc);
                    	  	
                    	}

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1397:4: LITERAL_STRING
                    {
                    	Match(input,LITERAL_STRING,FOLLOW_LITERAL_STRING_in_literal3925); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		// teraz text abc ma postac "abc", wiec znaki '"' nalezy usunac
                    	  		text = text.TrimStart('"');
                    	  		text = text.TrimEnd('"');
                    	  		retval.value =  new StringLiteral(text, loc);
                    	  	
                    	}

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1405:4: KW_TRUE
                    {
                    	Match(input,KW_TRUE,FOLLOW_KW_TRUE_in_literal3934); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new BoolLiteral(true, loc);
                    	  	
                    	}

                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1410:4: KW_FALSE
                    {
                    	Match(input,KW_FALSE,FOLLOW_KW_FALSE_in_literal3943); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new BoolLiteral(false, loc);
                    	  	
                    	}

                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1415:4: KW_NULL
                    {
                    	Match(input,KW_NULL,FOLLOW_KW_NULL_in_literal3952); if (state.failed) return retval;
                    	if ( (state.backtracking==0) )
                    	{

                    	  		retval.value =  new NullLiteral(loc);
                    	  	
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "literal"

    // $ANTLR start "synpred12_Grammar"
    public void synpred12_Grammar_fragment() {
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:966:4: ( cast_expression )
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:966:5: cast_expression
        {
        	PushFollow(FOLLOW_cast_expression_in_synpred12_Grammar2979);
        	cast_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred12_Grammar"

    // $ANTLR start "synpred13_Grammar"
    public void synpred13_Grammar_fragment() {
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1044:6: ( '(' )
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1044:7: '('
        {
        	Match(input,94,FOLLOW_94_in_synpred13_Grammar3199); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred13_Grammar"

    // $ANTLR start "synpred16_Grammar"
    public void synpred16_Grammar_fragment() {
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1094:4: ( '(' )
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1094:5: '('
        {
        	Match(input,94,FOLLOW_94_in_synpred16_Grammar3340); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred16_Grammar"

    // Delegated rules

   	public bool synpred13_Grammar() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred13_Grammar_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred12_Grammar() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred12_Grammar_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}
   	public bool synpred16_Grammar() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred16_Grammar_fragment(); // can never throw exception
   	    }
   	    catch (RecognitionException re) 
   	    {
   	        Console.Error.WriteLine("impossible: "+re);
   	    }
   	    bool success = !state.failed;
   	    input.Rewind(start);
   	    state.backtracking--;
   	    state.failed = false;
   	    return success;
   	}


   	protected DFA11 dfa11;
   	protected DFA21 dfa21;
   	protected DFA22 dfa22;
   	protected DFA27 dfa27;
   	protected DFA28 dfa28;
   	protected DFA61 dfa61;
   	protected DFA75 dfa75;
   	protected DFA101 dfa101;
   	protected DFA107 dfa107;
	private void InitializeCyclicDFAs()
	{
    	this.dfa11 = new DFA11(this);
    	this.dfa21 = new DFA21(this);
    	this.dfa22 = new DFA22(this);
    	this.dfa27 = new DFA27(this);
    	this.dfa28 = new DFA28(this);
    	this.dfa61 = new DFA61(this);
    	this.dfa75 = new DFA75(this);
    	this.dfa101 = new DFA101(this);
    	this.dfa107 = new DFA107(this);
	    this.dfa101.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA101_SpecialStateTransition);
	}

    const string DFA11_eotS =
        "\x0a\uffff";
    const string DFA11_eofS =
        "\x0a\uffff";
    const string DFA11_minS =
        "\x05\x08\x05\uffff";
    const string DFA11_maxS =
        "\x01\x2e\x04\x0f\x05\uffff";
    const string DFA11_acceptS =
        "\x05\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05";
    const string DFA11_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA11_transitionS = {
            "\x03\x05\x01\uffff\x01\x06\x01\x07\x01\x08\x01\x09\x1b\uffff"+
            "\x01\x01\x01\x02\x01\x03\x01\x04",
            "\x03\x05\x01\uffff\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x03\x05\x01\uffff\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x03\x05\x01\uffff\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x03\x05\x01\uffff\x01\x06\x01\x07\x01\x08\x01\x09",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
    static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
    static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
    static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
    static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
    static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
    static readonly short[][] DFA11_transition = DFA.UnpackEncodedStringArray(DFA11_transitionS);

    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept = DFA11_accept;
            this.special = DFA11_special;
            this.transition = DFA11_transition;

        }

        override public string Description
        {
            get { return "116:1: type_definition : ( class_declaration | struct_declaration | enum_declaration | interface_declaration | delegate_declaration );"; }
        }

    }

    const string DFA21_eotS =
        "\x0a\uffff";
    const string DFA21_eofS =
        "\x0a\uffff";
    const string DFA21_minS =
        "\x01\x08\x02\uffff\x06\x08\x01\uffff";
    const string DFA21_maxS =
        "\x01\x5d\x02\uffff\x02\x3d\x04\x60\x01\uffff";
    const string DFA21_acceptS =
        "\x01\uffff\x01\x03\x01\x01\x06\uffff\x01\x02";
    const string DFA21_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA21_transitionS = {
            "\x01\x09\x01\x03\x01\x04\x01\uffff\x04\x09\x01\x02\x02\uffff"+
            "\x05\x02\x13\uffff\x01\x05\x01\x06\x01\x07\x01\x08\x0f\x02\x1f"+
            "\uffff\x01\x01",
            "",
            "",
            "\x01\x09\x01\x03\x01\x04\x05\uffff\x01\x02\x02\uffff\x04\x02"+
            "\x18\uffff\x0f\x02",
            "\x01\x09\x01\x03\x01\x04\x05\uffff\x01\x02\x02\uffff\x04\x02"+
            "\x18\uffff\x0f\x02",
            "\x03\x09\x01\uffff\x04\x09\x50\uffff\x01\x02",
            "\x03\x09\x01\uffff\x04\x09\x50\uffff\x01\x02",
            "\x03\x09\x01\uffff\x04\x09\x50\uffff\x01\x02",
            "\x03\x09\x01\uffff\x04\x09\x50\uffff\x01\x02",
            ""
    };

    static readonly short[] DFA21_eot = DFA.UnpackEncodedString(DFA21_eotS);
    static readonly short[] DFA21_eof = DFA.UnpackEncodedString(DFA21_eofS);
    static readonly char[] DFA21_min = DFA.UnpackEncodedStringToUnsignedChars(DFA21_minS);
    static readonly char[] DFA21_max = DFA.UnpackEncodedStringToUnsignedChars(DFA21_maxS);
    static readonly short[] DFA21_accept = DFA.UnpackEncodedString(DFA21_acceptS);
    static readonly short[] DFA21_special = DFA.UnpackEncodedString(DFA21_specialS);
    static readonly short[][] DFA21_transition = DFA.UnpackEncodedStringArray(DFA21_transitionS);

    protected class DFA21 : DFA
    {
        public DFA21(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 21;
            this.eot = DFA21_eot;
            this.eof = DFA21_eof;
            this.min = DFA21_min;
            this.max = DFA21_max;
            this.accept = DFA21_accept;
            this.special = DFA21_special;
            this.transition = DFA21_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 191:4: ( class_member | type_definition )+"; }
        }

    }

    const string DFA22_eotS =
        "\x3f\uffff";
    const string DFA22_eofS =
        "\x3f\uffff";
    const string DFA22_minS =
        "\x02\x09\x0f\x2f\x04\x09\x05\uffff\x01\x09\x01\x0b\x01\x05\x01"+
        "\x2f\x01\x0b\x0f\x2f\x01\x09\x01\x0b\x01\x2f\x02\uffff\x01\x2f\x01"+
        "\x0b\x01\x2f\x01\x0b\x01\x5c\x01\x2f\x02\x0b\x02\x2f\x01\x0b\x01"+
        "\x2f";
    const string DFA22_maxS =
        "\x02\x3d\x0f\u0083\x04\x3d\x05\uffff\x01\x3d\x01\u0084\x01\x5e"+
        "\x01\x2f\x01\u0084\x0f\u0083\x01\x3d\x01\u0084\x01\x2f\x02\uffff"+
        "\x01\u0083\x01\u0084\x01\x2f\x01\u0084\x01\x5e\x01\x2f\x02\u0084"+
        "\x01\x2f\x01\u0083\x01\u0084\x01\x2f";
    const string DFA22_acceptS =
        "\x15\uffff\x01\x02\x01\x03\x01\x05\x01\x06\x01\x04\x17\uffff\x01"+
        "\x07\x01\x01\x0c\uffff";
    const string DFA22_specialS =
        "\x3f\uffff}>";
    static readonly string[] DFA22_transitionS = {
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x01\x01\x15"+
            "\x01\x13\x01\x14\x01\x16\x13\uffff\x04\x17\x01\x10\x01\x0a\x01"+
            "\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04"+
            "\x01\x05\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x1a\x01\x15"+
            "\x01\x13\x01\x14\x01\x19\x17\uffff\x01\x10\x01\x0a\x01\x0b\x01"+
            "\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04\x01\x05"+
            "\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x53\uffff\x01\x1b",
            "\x01\x1c\x52\uffff\x01\x1d\x01\x1e",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x2e\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2d\x01\x27\x01\x28\x01\x29\x01"+
            "\x2a\x01\x2b\x01\x2c\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23"+
            "\x01\x24\x01\x25\x01\x26",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x2e\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2d\x01\x27\x01\x28\x01\x29\x01"+
            "\x2a\x01\x2b\x01\x2c\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23"+
            "\x01\x24\x01\x25\x01\x26",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x2e\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2d\x01\x27\x01\x28\x01\x29\x01"+
            "\x2a\x01\x2b\x01\x2c\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23"+
            "\x01\x24\x01\x25\x01\x26",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x2e\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2d\x01\x27\x01\x28\x01\x29\x01"+
            "\x2a\x01\x2b\x01\x2c\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23"+
            "\x01\x24\x01\x25\x01\x26",
            "",
            "",
            "",
            "",
            "",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x1a\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x10\x01\x0a\x01\x0b\x01\x0c\x01"+
            "\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09",
            "\x01\x2f\x78\uffff\x01\x30",
            "\x01\x32\x56\uffff\x01\x31\x01\uffff\x01\x15",
            "\x01\x33",
            "\x01\x34\x78\uffff\x01\x35",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x53\uffff\x01\x36",
            "\x01\x37\x52\uffff\x01\x38\x01\x39",
            "\x01\x11\x01\x12\x05\uffff\x01\x18\x02\uffff\x01\x2e\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2d\x01\x27\x01\x28\x01\x29\x01"+
            "\x2a\x01\x2b\x01\x2c\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23"+
            "\x01\x24\x01\x25\x01\x26",
            "\x01\x2f\x78\uffff\x01\x30",
            "\x01\x1c",
            "",
            "",
            "\x01\x1c\x52\uffff\x01\x1d\x01\x1e",
            "\x01\x34\x78\uffff\x01\x35",
            "\x01\x1c",
            "\x01\x3a\x78\uffff\x01\x3b",
            "\x01\x31\x01\uffff\x01\x15",
            "\x01\x3c",
            "\x01\x3d\x78\uffff\x01\x3e",
            "\x01\x3a\x78\uffff\x01\x3b",
            "\x01\x37",
            "\x01\x37\x52\uffff\x01\x38\x01\x39",
            "\x01\x3d\x78\uffff\x01\x3e",
            "\x01\x37"
    };

    static readonly short[] DFA22_eot = DFA.UnpackEncodedString(DFA22_eotS);
    static readonly short[] DFA22_eof = DFA.UnpackEncodedString(DFA22_eofS);
    static readonly char[] DFA22_min = DFA.UnpackEncodedStringToUnsignedChars(DFA22_minS);
    static readonly char[] DFA22_max = DFA.UnpackEncodedStringToUnsignedChars(DFA22_maxS);
    static readonly short[] DFA22_accept = DFA.UnpackEncodedString(DFA22_acceptS);
    static readonly short[] DFA22_special = DFA.UnpackEncodedString(DFA22_specialS);
    static readonly short[][] DFA22_transition = DFA.UnpackEncodedStringArray(DFA22_transitionS);

    protected class DFA22 : DFA
    {
        public DFA22(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 22;
            this.eot = DFA22_eot;
            this.eof = DFA22_eof;
            this.min = DFA22_min;
            this.max = DFA22_max;
            this.accept = DFA22_accept;
            this.special = DFA22_special;
            this.transition = DFA22_transition;

        }

        override public string Description
        {
            get { return "195:1: class_member options {backtrack=true; } : ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | access_scope_directive | signal_declaration | property_declaration );"; }
        }

    }

    const string DFA27_eotS =
        "\x06\uffff";
    const string DFA27_eofS =
        "\x06\uffff";
    const string DFA27_minS =
        "\x01\x08\x02\uffff\x02\x08\x01\uffff";
    const string DFA27_maxS =
        "\x01\x5d\x02\uffff\x02\x3d\x01\uffff";
    const string DFA27_acceptS =
        "\x01\uffff\x01\x03\x01\x01\x02\uffff\x01\x02";
    const string DFA27_specialS =
        "\x06\uffff}>";
    static readonly string[] DFA27_transitionS = {
            "\x01\x05\x01\x03\x01\x04\x01\uffff\x04\x05\x01\x02\x02\uffff"+
            "\x05\x02\x13\uffff\x04\x05\x0f\x02\x1f\uffff\x01\x01",
            "",
            "",
            "\x01\x05\x01\x03\x01\x04\x05\uffff\x01\x02\x02\uffff\x04\x02"+
            "\x18\uffff\x0f\x02",
            "\x01\x05\x01\x03\x01\x04\x05\uffff\x01\x02\x02\uffff\x04\x02"+
            "\x18\uffff\x0f\x02",
            ""
    };

    static readonly short[] DFA27_eot = DFA.UnpackEncodedString(DFA27_eotS);
    static readonly short[] DFA27_eof = DFA.UnpackEncodedString(DFA27_eofS);
    static readonly char[] DFA27_min = DFA.UnpackEncodedStringToUnsignedChars(DFA27_minS);
    static readonly char[] DFA27_max = DFA.UnpackEncodedStringToUnsignedChars(DFA27_maxS);
    static readonly short[] DFA27_accept = DFA.UnpackEncodedString(DFA27_acceptS);
    static readonly short[] DFA27_special = DFA.UnpackEncodedString(DFA27_specialS);
    static readonly short[][] DFA27_transition = DFA.UnpackEncodedStringArray(DFA27_transitionS);

    protected class DFA27 : DFA
    {
        public DFA27(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 27;
            this.eot = DFA27_eot;
            this.eof = DFA27_eof;
            this.min = DFA27_min;
            this.max = DFA27_max;
            this.accept = DFA27_accept;
            this.special = DFA27_special;
            this.transition = DFA27_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 242:4: ( struct_member | type_definition )+"; }
        }

    }

    const string DFA28_eotS =
        "\x3e\uffff";
    const string DFA28_eofS =
        "\x3e\uffff";
    const string DFA28_minS =
        "\x02\x09\x0f\x2f\x04\x09\x04\uffff\x01\x09\x01\x0b\x01\x05\x01"+
        "\x2f\x01\x0b\x0f\x2f\x01\x09\x01\x0b\x01\x2f\x02\uffff\x01\x2f\x01"+
        "\x0b\x01\x2f\x01\x0b\x01\x5c\x01\x2f\x02\x0b\x02\x2f\x01\x0b\x01"+
        "\x2f";
    const string DFA28_maxS =
        "\x02\x3d\x0f\u0083\x04\x3d\x04\uffff\x01\x3d\x01\u0084\x01\x5e"+
        "\x01\x2f\x01\u0084\x0f\u0083\x01\x3d\x01\u0084\x01\x2f\x02\uffff"+
        "\x01\u0083\x01\u0084\x01\x2f\x01\u0084\x01\x5e\x01\x2f\x02\u0084"+
        "\x01\x2f\x01\u0083\x01\u0084\x01\x2f";
    const string DFA28_acceptS =
        "\x15\uffff\x01\x02\x01\x03\x01\x05\x01\x04\x17\uffff\x01\x06\x01"+
        "\x01\x0c\uffff";
    const string DFA28_specialS =
        "\x3e\uffff}>";
    static readonly string[] DFA28_transitionS = {
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x01\x01\x15"+
            "\x01\x13\x01\x14\x01\x16\x17\uffff\x01\x10\x01\x0a\x01\x0b\x01"+
            "\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04\x01\x05"+
            "\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x19\x01\x15"+
            "\x01\x13\x01\x14\x01\x18\x17\uffff\x01\x10\x01\x0a\x01\x0b\x01"+
            "\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04\x01\x05"+
            "\x01\x06\x01\x07\x01\x08\x01\x09",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x53\uffff\x01\x1a",
            "\x01\x1b\x52\uffff\x01\x1c\x01\x1d",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x2d\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2c\x01\x26\x01\x27\x01\x28\x01"+
            "\x29\x01\x2a\x01\x2b\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
            "\x01\x23\x01\x24\x01\x25",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x2d\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2c\x01\x26\x01\x27\x01\x28\x01"+
            "\x29\x01\x2a\x01\x2b\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
            "\x01\x23\x01\x24\x01\x25",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x2d\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2c\x01\x26\x01\x27\x01\x28\x01"+
            "\x29\x01\x2a\x01\x2b\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
            "\x01\x23\x01\x24\x01\x25",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x2d\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2c\x01\x26\x01\x27\x01\x28\x01"+
            "\x29\x01\x2a\x01\x2b\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
            "\x01\x23\x01\x24\x01\x25",
            "",
            "",
            "",
            "",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x19\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x10\x01\x0a\x01\x0b\x01\x0c\x01"+
            "\x0d\x01\x0e\x01\x0f\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09",
            "\x01\x2e\x78\uffff\x01\x2f",
            "\x01\x31\x56\uffff\x01\x30\x01\uffff\x01\x15",
            "\x01\x32",
            "\x01\x33\x78\uffff\x01\x34",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x53\uffff\x01\x35",
            "\x01\x36\x52\uffff\x01\x37\x01\x38",
            "\x01\x11\x01\x12\x05\uffff\x01\x17\x02\uffff\x01\x2d\x01\x15"+
            "\x01\x13\x01\x14\x18\uffff\x01\x2c\x01\x26\x01\x27\x01\x28\x01"+
            "\x29\x01\x2a\x01\x2b\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
            "\x01\x23\x01\x24\x01\x25",
            "\x01\x2e\x78\uffff\x01\x2f",
            "\x01\x1b",
            "",
            "",
            "\x01\x1b\x52\uffff\x01\x1c\x01\x1d",
            "\x01\x33\x78\uffff\x01\x34",
            "\x01\x1b",
            "\x01\x39\x78\uffff\x01\x3a",
            "\x01\x30\x01\uffff\x01\x15",
            "\x01\x3b",
            "\x01\x3c\x78\uffff\x01\x3d",
            "\x01\x39\x78\uffff\x01\x3a",
            "\x01\x36",
            "\x01\x36\x52\uffff\x01\x37\x01\x38",
            "\x01\x3c\x78\uffff\x01\x3d",
            "\x01\x36"
    };

    static readonly short[] DFA28_eot = DFA.UnpackEncodedString(DFA28_eotS);
    static readonly short[] DFA28_eof = DFA.UnpackEncodedString(DFA28_eofS);
    static readonly char[] DFA28_min = DFA.UnpackEncodedStringToUnsignedChars(DFA28_minS);
    static readonly char[] DFA28_max = DFA.UnpackEncodedStringToUnsignedChars(DFA28_maxS);
    static readonly short[] DFA28_accept = DFA.UnpackEncodedString(DFA28_acceptS);
    static readonly short[] DFA28_special = DFA.UnpackEncodedString(DFA28_specialS);
    static readonly short[][] DFA28_transition = DFA.UnpackEncodedStringArray(DFA28_transitionS);

    protected class DFA28 : DFA
    {
        public DFA28(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 28;
            this.eot = DFA28_eot;
            this.eof = DFA28_eof;
            this.min = DFA28_min;
            this.max = DFA28_max;
            this.accept = DFA28_accept;
            this.special = DFA28_special;
            this.transition = DFA28_transition;

        }

        override public string Description
        {
            get { return "246:1: struct_member options {backtrack=true; } : ( field_declaration | method_declaration | constructor_declaration | static_constructor_declaration | signal_declaration | property_declaration );"; }
        }

    }

    const string DFA61_eotS =
        "\x08\uffff";
    const string DFA61_eofS =
        "\x08\uffff";
    const string DFA61_minS =
        "\x01\x05\x01\uffff\x01\x05\x01\uffff\x01\x2f\x01\x0b\x01\uffff"+
        "\x01\x05";
    const string DFA61_maxS =
        "\x01\u0081\x01\uffff\x01\u0083\x01\uffff\x01\x2f\x01\u0084\x01"+
        "\uffff\x01\u0083";
    const string DFA61_acceptS =
        "\x01\uffff\x01\x01\x01\uffff\x01\x02\x02\uffff\x01\x03\x01\uffff";
    const string DFA61_specialS =
        "\x08\uffff}>";
    static readonly string[] DFA61_transitionS = {
            "\x01\x01\x10\uffff\x03\x01\x01\x03\x01\x01\x01\uffff\x08\x01"+
            "\x02\uffff\x01\x01\x02\uffff\x02\x01\x04\uffff\x01\x02\x0e\x03"+
            "\x07\x01\x17\uffff\x01\x01\x01\uffff\x01\x01\x10\uffff\x02\x01"+
            "\x0d\uffff\x04\x01",
            "",
            "\x01\x01\x21\uffff\x02\x01\x06\uffff\x01\x03\x2b\uffff\x01"+
            "\x01\x02\uffff\x01\x01\x01\uffff\x01\x06\x1d\x01\x04\uffff\x01"+
            "\x04\x01\x05",
            "",
            "\x01\x07",
            "\x01\x03\x0a\uffff\x03\x01\x10\uffff\x02\x01\x04\uffff\x01"+
            "\x01\x0e\uffff\x07\x01\x19\uffff\x01\x01\x10\uffff\x02\x01\x0d"+
            "\uffff\x04\x01\x02\uffff\x01\x03",
            "",
            "\x01\x01\x21\uffff\x02\x01\x06\uffff\x01\x03\x2b\uffff\x01"+
            "\x01\x02\uffff\x01\x01\x02\uffff\x1d\x01\x04\uffff\x01\x04\x01"+
            "\x05"
    };

    static readonly short[] DFA61_eot = DFA.UnpackEncodedString(DFA61_eotS);
    static readonly short[] DFA61_eof = DFA.UnpackEncodedString(DFA61_eofS);
    static readonly char[] DFA61_min = DFA.UnpackEncodedStringToUnsignedChars(DFA61_minS);
    static readonly char[] DFA61_max = DFA.UnpackEncodedStringToUnsignedChars(DFA61_maxS);
    static readonly short[] DFA61_accept = DFA.UnpackEncodedString(DFA61_acceptS);
    static readonly short[] DFA61_special = DFA.UnpackEncodedString(DFA61_specialS);
    static readonly short[][] DFA61_transition = DFA.UnpackEncodedStringArray(DFA61_transitionS);

    protected class DFA61 : DFA
    {
        public DFA61(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 61;
            this.eot = DFA61_eot;
            this.eof = DFA61_eof;
            this.min = DFA61_min;
            this.max = DFA61_max;
            this.accept = DFA61_accept;
            this.special = DFA61_special;
            this.transition = DFA61_transition;

        }

        override public string Description
        {
            get { return "581:1: statement returns [Statement value] : ( embedded_statement | declaration_statement | labeled_statement );"; }
        }

    }

    const string DFA75_eotS =
        "\x09\uffff";
    const string DFA75_eofS =
        "\x09\uffff";
    const string DFA75_minS =
        "\x01\x1c\x01\x5e\x01\x05\x01\uffff\x01\x05\x01\uffff\x01\x2f\x01"+
        "\x0b\x01\x05";
    const string DFA75_maxS =
        "\x01\x1c\x01\x5e\x01\u0081\x01\uffff\x01\u0083\x01\uffff\x01\x2f"+
        "\x01\u0084\x01\u0083";
    const string DFA75_acceptS =
        "\x03\uffff\x01\x01\x01\uffff\x01\x02\x03\uffff";
    const string DFA75_specialS =
        "\x09\uffff}>";
    static readonly string[] DFA75_transitionS = {
            "\x01\x01",
            "\x01\x02",
            "\x01\x03\x10\uffff\x03\x03\x01\x05\x0f\uffff\x02\x03\x04\uffff"+
            "\x01\x04\x0e\x05\x07\x03\x19\uffff\x01\x03\x10\uffff\x02\x03"+
            "\x0d\uffff\x04\x03",
            "",
            "\x01\x03\x21\uffff\x02\x03\x06\uffff\x01\x05\x2b\uffff\x01"+
            "\x03\x02\uffff\x01\x03\x02\uffff\x1d\x03\x04\uffff\x01\x06\x01"+
            "\x07",
            "",
            "\x01\x08",
            "\x01\x05\x0a\uffff\x03\x03\x10\uffff\x02\x03\x04\uffff\x01"+
            "\x03\x0e\uffff\x07\x03\x19\uffff\x01\x03\x10\uffff\x02\x03\x0d"+
            "\uffff\x04\x03\x02\uffff\x01\x05",
            "\x01\x03\x21\uffff\x02\x03\x06\uffff\x01\x05\x2b\uffff\x01"+
            "\x03\x02\uffff\x01\x03\x02\uffff\x1d\x03\x04\uffff\x01\x06\x01"+
            "\x07"
    };

    static readonly short[] DFA75_eot = DFA.UnpackEncodedString(DFA75_eotS);
    static readonly short[] DFA75_eof = DFA.UnpackEncodedString(DFA75_eofS);
    static readonly char[] DFA75_min = DFA.UnpackEncodedStringToUnsignedChars(DFA75_minS);
    static readonly char[] DFA75_max = DFA.UnpackEncodedStringToUnsignedChars(DFA75_maxS);
    static readonly short[] DFA75_accept = DFA.UnpackEncodedString(DFA75_acceptS);
    static readonly short[] DFA75_special = DFA.UnpackEncodedString(DFA75_specialS);
    static readonly short[][] DFA75_transition = DFA.UnpackEncodedStringArray(DFA75_transitionS);

    protected class DFA75 : DFA
    {
        public DFA75(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 75;
            this.eot = DFA75_eot;
            this.eof = DFA75_eof;
            this.min = DFA75_min;
            this.max = DFA75_max;
            this.accept = DFA75_accept;
            this.special = DFA75_special;
            this.transition = DFA75_transition;

        }

        override public string Description
        {
            get { return "689:1: for_statement returns [Statement value] : ( KW_FOR '(' (init= expression )? SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement | KW_FOR '(' decl= local_declaration SEMI (cond= expression )? SEMI (iter= expression )? ')' embedded_statement );"; }
        }

    }

    const string DFA101_eotS =
        "\x16\uffff";
    const string DFA101_eofS =
        "\x16\uffff";
    const string DFA101_minS =
        "\x01\x16\x01\x00\x14\uffff";
    const string DFA101_maxS =
        "\x01\u0081\x01\x00\x14\uffff";
    const string DFA101_acceptS =
        "\x02\uffff\x01\x02\x0c\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x01";
    const string DFA101_specialS =
        "\x01\uffff\x01\x00\x14\uffff}>";
    static readonly string[] DFA101_transitionS = {
            "\x03\x02\x10\uffff\x02\x02\x04\uffff\x01\x02\x0e\uffff\x07"+
            "\x02\x19\uffff\x01\x01\x10\uffff\x01\x0f\x01\x10\x0d\uffff\x01"+
            "\x11\x01\x12\x01\x13\x01\x14",
            "\x01\uffff",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA101_eot = DFA.UnpackEncodedString(DFA101_eotS);
    static readonly short[] DFA101_eof = DFA.UnpackEncodedString(DFA101_eofS);
    static readonly char[] DFA101_min = DFA.UnpackEncodedStringToUnsignedChars(DFA101_minS);
    static readonly char[] DFA101_max = DFA.UnpackEncodedStringToUnsignedChars(DFA101_maxS);
    static readonly short[] DFA101_accept = DFA.UnpackEncodedString(DFA101_acceptS);
    static readonly short[] DFA101_special = DFA.UnpackEncodedString(DFA101_specialS);
    static readonly short[][] DFA101_transition = DFA.UnpackEncodedStringArray(DFA101_transitionS);

    protected class DFA101 : DFA
    {
        public DFA101(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 101;
            this.eot = DFA101_eot;
            this.eof = DFA101_eof;
            this.min = DFA101_min;
            this.max = DFA101_max;
            this.accept = DFA101_accept;
            this.special = DFA101_special;
            this.transition = DFA101_transition;

        }

        override public string Description
        {
            get { return "965:1: unary_expression returns [Expression value] : ( ( cast_expression )=> cast_expression | postfix_expression ( assignment_operator r1= expression | op= complex_assignment_operator r2= expression | ) | '+' a= postfix_expression | '-' b= postfix_expression | '!' c= postfix_expression | '~' d= postfix_expression | '++' e= postfix_expression | '--' f= postfix_expression );"; }
        }

    }


    protected internal int DFA101_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA101_1 = input.LA(1);

                   	 
                   	int index101_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred12_Grammar()) ) { s = 21; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index101_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae101 =
            new NoViableAltException(dfa.Description, 101, _s, input);
        dfa.Error(nvae101);
        throw nvae101;
    }
    const string DFA107_eotS =
        "\x22\uffff";
    const string DFA107_eofS =
        "\x22\uffff";
    const string DFA107_minS =
        "\x01\x16\x01\x2f\x07\uffff\x0f\x5e\x01\x0b\x01\uffff\x01\x2f\x01"+
        "\x0b\x01\uffff\x01\x0b\x02\x5e\x01\x0b\x01\x5e";
    const string DFA107_maxS =
        "\x01\x5e\x01\x3d\x07\uffff\x0f\u0083\x01\u0084\x01\uffff\x01\x2f"+
        "\x01\u0084\x01\uffff\x01\u0084\x02\u0083\x01\u0084\x01\u0083";
    const string DFA107_acceptS =
        "\x02\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x01"+
        "\x09\x10\uffff\x01\x02\x02\uffff\x01\x01\x05\uffff";
    const string DFA107_specialS =
        "\x22\uffff}>";
    static readonly string[] DFA107_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x10\uffff\x01\x04\x01\x07\x04\uffff"+
            "\x01\x05\x0e\uffff\x07\x06\x19\uffff\x01\x08",
            "\x01\x17\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
            "\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x24\uffff\x01\x18",
            "\x01\x19\x23\uffff\x01\x1a\x01\x1b",
            "\x01\x1d\x0a\uffff\x03\x1c\x10\uffff\x02\x1c\x04\uffff\x01"+
            "\x1c\x0e\uffff\x07\x1c\x19\uffff\x01\x1c\x10\uffff\x02\x1c\x0d"+
            "\uffff\x04\x1c\x02\uffff\x01\x1e",
            "",
            "\x01\x1f",
            "\x01\x20\x0a\uffff\x03\x1c\x10\uffff\x02\x1c\x04\uffff\x01"+
            "\x1c\x0e\uffff\x07\x1c\x19\uffff\x01\x1c\x10\uffff\x02\x1c\x0d"+
            "\uffff\x04\x1c\x02\uffff\x01\x21",
            "",
            "\x01\x1d\x78\uffff\x01\x1e",
            "\x01\x19\x24\uffff\x01\x1c",
            "\x01\x19\x23\uffff\x01\x1a\x01\x1b",
            "\x01\x20\x78\uffff\x01\x21",
            "\x01\x19\x24\uffff\x01\x1c"
    };

    static readonly short[] DFA107_eot = DFA.UnpackEncodedString(DFA107_eotS);
    static readonly short[] DFA107_eof = DFA.UnpackEncodedString(DFA107_eofS);
    static readonly char[] DFA107_min = DFA.UnpackEncodedStringToUnsignedChars(DFA107_minS);
    static readonly char[] DFA107_max = DFA.UnpackEncodedStringToUnsignedChars(DFA107_maxS);
    static readonly short[] DFA107_accept = DFA.UnpackEncodedString(DFA107_acceptS);
    static readonly short[] DFA107_special = DFA.UnpackEncodedString(DFA107_specialS);
    static readonly short[][] DFA107_transition = DFA.UnpackEncodedStringArray(DFA107_transitionS);

    protected class DFA107 : DFA
    {
        public DFA107(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 107;
            this.eot = DFA107_eot;
            this.eof = DFA107_eof;
            this.min = DFA107_min;
            this.max = DFA107_max;
            this.accept = DFA107_accept;
            this.special = DFA107_special;
            this.transition = DFA107_transition;

        }

        override public string Description
        {
            get { return "1066:1: primary_expression returns [Expression value] : ( array_creation_expression | object_creation_expression | KW_THIS | KW_BASE | KW_GLOBAL | identifier ( ( '(' )=> '(' (f= expressions_list )? ')' | ) | literal | typeof_expression | '(' expression ')' );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_using_directives_in_program71 = new BitSet(new ulong[]{0x000078000000F7C0UL});
    public static readonly BitSet FOLLOW_typedef_directives_in_program75 = new BitSet(new ulong[]{0x000078000000F780UL});
    public static readonly BitSet FOLLOW_namespace_definition_in_program80 = new BitSet(new ulong[]{0x000078000000F780UL});
    public static readonly BitSet FOLLOW_type_definition_in_program85 = new BitSet(new ulong[]{0x000078000000F780UL});
    public static readonly BitSet FOLLOW_EOF_in_program90 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_using_directive_in_using_directives104 = new BitSet(new ulong[]{0x0000000000000012UL});
    public static readonly BitSet FOLLOW_KW_USING_in_using_directive121 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_typename_expression_in_using_directive123 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_using_directive125 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typedef_directive_in_typedef_directives139 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_KW_TYPEDEF_in_typedef_directive155 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_typedef_directive157 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000008000000UL});
    public static readonly BitSet FOLLOW_91_in_typedef_directive159 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_typename_expression_in_typedef_directive161 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_typedef_directive163 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_NAMESPACE_in_namespace_definition182 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_namespace_definition184 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_namespace_block_in_namespace_definition190 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SEMI_in_namespace_definition192 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_92_in_namespace_block207 = new BitSet(new ulong[]{0x000078000000F7D0UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_namespace_body_in_namespace_block209 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_namespace_block212 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_using_directives_in_namespace_body223 = new BitSet(new ulong[]{0x000078000000F7C0UL});
    public static readonly BitSet FOLLOW_typedef_directives_in_namespace_body227 = new BitSet(new ulong[]{0x000078000000F780UL});
    public static readonly BitSet FOLLOW_namespace_definition_in_namespace_body232 = new BitSet(new ulong[]{0x000078000000F782UL});
    public static readonly BitSet FOLLOW_type_definition_in_namespace_body237 = new BitSet(new ulong[]{0x000078000000F782UL});
    public static readonly BitSet FOLLOW_class_declaration_in_type_definition250 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_declaration_in_type_definition255 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_declaration_in_type_definition260 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interface_declaration_in_type_definition265 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_delegate_declaration_in_type_definition270 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_class_declaration285 = new BitSet(new ulong[]{0x0000000000000700UL});
    public static readonly BitSet FOLLOW_class_specifiers_in_class_declaration288 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_KW_CLASS_in_class_declaration291 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_class_declaration293 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000150000000UL});
    public static readonly BitSet FOLLOW_class_base_in_class_declaration295 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000150000000UL});
    public static readonly BitSet FOLLOW_base_interfaces_in_class_declaration298 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000150000000UL});
    public static readonly BitSet FOLLOW_class_block_in_class_declaration305 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SEMI_in_class_declaration307 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_class_specifier_in_class_specifiers332 = new BitSet(new ulong[]{0x0000000000000602UL});
    public static readonly BitSet FOLLOW_KW_ABSTRACT_in_class_specifier354 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FINAL_in_class_specifier361 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_class_base379 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_class_base381 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_class_base383 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_96_in_base_interfaces407 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_base_interfaces411 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_COMMA_in_base_interfaces417 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_base_interfaces421 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_92_in_class_block437 = new BitSet(new ulong[]{0x3FFFF80000F9F780UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_class_body_in_class_block439 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_class_block442 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_class_member_in_class_body454 = new BitSet(new ulong[]{0x3FFFF80000F9F782UL});
    public static readonly BitSet FOLLOW_type_definition_in_class_body459 = new BitSet(new ulong[]{0x3FFFF80000F9F782UL});
    public static readonly BitSet FOLLOW_field_declaration_in_class_member485 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_declaration_in_class_member490 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constructor_declaration_in_class_member495 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_static_constructor_declaration_in_class_member500 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_scope_directive_in_class_member505 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_signal_declaration_in_class_member510 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_property_declaration_in_class_member515 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_struct_declaration532 = new BitSet(new ulong[]{0x0000000000001000UL});
    public static readonly BitSet FOLLOW_KW_STRUCT_in_struct_declaration535 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_struct_declaration537 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_base_interfaces_in_struct_declaration539 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_struct_block_in_struct_declaration546 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SEMI_in_struct_declaration548 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_92_in_struct_block563 = new BitSet(new ulong[]{0x3FFFF80000F9F780UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_struct_body_in_struct_block565 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_struct_block568 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_member_in_struct_body580 = new BitSet(new ulong[]{0x3FFFF80000F9F782UL});
    public static readonly BitSet FOLLOW_type_definition_in_struct_body585 = new BitSet(new ulong[]{0x3FFFF80000F9F782UL});
    public static readonly BitSet FOLLOW_field_declaration_in_struct_member610 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_declaration_in_struct_member615 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constructor_declaration_in_struct_member620 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_static_constructor_declaration_in_struct_member625 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_signal_declaration_in_struct_member630 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_property_declaration_in_struct_member635 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_enum_declaration652 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_KW_ENUM_in_enum_declaration655 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enum_declaration657 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000050000000UL});
    public static readonly BitSet FOLLOW_enum_base_in_enum_declaration659 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000050000000UL});
    public static readonly BitSet FOLLOW_enum_block_in_enum_declaration666 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SEMI_in_enum_declaration668 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_enum_base687 = new BitSet(new ulong[]{0x3FC0000000000000UL});
    public static readonly BitSet FOLLOW_primitive_integral_type_in_enum_base689 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_enum_base691 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_92_in_enum_block705 = new BitSet(new ulong[]{0x0000800000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_enum_body_in_enum_block707 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_enum_block710 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_member_in_enum_body721 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_COMMA_in_enum_body724 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_enum_member_in_enum_body726 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_identifier_in_enum_member743 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000008000000UL});
    public static readonly BitSet FOLLOW_91_in_enum_member745 = new BitSet(new ulong[]{0xC000000000000000UL,0x000000000000001FUL});
    public static readonly BitSet FOLLOW_literal_in_enum_member747 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_interface_declaration765 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_KW_INTERFACE_in_interface_declaration768 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_interface_declaration770 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_base_interfaces_in_interface_declaration772 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_interface_block_in_interface_declaration779 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SEMI_in_interface_declaration781 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_92_in_interface_block796 = new BitSet(new ulong[]{0x3FFF800000780600UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_interface_body_in_interface_block798 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_interface_block801 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interface_member_in_interface_body812 = new BitSet(new ulong[]{0x3FFF800000780602UL});
    public static readonly BitSet FOLLOW_method_signature_in_interface_member824 = new BitSet(new ulong[]{0x0000000000000020UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_method_block_in_interface_member827 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEMI_in_interface_member831 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_delegate_declaration852 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_KW_DELEGATE_in_delegate_declaration855 = new BitSet(new ulong[]{0x3FFF800000780600UL});
    public static readonly BitSet FOLLOW_return_type_in_delegate_declaration857 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_delegate_declaration859 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_delegate_declaration861 = new BitSet(new ulong[]{0x3FFF800000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_formal_arguments_in_delegate_declaration863 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_delegate_declaration866 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_delegate_declaration868 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_specifiers_in_signal_declaration886 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_KW_SIGNAL_in_signal_declaration889 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_signal_declaration891 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_signal_declaration893 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_signal_declaration895 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_specifiers_in_property_declaration913 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_property_declaration916 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_property_declaration918 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_92_in_property_declaration920 = new BitSet(new ulong[]{0x0000000000060000UL});
    public static readonly BitSet FOLLOW_accessor_declarations_in_property_declaration922 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_property_declaration924 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_get_accessor_in_accessor_declarations944 = new BitSet(new ulong[]{0x0000000000060002UL});
    public static readonly BitSet FOLLOW_set_accessor_in_accessor_declarations948 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_accessor_in_accessor_declarations958 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_get_accessor_in_accessor_declarations962 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_GET_in_get_accessor980 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_method_block_in_get_accessor982 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_SET_in_set_accessor1000 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_method_block_in_set_accessor1002 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_field_specifiers_in_field_declaration1020 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_field_declaration1023 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_field_declaration1025 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_field_declaration1027 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_field_specifier_in_field_specifiers1051 = new BitSet(new ulong[]{0x0000000000080002UL});
    public static readonly BitSet FOLLOW_KW_STATIC_in_field_specifier1072 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_in_return_type1089 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_VOID_in_return_type1097 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_specifiers_in_method_declaration1114 = new BitSet(new ulong[]{0x3FFF800000780600UL});
    public static readonly BitSet FOLLOW_return_type_in_method_declaration1117 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_method_declaration1119 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_method_declaration1121 = new BitSet(new ulong[]{0x3FFF800000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_formal_arguments_in_method_declaration1123 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_method_declaration1126 = new BitSet(new ulong[]{0x0000000000000020UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_method_block_in_method_declaration1129 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEMI_in_method_declaration1133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_return_type_in_method_signature1153 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_method_signature1155 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_method_signature1157 = new BitSet(new ulong[]{0x3FFF800000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_formal_arguments_in_method_signature1159 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_method_signature1162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_in_method_block1180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_formal_argument_in_formal_arguments1205 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_COMMA_in_formal_arguments1211 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_formal_argument_in_formal_arguments1215 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_type_in_formal_argument1235 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_formal_argument1237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_method_specifier_in_method_specifiers1261 = new BitSet(new ulong[]{0x0000000000680602UL});
    public static readonly BitSet FOLLOW_KW_ABSTRACT_in_method_specifier1282 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FINAL_in_method_specifier1289 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_STATIC_in_method_specifier1297 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_VIRTUAL_in_method_specifier1305 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_NEW_in_method_specifier1312 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_THIS_in_constructor_declaration1330 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_constructor_declaration1332 = new BitSet(new ulong[]{0x3FFF800000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_formal_arguments_in_constructor_declaration1334 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_constructor_declaration1337 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_constructor_initializer_in_constructor_declaration1339 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000110000000UL});
    public static readonly BitSet FOLLOW_constructor_block_in_constructor_declaration1342 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_96_in_constructor_initializer1360 = new BitSet(new ulong[]{0x0000000001800000UL});
    public static readonly BitSet FOLLOW_KW_THIS_in_constructor_initializer1365 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_KW_BASE_in_constructor_initializer1371 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_constructor_initializer1374 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_constructor_initializer1376 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_constructor_initializer1379 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_in_constructor_block1397 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_STATIC_in_static_constructor_declaration1415 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_KW_THIS_in_static_constructor_declaration1417 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_static_constructor_declaration1419 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_static_constructor_declaration1421 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_static_constructor_body_in_static_constructor_declaration1423 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_in_static_constructor_body1441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_statement1461 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_statement_in_statement1469 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_labeled_statement_in_statement1477 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_statements1502 = new BitSet(new ulong[]{0xFFFF864FF7C00022UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_92_in_block1522 = new BitSet(new ulong[]{0xFFFF864FF7C00020UL,0xC00180007000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_statements_in_block1524 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000020000000UL});
    public static readonly BitSet FOLLOW_93_in_block1527 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_labeled_statement1545 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000100000000UL});
    public static readonly BitSet FOLLOW_96_in_labeled_statement1547 = new BitSet(new ulong[]{0xFFFF864FF7C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_statement_in_labeled_statement1549 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_declaration_statement_in_declaration_statement1567 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_local_declaration_in_variable_declaration_statement1585 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_variable_declaration_statement1587 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_in_local_declaration1605 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_variable_declarators_in_local_declaration1607 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_VAR_in_local_declaration1615 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_variable_declarators_in_local_declaration1617 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_declarator_in_variable_declarators1642 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_COMMA_in_variable_declarators1648 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_variable_declarator_in_variable_declarators1652 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_identifier_in_variable_declarator1672 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000008000000UL});
    public static readonly BitSet FOLLOW_91_in_variable_declarator1675 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_variable_declarator1677 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_in_embedded_statement1697 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_statement_in_embedded_statement1708 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_if_statement_in_embedded_statement1715 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_loop_statement_in_embedded_statement1724 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_jump_statement_in_embedded_statement1732 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_try_statement_in_embedded_statement1740 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_throw_statement_in_embedded_statement1749 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_empty_statement_in_embedded_statement1757 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_IF_in_if_statement1775 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_if_statement1777 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_if_statement1779 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_if_statement1781 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_if_statement1783 = new BitSet(new ulong[]{0x0000000008000002UL});
    public static readonly BitSet FOLLOW_else_statement_in_if_statement1785 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_ELSE_in_else_statement1804 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_else_statement1806 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_for_statement_in_loop_statement1824 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_while_statement_in_loop_statement1833 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_do_statement_in_loop_statement1841 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FOR_in_for_statement1862 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_for_statement1864 = new BitSet(new ulong[]{0xC000860001C00020UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_for_statement1868 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_for_statement1871 = new BitSet(new ulong[]{0xC000860001C00020UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_for_statement1875 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_for_statement1878 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_for_statement1882 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_for_statement1885 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_for_statement1887 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FOR_in_for_statement1896 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_for_statement1898 = new BitSet(new ulong[]{0x3FFF800002000000UL});
    public static readonly BitSet FOLLOW_local_declaration_in_for_statement1902 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_for_statement1904 = new BitSet(new ulong[]{0xC000860001C00020UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_for_statement1908 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_for_statement1911 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_for_statement1915 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_for_statement1918 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_for_statement1920 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_WHILE_in_while_statement1941 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_while_statement1943 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_while_statement1945 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_while_statement1947 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_while_statement1949 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_DO_in_do_statement1967 = new BitSet(new ulong[]{0xC000864FF5C00020UL,0xC00180005000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_embedded_statement_in_do_statement1969 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_KW_WHILE_in_do_statement1971 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_do_statement1973 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_do_statement1975 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_do_statement1977 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_do_statement1979 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_break_statement_in_jump_statement1997 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_goto_statement_in_jump_statement2005 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_continue_statement_in_jump_statement2013 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_return_statement_in_jump_statement2020 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_GOTO_in_goto_statement2038 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_goto_statement2040 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_goto_statement2042 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_BREAK_in_break_statement2060 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_break_statement2062 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_CONTINUE_in_continue_statement2080 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_continue_statement2082 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_RETURN_in_return_statement2100 = new BitSet(new ulong[]{0xC000860001C00020UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_return_statement2102 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_return_statement2105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_TRY_in_try_statement2123 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_block_in_try_statement2125 = new BitSet(new ulong[]{0x0000003000000000UL});
    public static readonly BitSet FOLLOW_catch_statements_in_try_statement2130 = new BitSet(new ulong[]{0x0000003000000002UL});
    public static readonly BitSet FOLLOW_finally_statement_in_try_statement2134 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_finally_statement_in_try_statement2147 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_catch_statement_in_catch_statements2173 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_KW_CATCH_in_catch_statement2193 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_catch_statement2195 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_catch_statement2197 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_catch_statement2199 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_catch_statement2201 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_block_in_catch_statement2203 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FINALLY_in_finally_statement2222 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_block_in_finally_statement2224 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_THROW_in_throw_statement2242 = new BitSet(new ulong[]{0xC000860001C00020UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_throw_statement2244 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_throw_statement2247 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEMI_in_empty_statement2265 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expression_statement2283 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_SEMI_in_expression_statement2285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_coalescing_expression_in_expression2305 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditional_or_expression_in_null_coalescing_expression2325 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000200000000UL});
    public static readonly BitSet FOLLOW_97_in_null_coalescing_expression2332 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_conditional_or_expression_in_null_coalescing_expression2336 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000200000000UL});
    public static readonly BitSet FOLLOW_conditional_and_expression_in_conditional_or_expression2357 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_98_in_conditional_or_expression2364 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_conditional_and_expression_in_conditional_or_expression2368 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000400000000UL});
    public static readonly BitSet FOLLOW_inclusive_or_expression_in_conditional_and_expression2389 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000800000000UL});
    public static readonly BitSet FOLLOW_99_in_conditional_and_expression2396 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_inclusive_or_expression_in_conditional_and_expression2400 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000800000000UL});
    public static readonly BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression2421 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_100_in_inclusive_or_expression2428 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression2432 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001000000000UL});
    public static readonly BitSet FOLLOW_and_expression_in_exclusive_or_expression2453 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_101_in_exclusive_or_expression2460 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_and_expression_in_exclusive_or_expression2464 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000002000000000UL});
    public static readonly BitSet FOLLOW_equality_expression_in_and_expression2485 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
    public static readonly BitSet FOLLOW_102_in_and_expression2492 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_equality_expression_in_and_expression2496 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000004000000000UL});
    public static readonly BitSet FOLLOW_relational_expression_in_equality_expression2517 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000018000000000UL});
    public static readonly BitSet FOLLOW_equality_operator_in_equality_expression2526 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_relational_expression_in_equality_expression2530 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000018000000000UL});
    public static readonly BitSet FOLLOW_103_in_equality_operator2549 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_104_in_equality_operator2556 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_shift_expression_in_relational_expression2576 = new BitSet(new ulong[]{0x0000018000000002UL,0x00001E0000000000UL});
    public static readonly BitSet FOLLOW_relational_operator_in_relational_expression2590 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_shift_expression_in_relational_expression2594 = new BitSet(new ulong[]{0x0000000000000002UL,0x00001E0000000000UL});
    public static readonly BitSet FOLLOW_KW_IS_in_relational_expression2605 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_relational_expression2609 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_AS_in_relational_expression2618 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_relational_expression2622 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_105_in_relational_operator2650 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_106_in_relational_operator2658 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_107_in_relational_operator2666 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_108_in_relational_operator2674 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_additive_expression_in_shift_expression2694 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000600000000000UL});
    public static readonly BitSet FOLLOW_shift_operator_in_shift_expression2703 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_additive_expression_in_shift_expression2707 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000600000000000UL});
    public static readonly BitSet FOLLOW_109_in_shift_operator2726 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_110_in_shift_operator2734 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression2754 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001800000000000UL});
    public static readonly BitSet FOLLOW_additive_operator_in_additive_expression2763 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression2767 = new BitSet(new ulong[]{0x0000000000000002UL,0x0001800000000000UL});
    public static readonly BitSet FOLLOW_111_in_additive_operator2786 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_112_in_additive_operator2793 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_multiplicative_expression2813 = new BitSet(new ulong[]{0x0000000000000002UL,0x000E000000000000UL});
    public static readonly BitSet FOLLOW_multiplicative_operator_in_multiplicative_expression2822 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_multiplicative_expression2826 = new BitSet(new ulong[]{0x0000000000000002UL,0x000E000000000000UL});
    public static readonly BitSet FOLLOW_113_in_multiplicative_operator2845 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_114_in_multiplicative_operator2852 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_115_in_multiplicative_operator2859 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_91_in_assignment_operator2872 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_116_in_complex_assignment_operator2888 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_117_in_complex_assignment_operator2896 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_118_in_complex_assignment_operator2904 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_119_in_complex_assignment_operator2912 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_120_in_complex_assignment_operator2920 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_121_in_complex_assignment_operator2928 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_122_in_complex_assignment_operator2936 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_123_in_complex_assignment_operator2944 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_124_in_complex_assignment_operator2952 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_125_in_complex_assignment_operator2960 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_cast_expression_in_unary_expression2984 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression2992 = new BitSet(new ulong[]{0x0000000000000002UL,0x3FF0000008000000UL});
    public static readonly BitSet FOLLOW_assignment_operator_in_unary_expression3002 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_unary_expression3006 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_complex_assignment_operator_in_unary_expression3020 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_unary_expression3024 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_111_in_unary_expression3050 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3054 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_112_in_unary_expression3062 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3066 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_126_in_unary_expression3074 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3078 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_127_in_unary_expression3086 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3090 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_128_in_unary_expression3098 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3102 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_129_in_unary_expression3110 = new BitSet(new ulong[]{0xC000860001C00000UL,0x000000004000001FUL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression3114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_cast_expression3132 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_cast_expression3134 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_cast_expression3136 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_cast_expression3138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primary_expression_in_postfix_expression3156 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x000000000000000CUL});
    public static readonly BitSet FOLLOW_130_in_postfix_expression3181 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_postfix_expression3185 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000040000000UL,0x000000000000000CUL});
    public static readonly BitSet FOLLOW_94_in_postfix_expression3204 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_postfix_expression3208 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_postfix_expression3211 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x000000000000000CUL});
    public static readonly BitSet FOLLOW_131_in_postfix_expression3248 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_postfix_expression3252 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000000UL,0x0000000000000010UL});
    public static readonly BitSet FOLLOW_132_in_postfix_expression3254 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x000000000000000CUL});
    public static readonly BitSet FOLLOW_array_creation_expression_in_primary_expression3284 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_object_creation_expression_in_primary_expression3294 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_THIS_in_primary_expression3303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_BASE_in_primary_expression3312 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_GLOBAL_in_primary_expression3321 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_primary_expression3330 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_primary_expression3344 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_primary_expression3348 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_primary_expression3351 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_literal_in_primary_expression3379 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typeof_expression_in_primary_expression3388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_primary_expression3397 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_primary_expression3399 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_primary_expression3401 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_TYPEOF_in_typeof_expression3419 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_typeof_expression3421 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_typeof_expression3423 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_typeof_expression3425 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_TYPEOF_in_typeof_expression3434 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_typeof_expression3436 = new BitSet(new ulong[]{0x0000000000100000UL});
    public static readonly BitSet FOLLOW_KW_VOID_in_typeof_expression3438 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_typeof_expression3440 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_typename_expression3460 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_130_in_typename_expression3468 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_typename_expression3472 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_KW_NEW_in_object_creation_expression3493 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_object_creation_expression3495 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_object_creation_expression3497 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC0018000C000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_object_creation_expression3499 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000080000000UL});
    public static readonly BitSet FOLLOW_95_in_object_creation_expression3502 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_NEW_in_array_creation_expression3520 = new BitSet(new ulong[]{0x3FFF800000000000UL});
    public static readonly BitSet FOLLOW_type_in_array_creation_expression3522 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_131_in_array_creation_expression3524 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expressions_list_in_array_creation_expression3526 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000000UL,0x0000000000000010UL});
    public static readonly BitSet FOLLOW_132_in_array_creation_expression3528 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expressions_list3553 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_COMMA_in_expressions_list3559 = new BitSet(new ulong[]{0xC000860001C00000UL,0xC00180004000001FUL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_expressions_list3563 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_KW_PUBLIC_in_access_modifier3583 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FAMILY_in_access_modifier3591 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_PRIVATE_in_access_modifier3599 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_INTERNAL_in_access_modifier3606 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_access_modifier_in_access_scope_directive3619 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000100000000UL});
    public static readonly BitSet FOLLOW_96_in_access_scope_directive3621 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ID_in_identifier3639 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primitive_type_in_type3657 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_array_specifier_in_type3659 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typename_expression_in_type3671 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_array_specifier_in_type3673 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_131_in_array_specifier3693 = new BitSet(new ulong[]{0x0000000000000800UL,0x0000000000000000UL,0x0000000000000010UL});
    public static readonly BitSet FOLLOW_array_rank_declaration_in_array_specifier3695 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000000UL,0x0000000000000010UL});
    public static readonly BitSet FOLLOW_132_in_array_specifier3698 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_array_rank_declaration3722 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_primitive_integral_type_in_primitive_type3749 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_CHAR_in_primitive_type3756 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_BOOL_in_primitive_type3764 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FLOAT_in_primitive_type3772 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_DOUBLE_in_primitive_type3780 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_STRING_in_primitive_type3788 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_OBJECT_in_primitive_type3796 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_BYTE_in_primitive_integral_type3819 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_SBYTE_in_primitive_integral_type3827 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_SHORT_in_primitive_integral_type3835 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_USHORT_in_primitive_integral_type3843 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_INT_in_primitive_integral_type3851 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_UINT_in_primitive_integral_type3859 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_LONG_in_primitive_integral_type3867 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_ULONG_in_primitive_integral_type3875 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_INTEGER_in_literal3898 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_REAL_in_literal3907 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_CHAR_in_literal3916 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_STRING_in_literal3925 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_TRUE_in_literal3934 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_FALSE_in_literal3943 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_KW_NULL_in_literal3952 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_cast_expression_in_synpred12_Grammar2979 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_synpred13_Grammar3199 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_synpred16_Grammar3340 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}