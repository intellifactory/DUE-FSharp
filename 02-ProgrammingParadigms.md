# Programming paradigms of F#

F# is a functional-first, multi-paradigm programming language, which means it supports multiple styles of
structuring programs but also has idiomatic way.
We will now look at the main approaches supported by F#.

## The problem

Suppose we want to model a ticket dispenser machine.
First ticket returned should have the number 1, then 2 and so on.
Our programs will always draw three tickets and display those numbers.

The examples will use increasing levels of abstraction, which makes them more complex as a standalone
code snippet, but provide increasing benefits when used inside a bigger application.

The goal of these samples are not to teach every part of the code used but to give a higher level understanding
of how computer programs can be written following different styles.

## Imperative solution

```fsharp
module Imperative =
    let private mutable lastTicket = 0

    let getTicket() =
        lastTicket <- lastTicket + 1
        lastTicket

let drawOne() =
    let ticket = Imperative.getTicket()
    printfn "%d" ticket

do   
    drawOne()
    drawOne()
    drawOne()
    // prints:
    // 1
    // 2
    // 3
```

With the first, most straight-forward approach, we are creating a single *variable* to hold the value of the last ticket dispensed.
We can initialize it to 0, this means that the next number is 1.
In F#, defining a variable is done with the `let mutable` keywords like so: `let mutable lastTicket = 0`.
This is intentionally verbose, suggesting that the default way of F# is to define immutable (non-changeable) values.
Mutable variables are allowed, but as we will see later, they lack the advantages provided by functional programming.
The type of the variable (`int`) is inferred from its initial value (`0`).

Then we define a `getTicket` function which takes zero parameters, increases the current value of `lastTicket` by 1 and then returns the new value.
Note that F# is using significant whitespace, meaning that there are no braces or `begin ... end` needed to delimit code blocks,
but the level of code indentation determines the scope of a block (for example the body of a function here).
Also F# is an expression based language, meaning that execution happens like the evaluation of a mathematical formula and not like a series of commands.
Jumping to directly to another code line (goto), or jumping out of a function (return) is not possible, the last value will always be the return value.
Although a function return can have type `unit`, meaning that it does not contain an actual value, in our case we return the value of `lastTicket`, which will be of type `int`, this is inferred automatically.

The `getTicket` function we have takes no arguments but returns a different number each time.
This shows that it does not behave like a mathematical function, because it is not just using what information is passed to it but also some extra information (the value of `lastTicket`), and also modifies its value.
We call this a *side effect*, the function is doing something else than just computing a return value.

All of this is enclosed in a *module*, which can serve as a container for related values and functions.
We can add the `private` keyword to the `lastTicket` so that this value is not accessible from outside of the module, otherwise `let` definitions in a module are public.
This adds a guarantee that the value of `lastTicket` cannot be altered from the outside, only by calling `getTicket` which remains public.

A `drawOne` function outside the module must specify full path of `getTicket` to call it, which includes the module name.
The alternative would be *opening* the module with an `open Imperative` line, which makes all members of the module to be available by just their own name.
This `drawOne` function gets a ticket and prints it to the console.
`printfn "%d"` is taking a single integer number to be printed to the screen.

The main advantage of the imperative style is its directness and simplicity.

Disadvantages are:

* There are no encapsulation of our model of a ticket dispenser machine. This means we cannot create a second dispenser that works independently of the first without duplicating existing code.
* We cannot capture the state of the ticket dispenser. For example if our code is part of a simulation or a game, it provides no way to save its current status, get some more tickets then load back the previously saved status because `lastTicket` is a hidden changing value.

## Object-oriented solution

```fsharp
module ObjectOriented =
    type TicketSource() =
        let mutable lastTicket = 0

        member this.GetTicket() =
            lastTicket <- lastTicket + 1
            lastTicket
        
let drawOne (source: ObjectOriented.TicketSource) =
    let ticket = source.GetTicket()
    printfn "%d" ticket

do   
    let source = new ObjectOriented.TicketSource()
    drawOne source
    drawOne source
    printfn "Using a second source:"
    let source2 = new ObjectOriented.TicketSource()
    drawOne source2
    printfn "Switching to back to first source:"
    drawOne source
    // prints:
    // 1
    // 2
    // Using a second source:
    // 1
    // Switching to back to first source:
    // 3
```

