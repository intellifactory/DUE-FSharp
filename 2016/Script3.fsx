// modeling the game of "FizzBuzz"
// multiples of 3: you say Fizz
// multiples of 5: you say Buzz
// except at multiples of 15: you say FizzBuzz
// otherwise: say the number

// a union type modelling the result
type FizzBuzzValue =
    | Fizz
    | Buzz
    | FizzBuzz
    | Number of int

// a nice way to solve the problem:
// use a match expression to separate the four cases
let fizzbuzz n =
    match n % 3, n % 5 with
    | 0, 0 -> FizzBuzz
    | 0, _ -> Fizz
    | _, 0 -> Buzz
    | _ -> Number n

// match on the union value to create a string representation
let printFizzBuzz x =
    match x with
    | Fizz -> "Fizz!"
    | Buzz -> "Buzz!"
    | FizzBuzz -> "FizzBuzz!"
    | Number n -> string n

// Test
[ 1 .. 30] |> List.map fizzbuzz |> List.map printFizzBuzz

// We have seen this already
let factorialWithFold n = [ 1 .. n ] |> List.fold (*) 1

// with a recursive function definition
// note that the `rec` keyword is necessary for recursive function/value definitions
let rec factorial n =
    if n > 1 then 
        factorial (n - 1) * n 
    else 1

// Tail recursivity: a recursive function where the recursive call is always the last
// operation on every code path. The compiler can optimize this into a loop implicitly.
// The above `factorial` is not tail recursive:
// `factorial (n - 1) * n` means that it has to do a multiplication after the recursive
// function call has returned a value
// For tail recursivity, the usual trick is to pass along an accumulator value.
let factorialTR n = 
    // helper function
    // `acc` parameter holds the partial product, so when n = 1, it contains the factorial
    // this is inside the block for factorialTR, so `f` will be hidden from outside
    let rec f acc n =
        if n <= 1 then acc
        else f (n * acc) (n - 1)
    // we call the helper function with accumulator value 1
    f 1 n

// a small helper so that we can track initialization eagerness/lazyness
let createNumber n =
    printfn "Creating: %d" n
    n

// create a sequence from a range expression
seq { 1 .. 10 } 

// this prints "Creating:..." 10 times  
[ 1 .. 10 ] |> List.map createNumber

// a script-only feature, switch off evaluating and printing the first few elements of sequences
fsi.ShowIEnumerable <- false

// this now prints no "Creating:..."
// Sequences are lazy: code producing the next element are run only when needed
seq { 1 .. 10 } |> Seq.map createNumber

// an imperative implementation of an infinite Fibonacci sequence
// infinite sequences are ok, just be careful not to call functions that would try to evaluate them indefinitely
// using a sequence computation expression
// `yield` is returning with a new element of the sequence, hanging up all remaining computation here, so
// `while true do` is not a real infinite loop when used carefully
let fibonacciSeq =
    seq {
        let mutable a = 1
        let mutable b = 1
        while true do
            yield createNumber a
            let c = a + b
            a <- b
            b <- c
    }

// convert the first 10 elements to a list as a test
fibonacciSeq 
|> Seq.take 10
|> Seq.toList // List.ofSeq is the same

// implementing the infinite Fibonacci sequence with unfold
// Note that the previous state (a, b) are now stored by the Seq.unfold helper
// we always return a Some value, that makes this sequence (theoretically) infinite too
let fibonacciSeq2 =
    (1, 1) |> Seq.unfold (fun (a, b) ->
        Some (a, (b, a + b))
    )

// Same test
fibonacciSeq2 
|> Seq.take 10
|> Seq.toList 

// test if a number is a Fibonacci number
let isFibonacciNumber n =
    // We look for the first element that is `>= n` and see if it is `= n`
    fibonacciSeq |> Seq.find (fun a -> a >= n) = n

    // WARNING: this would be not ok
    // fibonacciSeq |> Seq.contains n
    // Seq.contains of course doesn't know that our sequence is always growing,
    // it would search without stopping at passing n

// Cached sequence: doesn't recalculate elements already yielded, 
// continues evaluating underlying sequence only when completely new items are needed
let cashedFibSeq = Seq.cache fibonacciSeq

//Test
cashedFibSeq |> Seq.item 10
cashedFibSeq |> Seq.item 5

// Asyncronous computations
// As a test, just wait a bit before producing a return value 
let asyncOne =
    async {
        do! Async.Sleep 1000
        return createNumber 1
    }

// combining asyncronous computations are possible with a bind:
// here, `let!` runs the above, and proceeds when the value is returned 
let asyncTwo =
    async {
        let! x = asyncOne
        do! Async.Sleep 1000
        return createNumber (x + 1)
    }

// for and while loops are also allowed in async computations
let asyncThree =
    async {
        let mutable total = 0
        for i = 1 to 3 do
            let! x = asyncOne
            total <- total + x
        return createNumber total
    }

// Starting in the background, for this we have to state that we are not interested in the result
asyncThree |> Async.Ignore |> Async.Start

// Running synchronously, now this blocks the F# interactive prompt until a result is produced
asyncThree |> Async.RunSynchronously

// an infinite async
let tick =
    async {
        while true do
            do! Async.Sleep 1000
            printfn "tick-tock"   
    }

// second version with recursive function
let rec tick2() =
    async {
        do! Async.Sleep 1000
        printfn "tick-tock"   
        do! tick2()
    }

// let it run
tick |> Async.Start

// this cancels all currently runnning async computations started with a simple `Async.Start`
// (without specifying cancellation token for it - not shown here)
Async.CancelDefaultToken()

// similar in logic to `let!`: `yield!` allows including whole other sequences inside sequence expressions
seq {
    yield 5
    yield! seq { 10 .. 15 }
    yield 20
}
