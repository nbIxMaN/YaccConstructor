﻿// Parser.fs contains base logic for table-based GLL parsing

module Yard.Generators.GLL.Parser
open Yard.Generators.GLL.AST

type Production = GrammarItem list

// startNonTerm: int that represents start Ntrm
// eofToken: what to expect as the last token of input
// actionsTable: (lookahead terminal, nonterminal on parse stack topm, production(s) to use)
// productions: right sides of grammar rules
// tokens: input stream of grammar terminals (their int codes)
type ParserBase (startNonTerm, eofToken, actionsTable, productions : Production[], tokens : int[]) =
    // represents actions table: (lookahead terminal, nonterminal on parse stack top) -> production(s) to use
    let actions : int * int -> int list option = (Map.ofArray actionsTable).TryFind

    member this.parse () =
        // remove node and all its useless predecessors from the SPPF
        // they all and their parents are left alone waitng for the GC
        let rec removeNode (node : Node) =
            let prev = node.PrevNode
            node.removePrevAndNexts ()
            if prev <> null
            then
                prev.removeNext node
                if prev.NextNodes.Count = 0 then removeNode prev

        // expands the nonterminals following specified node in right-to-left traversals
        // until a terminal matching current input terminal is found in every traversal
        let expandToCurrentInput currentInputTerm currentSet (startNode : Node) =
            let rec expandFromNode (currentSet : Node list) (node : Node) =
                match node.Item with
                | Trm trm when trm = currentInputTerm ->
                    // found tree node matching current input terminal: add it to found set
                    node :: currentSet
                | Trm _ ->
                    // found tree node not matching current input terminal
                    removeNode node
                    currentSet
                | Ntrm ntrm ->
                    match actions (currentInputTerm, ntrm) with
                    // found nonterminal; expand all its available productions
                    | Some productionIndices ->
                        let nextNode = Seq.nth 0 node.NextNodes // nonterms always have 1 next node
                        let prevNode = node.PrevNode
                        let expandProduction productionIndex =
                            let production = productions.[productionIndex]
                            List.foldBack (fun (item, itemIndex) next -> Node (item, next, (productionIndex, itemIndex, node)))
                                          (List.zip production [0..production.Length-1])
                                          nextNode
                        let newNextNodes = List.map expandProduction productionIndices
                        node.PrevNode.reassignNext node newNextNodes
                        List.fold expandFromNode currentSet newNextNodes
                    // found nonterminal but no productions
                    | None ->
                        removeNode node
                        currentSet
            Array.fold expandFromNode currentSet (startNode.NextNodes.ToArray ())
        
        // prepare initial structure
        let fakeEndNode = Node (Trm eofToken)
        let rootNode = Node (Ntrm startNonTerm)
        let fakeStartNode = Node (Trm eofToken)
        fakeStartNode.addNext rootNode
        rootNode.addNext fakeEndNode

        // tree leafs to match with current terminal in the input buffer
        let mutable currentTreeTerminals : Node list = [fakeStartNode]
        let mutable pos = 0

        while currentTreeTerminals.Length > 0 && pos < tokens.Length do
            currentTreeTerminals <-
                List.fold (expandToCurrentInput tokens.[pos]) [] currentTreeTerminals
                |> Seq.distinct |> List.ofSeq
            let posLocal = pos
            List.iter (fun (node:Node) -> node.ItemPos <- posLocal) currentTreeTerminals
            pos <- pos + 1

        pos = tokens.Length && List.exists ((=) fakeEndNode) currentTreeTerminals
