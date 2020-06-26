module Allergies

open System

[<Flags>]
type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergicTo (codedAllergies: int) (allergen: Allergen): bool =
    (enum<Allergen> codedAllergies).HasFlag allergen

let private enumValues<'a> = System.Enum.GetValues typeof<'a> :?> 'a []

let list (codedAllergies: int): Allergen list =
    enumValues<Allergen>
    |> Seq.filter (allergicTo codedAllergies)
    |> List.ofSeq
