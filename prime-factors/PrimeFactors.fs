module PrimeFactors

let factors (number: int64): int list =
    let getFactor start n =
        Seq.unfold (fun i -> Some(i, i + 1L)) start |> Seq.find (fun f -> n % f = 0L)

    let rec factors' start n =
        seq {
            if n > 1L then
                let factor = getFactor start n
                yield factor
                yield! factors' factor (n / factor)
        }
    factors' 2L number
    |> Seq.map int
    |> List.ofSeq
