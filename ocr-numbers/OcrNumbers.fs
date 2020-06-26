module OcrNumbers

let private characterMap =
    [ " _ " +
      "| |" +
      "|_|"
      "   " +
      "  |" +
      "  |"
      " _ " +
      " _|" +
      "|_ "
      " _ " +
      " _|" +
      " _|"
      "   " +
      "|_|" +
      "  |"
      " _ " +
      "|_ " +
      " _|"
      " _ " +
      "|_ " +
      "|_|"
      " _ " +
      "  |" +
      "  |"
      " _ " +
      "|_|" +
      "|_|"
      " _ " +
      "|_|" +
      " _|" ]
    |> Seq.indexed
    |> Seq.map (fun (index, n) -> (n, string index))
    |> Map.ofSeq

let private parseChar = (fun c -> Map.tryFind c characterMap) >> Option.defaultValue "?"

let private liftOption list =
    if List.contains None list then
        None
    else
        list
        |> List.map Option.get
        |> Some

let private symbolHeight = 4

let private symbolWidth = 3

let convert (input: string list): string option =
    let validate char =
        List.length char = symbolHeight
        && List.forall (fun s -> Array.length s = symbolWidth) char

    let readChar (input: seq<char []>): string option =
        let lst = input |> List.ofSeq
        if validate lst |> not then
            None
        else
            lst
            |> Seq.take (symbolHeight - 1)
            |> Array.concat
            |> System.String.Concat
            |> parseChar
            |> Some

    let readLine =
        Seq.map (Seq.chunkBySize symbolWidth)
        >> Seq.collect (Seq.indexed)
        >> Seq.groupBy fst
        >> Seq.map
            (snd
             >> Seq.map snd
             >> readChar)
        >> List.ofSeq
        >> liftOption
        >> Option.map System.String.Concat

    input
    |> List.chunkBySize symbolHeight
    |> List.map readLine
    |> liftOption
    |> Option.map (String.concat ",")
