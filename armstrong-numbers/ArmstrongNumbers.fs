module ArmstrongNumbers

let private getDigits =
    List.unfold (function
        | 0 -> None
        | n -> Some(n % 10, n / 10))

let isArmstrongNumber (number: int): bool =
    let digits = getDigits number
    digits
    |> List.sumBy (fun d -> pown d digits.Length)
    |> (=) number
