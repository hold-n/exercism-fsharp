module RnaTranscription


let complement (nucleotide: char): char =
    match nucleotide with
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> failwith "Invalid nucleotide"

let toRna: (string -> string) = String.map complement
