// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "Parser.fsy"




# 11 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | RPAREN
  | LPAREN
  | CARET
  | SLASH
  | ASTERISK
  | DASH
  | PLUS
  | TAN
  | COS
  | SIN
  | E
  | PI
  | FLOAT
  | INT
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_RPAREN
    | TOKEN_LPAREN
    | TOKEN_CARET
    | TOKEN_SLASH
    | TOKEN_ASTERISK
    | TOKEN_DASH
    | TOKEN_PLUS
    | TOKEN_TAN
    | TOKEN_COS
    | TOKEN_SIN
    | TOKEN_E
    | TOKEN_PI
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_File

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | RPAREN  -> 1 
  | LPAREN  -> 2 
  | CARET  -> 3 
  | SLASH  -> 4 
  | ASTERISK  -> 5 
  | DASH  -> 6 
  | PLUS  -> 7 
  | TAN  -> 8 
  | COS  -> 9 
  | SIN  -> 10 
  | E  -> 11 
  | PI  -> 12 
  | FLOAT  -> 13 
  | INT  -> 14 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_RPAREN 
  | 2 -> TOKEN_LPAREN 
  | 3 -> TOKEN_CARET 
  | 4 -> TOKEN_SLASH 
  | 5 -> TOKEN_ASTERISK 
  | 6 -> TOKEN_DASH 
  | 7 -> TOKEN_PLUS 
  | 8 -> TOKEN_TAN 
  | 9 -> TOKEN_COS 
  | 10 -> TOKEN_SIN 
  | 11 -> TOKEN_E 
  | 12 -> TOKEN_PI 
  | 13 -> TOKEN_FLOAT 
  | 14 -> TOKEN_INT 
  | 17 -> TOKEN_end_of_input
  | 15 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_File 
    | 3 -> NONTERM_File 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 17 
let _fsyacc_tagOfErrorTerminal = 15

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | RPAREN  -> "RPAREN" 
  | LPAREN  -> "LPAREN" 
  | CARET  -> "CARET" 
  | SLASH  -> "SLASH" 
  | ASTERISK  -> "ASTERISK" 
  | DASH  -> "DASH" 
  | PLUS  -> "PLUS" 
  | TAN  -> "TAN" 
  | COS  -> "COS" 
  | SIN  -> "SIN" 
  | E  -> "E" 
  | PI  -> "PI" 
  | FLOAT  -> "FLOAT" 
  | INT  -> "INT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | CARET  -> (null : System.Object) 
  | SLASH  -> (null : System.Object) 
  | ASTERISK  -> (null : System.Object) 
  | DASH  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | TAN  -> (null : System.Object) 
  | COS  -> (null : System.Object) 
  | SIN  -> (null : System.Object) 
  | E  -> (null : System.Object) 
  | PI  -> (null : System.Object) 
  | FLOAT  -> (null : System.Object) 
  | INT  -> (null : System.Object) 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 3us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 10us; 12us; |]
let _fsyacc_action_rows = 7
let _fsyacc_actionTableElements = [|2us; 32768us; 10us; 4us; 11us; 5us; 0us; 49152us; 1us; 32768us; 0us; 3us; 0us; 16385us; 0us; 16386us; 1us; 32768us; 12us; 6us; 0us; 16387us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 3us; 4us; 6us; 7us; 8us; 10us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 16386us; 65535us; 16387us; |]
let _fsyacc_reductions ()  =    [| 
# 155 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data :  int )) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 164 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'File)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "Parser.fsy"
                                       _1 
                   )
# 36 "Parser.fsy"
                 :  int ));
# 175 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "Parser.fsy"
                                   1 
                   )
# 39 "Parser.fsy"
                 : 'File));
# 185 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "Parser.fsy"
                                      2 
                   )
# 40 "Parser.fsy"
                 : 'File));
|]
# 196 "Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 18;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf :  int  =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))