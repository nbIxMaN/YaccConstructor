//this tables was generated by GNESCC
//source grammar:../../../Tests/GNESCC/summator_1/summator_1.yrd
//date:11/4/2011 2:49:31 PM

module Yard.Generators.GNESCCGenerator.Tables_summator_1

open Yard.Generators.GNESCCGenerator
open Yard.Generators.GNESCCGenerator.CommonTypes

type symbol =
    | T_PLUS
    | T_NUMBER
    | NT_e
    | NT_s
    | NT_gnesccStart
let getTag smb =
    match smb with
    | T_PLUS -> 7
    | T_NUMBER -> 6
    | NT_e -> 5
    | NT_s -> 4
    | NT_gnesccStart -> 2
let getName tag =
    match tag with
    | 7 -> T_PLUS
    | 6 -> T_NUMBER
    | 5 -> NT_e
    | 4 -> NT_s
    | 2 -> NT_gnesccStart
    | _ -> failwith "getName: bad tag."
let prodToNTerm = 
  [| 2; 1; 0 |];
let symbolIdx = 
  [| 2; 3; 2; 3; 1; 0; 1; 0 |];
let startKernelIdxs =  [0]
let isStart =
  [| [| true; true; true |];
     [| false; false; false |];
     [| false; false; false |];
     [| false; false; false |];
     [| false; false; true |];
     [| false; false; false |]; |]
let gotoTable =
  [| [| Some 2; Some 1; None |];
     [| None; None; None |];
     [| None; None; None |];
     [| None; None; None |];
     [| Some 5; None; None |];
     [| None; None; None |]; |]
let actionTable = 
  [| [| [Error]; [Shift 3]; [Error]; [Error] |];
     [| [Accept]; [Accept]; [Accept]; [Accept] |];
     [| [Reduce 1]; [Reduce 1]; [Reduce 1]; [Reduce 1] |];
     [| [Shift 4]; [Reduce 2]; [Reduce 2]; [Reduce 2] |];
     [| [Error]; [Shift 3]; [Error]; [Error] |];
     [| [Reduce 2]; [Reduce 2]; [Reduce 2]; [Reduce 2] |]; |]
let tables = 
  {StartIdx=startKernelIdxs
   SymbolIdx=symbolIdx
   GotoTable=gotoTable
   ActionTable=actionTable
   IsStart=isStart
   ProdToNTerm=prodToNTerm}