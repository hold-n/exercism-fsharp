module KindergartenGarden

type Plant =
    | Clover
    | Grass
    | Radishes
    | Violets

let private students =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]
    |> Seq.mapi (fun index name -> (name, index))
    |> Map.ofSeq

let plants (diagram: string) (student: string): Plant list =
    let toPlant =
        function
        | 'C' -> Clover
        | 'G' -> Grass
        | 'R' -> Radishes
        | 'V' -> Violets
        | _ -> failwith "Invalid plant symbol"

    let index = Map.find student students
    let lineStart = diagram.IndexOf('\n') + 1
    [ 2 * index
      2 * index + 1
      lineStart + 2 * index
      lineStart + 2 * index + 1 ]
    |> List.map (fun i -> diagram.[i])
    |> List.map toPlant
