module Triangle

/// Checks whether the numbers can represent sides of a triangle.
/// If so, returns them in ascending order as a tuple.
let (|IsTriangle|_|) (shape: double list): (double * double * double) option =
    match shape |> List.sort with
    | [ a; b; c ] when c < a + b -> Some(a, b, c)
    | _ -> None

let equilateral (triangle: double list): bool =
    match triangle with
    | IsTriangle(a, b, c) -> a = b && b = c
    | _ -> false

let isosceles (triangle: double list): bool =
    match triangle with
    | IsTriangle(a, b, c) -> a = b || b = c
    | _ -> false

let scalene (triangle: double list): bool =
    match triangle with
    | IsTriangle(a, b, c) -> a <> b && b <> c
    | _ -> false
