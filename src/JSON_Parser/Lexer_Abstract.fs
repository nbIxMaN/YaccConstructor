 
module YC.JSONLexer

open Microsoft.FSharp.Collections
open YC.FST.GraphBasedFst
open YC.FSA.GraphBasedFsa
open YC.FST.AbstractLexing.Interpreter
open AbstractAnalysis.Common
open JSON.Parser
open System


let fstLexer () = 
   let startState = ResizeArray.singleton 0
   let finishState = ResizeArray.singleton 65535
   let transitions = new ResizeArray<_>()
   transitions.Add(0, (Smbl (char 65535), Eps), 65535)
   transitions.Add(0, (Smbl '\t', Eps), 1)
   transitions.Add(0, (Smbl ' ', Eps), 1)
   transitions.Add(0, (Smbl '\"', Eps), 5)
   transitions.Add(0, (Smbl '-', Eps), 4)
   transitions.Add(0, (Smbl '0', Eps), 2)
   transitions.Add(0, (Smbl '1', Eps), 3)
   transitions.Add(0, (Smbl '2', Eps), 3)
   transitions.Add(0, (Smbl '3', Eps), 3)
   transitions.Add(0, (Smbl '4', Eps), 3)
   transitions.Add(0, (Smbl '5', Eps), 3)
   transitions.Add(0, (Smbl '6', Eps), 3)
   transitions.Add(0, (Smbl '7', Eps), 3)
   transitions.Add(0, (Smbl '8', Eps), 3)
   transitions.Add(0, (Smbl '9', Eps), 3)
   transitions.Add(1, (Smbl '\t', Eps), 33)
   transitions.Add(1, (Smbl ' ', Eps), 33)
   transitions.Add(1, (Smbl '\"', Smbl 0), 5)
   transitions.Add(1, (Smbl '-', Smbl 0), 4)
   transitions.Add(1, (Smbl '0', Smbl 0), 2)
   transitions.Add(1, (Smbl '1', Smbl 0), 3)
   transitions.Add(1, (Smbl '2', Smbl 0), 3)
   transitions.Add(1, (Smbl '3', Smbl 0), 3)
   transitions.Add(1, (Smbl '4', Smbl 0), 3)
   transitions.Add(1, (Smbl '5', Smbl 0), 3)
   transitions.Add(1, (Smbl '6', Smbl 0), 3)
   transitions.Add(1, (Smbl '7', Smbl 0), 3)
   transitions.Add(1, (Smbl '8', Smbl 0), 3)
   transitions.Add(1, (Smbl '9', Smbl 0), 3)
   transitions.Add(1, (Smbl (char 65535), Smbl 0), 65535)
   transitions.Add(5, (Smbl '\t', Eps), 1)
   transitions.Add(5, (Smbl ' ', Eps), 7)
   transitions.Add(5, (Smbl '\"', Eps), 6)
   transitions.Add(5, (Smbl '-', Eps), 4)
   transitions.Add(5, (Smbl '/', Eps), 7)
   transitions.Add(5, (Smbl '0', Eps), 7)
   transitions.Add(5, (Smbl '1', Eps), 7)
   transitions.Add(5, (Smbl '2', Eps), 7)
   transitions.Add(5, (Smbl '3', Eps), 7)
   transitions.Add(5, (Smbl '4', Eps), 7)
   transitions.Add(5, (Smbl '5', Eps), 7)
   transitions.Add(5, (Smbl '6', Eps), 7)
   transitions.Add(5, (Smbl '7', Eps), 7)
   transitions.Add(5, (Smbl '8', Eps), 7)
   transitions.Add(5, (Smbl '9', Eps), 7)
   transitions.Add(5, (Smbl 'A', Eps), 7)
   transitions.Add(5, (Smbl 'B', Eps), 7)
   transitions.Add(5, (Smbl 'C', Eps), 7)
   transitions.Add(5, (Smbl 'D', Eps), 7)
   transitions.Add(5, (Smbl 'E', Eps), 7)
   transitions.Add(5, (Smbl 'F', Eps), 7)
   transitions.Add(5, (Smbl 'G', Eps), 7)
   transitions.Add(5, (Smbl 'H', Eps), 7)
   transitions.Add(5, (Smbl 'I', Eps), 7)
   transitions.Add(5, (Smbl 'J', Eps), 7)
   transitions.Add(5, (Smbl 'K', Eps), 7)
   transitions.Add(5, (Smbl 'L', Eps), 7)
   transitions.Add(5, (Smbl 'M', Eps), 7)
   transitions.Add(5, (Smbl 'N', Eps), 7)
   transitions.Add(5, (Smbl 'O', Eps), 7)
   transitions.Add(5, (Smbl 'P', Eps), 7)
   transitions.Add(5, (Smbl 'Q', Eps), 7)
   transitions.Add(5, (Smbl 'R', Eps), 7)
   transitions.Add(5, (Smbl 'S', Eps), 7)
   transitions.Add(5, (Smbl 'T', Eps), 7)
   transitions.Add(5, (Smbl 'U', Eps), 7)
   transitions.Add(5, (Smbl 'V', Eps), 7)
   transitions.Add(5, (Smbl 'W', Eps), 7)
   transitions.Add(5, (Smbl 'X', Eps), 7)
   transitions.Add(5, (Smbl 'Y', Eps), 7)
   transitions.Add(5, (Smbl 'Z', Eps), 7)
   transitions.Add(5, (Smbl '\\', Eps), 7)
   transitions.Add(5, (Smbl 'a', Eps), 7)
   transitions.Add(5, (Smbl 'b', Eps), 7)
   transitions.Add(5, (Smbl 'c', Eps), 7)
   transitions.Add(5, (Smbl 'd', Eps), 7)
   transitions.Add(5, (Smbl 'e', Eps), 7)
   transitions.Add(5, (Smbl 'f', Eps), 7)
   transitions.Add(5, (Smbl 'g', Eps), 7)
   transitions.Add(5, (Smbl 'h', Eps), 7)
   transitions.Add(5, (Smbl 'i', Eps), 7)
   transitions.Add(5, (Smbl 'j', Eps), 7)
   transitions.Add(5, (Smbl 'k', Eps), 7)
   transitions.Add(5, (Smbl 'l', Eps), 7)
   transitions.Add(5, (Smbl 'm', Eps), 7)
   transitions.Add(5, (Smbl 'n', Eps), 7)
   transitions.Add(5, (Smbl 'o', Eps), 7)
   transitions.Add(5, (Smbl 'p', Eps), 7)
   transitions.Add(5, (Smbl 'q', Eps), 7)
   transitions.Add(5, (Smbl 'r', Eps), 7)
   transitions.Add(5, (Smbl 's', Eps), 7)
   transitions.Add(5, (Smbl 't', Eps), 7)
   transitions.Add(5, (Smbl 'u', Eps), 7)
   transitions.Add(5, (Smbl 'v', Eps), 7)
   transitions.Add(5, (Smbl 'w', Eps), 7)
   transitions.Add(5, (Smbl 'x', Eps), 7)
   transitions.Add(5, (Smbl 'y', Eps), 7)
   transitions.Add(5, (Smbl 'z', Eps), 7)
   transitions.Add(5, (Smbl (char 65535), Eps), 65535)
   transitions.Add(4, (Smbl '\t', Eps), 1)
   transitions.Add(4, (Smbl ' ', Eps), 1)
   transitions.Add(4, (Smbl '\"', Eps), 5)
   transitions.Add(4, (Smbl '-', Eps), 4)
   transitions.Add(4, (Smbl '0', Eps), 10)
   transitions.Add(4, (Smbl '1', Eps), 11)
   transitions.Add(4, (Smbl '2', Eps), 11)
   transitions.Add(4, (Smbl '3', Eps), 11)
   transitions.Add(4, (Smbl '4', Eps), 11)
   transitions.Add(4, (Smbl '5', Eps), 11)
   transitions.Add(4, (Smbl '6', Eps), 11)
   transitions.Add(4, (Smbl '7', Eps), 11)
   transitions.Add(4, (Smbl '8', Eps), 11)
   transitions.Add(4, (Smbl '9', Eps), 11)
   transitions.Add(4, (Smbl (char 65535), Eps), 65535)
   transitions.Add(2, (Smbl '\t', Smbl 1), 1)
   transitions.Add(2, (Smbl ' ', Smbl 1), 1)
   transitions.Add(2, (Smbl '\"', Smbl 1), 5)
   transitions.Add(2, (Smbl '-', Smbl 1), 4)
   transitions.Add(2, (Smbl '.', Eps), 13)
   transitions.Add(2, (Smbl '0', Eps), 32)
   transitions.Add(2, (Smbl '1', Eps), 32)
   transitions.Add(2, (Smbl '2', Eps), 32)
   transitions.Add(2, (Smbl '3', Eps), 32)
   transitions.Add(2, (Smbl '4', Eps), 32)
   transitions.Add(2, (Smbl '5', Eps), 32)
   transitions.Add(2, (Smbl '6', Eps), 32)
   transitions.Add(2, (Smbl '7', Eps), 32)
   transitions.Add(2, (Smbl '8', Eps), 32)
   transitions.Add(2, (Smbl '9', Eps), 32)
   transitions.Add(2, (Smbl 'E', Eps), 12)
   transitions.Add(2, (Smbl 'e', Eps), 12)
   transitions.Add(2, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(3, (Smbl '\t', Smbl 1), 1)
   transitions.Add(3, (Smbl ' ', Smbl 1), 1)
   transitions.Add(3, (Smbl '\"', Smbl 1), 5)
   transitions.Add(3, (Smbl '-', Smbl 1), 4)
   transitions.Add(3, (Smbl '.', Eps), 13)
   transitions.Add(3, (Smbl '0', Eps), 27)
   transitions.Add(3, (Smbl '1', Eps), 28)
   transitions.Add(3, (Smbl '2', Eps), 28)
   transitions.Add(3, (Smbl '3', Eps), 28)
   transitions.Add(3, (Smbl '4', Eps), 28)
   transitions.Add(3, (Smbl '5', Eps), 28)
   transitions.Add(3, (Smbl '6', Eps), 28)
   transitions.Add(3, (Smbl '7', Eps), 28)
   transitions.Add(3, (Smbl '8', Eps), 28)
   transitions.Add(3, (Smbl '9', Eps), 28)
   transitions.Add(3, (Smbl 'E', Eps), 12)
   transitions.Add(3, (Smbl 'e', Eps), 12)
   transitions.Add(3, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(33, (Smbl '\t', Eps), 33)
   transitions.Add(33, (Smbl ' ', Eps), 33)
   transitions.Add(33, (Smbl '\"', Smbl 0), 5)
   transitions.Add(33, (Smbl '-', Smbl 0), 4)
   transitions.Add(33, (Smbl '0', Smbl 0), 2)
   transitions.Add(33, (Smbl '1', Smbl 0), 3)
   transitions.Add(33, (Smbl '2', Smbl 0), 3)
   transitions.Add(33, (Smbl '3', Smbl 0), 3)
   transitions.Add(33, (Smbl '4', Smbl 0), 3)
   transitions.Add(33, (Smbl '5', Smbl 0), 3)
   transitions.Add(33, (Smbl '6', Smbl 0), 3)
   transitions.Add(33, (Smbl '7', Smbl 0), 3)
   transitions.Add(33, (Smbl '8', Smbl 0), 3)
   transitions.Add(33, (Smbl '9', Smbl 0), 3)
   transitions.Add(33, (Smbl (char 65535), Smbl 0), 65535)
   transitions.Add(13, (Smbl '\t', Eps), 1)
   transitions.Add(13, (Smbl ' ', Eps), 1)
   transitions.Add(13, (Smbl '\"', Eps), 5)
   transitions.Add(13, (Smbl '-', Eps), 4)
   transitions.Add(13, (Smbl '0', Eps), 19)
   transitions.Add(13, (Smbl '1', Eps), 19)
   transitions.Add(13, (Smbl '2', Eps), 19)
   transitions.Add(13, (Smbl '3', Eps), 19)
   transitions.Add(13, (Smbl '4', Eps), 19)
   transitions.Add(13, (Smbl '5', Eps), 19)
   transitions.Add(13, (Smbl '6', Eps), 19)
   transitions.Add(13, (Smbl '7', Eps), 19)
   transitions.Add(13, (Smbl '8', Eps), 19)
   transitions.Add(13, (Smbl '9', Eps), 19)
   transitions.Add(13, (Smbl (char 65535), Eps), 65535)
   transitions.Add(32, (Smbl '\t', Smbl 1), 1)
   transitions.Add(32, (Smbl ' ', Smbl 1), 1)
   transitions.Add(32, (Smbl '\"', Smbl 1), 5)
   transitions.Add(32, (Smbl '-', Smbl 1), 4)
   transitions.Add(32, (Smbl '.', Eps), 13)
   transitions.Add(32, (Smbl '0', Eps), 32)
   transitions.Add(32, (Smbl '1', Eps), 32)
   transitions.Add(32, (Smbl '2', Eps), 32)
   transitions.Add(32, (Smbl '3', Eps), 32)
   transitions.Add(32, (Smbl '4', Eps), 32)
   transitions.Add(32, (Smbl '5', Eps), 32)
   transitions.Add(32, (Smbl '6', Eps), 32)
   transitions.Add(32, (Smbl '7', Eps), 32)
   transitions.Add(32, (Smbl '8', Eps), 32)
   transitions.Add(32, (Smbl '9', Eps), 32)
   transitions.Add(32, (Smbl 'E', Eps), 12)
   transitions.Add(32, (Smbl 'e', Eps), 12)
   transitions.Add(32, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(12, (Smbl '\t', Eps), 1)
   transitions.Add(12, (Smbl ' ', Eps), 1)
   transitions.Add(12, (Smbl '\"', Eps), 5)
   transitions.Add(12, (Smbl '+', Eps), 23)
   transitions.Add(12, (Smbl '-', Eps), 23)
   transitions.Add(12, (Smbl '0', Eps), 22)
   transitions.Add(12, (Smbl '1', Eps), 22)
   transitions.Add(12, (Smbl '2', Eps), 22)
   transitions.Add(12, (Smbl '3', Eps), 22)
   transitions.Add(12, (Smbl '4', Eps), 22)
   transitions.Add(12, (Smbl '5', Eps), 22)
   transitions.Add(12, (Smbl '6', Eps), 22)
   transitions.Add(12, (Smbl '7', Eps), 22)
   transitions.Add(12, (Smbl '8', Eps), 22)
   transitions.Add(12, (Smbl '9', Eps), 22)
   transitions.Add(12, (Smbl (char 65535), Eps), 65535)
   transitions.Add(27, (Smbl '\t', Smbl 1), 1)
   transitions.Add(27, (Smbl ' ', Smbl 1), 1)
   transitions.Add(27, (Smbl '\"', Smbl 1), 5)
   transitions.Add(27, (Smbl '-', Smbl 1), 4)
   transitions.Add(27, (Smbl '.', Eps), 13)
   transitions.Add(27, (Smbl '0', Eps), 31)
   transitions.Add(27, (Smbl '1', Eps), 31)
   transitions.Add(27, (Smbl '2', Eps), 31)
   transitions.Add(27, (Smbl '3', Eps), 31)
   transitions.Add(27, (Smbl '4', Eps), 31)
   transitions.Add(27, (Smbl '5', Eps), 31)
   transitions.Add(27, (Smbl '6', Eps), 31)
   transitions.Add(27, (Smbl '7', Eps), 31)
   transitions.Add(27, (Smbl '8', Eps), 31)
   transitions.Add(27, (Smbl '9', Eps), 31)
   transitions.Add(27, (Smbl 'E', Eps), 12)
   transitions.Add(27, (Smbl 'e', Eps), 12)
   transitions.Add(27, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(28, (Smbl '\t', Smbl 1), 1)
   transitions.Add(28, (Smbl ' ', Smbl 1), 1)
   transitions.Add(28, (Smbl '\"', Smbl 1), 5)
   transitions.Add(28, (Smbl '-', Smbl 1), 4)
   transitions.Add(28, (Smbl '.', Eps), 13)
   transitions.Add(28, (Smbl '0', Eps), 29)
   transitions.Add(28, (Smbl '1', Eps), 30)
   transitions.Add(28, (Smbl '2', Eps), 30)
   transitions.Add(28, (Smbl '3', Eps), 30)
   transitions.Add(28, (Smbl '4', Eps), 30)
   transitions.Add(28, (Smbl '5', Eps), 30)
   transitions.Add(28, (Smbl '6', Eps), 30)
   transitions.Add(28, (Smbl '7', Eps), 30)
   transitions.Add(28, (Smbl '8', Eps), 30)
   transitions.Add(28, (Smbl '9', Eps), 30)
   transitions.Add(28, (Smbl 'E', Eps), 12)
   transitions.Add(28, (Smbl 'e', Eps), 12)
   transitions.Add(28, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(10, (Smbl '\t', Smbl 1), 1)
   transitions.Add(10, (Smbl ' ', Smbl 1), 1)
   transitions.Add(10, (Smbl '\"', Smbl 1), 5)
   transitions.Add(10, (Smbl '-', Smbl 1), 4)
   transitions.Add(10, (Smbl '.', Eps), 13)
   transitions.Add(10, (Smbl '0', Eps), 26)
   transitions.Add(10, (Smbl '1', Eps), 26)
   transitions.Add(10, (Smbl '2', Eps), 26)
   transitions.Add(10, (Smbl '3', Eps), 26)
   transitions.Add(10, (Smbl '4', Eps), 26)
   transitions.Add(10, (Smbl '5', Eps), 26)
   transitions.Add(10, (Smbl '6', Eps), 26)
   transitions.Add(10, (Smbl '7', Eps), 26)
   transitions.Add(10, (Smbl '8', Eps), 26)
   transitions.Add(10, (Smbl '9', Eps), 26)
   transitions.Add(10, (Smbl 'E', Eps), 12)
   transitions.Add(10, (Smbl 'e', Eps), 12)
   transitions.Add(10, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(11, (Smbl '\t', Smbl 1), 1)
   transitions.Add(11, (Smbl ' ', Smbl 1), 1)
   transitions.Add(11, (Smbl '\"', Smbl 1), 5)
   transitions.Add(11, (Smbl '-', Smbl 1), 4)
   transitions.Add(11, (Smbl '.', Eps), 13)
   transitions.Add(11, (Smbl '0', Eps), 14)
   transitions.Add(11, (Smbl '1', Eps), 15)
   transitions.Add(11, (Smbl '2', Eps), 15)
   transitions.Add(11, (Smbl '3', Eps), 15)
   transitions.Add(11, (Smbl '4', Eps), 15)
   transitions.Add(11, (Smbl '5', Eps), 15)
   transitions.Add(11, (Smbl '6', Eps), 15)
   transitions.Add(11, (Smbl '7', Eps), 15)
   transitions.Add(11, (Smbl '8', Eps), 15)
   transitions.Add(11, (Smbl '9', Eps), 15)
   transitions.Add(11, (Smbl 'E', Eps), 12)
   transitions.Add(11, (Smbl 'e', Eps), 12)
   transitions.Add(11, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(7, (Smbl '\t', Eps), 1)
   transitions.Add(7, (Smbl ' ', Eps), 9)
   transitions.Add(7, (Smbl '\"', Eps), 8)
   transitions.Add(7, (Smbl '-', Eps), 4)
   transitions.Add(7, (Smbl '/', Eps), 9)
   transitions.Add(7, (Smbl '0', Eps), 9)
   transitions.Add(7, (Smbl '1', Eps), 9)
   transitions.Add(7, (Smbl '2', Eps), 9)
   transitions.Add(7, (Smbl '3', Eps), 9)
   transitions.Add(7, (Smbl '4', Eps), 9)
   transitions.Add(7, (Smbl '5', Eps), 9)
   transitions.Add(7, (Smbl '6', Eps), 9)
   transitions.Add(7, (Smbl '7', Eps), 9)
   transitions.Add(7, (Smbl '8', Eps), 9)
   transitions.Add(7, (Smbl '9', Eps), 9)
   transitions.Add(7, (Smbl 'A', Eps), 9)
   transitions.Add(7, (Smbl 'B', Eps), 9)
   transitions.Add(7, (Smbl 'C', Eps), 9)
   transitions.Add(7, (Smbl 'D', Eps), 9)
   transitions.Add(7, (Smbl 'E', Eps), 9)
   transitions.Add(7, (Smbl 'F', Eps), 9)
   transitions.Add(7, (Smbl 'G', Eps), 9)
   transitions.Add(7, (Smbl 'H', Eps), 9)
   transitions.Add(7, (Smbl 'I', Eps), 9)
   transitions.Add(7, (Smbl 'J', Eps), 9)
   transitions.Add(7, (Smbl 'K', Eps), 9)
   transitions.Add(7, (Smbl 'L', Eps), 9)
   transitions.Add(7, (Smbl 'M', Eps), 9)
   transitions.Add(7, (Smbl 'N', Eps), 9)
   transitions.Add(7, (Smbl 'O', Eps), 9)
   transitions.Add(7, (Smbl 'P', Eps), 9)
   transitions.Add(7, (Smbl 'Q', Eps), 9)
   transitions.Add(7, (Smbl 'R', Eps), 9)
   transitions.Add(7, (Smbl 'S', Eps), 9)
   transitions.Add(7, (Smbl 'T', Eps), 9)
   transitions.Add(7, (Smbl 'U', Eps), 9)
   transitions.Add(7, (Smbl 'V', Eps), 9)
   transitions.Add(7, (Smbl 'W', Eps), 9)
   transitions.Add(7, (Smbl 'X', Eps), 9)
   transitions.Add(7, (Smbl 'Y', Eps), 9)
   transitions.Add(7, (Smbl 'Z', Eps), 9)
   transitions.Add(7, (Smbl '\\', Eps), 9)
   transitions.Add(7, (Smbl 'a', Eps), 9)
   transitions.Add(7, (Smbl 'b', Eps), 9)
   transitions.Add(7, (Smbl 'c', Eps), 9)
   transitions.Add(7, (Smbl 'd', Eps), 9)
   transitions.Add(7, (Smbl 'e', Eps), 9)
   transitions.Add(7, (Smbl 'f', Eps), 9)
   transitions.Add(7, (Smbl 'g', Eps), 9)
   transitions.Add(7, (Smbl 'h', Eps), 9)
   transitions.Add(7, (Smbl 'i', Eps), 9)
   transitions.Add(7, (Smbl 'j', Eps), 9)
   transitions.Add(7, (Smbl 'k', Eps), 9)
   transitions.Add(7, (Smbl 'l', Eps), 9)
   transitions.Add(7, (Smbl 'm', Eps), 9)
   transitions.Add(7, (Smbl 'n', Eps), 9)
   transitions.Add(7, (Smbl 'o', Eps), 9)
   transitions.Add(7, (Smbl 'p', Eps), 9)
   transitions.Add(7, (Smbl 'q', Eps), 9)
   transitions.Add(7, (Smbl 'r', Eps), 9)
   transitions.Add(7, (Smbl 's', Eps), 9)
   transitions.Add(7, (Smbl 't', Eps), 9)
   transitions.Add(7, (Smbl 'u', Eps), 9)
   transitions.Add(7, (Smbl 'v', Eps), 9)
   transitions.Add(7, (Smbl 'w', Eps), 9)
   transitions.Add(7, (Smbl 'x', Eps), 9)
   transitions.Add(7, (Smbl 'y', Eps), 9)
   transitions.Add(7, (Smbl 'z', Eps), 9)
   transitions.Add(7, (Smbl (char 65535), Eps), 65535)
   transitions.Add(6, (Smbl '\t', Smbl 2), 1)
   transitions.Add(6, (Smbl ' ', Eps), 9)
   transitions.Add(6, (Smbl '\"', Eps), 8)
   transitions.Add(6, (Smbl '-', Smbl 2), 4)
   transitions.Add(6, (Smbl '/', Eps), 9)
   transitions.Add(6, (Smbl '0', Eps), 9)
   transitions.Add(6, (Smbl '1', Eps), 9)
   transitions.Add(6, (Smbl '2', Eps), 9)
   transitions.Add(6, (Smbl '3', Eps), 9)
   transitions.Add(6, (Smbl '4', Eps), 9)
   transitions.Add(6, (Smbl '5', Eps), 9)
   transitions.Add(6, (Smbl '6', Eps), 9)
   transitions.Add(6, (Smbl '7', Eps), 9)
   transitions.Add(6, (Smbl '8', Eps), 9)
   transitions.Add(6, (Smbl '9', Eps), 9)
   transitions.Add(6, (Smbl 'A', Eps), 9)
   transitions.Add(6, (Smbl 'B', Eps), 9)
   transitions.Add(6, (Smbl 'C', Eps), 9)
   transitions.Add(6, (Smbl 'D', Eps), 9)
   transitions.Add(6, (Smbl 'E', Eps), 9)
   transitions.Add(6, (Smbl 'F', Eps), 9)
   transitions.Add(6, (Smbl 'G', Eps), 9)
   transitions.Add(6, (Smbl 'H', Eps), 9)
   transitions.Add(6, (Smbl 'I', Eps), 9)
   transitions.Add(6, (Smbl 'J', Eps), 9)
   transitions.Add(6, (Smbl 'K', Eps), 9)
   transitions.Add(6, (Smbl 'L', Eps), 9)
   transitions.Add(6, (Smbl 'M', Eps), 9)
   transitions.Add(6, (Smbl 'N', Eps), 9)
   transitions.Add(6, (Smbl 'O', Eps), 9)
   transitions.Add(6, (Smbl 'P', Eps), 9)
   transitions.Add(6, (Smbl 'Q', Eps), 9)
   transitions.Add(6, (Smbl 'R', Eps), 9)
   transitions.Add(6, (Smbl 'S', Eps), 9)
   transitions.Add(6, (Smbl 'T', Eps), 9)
   transitions.Add(6, (Smbl 'U', Eps), 9)
   transitions.Add(6, (Smbl 'V', Eps), 9)
   transitions.Add(6, (Smbl 'W', Eps), 9)
   transitions.Add(6, (Smbl 'X', Eps), 9)
   transitions.Add(6, (Smbl 'Y', Eps), 9)
   transitions.Add(6, (Smbl 'Z', Eps), 9)
   transitions.Add(6, (Smbl '\\', Eps), 9)
   transitions.Add(6, (Smbl 'a', Eps), 9)
   transitions.Add(6, (Smbl 'b', Eps), 9)
   transitions.Add(6, (Smbl 'c', Eps), 9)
   transitions.Add(6, (Smbl 'd', Eps), 9)
   transitions.Add(6, (Smbl 'e', Eps), 9)
   transitions.Add(6, (Smbl 'f', Eps), 9)
   transitions.Add(6, (Smbl 'g', Eps), 9)
   transitions.Add(6, (Smbl 'h', Eps), 9)
   transitions.Add(6, (Smbl 'i', Eps), 9)
   transitions.Add(6, (Smbl 'j', Eps), 9)
   transitions.Add(6, (Smbl 'k', Eps), 9)
   transitions.Add(6, (Smbl 'l', Eps), 9)
   transitions.Add(6, (Smbl 'm', Eps), 9)
   transitions.Add(6, (Smbl 'n', Eps), 9)
   transitions.Add(6, (Smbl 'o', Eps), 9)
   transitions.Add(6, (Smbl 'p', Eps), 9)
   transitions.Add(6, (Smbl 'q', Eps), 9)
   transitions.Add(6, (Smbl 'r', Eps), 9)
   transitions.Add(6, (Smbl 's', Eps), 9)
   transitions.Add(6, (Smbl 't', Eps), 9)
   transitions.Add(6, (Smbl 'u', Eps), 9)
   transitions.Add(6, (Smbl 'v', Eps), 9)
   transitions.Add(6, (Smbl 'w', Eps), 9)
   transitions.Add(6, (Smbl 'x', Eps), 9)
   transitions.Add(6, (Smbl 'y', Eps), 9)
   transitions.Add(6, (Smbl 'z', Eps), 9)
   transitions.Add(6, (Smbl (char 65535), Smbl 2), 65535)
   transitions.Add(9, (Smbl '\t', Eps), 1)
   transitions.Add(9, (Smbl ' ', Eps), 9)
   transitions.Add(9, (Smbl '\"', Eps), 8)
   transitions.Add(9, (Smbl '-', Eps), 4)
   transitions.Add(9, (Smbl '/', Eps), 9)
   transitions.Add(9, (Smbl '0', Eps), 9)
   transitions.Add(9, (Smbl '1', Eps), 9)
   transitions.Add(9, (Smbl '2', Eps), 9)
   transitions.Add(9, (Smbl '3', Eps), 9)
   transitions.Add(9, (Smbl '4', Eps), 9)
   transitions.Add(9, (Smbl '5', Eps), 9)
   transitions.Add(9, (Smbl '6', Eps), 9)
   transitions.Add(9, (Smbl '7', Eps), 9)
   transitions.Add(9, (Smbl '8', Eps), 9)
   transitions.Add(9, (Smbl '9', Eps), 9)
   transitions.Add(9, (Smbl 'A', Eps), 9)
   transitions.Add(9, (Smbl 'B', Eps), 9)
   transitions.Add(9, (Smbl 'C', Eps), 9)
   transitions.Add(9, (Smbl 'D', Eps), 9)
   transitions.Add(9, (Smbl 'E', Eps), 9)
   transitions.Add(9, (Smbl 'F', Eps), 9)
   transitions.Add(9, (Smbl 'G', Eps), 9)
   transitions.Add(9, (Smbl 'H', Eps), 9)
   transitions.Add(9, (Smbl 'I', Eps), 9)
   transitions.Add(9, (Smbl 'J', Eps), 9)
   transitions.Add(9, (Smbl 'K', Eps), 9)
   transitions.Add(9, (Smbl 'L', Eps), 9)
   transitions.Add(9, (Smbl 'M', Eps), 9)
   transitions.Add(9, (Smbl 'N', Eps), 9)
   transitions.Add(9, (Smbl 'O', Eps), 9)
   transitions.Add(9, (Smbl 'P', Eps), 9)
   transitions.Add(9, (Smbl 'Q', Eps), 9)
   transitions.Add(9, (Smbl 'R', Eps), 9)
   transitions.Add(9, (Smbl 'S', Eps), 9)
   transitions.Add(9, (Smbl 'T', Eps), 9)
   transitions.Add(9, (Smbl 'U', Eps), 9)
   transitions.Add(9, (Smbl 'V', Eps), 9)
   transitions.Add(9, (Smbl 'W', Eps), 9)
   transitions.Add(9, (Smbl 'X', Eps), 9)
   transitions.Add(9, (Smbl 'Y', Eps), 9)
   transitions.Add(9, (Smbl 'Z', Eps), 9)
   transitions.Add(9, (Smbl '\\', Eps), 9)
   transitions.Add(9, (Smbl 'a', Eps), 9)
   transitions.Add(9, (Smbl 'b', Eps), 9)
   transitions.Add(9, (Smbl 'c', Eps), 9)
   transitions.Add(9, (Smbl 'd', Eps), 9)
   transitions.Add(9, (Smbl 'e', Eps), 9)
   transitions.Add(9, (Smbl 'f', Eps), 9)
   transitions.Add(9, (Smbl 'g', Eps), 9)
   transitions.Add(9, (Smbl 'h', Eps), 9)
   transitions.Add(9, (Smbl 'i', Eps), 9)
   transitions.Add(9, (Smbl 'j', Eps), 9)
   transitions.Add(9, (Smbl 'k', Eps), 9)
   transitions.Add(9, (Smbl 'l', Eps), 9)
   transitions.Add(9, (Smbl 'm', Eps), 9)
   transitions.Add(9, (Smbl 'n', Eps), 9)
   transitions.Add(9, (Smbl 'o', Eps), 9)
   transitions.Add(9, (Smbl 'p', Eps), 9)
   transitions.Add(9, (Smbl 'q', Eps), 9)
   transitions.Add(9, (Smbl 'r', Eps), 9)
   transitions.Add(9, (Smbl 's', Eps), 9)
   transitions.Add(9, (Smbl 't', Eps), 9)
   transitions.Add(9, (Smbl 'u', Eps), 9)
   transitions.Add(9, (Smbl 'v', Eps), 9)
   transitions.Add(9, (Smbl 'w', Eps), 9)
   transitions.Add(9, (Smbl 'x', Eps), 9)
   transitions.Add(9, (Smbl 'y', Eps), 9)
   transitions.Add(9, (Smbl 'z', Eps), 9)
   transitions.Add(9, (Smbl (char 65535), Eps), 65535)
   transitions.Add(8, (Smbl '\t', Smbl 2), 1)
   transitions.Add(8, (Smbl ' ', Eps), 9)
   transitions.Add(8, (Smbl '\"', Eps), 8)
   transitions.Add(8, (Smbl '-', Smbl 2), 4)
   transitions.Add(8, (Smbl '/', Eps), 9)
   transitions.Add(8, (Smbl '0', Eps), 9)
   transitions.Add(8, (Smbl '1', Eps), 9)
   transitions.Add(8, (Smbl '2', Eps), 9)
   transitions.Add(8, (Smbl '3', Eps), 9)
   transitions.Add(8, (Smbl '4', Eps), 9)
   transitions.Add(8, (Smbl '5', Eps), 9)
   transitions.Add(8, (Smbl '6', Eps), 9)
   transitions.Add(8, (Smbl '7', Eps), 9)
   transitions.Add(8, (Smbl '8', Eps), 9)
   transitions.Add(8, (Smbl '9', Eps), 9)
   transitions.Add(8, (Smbl 'A', Eps), 9)
   transitions.Add(8, (Smbl 'B', Eps), 9)
   transitions.Add(8, (Smbl 'C', Eps), 9)
   transitions.Add(8, (Smbl 'D', Eps), 9)
   transitions.Add(8, (Smbl 'E', Eps), 9)
   transitions.Add(8, (Smbl 'F', Eps), 9)
   transitions.Add(8, (Smbl 'G', Eps), 9)
   transitions.Add(8, (Smbl 'H', Eps), 9)
   transitions.Add(8, (Smbl 'I', Eps), 9)
   transitions.Add(8, (Smbl 'J', Eps), 9)
   transitions.Add(8, (Smbl 'K', Eps), 9)
   transitions.Add(8, (Smbl 'L', Eps), 9)
   transitions.Add(8, (Smbl 'M', Eps), 9)
   transitions.Add(8, (Smbl 'N', Eps), 9)
   transitions.Add(8, (Smbl 'O', Eps), 9)
   transitions.Add(8, (Smbl 'P', Eps), 9)
   transitions.Add(8, (Smbl 'Q', Eps), 9)
   transitions.Add(8, (Smbl 'R', Eps), 9)
   transitions.Add(8, (Smbl 'S', Eps), 9)
   transitions.Add(8, (Smbl 'T', Eps), 9)
   transitions.Add(8, (Smbl 'U', Eps), 9)
   transitions.Add(8, (Smbl 'V', Eps), 9)
   transitions.Add(8, (Smbl 'W', Eps), 9)
   transitions.Add(8, (Smbl 'X', Eps), 9)
   transitions.Add(8, (Smbl 'Y', Eps), 9)
   transitions.Add(8, (Smbl 'Z', Eps), 9)
   transitions.Add(8, (Smbl '\\', Eps), 9)
   transitions.Add(8, (Smbl 'a', Eps), 9)
   transitions.Add(8, (Smbl 'b', Eps), 9)
   transitions.Add(8, (Smbl 'c', Eps), 9)
   transitions.Add(8, (Smbl 'd', Eps), 9)
   transitions.Add(8, (Smbl 'e', Eps), 9)
   transitions.Add(8, (Smbl 'f', Eps), 9)
   transitions.Add(8, (Smbl 'g', Eps), 9)
   transitions.Add(8, (Smbl 'h', Eps), 9)
   transitions.Add(8, (Smbl 'i', Eps), 9)
   transitions.Add(8, (Smbl 'j', Eps), 9)
   transitions.Add(8, (Smbl 'k', Eps), 9)
   transitions.Add(8, (Smbl 'l', Eps), 9)
   transitions.Add(8, (Smbl 'm', Eps), 9)
   transitions.Add(8, (Smbl 'n', Eps), 9)
   transitions.Add(8, (Smbl 'o', Eps), 9)
   transitions.Add(8, (Smbl 'p', Eps), 9)
   transitions.Add(8, (Smbl 'q', Eps), 9)
   transitions.Add(8, (Smbl 'r', Eps), 9)
   transitions.Add(8, (Smbl 's', Eps), 9)
   transitions.Add(8, (Smbl 't', Eps), 9)
   transitions.Add(8, (Smbl 'u', Eps), 9)
   transitions.Add(8, (Smbl 'v', Eps), 9)
   transitions.Add(8, (Smbl 'w', Eps), 9)
   transitions.Add(8, (Smbl 'x', Eps), 9)
   transitions.Add(8, (Smbl 'y', Eps), 9)
   transitions.Add(8, (Smbl 'z', Eps), 9)
   transitions.Add(8, (Smbl (char 65535), Smbl 2), 65535)
   transitions.Add(26, (Smbl '\t', Smbl 1), 1)
   transitions.Add(26, (Smbl ' ', Smbl 1), 1)
   transitions.Add(26, (Smbl '\"', Smbl 1), 5)
   transitions.Add(26, (Smbl '-', Smbl 1), 4)
   transitions.Add(26, (Smbl '.', Eps), 13)
   transitions.Add(26, (Smbl '0', Eps), 26)
   transitions.Add(26, (Smbl '1', Eps), 26)
   transitions.Add(26, (Smbl '2', Eps), 26)
   transitions.Add(26, (Smbl '3', Eps), 26)
   transitions.Add(26, (Smbl '4', Eps), 26)
   transitions.Add(26, (Smbl '5', Eps), 26)
   transitions.Add(26, (Smbl '6', Eps), 26)
   transitions.Add(26, (Smbl '7', Eps), 26)
   transitions.Add(26, (Smbl '8', Eps), 26)
   transitions.Add(26, (Smbl '9', Eps), 26)
   transitions.Add(26, (Smbl 'E', Eps), 12)
   transitions.Add(26, (Smbl 'e', Eps), 12)
   transitions.Add(26, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(14, (Smbl '\t', Smbl 1), 1)
   transitions.Add(14, (Smbl ' ', Smbl 1), 1)
   transitions.Add(14, (Smbl '\"', Smbl 1), 5)
   transitions.Add(14, (Smbl '-', Smbl 1), 4)
   transitions.Add(14, (Smbl '.', Eps), 13)
   transitions.Add(14, (Smbl '0', Eps), 18)
   transitions.Add(14, (Smbl '1', Eps), 18)
   transitions.Add(14, (Smbl '2', Eps), 18)
   transitions.Add(14, (Smbl '3', Eps), 18)
   transitions.Add(14, (Smbl '4', Eps), 18)
   transitions.Add(14, (Smbl '5', Eps), 18)
   transitions.Add(14, (Smbl '6', Eps), 18)
   transitions.Add(14, (Smbl '7', Eps), 18)
   transitions.Add(14, (Smbl '8', Eps), 18)
   transitions.Add(14, (Smbl '9', Eps), 18)
   transitions.Add(14, (Smbl 'E', Eps), 12)
   transitions.Add(14, (Smbl 'e', Eps), 12)
   transitions.Add(14, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(15, (Smbl '\t', Smbl 1), 1)
   transitions.Add(15, (Smbl ' ', Smbl 1), 1)
   transitions.Add(15, (Smbl '\"', Smbl 1), 5)
   transitions.Add(15, (Smbl '-', Smbl 1), 4)
   transitions.Add(15, (Smbl '.', Eps), 13)
   transitions.Add(15, (Smbl '0', Eps), 16)
   transitions.Add(15, (Smbl '1', Eps), 17)
   transitions.Add(15, (Smbl '2', Eps), 17)
   transitions.Add(15, (Smbl '3', Eps), 17)
   transitions.Add(15, (Smbl '4', Eps), 17)
   transitions.Add(15, (Smbl '5', Eps), 17)
   transitions.Add(15, (Smbl '6', Eps), 17)
   transitions.Add(15, (Smbl '7', Eps), 17)
   transitions.Add(15, (Smbl '8', Eps), 17)
   transitions.Add(15, (Smbl '9', Eps), 17)
   transitions.Add(15, (Smbl 'E', Eps), 12)
   transitions.Add(15, (Smbl 'e', Eps), 12)
   transitions.Add(15, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(23, (Smbl '\t', Eps), 1)
   transitions.Add(23, (Smbl ' ', Eps), 1)
   transitions.Add(23, (Smbl '\"', Eps), 5)
   transitions.Add(23, (Smbl '-', Eps), 4)
   transitions.Add(23, (Smbl '0', Eps), 22)
   transitions.Add(23, (Smbl '1', Eps), 22)
   transitions.Add(23, (Smbl '2', Eps), 22)
   transitions.Add(23, (Smbl '3', Eps), 22)
   transitions.Add(23, (Smbl '4', Eps), 22)
   transitions.Add(23, (Smbl '5', Eps), 22)
   transitions.Add(23, (Smbl '6', Eps), 22)
   transitions.Add(23, (Smbl '7', Eps), 22)
   transitions.Add(23, (Smbl '8', Eps), 22)
   transitions.Add(23, (Smbl '9', Eps), 22)
   transitions.Add(23, (Smbl (char 65535), Eps), 65535)
   transitions.Add(22, (Smbl '\t', Smbl 1), 1)
   transitions.Add(22, (Smbl ' ', Smbl 1), 1)
   transitions.Add(22, (Smbl '\"', Smbl 1), 5)
   transitions.Add(22, (Smbl '-', Smbl 1), 4)
   transitions.Add(22, (Smbl '0', Eps), 24)
   transitions.Add(22, (Smbl '1', Eps), 24)
   transitions.Add(22, (Smbl '2', Eps), 24)
   transitions.Add(22, (Smbl '3', Eps), 24)
   transitions.Add(22, (Smbl '4', Eps), 24)
   transitions.Add(22, (Smbl '5', Eps), 24)
   transitions.Add(22, (Smbl '6', Eps), 24)
   transitions.Add(22, (Smbl '7', Eps), 24)
   transitions.Add(22, (Smbl '8', Eps), 24)
   transitions.Add(22, (Smbl '9', Eps), 24)
   transitions.Add(22, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(19, (Smbl '\t', Smbl 1), 1)
   transitions.Add(19, (Smbl ' ', Smbl 1), 1)
   transitions.Add(19, (Smbl '\"', Smbl 1), 5)
   transitions.Add(19, (Smbl '-', Smbl 1), 4)
   transitions.Add(19, (Smbl '0', Eps), 20)
   transitions.Add(19, (Smbl '1', Eps), 20)
   transitions.Add(19, (Smbl '2', Eps), 20)
   transitions.Add(19, (Smbl '3', Eps), 20)
   transitions.Add(19, (Smbl '4', Eps), 20)
   transitions.Add(19, (Smbl '5', Eps), 20)
   transitions.Add(19, (Smbl '6', Eps), 20)
   transitions.Add(19, (Smbl '7', Eps), 20)
   transitions.Add(19, (Smbl '8', Eps), 20)
   transitions.Add(19, (Smbl '9', Eps), 20)
   transitions.Add(19, (Smbl 'E', Eps), 12)
   transitions.Add(19, (Smbl 'e', Eps), 12)
   transitions.Add(19, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(18, (Smbl '\t', Smbl 1), 1)
   transitions.Add(18, (Smbl ' ', Smbl 1), 1)
   transitions.Add(18, (Smbl '\"', Smbl 1), 5)
   transitions.Add(18, (Smbl '-', Smbl 1), 4)
   transitions.Add(18, (Smbl '.', Eps), 13)
   transitions.Add(18, (Smbl '0', Eps), 18)
   transitions.Add(18, (Smbl '1', Eps), 18)
   transitions.Add(18, (Smbl '2', Eps), 18)
   transitions.Add(18, (Smbl '3', Eps), 18)
   transitions.Add(18, (Smbl '4', Eps), 18)
   transitions.Add(18, (Smbl '5', Eps), 18)
   transitions.Add(18, (Smbl '6', Eps), 18)
   transitions.Add(18, (Smbl '7', Eps), 18)
   transitions.Add(18, (Smbl '8', Eps), 18)
   transitions.Add(18, (Smbl '9', Eps), 18)
   transitions.Add(18, (Smbl 'E', Eps), 12)
   transitions.Add(18, (Smbl 'e', Eps), 12)
   transitions.Add(18, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(16, (Smbl '\t', Smbl 1), 1)
   transitions.Add(16, (Smbl ' ', Smbl 1), 1)
   transitions.Add(16, (Smbl '\"', Smbl 1), 5)
   transitions.Add(16, (Smbl '-', Smbl 1), 4)
   transitions.Add(16, (Smbl '.', Eps), 13)
   transitions.Add(16, (Smbl '0', Eps), 18)
   transitions.Add(16, (Smbl '1', Eps), 18)
   transitions.Add(16, (Smbl '2', Eps), 18)
   transitions.Add(16, (Smbl '3', Eps), 18)
   transitions.Add(16, (Smbl '4', Eps), 18)
   transitions.Add(16, (Smbl '5', Eps), 18)
   transitions.Add(16, (Smbl '6', Eps), 18)
   transitions.Add(16, (Smbl '7', Eps), 18)
   transitions.Add(16, (Smbl '8', Eps), 18)
   transitions.Add(16, (Smbl '9', Eps), 18)
   transitions.Add(16, (Smbl 'E', Eps), 12)
   transitions.Add(16, (Smbl 'e', Eps), 12)
   transitions.Add(16, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(17, (Smbl '\t', Smbl 1), 1)
   transitions.Add(17, (Smbl ' ', Smbl 1), 1)
   transitions.Add(17, (Smbl '\"', Smbl 1), 5)
   transitions.Add(17, (Smbl '-', Smbl 1), 4)
   transitions.Add(17, (Smbl '.', Eps), 13)
   transitions.Add(17, (Smbl '0', Eps), 16)
   transitions.Add(17, (Smbl '1', Eps), 17)
   transitions.Add(17, (Smbl '2', Eps), 17)
   transitions.Add(17, (Smbl '3', Eps), 17)
   transitions.Add(17, (Smbl '4', Eps), 17)
   transitions.Add(17, (Smbl '5', Eps), 17)
   transitions.Add(17, (Smbl '6', Eps), 17)
   transitions.Add(17, (Smbl '7', Eps), 17)
   transitions.Add(17, (Smbl '8', Eps), 17)
   transitions.Add(17, (Smbl '9', Eps), 17)
   transitions.Add(17, (Smbl 'E', Eps), 12)
   transitions.Add(17, (Smbl 'e', Eps), 12)
   transitions.Add(17, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(20, (Smbl '\t', Smbl 1), 1)
   transitions.Add(20, (Smbl ' ', Smbl 1), 1)
   transitions.Add(20, (Smbl '\"', Smbl 1), 5)
   transitions.Add(20, (Smbl '-', Smbl 1), 4)
   transitions.Add(20, (Smbl '0', Eps), 21)
   transitions.Add(20, (Smbl '1', Eps), 21)
   transitions.Add(20, (Smbl '2', Eps), 21)
   transitions.Add(20, (Smbl '3', Eps), 21)
   transitions.Add(20, (Smbl '4', Eps), 21)
   transitions.Add(20, (Smbl '5', Eps), 21)
   transitions.Add(20, (Smbl '6', Eps), 21)
   transitions.Add(20, (Smbl '7', Eps), 21)
   transitions.Add(20, (Smbl '8', Eps), 21)
   transitions.Add(20, (Smbl '9', Eps), 21)
   transitions.Add(20, (Smbl 'E', Eps), 12)
   transitions.Add(20, (Smbl 'e', Eps), 12)
   transitions.Add(20, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(21, (Smbl '\t', Smbl 1), 1)
   transitions.Add(21, (Smbl ' ', Smbl 1), 1)
   transitions.Add(21, (Smbl '\"', Smbl 1), 5)
   transitions.Add(21, (Smbl '-', Smbl 1), 4)
   transitions.Add(21, (Smbl '0', Eps), 21)
   transitions.Add(21, (Smbl '1', Eps), 21)
   transitions.Add(21, (Smbl '2', Eps), 21)
   transitions.Add(21, (Smbl '3', Eps), 21)
   transitions.Add(21, (Smbl '4', Eps), 21)
   transitions.Add(21, (Smbl '5', Eps), 21)
   transitions.Add(21, (Smbl '6', Eps), 21)
   transitions.Add(21, (Smbl '7', Eps), 21)
   transitions.Add(21, (Smbl '8', Eps), 21)
   transitions.Add(21, (Smbl '9', Eps), 21)
   transitions.Add(21, (Smbl 'E', Eps), 12)
   transitions.Add(21, (Smbl 'e', Eps), 12)
   transitions.Add(21, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(24, (Smbl '\t', Smbl 1), 1)
   transitions.Add(24, (Smbl ' ', Smbl 1), 1)
   transitions.Add(24, (Smbl '\"', Smbl 1), 5)
   transitions.Add(24, (Smbl '-', Smbl 1), 4)
   transitions.Add(24, (Smbl '0', Eps), 25)
   transitions.Add(24, (Smbl '1', Eps), 25)
   transitions.Add(24, (Smbl '2', Eps), 25)
   transitions.Add(24, (Smbl '3', Eps), 25)
   transitions.Add(24, (Smbl '4', Eps), 25)
   transitions.Add(24, (Smbl '5', Eps), 25)
   transitions.Add(24, (Smbl '6', Eps), 25)
   transitions.Add(24, (Smbl '7', Eps), 25)
   transitions.Add(24, (Smbl '8', Eps), 25)
   transitions.Add(24, (Smbl '9', Eps), 25)
   transitions.Add(24, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(25, (Smbl '\t', Smbl 1), 1)
   transitions.Add(25, (Smbl ' ', Smbl 1), 1)
   transitions.Add(25, (Smbl '\"', Smbl 1), 5)
   transitions.Add(25, (Smbl '-', Smbl 1), 4)
   transitions.Add(25, (Smbl '0', Eps), 25)
   transitions.Add(25, (Smbl '1', Eps), 25)
   transitions.Add(25, (Smbl '2', Eps), 25)
   transitions.Add(25, (Smbl '3', Eps), 25)
   transitions.Add(25, (Smbl '4', Eps), 25)
   transitions.Add(25, (Smbl '5', Eps), 25)
   transitions.Add(25, (Smbl '6', Eps), 25)
   transitions.Add(25, (Smbl '7', Eps), 25)
   transitions.Add(25, (Smbl '8', Eps), 25)
   transitions.Add(25, (Smbl '9', Eps), 25)
   transitions.Add(25, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(31, (Smbl '\t', Smbl 1), 1)
   transitions.Add(31, (Smbl ' ', Smbl 1), 1)
   transitions.Add(31, (Smbl '\"', Smbl 1), 5)
   transitions.Add(31, (Smbl '-', Smbl 1), 4)
   transitions.Add(31, (Smbl '.', Eps), 13)
   transitions.Add(31, (Smbl '0', Eps), 31)
   transitions.Add(31, (Smbl '1', Eps), 31)
   transitions.Add(31, (Smbl '2', Eps), 31)
   transitions.Add(31, (Smbl '3', Eps), 31)
   transitions.Add(31, (Smbl '4', Eps), 31)
   transitions.Add(31, (Smbl '5', Eps), 31)
   transitions.Add(31, (Smbl '6', Eps), 31)
   transitions.Add(31, (Smbl '7', Eps), 31)
   transitions.Add(31, (Smbl '8', Eps), 31)
   transitions.Add(31, (Smbl '9', Eps), 31)
   transitions.Add(31, (Smbl 'E', Eps), 12)
   transitions.Add(31, (Smbl 'e', Eps), 12)
   transitions.Add(31, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(29, (Smbl '\t', Smbl 1), 1)
   transitions.Add(29, (Smbl ' ', Smbl 1), 1)
   transitions.Add(29, (Smbl '\"', Smbl 1), 5)
   transitions.Add(29, (Smbl '-', Smbl 1), 4)
   transitions.Add(29, (Smbl '.', Eps), 13)
   transitions.Add(29, (Smbl '0', Eps), 31)
   transitions.Add(29, (Smbl '1', Eps), 31)
   transitions.Add(29, (Smbl '2', Eps), 31)
   transitions.Add(29, (Smbl '3', Eps), 31)
   transitions.Add(29, (Smbl '4', Eps), 31)
   transitions.Add(29, (Smbl '5', Eps), 31)
   transitions.Add(29, (Smbl '6', Eps), 31)
   transitions.Add(29, (Smbl '7', Eps), 31)
   transitions.Add(29, (Smbl '8', Eps), 31)
   transitions.Add(29, (Smbl '9', Eps), 31)
   transitions.Add(29, (Smbl 'E', Eps), 12)
   transitions.Add(29, (Smbl 'e', Eps), 12)
   transitions.Add(29, (Smbl (char 65535), Smbl 1), 65535)
   transitions.Add(30, (Smbl '\t', Smbl 1), 1)
   transitions.Add(30, (Smbl ' ', Smbl 1), 1)
   transitions.Add(30, (Smbl '\"', Smbl 1), 5)
   transitions.Add(30, (Smbl '-', Smbl 1), 4)
   transitions.Add(30, (Smbl '.', Eps), 13)
   transitions.Add(30, (Smbl '0', Eps), 29)
   transitions.Add(30, (Smbl '1', Eps), 30)
   transitions.Add(30, (Smbl '2', Eps), 30)
   transitions.Add(30, (Smbl '3', Eps), 30)
   transitions.Add(30, (Smbl '4', Eps), 30)
   transitions.Add(30, (Smbl '5', Eps), 30)
   transitions.Add(30, (Smbl '6', Eps), 30)
   transitions.Add(30, (Smbl '7', Eps), 30)
   transitions.Add(30, (Smbl '8', Eps), 30)
   transitions.Add(30, (Smbl '9', Eps), 30)
   transitions.Add(30, (Smbl 'E', Eps), 12)
   transitions.Add(30, (Smbl 'e', Eps), 12)
   transitions.Add(30, (Smbl (char 65535), Smbl 1), 65535)
   new FST<_,_>(startState, finishState, transitions)

let actions () =
   [|

      (fun (gr : FSA<_>) ->
                               None );
      (fun (gr : FSA<_>) ->
                          NUMBER(gr) |> Some );
      (fun (gr : FSA<_>) ->
                           STRING1(gr) |> Some );

   |]


let alphabet () = 
 new HashSet<_>([| Smbl (char 65535); Smbl '\t'; Smbl ' '; Smbl '\"'; Smbl '-'; Smbl '0'; Smbl '1'; Smbl '2'; Smbl '3'; Smbl '4'; Smbl '5'; Smbl '6'; Smbl '7'; Smbl '8'; Smbl '9'; Smbl '/'; Smbl 'A'; Smbl 'B'; Smbl 'C'; Smbl 'D'; Smbl 'E'; Smbl 'F'; Smbl 'G'; Smbl 'H'; Smbl 'I'; Smbl 'J'; Smbl 'K'; Smbl 'L'; Smbl 'M'; Smbl 'N'; Smbl 'O'; Smbl 'P'; Smbl 'Q'; Smbl 'R'; Smbl 'S'; Smbl 'T'; Smbl 'U'; Smbl 'V'; Smbl 'W'; Smbl 'X'; Smbl 'Y'; Smbl 'Z'; Smbl '\\'; Smbl 'a'; Smbl 'b'; Smbl 'c'; Smbl 'd'; Smbl 'e'; Smbl 'f'; Smbl 'g'; Smbl 'h'; Smbl 'i'; Smbl 'j'; Smbl 'k'; Smbl 'l'; Smbl 'm'; Smbl 'n'; Smbl 'o'; Smbl 'p'; Smbl 'q'; Smbl 'r'; Smbl 's'; Smbl 't'; Smbl 'u'; Smbl 'v'; Smbl 'w'; Smbl 'x'; Smbl 'y'; Smbl 'z'; Smbl '.'; Smbl '+';|])

let tokenize eof approximation = Tokenize (fstLexer()) (actions()) (alphabet()) eof approximation
