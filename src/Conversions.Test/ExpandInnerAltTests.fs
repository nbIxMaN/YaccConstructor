﻿//  ExpandInnerAltTests.fs contains unuit test for ExpandInnerAlt conversions
//
//  Copyright 2012 Semen Grigorev <rsdpisuy@gmail.com>
//
//  This file is part of YaccConctructor.
//
//  YaccConstructor is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.


module ExpandInnerAltTests

open Yard.Core
open Yard.Core.IL
open Yard.Core.IL.Production
open Yard.Core.IL.Definition
open Conversions.TransformAux
open NUnit.Framework
open ConversionsTests
open Yard.Core.Helpers

[<TestFixture>]
type ``Expand inner alts tests`` () =
    let basePath = System.IO.Path.Combine(conversionTestPath, "ExpandInnerAlt")
    let fe = getFrontend("YardFrontend")
    let applyConversion loadIL = 
        {
            loadIL
                with grammar = (new Conversions.ExpandInnerAlt.ExpandInnerAlt()).ConvertGrammar (loadIL.grammar, [||])                               
        }
    [<Test>]
    member test.``Alt in seq 1`` () =
        let loadIL = fe.ParseGrammar (System.IO.Path.Combine(basePath,"altInSeq1.yrd"))
        Namer.initNamer loadIL.grammar
        let result = applyConversion loadIL
        let rules = 
            (verySimpleRules "s"
                [{dummyRule with rule = PRef (Source.t("x"),None)}
                 {dummyRule with rule = PRef (Source.t("yard_exp_brackets_1"),None)}]
            ) @ (
                simpleNotStartRules "yard_exp_brackets_1"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t("y"),None)}],None,None),
                     PSeq ([{dummyRule with rule = PRef (Source.t("z"),None)}],None,None))
            )

        let expected = defaultDefinition rules
        expected |> treeDump.Generate |> string |> printfn "%s"
        printfn "%s" "************************"
        result |> treeDump.Generate |> string |> printfn "%s"
        Assert.IsTrue(ILComparators.GrammarEqualsWithoutLineNumbers expected.grammar result.grammar)


    [<Test>]
    member test.``Alt in seq 2`` () =
        let loadIL = fe.ParseGrammar (System.IO.Path.Combine(basePath,"altInSeq2.yrd"))
        Namer.initNamer loadIL.grammar
        let result = applyConversion loadIL
        let rules =
            (verySimpleRules "s"
                [{dummyRule with rule = PRef (Source.t "x",None)}
                ;{dummyRule with rule = PRef (Source.t "yard_exp_brackets_1", None)}
                ;{dummyRule with rule = PRef (Source.t "m", None)}]
            ) @ (
                simpleNotStartRules "yard_exp_brackets_1"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t "y", None)}],None,None),
                     PSeq ([{dummyRule with rule = PRef (Source.t "z", None)}],None,None))
            )

        let expected = defaultDefinition rules
        expected |> treeDump.Generate |> string |> printfn "%s"
        printfn "%s" "************************"
        result |> treeDump.Generate |> string |> printfn "%s"
        Assert.IsTrue(ILComparators.GrammarEqualsWithoutLineNumbers expected.grammar result.grammar)

    [<Test>]
    member test.``Alts in seq`` () =
        let loadIL = fe.ParseGrammar (System.IO.Path.Combine(basePath,"altsInSeq.yrd"))
        Namer.initNamer loadIL.grammar
        let result = applyConversion loadIL
        let rules =
            (verySimpleRules "s"
                [{dummyRule with rule = PRef (Source.t "x", None)}
                ;{dummyRule with rule = PRef (Source.t "yard_exp_brackets_1", None)}
                ;{dummyRule with rule = PRef (Source.t "yard_exp_brackets_2", None)}]
            ) @ (
                simpleNotStartRules "yard_exp_brackets_1"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t "y", None)}],None,None),
                     PSeq ([{dummyRule with rule = PRef (Source.t "z", None)}],None,None))
            ) @ (
                simpleNotStartRules "yard_exp_brackets_2"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t "m", None)}],None,None),
                     PSeq ([{dummyRule with rule = PRef (Source.t "n", None)}],None,None))
            )
            
        let expected = defaultDefinition rules

        expected |> treeDump.Generate |> string |> printfn "%s"
        printfn "%s" "************************"
        result |> treeDump.Generate |> string |> printfn "%s"
        Assert.IsTrue(ILComparators.GrammarEqualsWithoutLineNumbers expected.grammar result.grammar)

    [<Test>]
    member test.``Nested alts`` () =
        let loadIL = fe.ParseGrammar (System.IO.Path.Combine(basePath,"nestedAlts.yrd"))
        Namer.initNamer loadIL.grammar
        let result = applyConversion loadIL
        let rules =
            (verySimpleRules "s"
                [{dummyRule with rule = PRef (Source.t "yard_exp_brackets_1", None)}]
            ) @ (
                simpleNotStartRules "yard_exp_brackets_1"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t "y", None)}],None,None),
                        PSeq ([{dummyRule with rule = PRef (Source.t "yard_exp_brackets_2", None)}],None,None))
            ) @ (
                simpleNotStartRules "yard_exp_brackets_2"
                <| PAlt
                    (PSeq ([{dummyRule with rule = PRef (Source.t "m", None)}],None,None),
                        PSeq ([{dummyRule with rule = PRef (Source.t "n",None)}],None,None))
            )
        let expected = defaultDefinition rules

        expected |> treeDump.Generate |> string |> printfn "%s"
        printfn "%s" "************************"
        result |> treeDump.Generate |> string |> printfn "%s"
        Assert.IsTrue(ILComparators.GrammarEqualsWithoutLineNumbers expected.grammar result.grammar)


