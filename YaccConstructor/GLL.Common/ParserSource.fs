﻿namespace Yard.Generators.GLL

       
type ParserSource<'TokenType> (
                               tokenToNumber        : 'TokenType -> int
                               , genLiteral         : string -> int -> int -> string
                               , numToString        : int -> string
                               , tokenData          : int -> string
                               , isLiteral          : string -> string
                               , isTerminal         : string -> string
                               , isNonTerminal      : string -> string
                               , getLiteralNames    : string -> string
                               , table              : int[][]
                               , rules              : int[][]
                               , rulesStart         : int[]
                               , leftSide           : int[]
                               , startRule          : int
                               , literalEnd         : int
                               , literalStart       : int
                               , termEnd            : int
                               , termStart          : int
                               , termCount          : int
                               , nonTermCount       : int
                               , literalCount       : int
                               , indexEOF           : int
                               , rulesCount         : int
                               , indexatorFullCount : int
                               , acceptEmptyInput   : bool
                               ) =
    let length =
        let res = Array.zeroCreate <| (rulesStart.Length - 1)
        for i=0 to res.Length-1 do
            res.[i] <- rulesStart.[i+1] - rulesStart.[i]
        res
    let _rules = Array.zeroCreate length.Length
    do for i = 0 to length.Length-1 do
        _rules.[i] <- Array.zeroCreate length.[i]
        for j = 0 to length.[i]-1 do
            _rules.[i].[j] <- rules.[rulesStart.[i] + j]
                  
                               
    member this.GenLiteral = genLiteral 
    member this.TokenData = tokenData
    member this.IsLiteral = isLiteral
    member this.IsTerminal = isTerminal
    member this.IsNonTerminal = isNonTerminal 
    member this.GetLiteralNames = getLiteralNames                         
    member this.Table = table
    member this.Rules = _rules
    member this.RulesStart = rulesStart
    member this.Length = length
    member this.LeftSide = leftSide
    member this.StartRule = startRule
    member this.TokenToNumber = tokenToNumber
    member this.NumToString = numToString
    member this.LiteralEnd = literalEnd
    member this.LiteralStart = literalStart
    member this.TermEnd = termEnd 
    member this.TermStart = termStart
    member this.TermCount = termCount
    member this.NonTermCount = nonTermCount
    member this.LiteralCount = literalCount
    member this.IndexEOF = indexEOF
    member this.RulesCount = rulesCount
    member this.IndexatorFullCount = indexatorFullCount
    member this.AcceptEmptyInput = acceptEmptyInput