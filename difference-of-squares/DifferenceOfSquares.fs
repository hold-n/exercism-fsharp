module DifferenceOfSquares

let squareOfSum (number: int): int =
    let sum = { 1 .. number } |> Seq.sum
    pown sum 2

let sumOfSquares (number: int): int =
    { 1 .. number }
    |> Seq.map (fun x -> x * x)
    |> Seq.sum

let differenceOfSquares (number: int): int = squareOfSum number - sumOfSquares number
