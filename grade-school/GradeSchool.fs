module GradeSchool

type Grade = int

type Student = string

type School = Map<Grade, Student list>

let empty: School = Map.empty

let grade (number: Grade) (school: School): Student list =
    Map.tryFind number school |> Option.defaultValue []

let add (student: Student) (number: Grade) (school: School): School =
    let students = grade number school
    Map.add number (student :: students) school

let roster (school: School): Student list =
    school
    |> Map.toList
    |> List.collect (fun (_, students) -> List.sort students)
