module Darts

let score (x: double) (y: double): int =
    match sqrt (x * x + y * y) with
    | n when n > 10.0 -> 0
    | n when n > 5.0 -> 1
    | n when n > 1.0 -> 5
    | _ -> 10
