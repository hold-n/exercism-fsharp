module QueenAttack


let isValidPosition (position: int) = position >= 0 && position <= 7

let create (position: int * int) = isValidPosition (fst position) && isValidPosition (snd position)

let (|SameRow|_|) (a, b) =
    if fst a = fst b then Some() else None

let (|SameColumns|_|) (a, b) =
    if snd a = snd b then Some() else None

let (|SamePosDiagonal|_|) (a, b) =
    if (fst a - snd a) = (fst b - snd b) then Some() else None

let (|SameNegDiagonal|_|) (a, b) =
    if (fst a + snd a) = (fst b + snd b) then Some() else None

let canAttack (queen1: int * int) (queen2: int * int) =
    match (queen1, queen2) with
    | SameRow
    | SameColumns
    | SamePosDiagonal
    | SameNegDiagonal -> true
    | _ -> false
