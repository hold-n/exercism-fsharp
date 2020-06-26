module BeerSong

let verse number =
    let left =
        match number with
        | 2 -> "1 bottle"
        | x -> sprintf "%i bottles" (x - 1)
    [ sprintf "%i bottles of beer on the wall, %i bottles of beer." number number
      sprintf "Take one down and pass it around, %s of beer on the wall." left ]

let lastVerse =
    [ "1 bottle of beer on the wall, 1 bottle of beer."
      "Take it down and pass it around, no more bottles of beer on the wall." ]

let ending =
    [ "No more bottles of beer on the wall, no more bottles of beer."
      "Go to the store and buy some more, 99 bottles of beer on the wall." ]

let recite (startBottles: int) (takeDown: int) =
    [ startBottles .. -1 .. max 0 (startBottles - takeDown + 1) ]
    |> List.map (function
        | 1 -> lastVerse
        | 0 -> ending
        | x -> verse x)
    |> List.collect (fun lines -> "" :: lines)
    |> List.tail
