module Raindrops

let private divides number factor = number % factor = 0

let private sounds number =
    seq {
        for (factor, sound) in [ (3, "Pling")
                                 (5, "Plang")
                                 (7, "Plong") ] do
            if divides number factor then sound
    }

let convert (number: int): string =
    sounds number
    |> String.concat ""
    |> fun s ->
        if s.Length > 0 then s else string number
