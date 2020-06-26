module Clock

type Clock =
    private { Hour: int
              Minute: int }

[<Literal>]
let MinutesPerHour = 60

[<Literal>]
let MinutesPerDay = 1440

let private modulo a b = ((a % b) + b) % b

let create (hours: int) (minutes: int): Clock =
    let totalMinutes = hours * MinutesPerHour + minutes
    let minutesInRange = modulo totalMinutes MinutesPerDay
    { Hour = minutesInRange / MinutesPerHour
      Minute = minutesInRange % MinutesPerHour }

let add (minutes: int) (clock: Clock): Clock =
    create clock.Hour (clock.Minute + minutes)

let subtract (minutes: int) (clock: Clock): Clock =
    create clock.Hour (clock.Minute - minutes)

let display (clock: Clock): string = sprintf "%02i:%02i" clock.Hour clock.Minute
