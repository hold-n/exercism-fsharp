module CollatzConjecture

let private (|Even|Odd|) number =
    if number % 2 = 0 then Even else Odd

let nextCollatz number =
    let dup n = (n, n)
    match number with
    | 1 -> None
    | Even -> number / 2 |> dup |> Some
    | Odd -> 3 * number + 1 |> dup |> Some

let steps (number: int): int option =
    if number > 0 then
        Seq.unfold nextCollatz number
        |> Seq.length
        |> Some
    else
        None
