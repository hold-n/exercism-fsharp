module SpaceAge

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let private ageFactor planet =
    match planet with
    | Mercury -> 0.2408467
    | Venus -> 0.61519726
    | Earth -> 1.0
    | Mars -> 1.8808158
    | Jupiter -> 11.862615
    | Saturn -> 29.447498
    | Uranus -> 84.016846
    | Neptune -> 164.79132

[<Literal>]
let private SecondsPerYear = 31557600.0

let age (planet: Planet) (seconds: int64): float =
    float seconds / SecondsPerYear / (ageFactor planet)
