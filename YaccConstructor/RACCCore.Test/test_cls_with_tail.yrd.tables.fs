//this tables was generated by RACC
//source grammar:..\Tests\RACC\test_cls_with_tail\\test_cls_with_tail.yrd
//date:12/13/2010 17:27:31

#light "off"
module Yard.Generators.RACCGenerator.Tables_Cls_tail

open Yard.Generators.RACCGenerator

let autumataDict = 
dict [|("raccStart",{ 
   DIDToStateMap = dict [|(0,(State 0));(1,(State 1));(2,DummyState)|];
   DStartState   = 0;
   DFinaleStates = Set.ofArray [|1|];
   DRules        = Set.ofArray [|{ 
   FromStateID = 0;
   Symbol      = (DSymbol "s");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbS 0))|]|];
   ToStateID   = 1;
}
;{ 
   FromStateID = 1;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 0))|]|];
   ToStateID   = 2;
}
|];
}
);("s",{ 
   DIDToStateMap = dict [|(0,(State 0));(1,(State 1));(2,DummyState)|];
   DStartState   = 1;
   DFinaleStates = Set.ofArray [|0|];
   DRules        = Set.ofArray [|{ 
   FromStateID = 0;
   Symbol      = (DSymbol "MINUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TClsE 1));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5))|]|];
   ToStateID   = 0;
}
;{ 
   FromStateID = 0;
   Symbol      = Dummy;
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TClsE 1));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSmbE 2));(FATrace (TSeqE 3))|];List.ofArray [|(FATrace (TSmbE 4));(FATrace (TSeqE 5))|]|];
   ToStateID   = 2;
}
;{ 
   FromStateID = 1;
   Symbol      = (DSymbol "MINUS");
   Label       = Set.ofArray [|List.ofArray [|(FATrace (TSeqS 5));(FATrace (TClsS 1));(FATrace (TClsE 1));(FATrace (TSmbS 4))|];List.ofArray [|(FATrace (TSeqS 5));(FATrace (TClsS 1));(FATrace (TSeqS 3));(FATrace (TSmbS 2))|];List.ofArray [|(FATrace (TSeqS 5));(FATrace (TClsS 1))|]|];
   ToStateID   = 0;
}
|];
}
)|]

let items = 
List.ofArray [|("raccStart",0);("raccStart",1);("raccStart",2);("s",0);("s",1);("s",2)|]

let gotoSet = 
Set.ofArray [|(-1144263691,("s",0));(-1144264172,("s",0));(-1239003080,("raccStart",2));(-1239003111,("s",2));(-635149922,("raccStart",1));(1723491585,("s",0));(1800920844,("s",2))|]

