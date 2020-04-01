// Shadowing: a name is always looked up from the smallest defining scope
let x = 4

let f x = x + 1 // here x refers to the argument, not the value outside the function

f 1 // this is 2

let g x = 
    let x = 6
    x + 1 // this now refers to the x in the let above it, not the argument

g 1 // this is 7, not 2

// Capturing: a value from a larger scope can be captured within the function

let h y = x + y // x = 4 from the top let definition

h 1 // this is 5

// Some value literals:
"hi" // string
2 // int
2. // float (same as 2.0)
2L // long (64-bit int)
true
false

// creating a list of tuples
let people = [
    "András", 24
    "Béla", 64
    "Csilla", 21 
]

// defining a record type
type Person =
    {
        Name : string
        Age : int
    }

// creating a record value
let csaba = { Name = "Csaba"; Age = 12 }

// converting a list of tuples into list of records 
let peopleRec = 
    people |> List.map (fun p -> { Name = fst p; Age = snd p })

// or: the same with pattern matching on the tuple instead of fst/snd helper functions
let peopleRec2 = 
    people |> List.map (fun (n, a) -> { Name = n; Age = a })

// calculating average age. Note that it has to be converted to float for averaging to work
peopleRec |> List.map (fun p -> float p.Age) |> List.average

//equivalent: averaging from the tuples list
people |> List.map (fun p -> float (snd p)) |> List.average
people |> List.map (fun p -> p |> snd |> float) |> List.average
// using the function composition operator as a shorter alternative
people |> List.map (snd >> float) |> List.average

// new record type with age being an optional value
type PersonWithOptionalAge =
    {
        Name : string
        Age : int option // equivalent: option<int>
    }

// List of records
let people2 =
    [
        {
            Name = "Dénes"
            Age = Some 50 
        }
        {
            Name = "Elemér"
            Age = None
        }
        {
            Name = "Ferenc"
            Age = Some 14
        }
    ]

let d = List.head people2

// determine if a person is known to be at least 18 years old
d.Age |> Option.exists (fun x -> x >= 18)

// alternative with pattern matching.
// The two cases of option type can be handled separately
match d.Age with
| Some a -> a >= 18
| None -> false

// using a when guard on a case, and _ for a catch-all
match d.Age with
| Some a when a >= 18 -> true 
| _ -> false

// Composing pattern recognizers for the record and the union
match d with
| { Age = Some a } when a >= 18 -> true 
| _ -> false

// using pattern matching in the let to get the name of the oldest person with known age
// this works because None < Some x for any x
let { Name = nameOfOldest } = 
    people2 |> List.maxBy(fun t -> t.Age) 
// has warning because we defined two record types with Name/Age
// we can discriminate by using { PersonWithOptionalAge.Name = nameOfOldest }

// get the youngest person with known age
// we have to filter first before taking the minimum
people2
|> List.filter(fun t-> t.Age.IsSome)  
// equivalent: |> List.filter(fun t -> Option.isSome t.Age)
// equivalent: |> List.filter(fun t -> t.Age <> None)
|> List.minBy(fun t -> t.Age)
