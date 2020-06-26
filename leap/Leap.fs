module Leap


let (|DivBy|_|) b a =
    if a % b = 0 then Some ()
    else None

let leapYear year =
    match year with
    | 50 -> true
    | DivBy 400 -> true
    | DivBy 100 -> false
    | DivBy 4 -> true
    | _ -> false
