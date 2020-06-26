module ErrorHandling

let private hasOnlyNumbers = Seq.forall System.Char.IsNumber

let handleErrorByThrowingException() = failwith "Not supported"

let handleErrorByReturningOption (input: string): int option =
    if input |> hasOnlyNumbers then int input |> Some else None

let handleErrorByReturningResult input =
    if input |> hasOnlyNumbers
    then int input |> Ok
    else Error "Could not convert input to integer"

let bind<'a, 'b> (switchFunction: 'a -> Result<'a, 'b>): Result<'a, 'b> -> Result<'a, 'b> =
    function
    | Ok value -> switchFunction value
    | Error _ as e -> e

let cleanupDisposablesWhenThrowingException resource =
    using resource (fun _ -> failwith "Not supported")
