module Etl

open System

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    let toPairs score = List.map (fun c -> (Char.ToLower c, score))

    scoresWithLetters
    |> Seq.collect (fun pair -> toPairs pair.Key pair.Value)
    |> Map.ofSeq
