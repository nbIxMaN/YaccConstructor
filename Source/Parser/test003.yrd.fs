//this file was generated by YARD Recursive-Ascent 
//source grammar:..\..\..\..\Tests\test003.yrd
//date:05.11.2009 10:56:44
#light "off"

module Actions
open Yard.Core

let getValue,getSeqNum =
 let _val arg =
      if (Option.isNone arg)
      then failwith "Argument exception. Value can not be None"
     else Option.get arg
 in
 let _getSeqNum arg = (fst (_val arg)):int in
 let _getV arg = ignore(_getSeqNum arg);snd (_val arg) in
 _getV,_getSeqNum


let s1_action  arg0 = 
 (fun x0 ->
  let (res) = (getValue x0)
 in 
 res ) arg0


let expr2_action  arg0 arg1 = 
 (fun x0 x1 ->
  let (res) = 
(fun x0 x1 -> 
  if not(Option.isNone x0)
then (fun x0 ->
  let (n:string) = (getValue x0)
 in 
 "Number = " + (string n) )x0
else (fun x1 ->
  let (l:string) = (getValue x1)
 in 
 "literal = " + (string l) )x1
)x0 x1
 in 
printfn "Result = %A"res) arg0 arg1
