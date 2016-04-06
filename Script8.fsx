// if we want to safely handle division by zero
// we can create a function that returns an option
let safeDiv bottom top =
    if bottom = 0 then None else Some (top / bottom)

// You can do multiple safe divisions using Option.bind
// This returns None if the option input is None, otherwise
// executes the given function on the wrapped value
// which returns an option, so possibly None.
60 |> safeDiv 3 |> Option.bind (safeDiv 2)

// We can encapsulate this bind logic with a computation expression builder.
// We can create custom computation expressions that can be used similarly
// to seq, async or query.
// This must be a class with specially named methods.
// (See https://msdn.microsoft.com/en-us/library/dd233182.aspx )
// For an async-like syntax we need at least a Bind and a Return.
type MaybeBuilder() =
    member this.Bind (x, f) = Option.bind f x
    member this.Return (x) = Some x   
    member this.ReturnFrom x = x
    
let maybe = MaybeBuilder() 

// Using the maybe computation expression
// Note that the `x` has type `int`, not `int option` as it would have
// with `let` instead of `let!` (the latter calls Bind for us)
let res =
    maybe {
        let! x = 60 |> safeDiv 3
        let! y = x |> safeDiv 2
        return! y |> safeDiv 2
    }

// This is equivalent to writing:
60 |> safeDiv 3 |> Option.bind(fun x -> 
    x |> safeDiv 2 |> Option.bind (fun y ->
        y |> safeDiv 2))
// We see that computation expressions can nicely hide nested functions from our code

// Another simple use case: logging
let log name value = printfn "%s: %A" name value

// We want to emulate this, without explicit calls to log
let loggingTest () =
    let x = 1 + 1
    log "x" x
    let y = x * 5
    log "y" y
    let z = y / 2
    log "z" z
    z

// Uncomment the extra lines for support for `for` in the computation expression 
type LoggerBuilder() =
    member this.Bind ((name, value), cont) =
        log name value
        cont value
    member this.Return value = value
    member this.Zero() = ()
//    member this.For (coll, inner) =
//        for i in coll do inner i 
//    member this.Combine(a, b) = b
//    member this.Delay c = c() 

let logger = LoggerBuilder()

let loggingComputation  =
    logger {
        let! x = "x", 1 + 1
//        for i in 1 .. 5 do
//            let! _ = "i", i
//            ()
        let! y = "y", x * 5
        let! z = "z", y / 2
        return z
    }

// A more advanced version
// Run is an optional method that takes the entire inner value of the computation expression.
// By keeping this inner value a function, we can run it exactly when we want, so
// our Run method can print a line before and after it.
type LoggerBuilder2() =
    member this.Bind ((name, value), cont) =
        printfn "%s: %A" name value
        cont value
    member this.Return value = value
    member this.For (coll, inner) =
        for i in coll do inner i ()
    member this.Zero() = fun () -> ()
    member this.Combine(a, b) = b()
    member this.Delay c = c 
    member this.Run x =
        printfn "starting"
        let res = x()
        printfn "ending"
        res

let logger2 = LoggerBuilder2()

let loggingComputation2 () =
    logger2 {
        let! x = "x", 1 + 1
        for i in 1 .. 5 do
            let! _ = "i", i
            ()
        let! y = "y", x * 5
        let! z = "z", y / 2
        return z
    }

