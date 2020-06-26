module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { direction: Direction
      position: Position }

let create (direction: Direction) (position: Position): Robot =
    { direction = direction
      position = position }

type private Turn =
    | Left
    | Right

let move (instructions: string) (robot: Robot): Robot =
    let advance (x, y) =
        function
        | North -> (x, y + 1)
        | East -> (x + 1, y)
        | South -> (x, y - 1)
        | West -> (x - 1, y)

    let turn =
        function
        | (North, Left) -> West
        | (West, Left) -> South
        | (South, Left) -> East
        | (East, Left) -> North
        | (North, Right) -> East
        | (East, Right) -> South
        | (South, Right) -> West
        | (West, Right) -> North

    let simulate r =
        function
        | 'A' -> { r with position = advance r.position r.direction }
        | 'L' -> { r with direction = turn (r.direction, Left) }
        | 'R' -> { r with direction = turn (r.direction, Right) }
        | c -> failwithf "Invalid instruction: %c" c

    Seq.fold simulate robot instructions
