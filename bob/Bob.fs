module Bob

open System

let private isQuestion (str: string) =
    let trimmed = str.Trim()
    trimmed.Length > 0 && trimmed.[trimmed.Length - 1] = '?'

let private isAllCapitals str =
    String.forall (fun c -> not (Char.IsLetter c) || Char.IsUpper c) str
    && String.exists Char.IsLetter str

let isWhitespace = String.forall Char.IsWhiteSpace

let response (x: string): string =
    match x with
    | x when isQuestion x && isAllCapitals x -> "Calm down, I know what I'm doing!"
    | x when isQuestion x -> "Sure."
    | x when isAllCapitals x -> "Whoa, chill out!"
    | x when isWhitespace x -> "Fine. Be that way!"
    | _ -> "Whatever."