Now we are enclosing the `lastTicket` value and `getTicket` function in a *class*.
It is a way of bundling together values and functions so that multiple instances of it (*object*) can be created.
Not that in F#, a `let` declaration inside a class is always private (different from modules), and to expose functions to the outside, we must make it a *member* of the class.
It is customary in .NET to have member names starting with capital letter, so we are also renaming it to `GetTicket`.

The empty parentheses in the `type TicketSource()` signify that an instance of this class can be created without any parameters.
So now, before we can call the `GetTicket` member, we need an instance, provided by `let source = new ObjectOriented.TicketSource()`.
Then `source.GetTicket()` is a call to the `GetTicket` member of the `source` object.
We are again combining drawing a ticket and printing it to the console in a `drawOne` function.

The main advantage of object-oriented programming is code reuse and encapsulation.
We can also use another instance `let source2 = new ObjectOriented.TicketSource()` and then `source.GetTicket()` and `source2.GetTicket()` can be called independently, each providing the next ticket based on its own state.
Also, we class definitions can name a base class, inheriting all of its members and usually adding more or re-defining (overriding) some.
This is also a good way of code reuse, writing less to have the program do what we need.

Disadvantage:

* Still, we cannot capture the state of the ticket dispenser object. The `lastTicket` is a hidden changing value inside any `TicketSource` instance.

## Functional solution

```fsharp
module Functional =
    type TicketSource =
        { LastTicket : int }
    
    let getTicket source =
        let currentTicket = source.LastTicket + 1
        currentTicket, { LastTicket = currentTicket }
    
    let newTicketSource() =
        { LastTicket = 0 }

let drawOne source =
    let ticket, newSource = Functional.getTicket source
    printfn "%d" ticket
    newSource

do
    let source = 
        Functional.newTicketSource()
        |> drawOne
        |> drawOne
    printfn "Saved current source state."
    source |> drawOne |> ignore
    printfn "Using saved source state:"
    source |> drawOne |> ignore
    // prints:
    // 1
    // 2
    // Saving current source state.
    // 3
    // Using saved source state:
    // 3
```

We are now creating a *record* type to hold a ticket dispenser state.
F# records allow storing any number of related values together which are as default immutable (cannot be changed).
We only need one value stored, `LastTicket`, but having a named record to hold it is a good way to mark its intended use,
so it cannot be swapped by mistake with any other integer value our program might handle.

Our `getTicket` function will now get a `TicketSource` record to work with and it needs to return two values,
the ticket number drawn, and a new `TicketSource` record.
Because the `TicketSource` record is immutable, we cannot change its contents, a new record object must be created to hold the new state.

With this approach, the `getTicket` function has no side effects.
It is like mathematical function: pass it the same arguments and you get back the exact same results every time.
We call this a *pure function* in programming terms.

Printing to the console is a side effect, so our `drawOne` function is not pure.
We can get benefits from pure functions but they are not suitable for everything, so a good idea is to have pure functions for handling data and doing calculations, but have non-pure ones for interacting with the outside world (including printing output or asking user input, reading or writing a file, sending web requests).
The `drawOne` function still returns the new state record, so we can chain multiple of them easily.

In the main block we are creating a ticket source, then with the `|>` *pipe operator* we are passing it to `drawOne` then again pass the resulting new source to `drawOne`.
This is withing a block started with `let source =` so the final result stored under the name `source` is the result of the second call to `drawOne`.
It is shown when we use this same source twice to call `drawOne` (and ignore the result), the program prints the same ticket number (3) twice.

Here we see a main advantage of functional programming: we can easily capture the state of our program and reproduce some step multiple times if needed.
Also, using pure functions whenever possible makes us pass along any changing state explicitly.
In a complex program with pure functions, it is much easier to see in what order we can use our functions and pass the result to the next one compared to
an imperative/object-oriented approach where functions have side effects and calling them in wrong order can lead to bugs.
The functional paradigm helps in multiple ways to achieve correctness.

## Summary

We have seen that imperative, object-oriented and functional programming are all possible to do in F#.
There are distinct advantages and disadvantages to all, but F# is designed around making the most of functional programming, so structuring larger programs in this way is highly recommended.