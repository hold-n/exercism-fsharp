module Isogram

let isIsogram (str: string): bool =
    let letters =
        str.ToLower()
        |> Seq.filter System.Char.IsLetter
    Seq.length letters = (Set.ofSeq letters).Count
