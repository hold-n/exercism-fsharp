module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    [for a in input -> func a]
