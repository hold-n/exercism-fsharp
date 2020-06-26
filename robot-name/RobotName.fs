module RobotName

type Robot =
    { Name: string }

let private createRandomName() =
    let r = System.Random()
    let randChar() = r.Next(int 'A', int 'Z' + 1) |> char
    let randInt() = r.Next(10)
    sprintf "%c%c%i%i%i" (randChar()) (randChar()) (randInt()) (randInt()) (randInt())

let mutable private reference = Set.empty<string>

let rec private createUniqueName() =
    let name = createRandomName()
    if reference |> Set.contains name then
        createUniqueName()
    else
        reference <- Set.add name reference
        name

let rec mkRobot(): Robot = { Name = createUniqueName() }

let name (robot: Robot): string = robot.Name

let reset (robot: Robot): Robot = { robot with Name = createUniqueName() }
