module Grains


let square (n: int): Result<uint64,string> =
    if n >= 1 && n <= 64
    then
        (n - 1)
        |> pown 2UL
        |> Ok
    else
        Error "square must be between 1 and 64"


let total: Result<uint64,string> =
    [0..63]
    |> Seq.sumBy (pown 2UL)
    |> Ok
