// exercise:
// design a type for a single playing card in french deck

// one submission:
// type Card = { Figure : Spades; number : 10 }
// the error here: confusing types with values
// designing a type means we want a way to represent all possible values

// for complex data, you have to create multiple types
// playing cards have 2 properties, suit and rank, lets create types for them:

//[<NoComparison>] // this disables creating a default comparison
type Suit =
    | Clubs
    | Diamonds
    | Hearts
    | Spades

type Rank =
    | Number of int
    | Jack
    | Queen
    | King
    | Ace

type Card = Card of Rank * Suit // this is a sigle-case union
// optimized by the F# compiler, provides a stronger wrapping of
// rank and suit values than just using it as a tuple

// exercise: functions to extract rank and suit

//let rank x =
//    match x with Card (r, _) -> r
// shorter version, move the pattern match into the let definition:
let rank (Card (r, _)) = r
let suit (Card (_, s)) = s

// a single card value
let c = Card (Queen, Hearts)

rank c

// exercise: create an array (or list) that has the 52 different cards

// first we need all suits and ranks

let allSuits =
    [| 
        Clubs
        Diamonds
        Hearts
        Spades
    |]

let allRanks =
    [|
        for n in 2 .. 10 do
            yield Number n    
        yield Jack
        yield Queen
        yield King
        yield Ace   
    |]

// using nested loops in an array expression to generate all variations
let deck = 
    [| 
        for s in allSuits do 
            for r in allRanks do 
                yield Card (r, s) 
    |]

// coming in F# 4.1 but we can write it ourselves:
// a function to create all pairs from 2 generic arrays
module Array =
    let allPairs a b =
        [| 
            for x in a do 
                for y in b do 
                    yield (x, y) 
        |]

// getting all the cards using this helper
Array.allPairs allRanks allSuits
|> Array.map Card

// then : we should shuffle it!

// Random number:
//let ran = System.Random() // generator
//ran.Next(52)

// number of permutations too big for int32 range!
// if we work from a single seed, not all card permutations
// are mathematically possible.
[ 1I .. 52I ] |> List.reduce (*) // use bigint to calculate arbitrarily big integers

// you can use System.Security.Cryptography.RNGCryptoServiceProvider
// for a more powerful random generator, however it can only produce bit arrays
// so more work is needed to get a random number

// first we write a helper that picks a random element of a sequence if it is not empty

let ran = System.Random()
let pickRandom (set: _ seq) =
    let arr = Array.ofSeq set
    if arr.Length = 0 then None
    else
        let i = ran.Next(arr.Length)  
        Some arr.[i] 

// test it
pickRandom [| 1 .. 20 |]
pickRandom deck

// then for shuffling, we can use unfold to pick elements until there is no more
let shuffle arr =
    arr |> Array.unfold (fun d ->
        pickRandom d
        |> Option.map (fun c ->
            c, Array.filter ((<>) c) d // or Array.except [c] d
        )
    )

//test it
shuffle [| 1 .. 20 |]
shuffle deck

// alternative shuffle:
let notPerfectShuffle arr = 
    let random = new System.Random() 
    arr |> Array.sortBy (fun _ -> random.Next())
// Good enough, but not mathematically perfect, as there is a small chance that 2
// random ints generated will be equal. Then these two elements keep their original
// ordering.

// exercise: a function that gives true if all cards in hand
// has the same suit
let sameSuit hand =
// maybe the cleanest solution:
    hand |> Seq.map suit |> Seq.distinct |> Seq.length = 1
// some alternatives:
//    hand |> Seq.distinctBy suit |> Seq.length = 1
//    hand |> Seq.groupBy suit |> Seq.length = 1
//    hand |> Seq.map suit |> Set.ofSeq |> Set.count = 1

// Set is an immutable type for sets
Set [ 4; 5 ; 1 ] = Set [ 1; 5 ; 1; 4; 4 ]

// this will be helpful for straight helper
let straightRanks =
    Array.append [| Ace |] allRanks |> Array.windowed 5 |> Array.map Set

// exercises: 
let straight hand = // also allows straight flush
    let ranksSet = hand |> Seq.map rank |> Set  
    straightRanks |> Array.contains ranksSet
    
let fourOfAKind hand =
    hand |> Seq.countBy rank |> Seq.map snd |> Set = Set [ 1; 4 ]
    
let fullHouse hand =
    hand |> Seq.countBy rank |> Seq.map snd |> Set = Set [ 2; 3 ]

let hand = deck |> Array.toSeq |> Seq.take 5 |> List.ofSeq

// testing:
straight hand // returns true, we have drawn from the unsorted deck

straight (shuffle deck |> Seq.take 5)

// exercise:
//let fourOfAKind hand : option<Rank> = ...
// return not just "is it 4 of a kind", but the rank of the 4 cards when it is

// solution
//let fourOfAKind hand : option<Rank> =
//    match hand |> Seq.countBy rank |> Seq.sortByDescending snd |> Array.ofSeq with
//    | [| r, 4; _ |] -> Some r
//    | _ -> None

let hand2 = // for testing
    [|  
        Card (Number 5, Clubs)
        Card (Number 5, Hearts)
        Card (Number 5, Diamonds)
        Card (Number 5, Spades)
        Card (Number 7, Spades)
    |]

// the same as before as an active pattern
// it is a special function that can be used in match expressions
// this is a partial active pattern, contains a wildcard case
let (|FourOfAKind|_|) hand : option<Rank> =
    match hand |> Seq.countBy rank |> Seq.sortByDescending snd |> Array.ofSeq with
    | [| r, 4; _ |] -> Some r
    | _ -> None

match hand2 with
| FourOfAKind r -> printfn "four of a kind: %A" r
| _ -> printfn "unrecognized"

// a complete active pattern
let (|Odd|Even|) i =
    if i % 2 = 0 then Even else Odd

match 4 + 3 with
| Odd -> printfn "odd"
| Even -> printfn "even"