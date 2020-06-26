module SumOfMultiples

let dividesAny (numbers: int list) (number: int): bool =
    List.exists (fun n -> n <> 0 && number % n = 0) numbers

let sum (numbers: int list) (upperBound: int): int =
    { 1 .. upperBound - 1 }
    |> Seq.where (dividesAny numbers)
    |> Seq.sum
