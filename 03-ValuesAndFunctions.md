# Values and functions

## Values

One of the simplest lines we can write in F# is this:

```fsharp
let x = 1
```

We call this a *value binding*, giving a name to a value.
In the same block of code, we can write `x` and it will mean `1`.
For example:

```fsharp
let x = 1
x + x // evaluates to 2
```

If we mouse over `x`, we can see `val x: int`.
It means that `x` is a value of type `int` (integer number), this is automatically inferred by the language because `1` is an `int`.
Optionally the type can be specified explicitly, this does not change the meaning of our program, but makes the type clearly visible.

```fsharp
let x : int = 1
```

Examples of simple values and types:

```fsharp
let a : int = 1 // an integer on 32 bits (range -2,147,483,648 to 2,147,483,647)
let b : float = 1.0 // a floating point number on 54 bits
let c : uint32 = 1u // an unsigned integer on 32 bits (range)
let d : char = 'a' // a single character
let e : string = "hello" // a string - text with any number of characters
let f : bool = true // Boolean - true or false value
let g : unit = () // the type of having no value
```

For a full list of basic types, see the [documentation here](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types).

## Immutability and shadowing

What we can't do is to change the value of `x`.
In F#, a simple `let` binding is not a variable but a constant declaration.
This won't work:

```fsharp
let x = 1
x <- 2 // Error: x is not mutable
```

But we can have `let` bindings inside each other.

```fsharp
let y =
    let x = 1
    x + x
```

Here, while we are calculating the value of `y`, we are naming a value of `x` internally.
This `x` is not visible from the outside.
The *scope* of the `let` binding is just any code below it in the same block or nested block of code.

```fsharp
let y =
    let x = 1
    let x = x + 1
    x + x
```

Now, it seems as though the value of `x` is changed from 1 to 2.
But actually, the second `let x =` is just reusing the name `x`, *shadowing* the original value bound to it.
On the final line, `x` has value 2, because it is the closest value tied to the name `x`.

## Variables

To declare *variables*, having values that change over time, we need the extra keyword `mutable`:

```fsharp
let mutable x = 1
x <- 2 // No errors now
x + 1 // evaluates to 3
```

## Functions

Consider this line of code:

```fsharp
let addOne x = x + 1
```

If we mouse over `addOne`, we see a tooltip with `val addOne: x:int -> int`.
This tells us, that `addOne` is also a value, but has type `int -> int` which means it is a function
(we can ignore the parameter names like `x` function type).

That's right, functions are also a kind of value, this will come in very handy later.
The type of a function value is also called a `signature`, because it is a good descriptor of how it can be used:
what parameter can be passed to it and what it will return.
`int -> int` means this function takes a single `int` parameter and returns an `int`.

The `x` parameter is automatically inferred to be an `int` from how it is used: it is added to an `int` (`1`).
We can make the types explicit too if we want:

```fsharp
let addOne (x: int) -> int = x + 1
```

This is the simplest way we can use this function:

```fsharp
addOne 1 // evaluates to 2
```

## Curried functions

Let's take a look at a function that takes two parameters:

```fsharp
let add x y = x + 1
```
It will have a tooltip `val add: x:int -> y:int -> int`.

This is called a *curried* function (named after Haskell Curry, not the spice).
It can take two `int` values consecutively and will return an `int`. See:

```fsharp
add 1 2 // evaluates to 3
```

So if the type of `add` is `int -> int -> int`, what happens if we provide it only one argument?

```fsharp
let addOne = add 1
```

The tooltip says `val addOne: (int -> int)`, this shows that what we get is still a function that expects an `int` argument.
This makes sense if you look at `add 1 2` and add some parentheses: `(add 1) 2`.
This evaluates to 3, the same as before, and highlights that passing the value `1` to add results in a function
to which we are passing `2` to get the final result.
So with the `let` binding above, `addOne` is the same as `add 1`, so you can also write `addOne 2` to get `3`.

## Pipe operator

When writing expressions with multiple function calls, often we need parentheses: `add 1 (add 2 3)`.
F# does not require parentheses around arguments but when we want to evaluate a sub-expression to pass to an outside function, we need them.
This can get harder to read if there is a lot of them, so there is a nicer way:

```fsharp
1 |> add 2 |> add 3 // evaluates to 6
```

The `|>` sign is called a *pipe operator*, and what it does is it takes the left hand value and pass it as an argument to the right side function.
So `1 |> add 2 |> add 3` is equivalent to `add 3 (1 |> add 2)` which in turn is the same as `add 3 (add 2 1)`.
The piped version is just easier to read when looking at code: we are taking `1` then adding `2` then adding `3`.

F# actually defines the pipe operator like this:

```fsharp
let (|>) arg func = func arg
```

Operators are just special functions that can be used in infix position (between their two arguments) if they are not parenthesized.
So `1 + 1` could also be written as `(+) 1 1`, where `(+)` works the same as the `add` function we defined for ourselves.

## Summary
`let` is the most versatile keyword in F#, defining values with a name.
Functions are just a special kind of value, to which other values can be applied to produce results,
but otherwise they can be stored and passed around just like any other value.