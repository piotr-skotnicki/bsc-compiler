// $ANTLR 3.2 Sep 23, 2009 12:02:23 D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g 2011-01-01 16:34:32

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


namespace 
	Compiler.Grammar

{
public partial class GrammarLexer : Lexer {
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
    public const int KW_BREAK = 32;
    public const int KW_INTERFACE = 14;
    public const int Digits = 78;
    public const int OctalDigits = 82;
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
    public const int KW_FINALLY = 37;
    public const int T__126 = 126;
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
    public const int KW_RETURN = 34;
    public const int KW_SET = 18;
    public const int T__105 = 105;
    public const int KW_DELEGATE = 15;
    public const int T__106 = 106;
    public const int T__111 = 111;
    public const int T__110 = 110;
    public const int KW_IN = 70;
    public const int T__113 = 113;
    public const int T__112 = 112;
    public const int KW_IS = 39;
    public const int IdTail = 74;
    public const int KW_TRY = 35;
    public const int KW_TYPEDEF = 6;
    public const int KW_IF = 26;
    public const int KW_THIS = 23;
    public const int HexDigits = 80;
    public const int KW_FALSE = 67;
    public const int KW_INTERNAL = 46;
    public const int KW_FINAL = 10;
    public const int KW_CONTINUE = 33;
    public const int KW_PRIVATE = 45;
    public const int LITERAL_CHAR = 64;
    public const int T__102 = 102;
    public const int KW_ENUM = 13;
    public const int T__101 = 101;
    public const int T__100 = 100;
    public const int KW_UINT = 59;
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
    public const int KW_NULL = 68;
    public const int KW_AUTO = 71;
    public const int KW_OBJECT = 53;
    public const int COMMENT_MULTILINE = 90;

    // delegates
    // delegators

    public GrammarLexer() 
    {
		InitializeCyclicDFAs();
    }
    public GrammarLexer(ICharStream input)
		: this(input, null) {
    }
    public GrammarLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g";} 
    }

    // $ANTLR start "T__91"
    public void mT__91() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__91;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:11:7: ( '=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:11:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__91"

    // $ANTLR start "T__92"
    public void mT__92() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__92;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:12:7: ( '{' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:12:9: '{'
            {
            	Match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__92"

    // $ANTLR start "T__93"
    public void mT__93() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__93;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:13:7: ( '}' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:13:9: '}'
            {
            	Match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__93"

    // $ANTLR start "T__94"
    public void mT__94() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__94;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:14:7: ( '(' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:14:9: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__94"

    // $ANTLR start "T__95"
    public void mT__95() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__95;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:15:7: ( ')' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:15:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__95"

    // $ANTLR start "T__96"
    public void mT__96() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__96;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:16:7: ( ':' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:16:9: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__96"

    // $ANTLR start "T__97"
    public void mT__97() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__97;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:17:7: ( '??' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:17:9: '??'
            {
            	Match("??"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__97"

    // $ANTLR start "T__98"
    public void mT__98() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__98;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:18:7: ( '||' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:18:9: '||'
            {
            	Match("||"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__98"

    // $ANTLR start "T__99"
    public void mT__99() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__99;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:19:7: ( '&&' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:19:9: '&&'
            {
            	Match("&&"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__99"

    // $ANTLR start "T__100"
    public void mT__100() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__100;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:20:8: ( '|' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:20:10: '|'
            {
            	Match('|'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__100"

    // $ANTLR start "T__101"
    public void mT__101() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__101;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:21:8: ( '^' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:21:10: '^'
            {
            	Match('^'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__101"

    // $ANTLR start "T__102"
    public void mT__102() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__102;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:22:8: ( '&' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:22:10: '&'
            {
            	Match('&'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__102"

    // $ANTLR start "T__103"
    public void mT__103() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__103;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:23:8: ( '==' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:23:10: '=='
            {
            	Match("=="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__103"

    // $ANTLR start "T__104"
    public void mT__104() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__104;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:24:8: ( '!=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:24:10: '!='
            {
            	Match("!="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__104"

    // $ANTLR start "T__105"
    public void mT__105() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__105;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:25:8: ( '<' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:25:10: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__105"

    // $ANTLR start "T__106"
    public void mT__106() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__106;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:26:8: ( '>' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:26:10: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__106"

    // $ANTLR start "T__107"
    public void mT__107() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__107;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:27:8: ( '<=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:27:10: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__107"

    // $ANTLR start "T__108"
    public void mT__108() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__108;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:28:8: ( '>=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:28:10: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__108"

    // $ANTLR start "T__109"
    public void mT__109() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__109;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:29:8: ( '<<' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:29:10: '<<'
            {
            	Match("<<"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__109"

    // $ANTLR start "T__110"
    public void mT__110() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__110;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:30:8: ( '>>' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:30:10: '>>'
            {
            	Match(">>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__110"

    // $ANTLR start "T__111"
    public void mT__111() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__111;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:31:8: ( '+' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:31:10: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__111"

    // $ANTLR start "T__112"
    public void mT__112() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__112;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:32:8: ( '-' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:32:10: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__112"

    // $ANTLR start "T__113"
    public void mT__113() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__113;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:33:8: ( '*' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:33:10: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__113"

    // $ANTLR start "T__114"
    public void mT__114() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__114;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:34:8: ( '/' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:34:10: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__114"

    // $ANTLR start "T__115"
    public void mT__115() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__115;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:35:8: ( '%' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:35:10: '%'
            {
            	Match('%'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__115"

    // $ANTLR start "T__116"
    public void mT__116() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__116;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:36:8: ( '+=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:36:10: '+='
            {
            	Match("+="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__116"

    // $ANTLR start "T__117"
    public void mT__117() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__117;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:37:8: ( '-=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:37:10: '-='
            {
            	Match("-="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__117"

    // $ANTLR start "T__118"
    public void mT__118() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__118;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:38:8: ( '*=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:38:10: '*='
            {
            	Match("*="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__118"

    // $ANTLR start "T__119"
    public void mT__119() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__119;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:39:8: ( '/=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:39:10: '/='
            {
            	Match("/="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__119"

    // $ANTLR start "T__120"
    public void mT__120() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__120;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:40:8: ( '%=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:40:10: '%='
            {
            	Match("%="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__120"

    // $ANTLR start "T__121"
    public void mT__121() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__121;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:41:8: ( '&=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:41:10: '&='
            {
            	Match("&="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__121"

    // $ANTLR start "T__122"
    public void mT__122() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__122;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:42:8: ( '|=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:42:10: '|='
            {
            	Match("|="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__122"

    // $ANTLR start "T__123"
    public void mT__123() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__123;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:43:8: ( '^=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:43:10: '^='
            {
            	Match("^="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__123"

    // $ANTLR start "T__124"
    public void mT__124() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__124;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:44:8: ( '<<=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:44:10: '<<='
            {
            	Match("<<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__124"

    // $ANTLR start "T__125"
    public void mT__125() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__125;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:45:8: ( '>>=' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:45:10: '>>='
            {
            	Match(">>="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__125"

    // $ANTLR start "T__126"
    public void mT__126() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__126;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:46:8: ( '!' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:46:10: '!'
            {
            	Match('!'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__126"

    // $ANTLR start "T__127"
    public void mT__127() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__127;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:47:8: ( '~' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:47:10: '~'
            {
            	Match('~'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__127"

    // $ANTLR start "T__128"
    public void mT__128() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__128;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:48:8: ( '++' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:48:10: '++'
            {
            	Match("++"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__128"

    // $ANTLR start "T__129"
    public void mT__129() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__129;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:49:8: ( '--' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:49:10: '--'
            {
            	Match("--"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__129"

    // $ANTLR start "T__130"
    public void mT__130() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__130;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:50:8: ( '.' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:50:10: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__130"

    // $ANTLR start "T__131"
    public void mT__131() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__131;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:51:8: ( '[' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:51:10: '['
            {
            	Match('['); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__131"

    // $ANTLR start "T__132"
    public void mT__132() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__132;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:52:8: ( ']' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:52:10: ']'
            {
            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__132"

    // $ANTLR start "KW_CLASS"
    public void mKW_CLASS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_CLASS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1424:10: ( 'class' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1424:12: 'class'
            {
            	Match("class"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_CLASS"

    // $ANTLR start "KW_STRUCT"
    public void mKW_STRUCT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_STRUCT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1426:11: ( 'struct' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1426:13: 'struct'
            {
            	Match("struct"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_STRUCT"

    // $ANTLR start "KW_ENUM"
    public void mKW_ENUM() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_ENUM;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1428:9: ( 'enum' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1428:11: 'enum'
            {
            	Match("enum"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_ENUM"

    // $ANTLR start "KW_INTERFACE"
    public void mKW_INTERFACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_INTERFACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1430:14: ( 'interface' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1430:16: 'interface'
            {
            	Match("interface"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_INTERFACE"

    // $ANTLR start "KW_NAMESPACE"
    public void mKW_NAMESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_NAMESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1432:14: ( 'namespace' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1432:16: 'namespace'
            {
            	Match("namespace"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_NAMESPACE"

    // $ANTLR start "KW_THIS"
    public void mKW_THIS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_THIS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1434:9: ( 'this' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1434:11: 'this'
            {
            	Match("this"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_THIS"

    // $ANTLR start "KW_BASE"
    public void mKW_BASE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_BASE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1436:9: ( 'base' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1436:11: 'base'
            {
            	Match("base"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_BASE"

    // $ANTLR start "KW_GLOBAL"
    public void mKW_GLOBAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_GLOBAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1438:11: ( 'global' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1438:13: 'global'
            {
            	Match("global"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_GLOBAL"

    // $ANTLR start "KW_NULL"
    public void mKW_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1440:9: ( 'null' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1440:11: 'null'
            {
            	Match("null"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_NULL"

    // $ANTLR start "KW_TRUE"
    public void mKW_TRUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_TRUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1442:9: ( 'true' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1442:11: 'true'
            {
            	Match("true"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_TRUE"

    // $ANTLR start "KW_FALSE"
    public void mKW_FALSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FALSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1444:10: ( 'false' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1444:12: 'false'
            {
            	Match("false"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FALSE"

    // $ANTLR start "KW_IF"
    public void mKW_IF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_IF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1446:7: ( 'if' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1446:9: 'if'
            {
            	Match("if"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_IF"

    // $ANTLR start "KW_ELSE"
    public void mKW_ELSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_ELSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1448:9: ( 'else' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1448:11: 'else'
            {
            	Match("else"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_ELSE"

    // $ANTLR start "KW_FOR"
    public void mKW_FOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1450:8: ( 'for' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1450:10: 'for'
            {
            	Match("for"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FOR"

    // $ANTLR start "KW_FOREACH"
    public void mKW_FOREACH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FOREACH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1452:12: ( 'foreach' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1452:14: 'foreach'
            {
            	Match("foreach"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FOREACH"

    // $ANTLR start "KW_IN"
    public void mKW_IN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_IN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1454:7: ( 'in' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1454:9: 'in'
            {
            	Match("in"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_IN"

    // $ANTLR start "KW_WHILE"
    public void mKW_WHILE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_WHILE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1456:10: ( 'while' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1456:12: 'while'
            {
            	Match("while"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_WHILE"

    // $ANTLR start "KW_DO"
    public void mKW_DO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_DO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1458:7: ( 'do' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1458:9: 'do'
            {
            	Match("do"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_DO"

    // $ANTLR start "KW_BREAK"
    public void mKW_BREAK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_BREAK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1460:10: ( 'break' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1460:12: 'break'
            {
            	Match("break"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_BREAK"

    // $ANTLR start "KW_CONTINUE"
    public void mKW_CONTINUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_CONTINUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1462:13: ( 'continue' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1462:15: 'continue'
            {
            	Match("continue"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_CONTINUE"

    // $ANTLR start "KW_GOTO"
    public void mKW_GOTO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_GOTO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1464:9: ( 'goto' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1464:11: 'goto'
            {
            	Match("goto"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_GOTO"

    // $ANTLR start "KW_RETURN"
    public void mKW_RETURN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_RETURN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1466:11: ( 'return' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1466:13: 'return'
            {
            	Match("return"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_RETURN"

    // $ANTLR start "KW_TRY"
    public void mKW_TRY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_TRY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1468:8: ( 'try' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1468:10: 'try'
            {
            	Match("try"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_TRY"

    // $ANTLR start "KW_CATCH"
    public void mKW_CATCH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_CATCH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1470:10: ( 'catch' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1470:12: 'catch'
            {
            	Match("catch"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_CATCH"

    // $ANTLR start "KW_FINALLY"
    public void mKW_FINALLY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FINALLY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1472:12: ( 'finally' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1472:14: 'finally'
            {
            	Match("finally"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FINALLY"

    // $ANTLR start "KW_THROW"
    public void mKW_THROW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_THROW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1474:10: ( 'raise' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1474:12: 'raise'
            {
            	Match("raise"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_THROW"

    // $ANTLR start "KW_USING"
    public void mKW_USING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_USING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1476:10: ( 'using' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1476:12: 'using'
            {
            	Match("using"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_USING"

    // $ANTLR start "KW_TYPEDEF"
    public void mKW_TYPEDEF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_TYPEDEF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1478:12: ( 'typedef' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1478:14: 'typedef'
            {
            	Match("typedef"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_TYPEDEF"

    // $ANTLR start "KW_PRIVATE"
    public void mKW_PRIVATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_PRIVATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1480:12: ( 'private' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1480:14: 'private'
            {
            	Match("private"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_PRIVATE"

    // $ANTLR start "KW_FAMILY"
    public void mKW_FAMILY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FAMILY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1482:11: ( 'family' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1482:13: 'family'
            {
            	Match("family"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FAMILY"

    // $ANTLR start "KW_PUBLIC"
    public void mKW_PUBLIC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_PUBLIC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1484:11: ( 'public' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1484:13: 'public'
            {
            	Match("public"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_PUBLIC"

    // $ANTLR start "KW_INTERNAL"
    public void mKW_INTERNAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_INTERNAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1486:13: ( 'internal' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1486:15: 'internal'
            {
            	Match("internal"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_INTERNAL"

    // $ANTLR start "KW_ABSTRACT"
    public void mKW_ABSTRACT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_ABSTRACT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1488:13: ( 'abstract' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1488:15: 'abstract'
            {
            	Match("abstract"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_ABSTRACT"

    // $ANTLR start "KW_VIRTUAL"
    public void mKW_VIRTUAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_VIRTUAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1490:12: ( 'virtual' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1490:14: 'virtual'
            {
            	Match("virtual"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_VIRTUAL"

    // $ANTLR start "KW_FINAL"
    public void mKW_FINAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FINAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1492:10: ( 'final' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1492:12: 'final'
            {
            	Match("final"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FINAL"

    // $ANTLR start "KW_STATIC"
    public void mKW_STATIC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_STATIC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1494:11: ( 'shared' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1494:13: 'shared'
            {
            	Match("shared"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_STATIC"

    // $ANTLR start "KW_AUTO"
    public void mKW_AUTO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_AUTO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1496:9: ( 'auto' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1496:11: 'auto'
            {
            	Match("auto"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_AUTO"

    // $ANTLR start "KW_VAR"
    public void mKW_VAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_VAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1498:8: ( 'var' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1498:10: 'var'
            {
            	Match("var"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_VAR"

    // $ANTLR start "KW_NEW"
    public void mKW_NEW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_NEW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1500:8: ( 'new' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1500:10: 'new'
            {
            	Match("new"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_NEW"

    // $ANTLR start "KW_TYPEOF"
    public void mKW_TYPEOF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_TYPEOF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1502:11: ( 'typeof' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1502:13: 'typeof'
            {
            	Match("typeof"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_TYPEOF"

    // $ANTLR start "KW_IS"
    public void mKW_IS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_IS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1504:7: ( 'is' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1504:9: 'is'
            {
            	Match("is"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_IS"

    // $ANTLR start "KW_AS"
    public void mKW_AS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_AS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1506:7: ( 'as' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1506:9: 'as'
            {
            	Match("as"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_AS"

    // $ANTLR start "KW_SIGNAL"
    public void mKW_SIGNAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_SIGNAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1508:11: ( 'signal' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1508:13: 'signal'
            {
            	Match("signal"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_SIGNAL"

    // $ANTLR start "KW_DELEGATE"
    public void mKW_DELEGATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_DELEGATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1510:13: ( 'function' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1510:15: 'function'
            {
            	Match("function"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_DELEGATE"

    // $ANTLR start "KW_GET"
    public void mKW_GET() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_GET;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1512:8: ( 'get' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1512:10: 'get'
            {
            	Match("get"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_GET"

    // $ANTLR start "KW_SET"
    public void mKW_SET() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_SET;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1514:8: ( 'set' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1514:10: 'set'
            {
            	Match("set"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_SET"

    // $ANTLR start "KW_CHAR"
    public void mKW_CHAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_CHAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1516:9: ( 'char' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1516:11: 'char'
            {
            	Match("char"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_CHAR"

    // $ANTLR start "KW_BYTE"
    public void mKW_BYTE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_BYTE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1518:9: ( 'byte' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1518:11: 'byte'
            {
            	Match("byte"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_BYTE"

    // $ANTLR start "KW_SBYTE"
    public void mKW_SBYTE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_SBYTE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1520:10: ( 'sbyte' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1520:12: 'sbyte'
            {
            	Match("sbyte"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_SBYTE"

    // $ANTLR start "KW_SHORT"
    public void mKW_SHORT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_SHORT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1522:10: ( 'short' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1522:12: 'short'
            {
            	Match("short"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_SHORT"

    // $ANTLR start "KW_USHORT"
    public void mKW_USHORT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_USHORT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1524:11: ( 'ushort' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1524:13: 'ushort'
            {
            	Match("ushort"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_USHORT"

    // $ANTLR start "KW_INT"
    public void mKW_INT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_INT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1526:8: ( 'int' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1526:10: 'int'
            {
            	Match("int"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_INT"

    // $ANTLR start "KW_UINT"
    public void mKW_UINT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_UINT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1528:9: ( 'uint' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1528:11: 'uint'
            {
            	Match("uint"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_UINT"

    // $ANTLR start "KW_LONG"
    public void mKW_LONG() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_LONG;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1530:9: ( 'long' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1530:11: 'long'
            {
            	Match("long"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_LONG"

    // $ANTLR start "KW_ULONG"
    public void mKW_ULONG() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_ULONG;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1532:10: ( 'ulong' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1532:12: 'ulong'
            {
            	Match("ulong"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_ULONG"

    // $ANTLR start "KW_FLOAT"
    public void mKW_FLOAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_FLOAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1534:10: ( 'float' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1534:12: 'float'
            {
            	Match("float"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_FLOAT"

    // $ANTLR start "KW_DOUBLE"
    public void mKW_DOUBLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_DOUBLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1536:11: ( 'double' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1536:13: 'double'
            {
            	Match("double"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_DOUBLE"

    // $ANTLR start "KW_DECIMAL"
    public void mKW_DECIMAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_DECIMAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1538:12: ( 'decimal' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1538:14: 'decimal'
            {
            	Match("decimal"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_DECIMAL"

    // $ANTLR start "KW_STRING"
    public void mKW_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1540:11: ( 'string' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1540:13: 'string'
            {
            	Match("string"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_STRING"

    // $ANTLR start "KW_OBJECT"
    public void mKW_OBJECT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_OBJECT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1542:11: ( 'object' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1542:13: 'object'
            {
            	Match("object"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_OBJECT"

    // $ANTLR start "KW_BOOL"
    public void mKW_BOOL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_BOOL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1544:9: ( 'bool' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1544:11: 'bool'
            {
            	Match("bool"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_BOOL"

    // $ANTLR start "KW_VOID"
    public void mKW_VOID() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KW_VOID;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1546:9: ( 'void' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1546:11: 'void'
            {
            	Match("void"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KW_VOID"

    // $ANTLR start "SEMI"
    public void mSEMI() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEMI;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1549:6: ( ';' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1549:8: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SEMI"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1551:7: ( ',' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1551:9: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMA"

    // $ANTLR start "ID"
    public void mID() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ID;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1554:4: ( IdHead ( IdTail )* )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1554:6: IdHead ( IdTail )*
            {
            	mIdHead(); 
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1554:13: ( IdTail )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= '0' && LA1_0 <= '9') || (LA1_0 >= 'A' && LA1_0 <= 'Z') || LA1_0 == '_' || (LA1_0 >= 'a' && LA1_0 <= 'z')) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1554:13: IdTail
            			    {
            			    	mIdTail(); 

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ID"

    // $ANTLR start "IdHead"
    public void mIdHead() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1557:2: ( NotAKeywordPrefix ( IdTail )+ | '_' | Letter )
            int alt3 = 3;
            switch ( input.LA(1) ) 
            {
            case '$':
            	{
                alt3 = 1;
                }
                break;
            case '_':
            	{
                alt3 = 2;
                }
                break;
            case 'A':
            case 'B':
            case 'C':
            case 'D':
            case 'E':
            case 'F':
            case 'G':
            case 'H':
            case 'I':
            case 'J':
            case 'K':
            case 'L':
            case 'M':
            case 'N':
            case 'O':
            case 'P':
            case 'Q':
            case 'R':
            case 'S':
            case 'T':
            case 'U':
            case 'V':
            case 'W':
            case 'X':
            case 'Y':
            case 'Z':
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
            case 'g':
            case 'h':
            case 'i':
            case 'j':
            case 'k':
            case 'l':
            case 'm':
            case 'n':
            case 'o':
            case 'p':
            case 'q':
            case 'r':
            case 's':
            case 't':
            case 'u':
            case 'v':
            case 'w':
            case 'x':
            case 'y':
            case 'z':
            	{
                alt3 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d3s0 =
            	        new NoViableAltException("", 3, 0, input);

            	    throw nvae_d3s0;
            }

            switch (alt3) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1557:4: NotAKeywordPrefix ( IdTail )+
                    {
                    	mNotAKeywordPrefix(); 
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1557:22: ( IdTail )+
                    	int cnt2 = 0;
                    	do 
                    	{
                    	    int alt2 = 2;
                    	    int LA2_0 = input.LA(1);

                    	    if ( ((LA2_0 >= '0' && LA2_0 <= '9') || (LA2_0 >= 'A' && LA2_0 <= 'Z') || LA2_0 == '_' || (LA2_0 >= 'a' && LA2_0 <= 'z')) )
                    	    {
                    	        alt2 = 1;
                    	    }


                    	    switch (alt2) 
                    		{
                    			case 1 :
                    			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1557:22: IdTail
                    			    {
                    			    	mIdTail(); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt2 >= 1 ) goto loop2;
                    		            EarlyExitException eee2 =
                    		                new EarlyExitException(2, input);
                    		            throw eee2;
                    	    }
                    	    cnt2++;
                    	} while (true);

                    	loop2:
                    		;	// Stops C# compiler whining that label 'loop2' has no statements


                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1558:4: '_'
                    {
                    	Match('_'); 

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1559:4: Letter
                    {
                    	mLetter(); 

                    }
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IdHead"

    // $ANTLR start "NotAKeywordPrefix"
    public void mNotAKeywordPrefix() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1563:2: ( '$' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1563:4: '$'
            {
            	Match('$'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "NotAKeywordPrefix"

    // $ANTLR start "IdTail"
    public void mIdTail() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1567:2: ( Letter | Digit | '_' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            {
            	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "IdTail"

    // $ANTLR start "Letter"
    public void mLetter() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1573:2: ( 'A' .. 'Z' | 'a' .. 'z' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Letter"

    // $ANTLR start "Digit"
    public void mDigit() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1578:2: ( '0' .. '9' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1578:4: '0' .. '9'
            {
            	MatchRange('0','9'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Digit"

    // $ANTLR start "Digits"
    public void mDigits() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1582:2: ( ( Digit )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1582:4: ( Digit )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1582:4: ( Digit )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '0' && LA4_0 <= '9')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1582:4: Digit
            			    {
            			    	mDigit(); 

            			    }
            			    break;

            			default:
            			    if ( cnt4 >= 1 ) goto loop4;
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
        finally 
    	{
        }
    }
    // $ANTLR end "Digits"

    // $ANTLR start "HexDigit"
    public void mHexDigit() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1586:2: ( Digit | 'A' .. 'F' | 'a' .. 'f' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            {
            	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'F') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "HexDigit"

    // $ANTLR start "HexDigits"
    public void mHexDigits() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1592:2: ( ( HexDigit )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1592:4: ( HexDigit )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1592:4: ( HexDigit )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '0' && LA5_0 <= '9') || (LA5_0 >= 'A' && LA5_0 <= 'F') || (LA5_0 >= 'a' && LA5_0 <= 'f')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1592:4: HexDigit
            			    {
            			    	mHexDigit(); 

            			    }
            			    break;

            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
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
        finally 
    	{
        }
    }
    // $ANTLR end "HexDigits"

    // $ANTLR start "OctalDigit"
    public void mOctalDigit() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1596:2: ( '0' .. '7' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1596:4: '0' .. '7'
            {
            	MatchRange('0','7'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "OctalDigit"

    // $ANTLR start "OctalDigits"
    public void mOctalDigits() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1600:2: ( ( OctalDigit )+ )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1600:4: ( OctalDigit )+
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1600:4: ( OctalDigit )+
            	int cnt6 = 0;
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( ((LA6_0 >= '0' && LA6_0 <= '7')) )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1600:4: OctalDigit
            			    {
            			    	mOctalDigit(); 

            			    }
            			    break;

            			default:
            			    if ( cnt6 >= 1 ) goto loop6;
            		            EarlyExitException eee6 =
            		                new EarlyExitException(6, input);
            		            throw eee6;
            	    }
            	    cnt6++;
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "OctalDigits"

    // $ANTLR start "Exponent"
    public void mExponent() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1604:2: ( ( 'E' | 'e' ) ( Sign )? Digits )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1604:4: ( 'E' | 'e' ) ( Sign )? Digits
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1604:16: ( Sign )?
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == '+' || LA7_0 == '-') )
            	{
            	    alt7 = 1;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1604:16: Sign
            	        {
            	        	mSign(); 

            	        }
            	        break;

            	}

            	mDigits(); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Exponent"

    // $ANTLR start "Sign"
    public void mSign() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1608:2: ( '+' | '-' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            {
            	if ( input.LA(1) == '+' || input.LA(1) == '-' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Sign"

    // $ANTLR start "IntegerSuffix"
    public void mIntegerSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:2: ( 'u' | 'U' | 'l' | 'L' | 'ul' | 'UL' | 'Ul' | 'uL' | 'LU' | 'Lu' | 'lU' )
            int alt8 = 11;
            alt8 = dfa8.Predict(input);
            switch (alt8) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:4: 'u'
                    {
                    	Match('u'); 

                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:10: 'U'
                    {
                    	Match('U'); 

                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:16: 'l'
                    {
                    	Match('l'); 

                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:22: 'L'
                    {
                    	Match('L'); 

                    }
                    break;
                case 5 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:28: 'ul'
                    {
                    	Match("ul"); 


                    }
                    break;
                case 6 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:35: 'UL'
                    {
                    	Match("UL"); 


                    }
                    break;
                case 7 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:42: 'Ul'
                    {
                    	Match("Ul"); 


                    }
                    break;
                case 8 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:49: 'uL'
                    {
                    	Match("uL"); 


                    }
                    break;
                case 9 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:56: 'LU'
                    {
                    	Match("LU"); 


                    }
                    break;
                case 10 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:63: 'Lu'
                    {
                    	Match("Lu"); 


                    }
                    break;
                case 11 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1612:70: 'lU'
                    {
                    	Match("lU"); 


                    }
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IntegerSuffix"

    // $ANTLR start "RealSuffix"
    public void mRealSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1616:2: ( 'd' | 'f' | 'D' | 'F' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            {
            	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "RealSuffix"

    // $ANTLR start "LITERAL_INTEGER"
    public void mLITERAL_INTEGER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LITERAL_INTEGER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1620:2: ( ( Digits | '0' ( 'x' | 'X' ) HexDigits ) ( IntegerSuffix )? )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1620:4: ( Digits | '0' ( 'x' | 'X' ) HexDigits ) ( IntegerSuffix )?
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1620:4: ( Digits | '0' ( 'x' | 'X' ) HexDigits )
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( (LA9_0 == '0') )
            	{
            	    int LA9_1 = input.LA(2);

            	    if ( (LA9_1 == 'X' || LA9_1 == 'x') )
            	    {
            	        alt9 = 2;
            	    }
            	    else 
            	    {
            	        alt9 = 1;}
            	}
            	else if ( ((LA9_0 >= '1' && LA9_0 <= '9')) )
            	{
            	    alt9 = 1;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d9s0 =
            	        new NoViableAltException("", 9, 0, input);

            	    throw nvae_d9s0;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1620:5: Digits
            	        {
            	        	mDigits(); 

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1621:4: '0' ( 'x' | 'X' ) HexDigits
            	        {
            	        	Match('0'); 
            	        	if ( input.LA(1) == 'X' || input.LA(1) == 'x' ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}

            	        	mHexDigits(); 

            	        }
            	        break;

            	}

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1624:2: ( IntegerSuffix )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == 'L' || LA10_0 == 'U' || LA10_0 == 'l' || LA10_0 == 'u') )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1624:2: IntegerSuffix
            	        {
            	        	mIntegerSuffix(); 

            	        }
            	        break;

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LITERAL_INTEGER"

    // $ANTLR start "LITERAL_REAL"
    public void mLITERAL_REAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LITERAL_REAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:2: ( Digits '.' Digits ( Exponent )? ( RealSuffix )? | '.' Digits ( Exponent )? ( RealSuffix )? | Digits Exponent ( RealSuffix )? | Digits RealSuffix )
            int alt16 = 4;
            alt16 = dfa16.Predict(input);
            switch (alt16) 
            {
                case 1 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:4: Digits '.' Digits ( Exponent )? ( RealSuffix )?
                    {
                    	mDigits(); 
                    	Match('.'); 
                    	mDigits(); 
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:22: ( Exponent )?
                    	int alt11 = 2;
                    	int LA11_0 = input.LA(1);

                    	if ( (LA11_0 == 'E' || LA11_0 == 'e') )
                    	{
                    	    alt11 = 1;
                    	}
                    	switch (alt11) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:22: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:32: ( RealSuffix )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'D' || LA12_0 == 'F' || LA12_0 == 'd' || LA12_0 == 'f') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1628:32: RealSuffix
                    	        {
                    	        	mRealSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1629:4: '.' Digits ( Exponent )? ( RealSuffix )?
                    {
                    	Match('.'); 
                    	mDigits(); 
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1629:15: ( Exponent )?
                    	int alt13 = 2;
                    	int LA13_0 = input.LA(1);

                    	if ( (LA13_0 == 'E' || LA13_0 == 'e') )
                    	{
                    	    alt13 = 1;
                    	}
                    	switch (alt13) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1629:15: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1629:25: ( RealSuffix )?
                    	int alt14 = 2;
                    	int LA14_0 = input.LA(1);

                    	if ( (LA14_0 == 'D' || LA14_0 == 'F' || LA14_0 == 'd' || LA14_0 == 'f') )
                    	{
                    	    alt14 = 1;
                    	}
                    	switch (alt14) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1629:25: RealSuffix
                    	        {
                    	        	mRealSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1630:4: Digits Exponent ( RealSuffix )?
                    {
                    	mDigits(); 
                    	mExponent(); 
                    	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1630:20: ( RealSuffix )?
                    	int alt15 = 2;
                    	int LA15_0 = input.LA(1);

                    	if ( (LA15_0 == 'D' || LA15_0 == 'F' || LA15_0 == 'd' || LA15_0 == 'f') )
                    	{
                    	    alt15 = 1;
                    	}
                    	switch (alt15) 
                    	{
                    	    case 1 :
                    	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1630:20: RealSuffix
                    	        {
                    	        	mRealSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 4 :
                    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1631:4: Digits RealSuffix
                    {
                    	mDigits(); 
                    	mRealSuffix(); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LITERAL_REAL"

    // $ANTLR start "LITERAL_STRING"
    public void mLITERAL_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LITERAL_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1635:2: ( '\"' ( EscapeSequence | ~ ( '\"' | '\\\\' ) )* '\"' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1635:4: '\"' ( EscapeSequence | ~ ( '\"' | '\\\\' ) )* '\"'
            {
            	Match('\"'); 
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1635:8: ( EscapeSequence | ~ ( '\"' | '\\\\' ) )*
            	do 
            	{
            	    int alt17 = 3;
            	    int LA17_0 = input.LA(1);

            	    if ( (LA17_0 == '\\') )
            	    {
            	        alt17 = 1;
            	    }
            	    else if ( ((LA17_0 >= '\u0000' && LA17_0 <= '!') || (LA17_0 >= '#' && LA17_0 <= '[') || (LA17_0 >= ']' && LA17_0 <= '\uFFFF')) )
            	    {
            	        alt17 = 2;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1635:9: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1635:26: ~ ( '\"' | '\\\\' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LITERAL_STRING"

    // $ANTLR start "LITERAL_CHAR"
    public void mLITERAL_CHAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LITERAL_CHAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1639:2: ( '\\'' ( EscapeSequence | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ) '\\'' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1639:4: '\\'' ( EscapeSequence | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ) '\\''
            {
            	Match('\''); 
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1640:2: ( EscapeSequence | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) | ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) )
            	int alt18 = 4;
            	int LA18_0 = input.LA(1);

            	if ( (LA18_0 == '\\') )
            	{
            	    alt18 = 1;
            	}
            	else if ( ((LA18_0 >= '\u0000' && LA18_0 <= '\t') || (LA18_0 >= '\u000B' && LA18_0 <= '\f') || (LA18_0 >= '\u000E' && LA18_0 <= '&') || (LA18_0 >= '(' && LA18_0 <= '[') || (LA18_0 >= ']' && LA18_0 <= '\uFFFF')) )
            	{
            	    int LA18_2 = input.LA(2);

            	    if ( ((LA18_2 >= '\u0000' && LA18_2 <= '\t') || (LA18_2 >= '\u000B' && LA18_2 <= '\f') || (LA18_2 >= '\u000E' && LA18_2 <= '&') || (LA18_2 >= '(' && LA18_2 <= '[') || (LA18_2 >= ']' && LA18_2 <= '\uFFFF')) )
            	    {
            	        int LA18_3 = input.LA(3);

            	        if ( ((LA18_3 >= '\u0000' && LA18_3 <= '\t') || (LA18_3 >= '\u000B' && LA18_3 <= '\f') || (LA18_3 >= '\u000E' && LA18_3 <= '&') || (LA18_3 >= '(' && LA18_3 <= '[') || (LA18_3 >= ']' && LA18_3 <= '\uFFFF')) )
            	        {
            	            alt18 = 4;
            	        }
            	        else if ( (LA18_3 == '\'') )
            	        {
            	            alt18 = 3;
            	        }
            	        else 
            	        {
            	            NoViableAltException nvae_d18s3 =
            	                new NoViableAltException("", 18, 3, input);

            	            throw nvae_d18s3;
            	        }
            	    }
            	    else if ( (LA18_2 == '\'') )
            	    {
            	        alt18 = 2;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d18s2 =
            	            new NoViableAltException("", 18, 2, input);

            	        throw nvae_d18s2;
            	    }
            	}
            	else 
            	{
            	    NoViableAltException nvae_d18s0 =
            	        new NoViableAltException("", 18, 0, input);

            	    throw nvae_d18s0;
            	}
            	switch (alt18) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1640:3: EscapeSequence
            	        {
            	        	mEscapeSequence(); 

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1641:4: ~ ( '\\\\' | '\\'' | '\\r' | '\\n' )
            	        {
            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;
            	    case 3 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1642:4: ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' )
            	        {
            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}

            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;
            	    case 4 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1643:4: ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' ) ~ ( '\\\\' | '\\'' | '\\r' | '\\n' )
            	        {
            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}

            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}

            	        	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;

            	}

            	Match('\''); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LITERAL_CHAR"

    // $ANTLR start "EscapeSequence"
    public void mEscapeSequence() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1649:2: ( '\\\\' ( 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v' | '\\\"' | '\\'' | '\\\\' | ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) | 'x' HexDigit | 'x' HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit HexDigit | 'u' HexDigit HexDigit HexDigit | 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1649:4: '\\\\' ( 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v' | '\\\"' | '\\'' | '\\\\' | ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) | 'x' HexDigit | 'x' HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit HexDigit | 'u' HexDigit HexDigit HexDigit | 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit )
            {
            	Match('\\'); 
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1650:2: ( 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v' | '\\\"' | '\\'' | '\\\\' | ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) | 'x' HexDigit | 'x' HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit HexDigit | 'u' HexDigit HexDigit HexDigit | 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit )
            	int alt19 = 19;
            	alt19 = dfa19.Predict(input);
            	switch (alt19) 
            	{
            	    case 1 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1650:3: 'a'
            	        {
            	        	Match('a'); 

            	        }
            	        break;
            	    case 2 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1651:4: 'b'
            	        {
            	        	Match('b'); 

            	        }
            	        break;
            	    case 3 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1652:4: 'f'
            	        {
            	        	Match('f'); 

            	        }
            	        break;
            	    case 4 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1653:4: 'n'
            	        {
            	        	Match('n'); 

            	        }
            	        break;
            	    case 5 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1654:4: 'r'
            	        {
            	        	Match('r'); 

            	        }
            	        break;
            	    case 6 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1655:4: 't'
            	        {
            	        	Match('t'); 

            	        }
            	        break;
            	    case 7 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1656:4: 'v'
            	        {
            	        	Match('v'); 

            	        }
            	        break;
            	    case 8 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1657:4: '\\\"'
            	        {
            	        	Match('\"'); 

            	        }
            	        break;
            	    case 9 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1658:4: '\\''
            	        {
            	        	Match('\''); 

            	        }
            	        break;
            	    case 10 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1659:4: '\\\\'
            	        {
            	        	Match('\\'); 

            	        }
            	        break;
            	    case 11 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:4: ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
            	        {
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:4: ( '0' .. '3' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:5: '0' .. '3'
            	        	{
            	        		MatchRange('0','3'); 

            	        	}

            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:15: ( '0' .. '7' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:16: '0' .. '7'
            	        	{
            	        		MatchRange('0','7'); 

            	        	}

            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:26: ( '0' .. '7' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1660:27: '0' .. '7'
            	        	{
            	        		MatchRange('0','7'); 

            	        	}


            	        }
            	        break;
            	    case 12 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1661:4: ( '0' .. '7' ) ( '0' .. '7' )
            	        {
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1661:4: ( '0' .. '7' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1661:5: '0' .. '7'
            	        	{
            	        		MatchRange('0','7'); 

            	        	}

            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1661:15: ( '0' .. '7' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1661:16: '0' .. '7'
            	        	{
            	        		MatchRange('0','7'); 

            	        	}


            	        }
            	        break;
            	    case 13 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1662:4: ( '0' .. '7' )
            	        {
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1662:4: ( '0' .. '7' )
            	        	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1662:5: '0' .. '7'
            	        	{
            	        		MatchRange('0','7'); 

            	        	}


            	        }
            	        break;
            	    case 14 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1663:4: 'x' HexDigit
            	        {
            	        	Match('x'); 
            	        	mHexDigit(); 

            	        }
            	        break;
            	    case 15 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1664:4: 'x' HexDigit HexDigit
            	        {
            	        	Match('x'); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 

            	        }
            	        break;
            	    case 16 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1665:4: 'x' HexDigit HexDigit HexDigit
            	        {
            	        	Match('x'); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 

            	        }
            	        break;
            	    case 17 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1666:4: 'x' HexDigit HexDigit HexDigit HexDigit
            	        {
            	        	Match('x'); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 

            	        }
            	        break;
            	    case 18 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1667:4: 'u' HexDigit HexDigit HexDigit
            	        {
            	        	Match('u'); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 

            	        }
            	        break;
            	    case 19 :
            	        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1668:4: 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
            	        {
            	        	Match('U'); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 
            	        	mHexDigit(); 

            	        }
            	        break;

            	}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "EscapeSequence"

    // $ANTLR start "WHITE_SPACE"
    public void mWHITE_SPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITE_SPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1673:2: ( ( ' ' | '\\r' | '\\t' | '\\n' ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1673:4: ( ' ' | '\\r' | '\\t' | '\\n' )
            {
            	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	 _channel = HIDDEN; 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHITE_SPACE"

    // $ANTLR start "COMMENT_LINE"
    public void mCOMMENT_LINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT_LINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:2: ( ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' | '\\n' )+ ) )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:4: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' | '\\n' )+ )
            {
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:4: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' | '\\n' )+ )
            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:5: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' | '\\n' )+
            	{
            		Match("//"); 

            		// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:10: (~ ( '\\n' | '\\r' ) )*
            		do 
            		{
            		    int alt20 = 2;
            		    int LA20_0 = input.LA(1);

            		    if ( ((LA20_0 >= '\u0000' && LA20_0 <= '\t') || (LA20_0 >= '\u000B' && LA20_0 <= '\f') || (LA20_0 >= '\u000E' && LA20_0 <= '\uFFFF')) )
            		    {
            		        alt20 = 1;
            		    }


            		    switch (alt20) 
            			{
            				case 1 :
            				    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:10: ~ ( '\\n' | '\\r' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    goto loop20;
            		    }
            		} while (true);

            		loop20:
            			;	// Stops C# compiler whining that label 'loop20' has no statements

            		// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1682:26: ( '\\r' | '\\n' )+
            		int cnt21 = 0;
            		do 
            		{
            		    int alt21 = 2;
            		    int LA21_0 = input.LA(1);

            		    if ( (LA21_0 == '\n' || LA21_0 == '\r') )
            		    {
            		        alt21 = 1;
            		    }


            		    switch (alt21) 
            			{
            				case 1 :
            				    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:
            				    {
            				    	if ( input.LA(1) == '\n' || input.LA(1) == '\r' ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    if ( cnt21 >= 1 ) goto loop21;
            			            EarlyExitException eee21 =
            			                new EarlyExitException(21, input);
            			            throw eee21;
            		    }
            		    cnt21++;
            		} while (true);

            		loop21:
            			;	// Stops C# compiler whining that label 'loop21' has no statements


            	}

            	 Skip(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENT_LINE"

    // $ANTLR start "COMMENT_MULTILINE"
    public void mCOMMENT_MULTILINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT_MULTILINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1686:2: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1686:4: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1686:9: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == '*') )
            	    {
            	        int LA22_1 = input.LA(2);

            	        if ( (LA22_1 == '/') )
            	        {
            	            alt22 = 2;
            	        }
            	        else if ( ((LA22_1 >= '\u0000' && LA22_1 <= '.') || (LA22_1 >= '0' && LA22_1 <= '\uFFFF')) )
            	        {
            	            alt22 = 1;
            	        }


            	    }
            	    else if ( ((LA22_0 >= '\u0000' && LA22_0 <= ')') || (LA22_0 >= '+' && LA22_0 <= '\uFFFF')) )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1686:40: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	Match("*/"); 

            	 Skip(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENT_MULTILINE"

    override public void mTokens() // throws RecognitionException 
    {
        // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:8: ( T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | T__101 | T__102 | T__103 | T__104 | T__105 | T__106 | T__107 | T__108 | T__109 | T__110 | T__111 | T__112 | T__113 | T__114 | T__115 | T__116 | T__117 | T__118 | T__119 | T__120 | T__121 | T__122 | T__123 | T__124 | T__125 | T__126 | T__127 | T__128 | T__129 | T__130 | T__131 | T__132 | KW_CLASS | KW_STRUCT | KW_ENUM | KW_INTERFACE | KW_NAMESPACE | KW_THIS | KW_BASE | KW_GLOBAL | KW_NULL | KW_TRUE | KW_FALSE | KW_IF | KW_ELSE | KW_FOR | KW_FOREACH | KW_IN | KW_WHILE | KW_DO | KW_BREAK | KW_CONTINUE | KW_GOTO | KW_RETURN | KW_TRY | KW_CATCH | KW_FINALLY | KW_THROW | KW_USING | KW_TYPEDEF | KW_PRIVATE | KW_FAMILY | KW_PUBLIC | KW_INTERNAL | KW_ABSTRACT | KW_VIRTUAL | KW_FINAL | KW_STATIC | KW_AUTO | KW_VAR | KW_NEW | KW_TYPEOF | KW_IS | KW_AS | KW_SIGNAL | KW_DELEGATE | KW_GET | KW_SET | KW_CHAR | KW_BYTE | KW_SBYTE | KW_SHORT | KW_USHORT | KW_INT | KW_UINT | KW_LONG | KW_ULONG | KW_FLOAT | KW_DOUBLE | KW_DECIMAL | KW_STRING | KW_OBJECT | KW_BOOL | KW_VOID | SEMI | COMMA | ID | LITERAL_INTEGER | LITERAL_REAL | LITERAL_STRING | LITERAL_CHAR | WHITE_SPACE | COMMENT_LINE | COMMENT_MULTILINE )
        int alt23 = 114;
        alt23 = dfa23.Predict(input);
        switch (alt23) 
        {
            case 1 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:10: T__91
                {
                	mT__91(); 

                }
                break;
            case 2 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:16: T__92
                {
                	mT__92(); 

                }
                break;
            case 3 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:22: T__93
                {
                	mT__93(); 

                }
                break;
            case 4 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:28: T__94
                {
                	mT__94(); 

                }
                break;
            case 5 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:34: T__95
                {
                	mT__95(); 

                }
                break;
            case 6 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:40: T__96
                {
                	mT__96(); 

                }
                break;
            case 7 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:46: T__97
                {
                	mT__97(); 

                }
                break;
            case 8 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:52: T__98
                {
                	mT__98(); 

                }
                break;
            case 9 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:58: T__99
                {
                	mT__99(); 

                }
                break;
            case 10 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:64: T__100
                {
                	mT__100(); 

                }
                break;
            case 11 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:71: T__101
                {
                	mT__101(); 

                }
                break;
            case 12 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:78: T__102
                {
                	mT__102(); 

                }
                break;
            case 13 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:85: T__103
                {
                	mT__103(); 

                }
                break;
            case 14 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:92: T__104
                {
                	mT__104(); 

                }
                break;
            case 15 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:99: T__105
                {
                	mT__105(); 

                }
                break;
            case 16 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:106: T__106
                {
                	mT__106(); 

                }
                break;
            case 17 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:113: T__107
                {
                	mT__107(); 

                }
                break;
            case 18 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:120: T__108
                {
                	mT__108(); 

                }
                break;
            case 19 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:127: T__109
                {
                	mT__109(); 

                }
                break;
            case 20 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:134: T__110
                {
                	mT__110(); 

                }
                break;
            case 21 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:141: T__111
                {
                	mT__111(); 

                }
                break;
            case 22 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:148: T__112
                {
                	mT__112(); 

                }
                break;
            case 23 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:155: T__113
                {
                	mT__113(); 

                }
                break;
            case 24 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:162: T__114
                {
                	mT__114(); 

                }
                break;
            case 25 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:169: T__115
                {
                	mT__115(); 

                }
                break;
            case 26 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:176: T__116
                {
                	mT__116(); 

                }
                break;
            case 27 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:183: T__117
                {
                	mT__117(); 

                }
                break;
            case 28 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:190: T__118
                {
                	mT__118(); 

                }
                break;
            case 29 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:197: T__119
                {
                	mT__119(); 

                }
                break;
            case 30 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:204: T__120
                {
                	mT__120(); 

                }
                break;
            case 31 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:211: T__121
                {
                	mT__121(); 

                }
                break;
            case 32 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:218: T__122
                {
                	mT__122(); 

                }
                break;
            case 33 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:225: T__123
                {
                	mT__123(); 

                }
                break;
            case 34 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:232: T__124
                {
                	mT__124(); 

                }
                break;
            case 35 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:239: T__125
                {
                	mT__125(); 

                }
                break;
            case 36 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:246: T__126
                {
                	mT__126(); 

                }
                break;
            case 37 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:253: T__127
                {
                	mT__127(); 

                }
                break;
            case 38 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:260: T__128
                {
                	mT__128(); 

                }
                break;
            case 39 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:267: T__129
                {
                	mT__129(); 

                }
                break;
            case 40 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:274: T__130
                {
                	mT__130(); 

                }
                break;
            case 41 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:281: T__131
                {
                	mT__131(); 

                }
                break;
            case 42 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:288: T__132
                {
                	mT__132(); 

                }
                break;
            case 43 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:295: KW_CLASS
                {
                	mKW_CLASS(); 

                }
                break;
            case 44 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:304: KW_STRUCT
                {
                	mKW_STRUCT(); 

                }
                break;
            case 45 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:314: KW_ENUM
                {
                	mKW_ENUM(); 

                }
                break;
            case 46 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:322: KW_INTERFACE
                {
                	mKW_INTERFACE(); 

                }
                break;
            case 47 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:335: KW_NAMESPACE
                {
                	mKW_NAMESPACE(); 

                }
                break;
            case 48 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:348: KW_THIS
                {
                	mKW_THIS(); 

                }
                break;
            case 49 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:356: KW_BASE
                {
                	mKW_BASE(); 

                }
                break;
            case 50 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:364: KW_GLOBAL
                {
                	mKW_GLOBAL(); 

                }
                break;
            case 51 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:374: KW_NULL
                {
                	mKW_NULL(); 

                }
                break;
            case 52 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:382: KW_TRUE
                {
                	mKW_TRUE(); 

                }
                break;
            case 53 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:390: KW_FALSE
                {
                	mKW_FALSE(); 

                }
                break;
            case 54 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:399: KW_IF
                {
                	mKW_IF(); 

                }
                break;
            case 55 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:405: KW_ELSE
                {
                	mKW_ELSE(); 

                }
                break;
            case 56 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:413: KW_FOR
                {
                	mKW_FOR(); 

                }
                break;
            case 57 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:420: KW_FOREACH
                {
                	mKW_FOREACH(); 

                }
                break;
            case 58 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:431: KW_IN
                {
                	mKW_IN(); 

                }
                break;
            case 59 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:437: KW_WHILE
                {
                	mKW_WHILE(); 

                }
                break;
            case 60 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:446: KW_DO
                {
                	mKW_DO(); 

                }
                break;
            case 61 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:452: KW_BREAK
                {
                	mKW_BREAK(); 

                }
                break;
            case 62 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:461: KW_CONTINUE
                {
                	mKW_CONTINUE(); 

                }
                break;
            case 63 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:473: KW_GOTO
                {
                	mKW_GOTO(); 

                }
                break;
            case 64 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:481: KW_RETURN
                {
                	mKW_RETURN(); 

                }
                break;
            case 65 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:491: KW_TRY
                {
                	mKW_TRY(); 

                }
                break;
            case 66 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:498: KW_CATCH
                {
                	mKW_CATCH(); 

                }
                break;
            case 67 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:507: KW_FINALLY
                {
                	mKW_FINALLY(); 

                }
                break;
            case 68 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:518: KW_THROW
                {
                	mKW_THROW(); 

                }
                break;
            case 69 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:527: KW_USING
                {
                	mKW_USING(); 

                }
                break;
            case 70 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:536: KW_TYPEDEF
                {
                	mKW_TYPEDEF(); 

                }
                break;
            case 71 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:547: KW_PRIVATE
                {
                	mKW_PRIVATE(); 

                }
                break;
            case 72 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:558: KW_FAMILY
                {
                	mKW_FAMILY(); 

                }
                break;
            case 73 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:568: KW_PUBLIC
                {
                	mKW_PUBLIC(); 

                }
                break;
            case 74 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:578: KW_INTERNAL
                {
                	mKW_INTERNAL(); 

                }
                break;
            case 75 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:590: KW_ABSTRACT
                {
                	mKW_ABSTRACT(); 

                }
                break;
            case 76 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:602: KW_VIRTUAL
                {
                	mKW_VIRTUAL(); 

                }
                break;
            case 77 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:613: KW_FINAL
                {
                	mKW_FINAL(); 

                }
                break;
            case 78 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:622: KW_STATIC
                {
                	mKW_STATIC(); 

                }
                break;
            case 79 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:632: KW_AUTO
                {
                	mKW_AUTO(); 

                }
                break;
            case 80 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:640: KW_VAR
                {
                	mKW_VAR(); 

                }
                break;
            case 81 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:647: KW_NEW
                {
                	mKW_NEW(); 

                }
                break;
            case 82 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:654: KW_TYPEOF
                {
                	mKW_TYPEOF(); 

                }
                break;
            case 83 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:664: KW_IS
                {
                	mKW_IS(); 

                }
                break;
            case 84 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:670: KW_AS
                {
                	mKW_AS(); 

                }
                break;
            case 85 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:676: KW_SIGNAL
                {
                	mKW_SIGNAL(); 

                }
                break;
            case 86 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:686: KW_DELEGATE
                {
                	mKW_DELEGATE(); 

                }
                break;
            case 87 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:698: KW_GET
                {
                	mKW_GET(); 

                }
                break;
            case 88 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:705: KW_SET
                {
                	mKW_SET(); 

                }
                break;
            case 89 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:712: KW_CHAR
                {
                	mKW_CHAR(); 

                }
                break;
            case 90 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:720: KW_BYTE
                {
                	mKW_BYTE(); 

                }
                break;
            case 91 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:728: KW_SBYTE
                {
                	mKW_SBYTE(); 

                }
                break;
            case 92 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:737: KW_SHORT
                {
                	mKW_SHORT(); 

                }
                break;
            case 93 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:746: KW_USHORT
                {
                	mKW_USHORT(); 

                }
                break;
            case 94 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:756: KW_INT
                {
                	mKW_INT(); 

                }
                break;
            case 95 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:763: KW_UINT
                {
                	mKW_UINT(); 

                }
                break;
            case 96 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:771: KW_LONG
                {
                	mKW_LONG(); 

                }
                break;
            case 97 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:779: KW_ULONG
                {
                	mKW_ULONG(); 

                }
                break;
            case 98 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:788: KW_FLOAT
                {
                	mKW_FLOAT(); 

                }
                break;
            case 99 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:797: KW_DOUBLE
                {
                	mKW_DOUBLE(); 

                }
                break;
            case 100 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:807: KW_DECIMAL
                {
                	mKW_DECIMAL(); 

                }
                break;
            case 101 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:818: KW_STRING
                {
                	mKW_STRING(); 

                }
                break;
            case 102 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:828: KW_OBJECT
                {
                	mKW_OBJECT(); 

                }
                break;
            case 103 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:838: KW_BOOL
                {
                	mKW_BOOL(); 

                }
                break;
            case 104 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:846: KW_VOID
                {
                	mKW_VOID(); 

                }
                break;
            case 105 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:854: SEMI
                {
                	mSEMI(); 

                }
                break;
            case 106 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:859: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 107 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:865: ID
                {
                	mID(); 

                }
                break;
            case 108 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:868: LITERAL_INTEGER
                {
                	mLITERAL_INTEGER(); 

                }
                break;
            case 109 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:884: LITERAL_REAL
                {
                	mLITERAL_REAL(); 

                }
                break;
            case 110 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:897: LITERAL_STRING
                {
                	mLITERAL_STRING(); 

                }
                break;
            case 111 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:912: LITERAL_CHAR
                {
                	mLITERAL_CHAR(); 

                }
                break;
            case 112 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:925: WHITE_SPACE
                {
                	mWHITE_SPACE(); 

                }
                break;
            case 113 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:937: COMMENT_LINE
                {
                	mCOMMENT_LINE(); 

                }
                break;
            case 114 :
                // D:\\Users\\piotrek\\Documents\\Visual Studio 2008\\Projects\\Compiler\\Grammar\\Grammar.g:1:950: COMMENT_MULTILINE
                {
                	mCOMMENT_MULTILINE(); 

                }
                break;

        }

    }


    protected DFA8 dfa8;
    protected DFA16 dfa16;
    protected DFA19 dfa19;
    protected DFA23 dfa23;
	private void InitializeCyclicDFAs()
	{
	    this.dfa8 = new DFA8(this);
	    this.dfa16 = new DFA16(this);
	    this.dfa19 = new DFA19(this);
	    this.dfa23 = new DFA23(this);
	}

    const string DFA8_eotS =
        "\x01\uffff\x01\x07\x01\x0a\x01\x0c\x01\x0f\x0b\uffff";
    const string DFA8_eofS =
        "\x10\uffff";
    const string DFA8_minS =
        "\x03\x4c\x02\x55\x0b\uffff";
    const string DFA8_maxS =
        "\x01\x75\x02\x6c\x01\x55\x01\x75\x0b\uffff";
    const string DFA8_acceptS =
        "\x05\uffff\x01\x05\x01\x08\x01\x01\x01\x06\x01\x07\x01\x02\x01"+
        "\x0b\x01\x03\x01\x09\x01\x0a\x01\x04";
    const string DFA8_specialS =
        "\x10\uffff}>";
    static readonly string[] DFA8_transitionS = {
            "\x01\x04\x08\uffff\x01\x02\x16\uffff\x01\x03\x08\uffff\x01"+
            "\x01",
            "\x01\x06\x1f\uffff\x01\x05",
            "\x01\x08\x1f\uffff\x01\x09",
            "\x01\x0b",
            "\x01\x0d\x1f\uffff\x01\x0e",
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

    static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
    static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
    static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
    static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
    static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
    static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
    static readonly short[][] DFA8_transition = DFA.UnpackEncodedStringArray(DFA8_transitionS);

    protected class DFA8 : DFA
    {
        public DFA8(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 8;
            this.eot = DFA8_eot;
            this.eof = DFA8_eof;
            this.min = DFA8_min;
            this.max = DFA8_max;
            this.accept = DFA8_accept;
            this.special = DFA8_special;
            this.transition = DFA8_transition;

        }

        override public string Description
        {
            get { return "1611:10: fragment IntegerSuffix : ( 'u' | 'U' | 'l' | 'L' | 'ul' | 'UL' | 'Ul' | 'uL' | 'LU' | 'Lu' | 'lU' );"; }
        }

    }

    const string DFA16_eotS =
        "\x06\uffff";
    const string DFA16_eofS =
        "\x06\uffff";
    const string DFA16_minS =
        "\x02\x2e\x04\uffff";
    const string DFA16_maxS =
        "\x01\x39\x01\x66\x04\uffff";
    const string DFA16_acceptS =
        "\x02\uffff\x01\x02\x01\x04\x01\x03\x01\x01";
    const string DFA16_specialS =
        "\x06\uffff}>";
    static readonly string[] DFA16_transitionS = {
            "\x01\x02\x01\uffff\x0a\x01",
            "\x01\x05\x01\uffff\x0a\x01\x0a\uffff\x01\x03\x01\x04\x01\x03"+
            "\x1d\uffff\x01\x03\x01\x04\x01\x03",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
    static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
    static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
    static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
    static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
    static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
    static readonly short[][] DFA16_transition = DFA.UnpackEncodedStringArray(DFA16_transitionS);

    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept = DFA16_accept;
            this.special = DFA16_special;
            this.transition = DFA16_transition;

        }

        override public string Description
        {
            get { return "1627:1: LITERAL_REAL : ( Digits '.' Digits ( Exponent )? ( RealSuffix )? | '.' Digits ( Exponent )? ( RealSuffix )? | Digits Exponent ( RealSuffix )? | Digits RealSuffix );"; }
        }

    }

    const string DFA19_eotS =
        "\x0b\uffff\x02\x11\x03\uffff\x01\x12\x02\uffff\x01\x15\x02\uffff"+
        "\x01\x17\x01\uffff\x01\x19\x02\uffff";
    const string DFA19_eofS =
        "\x1b\uffff";
    const string DFA19_minS =
        "\x01\x22\x0a\uffff\x03\x30\x02\uffff\x01\x30\x02\uffff\x01\x30"+
        "\x02\uffff\x01\x30\x01\uffff\x01\x30\x02\uffff";
    const string DFA19_maxS =
        "\x01\x78\x0a\uffff\x02\x37\x01\x66\x02\uffff\x01\x37\x02\uffff"+
        "\x01\x66\x02\uffff\x01\x66\x01\uffff\x01\x66\x02\uffff";
    const string DFA19_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x03\uffff\x01\x12\x01\x13\x01\uffff"+
        "\x01\x0d\x01\x0c\x01\uffff\x01\x0b\x01\x0e\x01\uffff\x01\x0f\x01"+
        "\uffff\x01\x10\x01\x11";
    const string DFA19_specialS =
        "\x1b\uffff}>";
    static readonly string[] DFA19_transitionS = {
            "\x01\x08\x04\uffff\x01\x09\x08\uffff\x04\x0b\x04\x0c\x1d\uffff"+
            "\x01\x0f\x06\uffff\x01\x0a\x04\uffff\x01\x01\x01\x02\x03\uffff"+
            "\x01\x03\x07\uffff\x01\x04\x03\uffff\x01\x05\x01\uffff\x01\x06"+
            "\x01\x0e\x01\x07\x01\uffff\x01\x0d",
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
            "\x08\x10",
            "\x08\x12",
            "\x0a\x13\x07\uffff\x06\x13\x1a\uffff\x06\x13",
            "",
            "",
            "\x08\x14",
            "",
            "",
            "\x0a\x16\x07\uffff\x06\x16\x1a\uffff\x06\x16",
            "",
            "",
            "\x0a\x18\x07\uffff\x06\x18\x1a\uffff\x06\x18",
            "",
            "\x0a\x1a\x07\uffff\x06\x1a\x1a\uffff\x06\x1a",
            "",
            ""
    };

    static readonly short[] DFA19_eot = DFA.UnpackEncodedString(DFA19_eotS);
    static readonly short[] DFA19_eof = DFA.UnpackEncodedString(DFA19_eofS);
    static readonly char[] DFA19_min = DFA.UnpackEncodedStringToUnsignedChars(DFA19_minS);
    static readonly char[] DFA19_max = DFA.UnpackEncodedStringToUnsignedChars(DFA19_maxS);
    static readonly short[] DFA19_accept = DFA.UnpackEncodedString(DFA19_acceptS);
    static readonly short[] DFA19_special = DFA.UnpackEncodedString(DFA19_specialS);
    static readonly short[][] DFA19_transition = DFA.UnpackEncodedStringArray(DFA19_transitionS);

    protected class DFA19 : DFA
    {
        public DFA19(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 19;
            this.eot = DFA19_eot;
            this.eof = DFA19_eof;
            this.min = DFA19_min;
            this.max = DFA19_max;
            this.accept = DFA19_accept;
            this.special = DFA19_special;
            this.transition = DFA19_transition;

        }

        override public string Description
        {
            get { return "1650:2: ( 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v' | '\\\"' | '\\'' | '\\\\' | ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) ( '0' .. '7' ) | ( '0' .. '7' ) | 'x' HexDigit | 'x' HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit | 'x' HexDigit HexDigit HexDigit HexDigit | 'u' HexDigit HexDigit HexDigit | 'U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit )"; }
        }

    }

    const string DFA23_eotS =
        "\x01\uffff\x01\x32\x06\uffff\x01\x35\x01\x38\x01\x3a\x01\x3c\x01"+
        "\x3f\x01\x42\x01\x45\x01\x48\x01\x4a\x01\x4e\x01\x50\x01\uffff\x01"+
        "\x52\x02\uffff\x12\x2b\x03\uffff\x02\u0085\x10\uffff\x01\u0087\x02"+
        "\uffff\x01\u0089\x11\uffff\x0b\x2b\x01\u0097\x01\u0098\x01\u0099"+
        "\x13\x2b\x01\u00b0\x0a\x2b\x01\u00bc\x05\x2b\x05\uffff\x08\x2b\x01"+
        "\u00cb\x03\x2b\x01\u00d0\x03\uffff\x02\x2b\x01\u00d3\x02\x2b\x01"+
        "\u00d6\x07\x2b\x01\u00de\x02\x2b\x01\u00e2\x05\x2b\x01\uffff\x0b"+
        "\x2b\x01\uffff\x01\x2b\x01\u00f4\x06\x2b\x01\u00fb\x05\x2b\x01\uffff"+
        "\x01\x2b\x01\u0102\x01\u0103\x01\x2b\x01\uffff\x01\x2b\x01\u0106"+
        "\x01\uffff\x01\u0107\x01\u0108\x01\uffff\x01\x2b\x01\u010b\x01\x2b"+
        "\x01\u010d\x01\u010e\x01\x2b\x01\u0110\x01\uffff\x03\x2b\x01\uffff"+
        "\x0a\x2b\x01\u011e\x04\x2b\x01\u0123\x01\x2b\x01\uffff\x01\u0125"+
        "\x01\u0126\x01\x2b\x01\u0128\x01\x2b\x01\u012a\x01\uffff\x03\x2b"+
        "\x01\u012e\x01\x2b\x01\u0130\x02\uffff\x02\x2b\x03\uffff\x02\x2b"+
        "\x01\uffff\x01\u0136\x02\uffff\x01\x2b\x01\uffff\x01\u0138\x02\x2b"+
        "\x01\u013c\x01\x2b\x01\u013e\x01\u013f\x03\x2b\x01\u0143\x01\u0144"+
        "\x01\x2b\x01\uffff\x01\u0146\x03\x2b\x01\uffff\x01\x2b\x02\uffff"+
        "\x01\x2b\x01\uffff\x01\x2b\x01\uffff\x01\u014d\x01\u014e\x01\u014f"+
        "\x01\uffff\x01\u0150\x01\uffff\x04\x2b\x01\u0155\x01\uffff\x01\u0156"+
        "\x01\uffff\x01\u0157\x02\x2b\x01\uffff\x01\x2b\x02\uffff\x01\u015b"+
        "\x01\x2b\x01\u015d\x02\uffff\x01\u015e\x01\uffff\x01\x2b\x01\u0160"+
        "\x02\x2b\x01\u0163\x01\x2b\x04\uffff\x03\x2b\x01\u0168\x03\uffff"+
        "\x01\u0169\x01\u016a\x01\x2b\x01\uffff\x01\u016c\x02\uffff\x01\u016d"+
        "\x01\uffff\x01\x2b\x01\u016f\x01\uffff\x01\u0170\x01\x2b\x01\u0172"+
        "\x01\x2b\x03\uffff\x01\u0174\x02\uffff\x01\u0175\x02\uffff\x01\u0176"+
        "\x01\uffff\x01\u0177\x04\uffff";
    const string DFA23_eofS =
        "\u0178\uffff";
    const string DFA23_minS =
        "\x01\x09\x01\x3d\x06\uffff\x01\x3d\x01\x26\x02\x3d\x01\x3c\x01"+
        "\x3d\x01\x2b\x01\x2d\x01\x3d\x01\x2a\x01\x3d\x01\uffff\x01\x30\x02"+
        "\uffff\x01\x61\x01\x62\x01\x6c\x01\x66\x01\x61\x01\x68\x01\x61\x01"+
        "\x65\x01\x61\x01\x68\x01\x65\x01\x61\x01\x69\x01\x72\x01\x62\x01"+
        "\x61\x01\x6f\x01\x62\x03\uffff\x02\x2e\x10\uffff\x01\x3d\x02\uffff"+
        "\x01\x3d\x11\uffff\x01\x61\x01\x6e\x01\x74\x01\x61\x01\x72\x01\x61"+
        "\x01\x67\x01\x74\x01\x79\x01\x75\x01\x73\x03\x30\x01\x6d\x01\x6c"+
        "\x01\x77\x01\x69\x01\x75\x01\x70\x01\x73\x01\x65\x01\x74\x02\x6f"+
        "\x02\x74\x01\x6c\x01\x72\x02\x6e\x01\x6f\x01\x69\x01\x30\x01\x63"+
        "\x01\x74\x01\x69\x01\x68\x01\x6e\x01\x6f\x01\x69\x01\x62\x01\x73"+
        "\x01\x74\x01\x30\x02\x72\x01\x69\x01\x6e\x01\x6a\x05\uffff\x01\x73"+
        "\x01\x74\x01\x63\x01\x72\x01\x69\x02\x72\x01\x6e\x01\x30\x01\x74"+
        "\x01\x6d\x01\x65\x01\x30\x03\uffff\x01\x65\x01\x6c\x01\x30\x01\x73"+
        "\x01\x65\x01\x30\x02\x65\x01\x61\x01\x65\x01\x6c\x01\x62\x01\x6f"+
        "\x01\x30\x01\x73\x01\x69\x01\x30\x01\x61\x01\x63\x01\x61\x01\x6c"+
        "\x01\x62\x01\uffff\x01\x69\x01\x75\x01\x73\x01\x6e\x01\x6f\x01\x74"+
        "\x01\x6e\x01\x76\x01\x6c\x01\x74\x01\x6f\x01\uffff\x01\x74\x01\x30"+
        "\x01\x64\x01\x67\x01\x65\x01\x73\x01\x69\x01\x68\x01\x30\x01\x63"+
        "\x01\x6e\x01\x65\x01\x74\x01\x61\x01\uffff\x01\x65\x02\x30\x01\x72"+
        "\x01\uffff\x01\x73\x01\x30\x01\uffff\x02\x30\x01\uffff\x01\x64\x01"+
        "\x30\x01\x6b\x02\x30\x01\x61\x01\x30\x01\uffff\x01\x65\x01\x6c\x01"+
        "\x61\x01\uffff\x01\x6c\x02\x74\x01\x65\x01\x6c\x01\x6d\x01\x72\x01"+
        "\x65\x01\x67\x01\x72\x01\x30\x01\x67\x01\x61\x01\x69\x01\x72\x01"+
        "\x30\x01\x75\x01\uffff\x02\x30\x01\x63\x01\x30\x01\x6e\x01\x30\x01"+
        "\uffff\x01\x74\x01\x67\x01\x64\x01\x30\x01\x6c\x01\x30\x02\uffff"+
        "\x01\x66\x01\x70\x03\uffff\x01\x65\x01\x66\x01\uffff\x01\x30\x02"+
        "\uffff\x01\x6c\x01\uffff\x01\x30\x01\x79\x01\x63\x01\x30\x01\x69"+
        "\x02\x30\x01\x65\x01\x61\x01\x6e\x02\x30\x01\x74\x01\uffff\x01\x30"+
        "\x01\x74\x01\x63\x01\x61\x01\uffff\x01\x61\x02\uffff\x01\x74\x01"+
        "\uffff\x01\x75\x01\uffff\x03\x30\x01\uffff\x01\x30\x01\uffff\x03"+
        "\x61\x01\x66\x01\x30\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\x68"+
        "\x01\x79\x01\uffff\x01\x6f\x02\uffff\x01\x30\x01\x6c\x01\x30\x02"+
        "\uffff\x01\x30\x01\uffff\x01\x65\x01\x30\x01\x63\x01\x6c\x01\x30"+
        "\x01\x65\x04\uffff\x01\x63\x01\x6c\x01\x63\x01\x30\x03\uffff\x02"+
        "\x30\x01\x6e\x01\uffff\x01\x30\x02\uffff\x01\x30\x01\uffff\x01\x74"+
        "\x01\x30\x01\uffff\x01\x30\x01\x65\x01\x30\x01\x65\x03\uffff\x01"+
        "\x30\x02\uffff\x01\x30\x02\uffff\x01\x30\x01\uffff\x01\x30\x04\uffff";
    const string DFA23_maxS =
        "\x01\x7e\x01\x3d\x06\uffff\x01\x7c\x04\x3d\x01\x3e\x05\x3d\x01"+
        "\uffff\x01\x39\x02\uffff\x01\x6f\x01\x74\x01\x6e\x01\x73\x01\x75"+
        "\x02\x79\x01\x6f\x01\x75\x01\x68\x01\x6f\x01\x65\x01\x73\x02\x75"+
        "\x02\x6f\x01\x62\x03\uffff\x02\x66\x10\uffff\x01\x3d\x02\uffff\x01"+
        "\x3d\x11\uffff\x01\x61\x01\x6e\x01\x74\x01\x61\x01\x72\x01\x6f\x01"+
        "\x67\x01\x74\x01\x79\x01\x75\x01\x73\x03\x7a\x01\x6d\x01\x6c\x01"+
        "\x77\x01\x69\x01\x79\x01\x70\x01\x73\x01\x65\x01\x74\x02\x6f\x02"+
        "\x74\x01\x6d\x01\x72\x02\x6e\x01\x6f\x01\x69\x01\x7a\x01\x63\x01"+
        "\x74\x02\x69\x01\x6e\x01\x6f\x01\x69\x01\x62\x01\x73\x01\x74\x01"+
        "\x7a\x02\x72\x01\x69\x01\x6e\x01\x6a\x05\uffff\x01\x73\x01\x74\x01"+
        "\x63\x01\x72\x01\x75\x02\x72\x01\x6e\x01\x7a\x01\x74\x01\x6d\x01"+
        "\x65\x01\x7a\x03\uffff\x01\x65\x01\x6c\x01\x7a\x01\x73\x01\x65\x01"+
        "\x7a\x02\x65\x01\x61\x01\x65\x01\x6c\x01\x62\x01\x6f\x01\x7a\x01"+
        "\x73\x01\x69\x01\x7a\x01\x61\x01\x63\x01\x61\x01\x6c\x01\x62\x01"+
        "\uffff\x01\x69\x01\x75\x01\x73\x01\x6e\x01\x6f\x01\x74\x01\x6e\x01"+
        "\x76\x01\x6c\x01\x74\x01\x6f\x01\uffff\x01\x74\x01\x7a\x01\x64\x01"+
        "\x67\x01\x65\x01\x73\x01\x69\x01\x68\x01\x7a\x01\x63\x01\x6e\x01"+
        "\x65\x01\x74\x01\x61\x01\uffff\x01\x65\x02\x7a\x01\x72\x01\uffff"+
        "\x01\x73\x01\x7a\x01\uffff\x02\x7a\x01\uffff\x01\x6f\x01\x7a\x01"+
        "\x6b\x02\x7a\x01\x61\x01\x7a\x01\uffff\x01\x65\x01\x6c\x01\x61\x01"+
        "\uffff\x01\x6c\x02\x74\x01\x65\x01\x6c\x01\x6d\x01\x72\x01\x65\x01"+
        "\x67\x01\x72\x01\x7a\x01\x67\x01\x61\x01\x69\x01\x72\x01\x7a\x01"+
        "\x75\x01\uffff\x02\x7a\x01\x63\x01\x7a\x01\x6e\x01\x7a\x01\uffff"+
        "\x01\x74\x01\x67\x01\x64\x01\x7a\x01\x6c\x01\x7a\x02\uffff\x01\x6e"+
        "\x01\x70\x03\uffff\x01\x65\x01\x66\x01\uffff\x01\x7a\x02\uffff\x01"+
        "\x6c\x01\uffff\x01\x7a\x01\x79\x01\x63\x01\x7a\x01\x69\x02\x7a\x01"+
        "\x65\x01\x61\x01\x6e\x02\x7a\x01\x74\x01\uffff\x01\x7a\x01\x74\x01"+
        "\x63\x01\x61\x01\uffff\x01\x61\x02\uffff\x01\x74\x01\uffff\x01\x75"+
        "\x01\uffff\x03\x7a\x01\uffff\x01\x7a\x01\uffff\x03\x61\x01\x66\x01"+
        "\x7a\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\x68\x01\x79\x01\uffff"+
        "\x01\x6f\x02\uffff\x01\x7a\x01\x6c\x01\x7a\x02\uffff\x01\x7a\x01"+
        "\uffff\x01\x65\x01\x7a\x01\x63\x01\x6c\x01\x7a\x01\x65\x04\uffff"+
        "\x01\x63\x01\x6c\x01\x63\x01\x7a\x03\uffff\x02\x7a\x01\x6e\x01\uffff"+
        "\x01\x7a\x02\uffff\x01\x7a\x01\uffff\x01\x74\x01\x7a\x01\uffff\x01"+
        "\x7a\x01\x65\x01\x7a\x01\x65\x03\uffff\x01\x7a\x02\uffff\x01\x7a"+
        "\x02\uffff\x01\x7a\x01\uffff\x01\x7a\x04\uffff";
    const string DFA23_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x0b"+
        "\uffff\x01\x25\x01\uffff\x01\x29\x01\x2a\x12\uffff\x01\x69\x01\x6a"+
        "\x01\x6b\x02\uffff\x01\x6e\x01\x6f\x01\x70\x01\x0d\x01\x01\x01\x08"+
        "\x01\x20\x01\x0a\x01\x09\x01\x1f\x01\x0c\x01\x21\x01\x0b\x01\x0e"+
        "\x01\x24\x01\x11\x01\uffff\x01\x0f\x01\x12\x01\uffff\x01\x10\x01"+
        "\x1a\x01\x26\x01\x15\x01\x1b\x01\x27\x01\x16\x01\x1c\x01\x17\x01"+
        "\x1d\x01\x71\x01\x72\x01\x18\x01\x1e\x01\x19\x01\x6d\x01\x28\x32"+
        "\uffff\x01\x6c\x01\x22\x01\x13\x01\x23\x01\x14\x0d\uffff\x01\x3a"+
        "\x01\x36\x01\x53\x16\uffff\x01\x3c\x0b\uffff\x01\x54\x0e\uffff\x01"+
        "\x58\x04\uffff\x01\x5e\x02\uffff\x01\x51\x02\uffff\x01\x41\x07\uffff"+
        "\x01\x57\x03\uffff\x01\x38\x11\uffff\x01\x50\x06\uffff\x01\x59\x06"+
        "\uffff\x01\x2d\x01\x37\x02\uffff\x01\x33\x01\x30\x01\x34\x02\uffff"+
        "\x01\x31\x01\uffff\x01\x5a\x01\x67\x01\uffff\x01\x3f\x0d\uffff\x01"+
        "\x5f\x04\uffff\x01\x4f\x01\uffff\x01\x68\x01\x60\x01\uffff\x01\x2b"+
        "\x01\uffff\x01\x42\x03\uffff\x01\x5c\x01\uffff\x01\x5b\x05\uffff"+
        "\x01\x3d\x01\uffff\x01\x35\x03\uffff\x01\x4d\x01\uffff\x01\x62\x01"+
        "\x3b\x03\uffff\x01\x44\x01\x45\x01\uffff\x01\x61\x06\uffff\x01\x2c"+
        "\x01\x65\x01\x4e\x01\x55\x04\uffff\x01\x52\x01\x32\x01\x48\x03\uffff"+
        "\x01\x63\x01\uffff\x01\x40\x01\x5d\x01\uffff\x01\x49\x02\uffff\x01"+
        "\x66\x04\uffff\x01\x46\x01\x39\x01\x43\x01\uffff\x01\x64\x01\x47"+
        "\x01\uffff\x01\x4c\x01\x3e\x01\uffff\x01\x4a\x01\uffff\x01\x56\x01"+
        "\x4b\x01\x2e\x01\x2f";
    const string DFA23_specialS =
        "\u0178\uffff}>";
    static readonly string[] DFA23_transitionS = {
            "\x02\x30\x02\uffff\x01\x30\x12\uffff\x01\x30\x01\x0b\x01\x2e"+
            "\x01\uffff\x01\x2b\x01\x12\x01\x09\x01\x2f\x01\x04\x01\x05\x01"+
            "\x10\x01\x0e\x01\x2a\x01\x0f\x01\x14\x01\x11\x01\x2c\x09\x2d"+
            "\x01\x06\x01\x29\x01\x0c\x01\x01\x01\x0d\x01\x07\x01\uffff\x1a"+
            "\x2b\x01\x15\x01\uffff\x01\x16\x01\x0a\x01\x2b\x01\uffff\x01"+
            "\x25\x01\x1d\x01\x17\x01\x21\x01\x19\x01\x1f\x01\x1e\x01\x2b"+
            "\x01\x1a\x02\x2b\x01\x27\x01\x2b\x01\x1b\x01\x28\x01\x24\x01"+
            "\x2b\x01\x22\x01\x18\x01\x1c\x01\x23\x01\x26\x01\x20\x03\x2b"+
            "\x01\x02\x01\x08\x01\x03\x01\x13",
            "\x01\x31",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x34\x3e\uffff\x01\x33",
            "\x01\x36\x16\uffff\x01\x37",
            "\x01\x39",
            "\x01\x3b",
            "\x01\x3e\x01\x3d",
            "\x01\x40\x01\x41",
            "\x01\x44\x11\uffff\x01\x43",
            "\x01\x47\x0f\uffff\x01\x46",
            "\x01\x49",
            "\x01\x4d\x04\uffff\x01\x4c\x0d\uffff\x01\x4b",
            "\x01\x4f",
            "",
            "\x0a\x51",
            "",
            "",
            "\x01\x55\x06\uffff\x01\x56\x03\uffff\x01\x53\x02\uffff\x01"+
            "\x54",
            "\x01\x5b\x02\uffff\x01\x5a\x02\uffff\x01\x58\x01\x59\x0a\uffff"+
            "\x01\x57",
            "\x01\x5d\x01\uffff\x01\x5c",
            "\x01\x5f\x07\uffff\x01\x5e\x04\uffff\x01\x60",
            "\x01\x61\x03\uffff\x01\x63\x0f\uffff\x01\x62",
            "\x01\x64\x09\uffff\x01\x65\x06\uffff\x01\x66",
            "\x01\x67\x0d\uffff\x01\x6a\x02\uffff\x01\x68\x06\uffff\x01"+
            "\x69",
            "\x01\x6d\x06\uffff\x01\x6b\x02\uffff\x01\x6c",
            "\x01\x6e\x07\uffff\x01\x70\x02\uffff\x01\x72\x02\uffff\x01"+
            "\x6f\x05\uffff\x01\x71",
            "\x01\x73",
            "\x01\x75\x09\uffff\x01\x74",
            "\x01\x77\x03\uffff\x01\x76",
            "\x01\x79\x02\uffff\x01\x7a\x06\uffff\x01\x78",
            "\x01\x7b\x02\uffff\x01\x7c",
            "\x01\x7d\x10\uffff\x01\x7f\x01\uffff\x01\x7e",
            "\x01\u0081\x07\uffff\x01\u0080\x05\uffff\x01\u0082",
            "\x01\u0083",
            "\x01\u0084",
            "",
            "",
            "",
            "\x01\x51\x01\uffff\x0a\x2d\x0a\uffff\x03\x51\x1d\uffff\x03"+
            "\x51",
            "\x01\x51\x01\uffff\x0a\x2d\x0a\uffff\x03\x51\x1d\uffff\x03"+
            "\x51",
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
            "\x01\u0086",
            "",
            "",
            "\x01\u0088",
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
            "\x01\u008a",
            "\x01\u008b",
            "\x01\u008c",
            "\x01\u008d",
            "\x01\u008e",
            "\x01\u008f\x0d\uffff\x01\u0090",
            "\x01\u0091",
            "\x01\u0092",
            "\x01\u0093",
            "\x01\u0094",
            "\x01\u0095",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x13"+
            "\x2b\x01\u0096\x06\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u009a",
            "\x01\u009b",
            "\x01\u009c",
            "\x01\u009d",
            "\x01\u009e\x03\uffff\x01\u009f",
            "\x01\u00a0",
            "\x01\u00a1",
            "\x01\u00a2",
            "\x01\u00a3",
            "\x01\u00a4",
            "\x01\u00a5",
            "\x01\u00a6",
            "\x01\u00a7",
            "\x01\u00a8\x01\u00a9",
            "\x01\u00aa",
            "\x01\u00ab",
            "\x01\u00ac",
            "\x01\u00ad",
            "\x01\u00ae",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x14"+
            "\x2b\x01\u00af\x05\x2b",
            "\x01\u00b1",
            "\x01\u00b2",
            "\x01\u00b3",
            "\x01\u00b5\x01\u00b4",
            "\x01\u00b6",
            "\x01\u00b7",
            "\x01\u00b8",
            "\x01\u00b9",
            "\x01\u00ba",
            "\x01\u00bb",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00bd",
            "\x01\u00be",
            "\x01\u00bf",
            "\x01\u00c0",
            "\x01\u00c1",
            "",
            "",
            "",
            "",
            "",
            "\x01\u00c2",
            "\x01\u00c3",
            "\x01\u00c4",
            "\x01\u00c5",
            "\x01\u00c7\x0b\uffff\x01\u00c6",
            "\x01\u00c8",
            "\x01\u00c9",
            "\x01\u00ca",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00cc",
            "\x01\u00cd",
            "\x01\u00ce",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x04"+
            "\x2b\x01\u00cf\x15\x2b",
            "",
            "",
            "",
            "\x01\u00d1",
            "\x01\u00d2",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00d4",
            "\x01\u00d5",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00d7",
            "\x01\u00d8",
            "\x01\u00d9",
            "\x01\u00da",
            "\x01\u00db",
            "\x01\u00dc",
            "\x01\u00dd",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00df",
            "\x01\u00e0",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x04"+
            "\x2b\x01\u00e1\x15\x2b",
            "\x01\u00e3",
            "\x01\u00e4",
            "\x01\u00e5",
            "\x01\u00e6",
            "\x01\u00e7",
            "",
            "\x01\u00e8",
            "\x01\u00e9",
            "\x01\u00ea",
            "\x01\u00eb",
            "\x01\u00ec",
            "\x01\u00ed",
            "\x01\u00ee",
            "\x01\u00ef",
            "\x01\u00f0",
            "\x01\u00f1",
            "\x01\u00f2",
            "",
            "\x01\u00f3",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00f5",
            "\x01\u00f6",
            "\x01\u00f7",
            "\x01\u00f8",
            "\x01\u00f9",
            "\x01\u00fa",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u00fc",
            "\x01\u00fd",
            "\x01\u00fe",
            "\x01\u00ff",
            "\x01\u0100",
            "",
            "\x01\u0101",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0104",
            "",
            "\x01\u0105",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u0109\x0a\uffff\x01\u010a",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u010c",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u010f",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u0111",
            "\x01\u0112",
            "\x01\u0113",
            "",
            "\x01\u0114",
            "\x01\u0115",
            "\x01\u0116",
            "\x01\u0117",
            "\x01\u0118",
            "\x01\u0119",
            "\x01\u011a",
            "\x01\u011b",
            "\x01\u011c",
            "\x01\u011d",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u011f",
            "\x01\u0120",
            "\x01\u0121",
            "\x01\u0122",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0124",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0127",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0129",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u012b",
            "\x01\u012c",
            "\x01\u012d",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u012f",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x01\u0131\x07\uffff\x01\u0132",
            "\x01\u0133",
            "",
            "",
            "",
            "\x01\u0134",
            "\x01\u0135",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x01\u0137",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0139",
            "\x01\u013a",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x0b"+
            "\x2b\x01\u013b\x0e\x2b",
            "\x01\u013d",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0140",
            "\x01\u0141",
            "\x01\u0142",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0145",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0147",
            "\x01\u0148",
            "\x01\u0149",
            "",
            "\x01\u014a",
            "",
            "",
            "\x01\u014b",
            "",
            "\x01\u014c",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u0151",
            "\x01\u0152",
            "\x01\u0153",
            "\x01\u0154",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0158",
            "\x01\u0159",
            "",
            "\x01\u015a",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u015c",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u015f",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0161",
            "\x01\u0162",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0164",
            "",
            "",
            "",
            "",
            "\x01\u0165",
            "\x01\u0166",
            "\x01\u0167",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u016b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x01\u016e",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0171",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "\x01\u0173",
            "",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "\x0a\x2b\x07\uffff\x1a\x2b\x04\uffff\x01\x2b\x01\uffff\x1a"+
            "\x2b",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA23_eot = DFA.UnpackEncodedString(DFA23_eotS);
    static readonly short[] DFA23_eof = DFA.UnpackEncodedString(DFA23_eofS);
    static readonly char[] DFA23_min = DFA.UnpackEncodedStringToUnsignedChars(DFA23_minS);
    static readonly char[] DFA23_max = DFA.UnpackEncodedStringToUnsignedChars(DFA23_maxS);
    static readonly short[] DFA23_accept = DFA.UnpackEncodedString(DFA23_acceptS);
    static readonly short[] DFA23_special = DFA.UnpackEncodedString(DFA23_specialS);
    static readonly short[][] DFA23_transition = DFA.UnpackEncodedStringArray(DFA23_transitionS);

    protected class DFA23 : DFA
    {
        public DFA23(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 23;
            this.eot = DFA23_eot;
            this.eof = DFA23_eof;
            this.min = DFA23_min;
            this.max = DFA23_max;
            this.accept = DFA23_accept;
            this.special = DFA23_special;
            this.transition = DFA23_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | T__101 | T__102 | T__103 | T__104 | T__105 | T__106 | T__107 | T__108 | T__109 | T__110 | T__111 | T__112 | T__113 | T__114 | T__115 | T__116 | T__117 | T__118 | T__119 | T__120 | T__121 | T__122 | T__123 | T__124 | T__125 | T__126 | T__127 | T__128 | T__129 | T__130 | T__131 | T__132 | KW_CLASS | KW_STRUCT | KW_ENUM | KW_INTERFACE | KW_NAMESPACE | KW_THIS | KW_BASE | KW_GLOBAL | KW_NULL | KW_TRUE | KW_FALSE | KW_IF | KW_ELSE | KW_FOR | KW_FOREACH | KW_IN | KW_WHILE | KW_DO | KW_BREAK | KW_CONTINUE | KW_GOTO | KW_RETURN | KW_TRY | KW_CATCH | KW_FINALLY | KW_THROW | KW_USING | KW_TYPEDEF | KW_PRIVATE | KW_FAMILY | KW_PUBLIC | KW_INTERNAL | KW_ABSTRACT | KW_VIRTUAL | KW_FINAL | KW_STATIC | KW_AUTO | KW_VAR | KW_NEW | KW_TYPEOF | KW_IS | KW_AS | KW_SIGNAL | KW_DELEGATE | KW_GET | KW_SET | KW_CHAR | KW_BYTE | KW_SBYTE | KW_SHORT | KW_USHORT | KW_INT | KW_UINT | KW_LONG | KW_ULONG | KW_FLOAT | KW_DOUBLE | KW_DECIMAL | KW_STRING | KW_OBJECT | KW_BOOL | KW_VOID | SEMI | COMMA | ID | LITERAL_INTEGER | LITERAL_REAL | LITERAL_STRING | LITERAL_CHAR | WHITE_SPACE | COMMENT_LINE | COMMENT_MULTILINE );"; }
        }

    }

 
    
}
}