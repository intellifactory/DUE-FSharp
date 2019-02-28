# Working with lists

A `list` in F# is a type that can hold zero or more values of the same `type`.
For example:

```fsharp
let numbers = [ 5; 2; 7 ]
let OneToFive = [ 1 .. 5 ]
```

The `1 .. 5` is called a *range expression* and just produces the same list as `[ 1; 2; 3; 4; 5 ]`.
These values are stored in memory as a singly-linked immutable list, here is how we can visualize it:

```
( 1 | -)--> ( 2 | -)--> ( 3 | -)--> ( 4 | -)--> ( 5 | -)--> ()
```

Each chain in the link represents a small object that holds a single value and a *reference* to the next item.
Both parts of the chain are immutable, so we can't change values inside existing lists of modify their ordering.
This guarantees that once we have a list value, until we keep it, its contents remain the same.

Note that the type of these values are `int list`.
`list` is a generic type so it can be parametrized with another type to mark what type of elements it is containing.
This type can also be written as `list<int>`, but it is possible in F# to put the type parameter first
if there are only one for a generic type (like `list`).

## Adding a new item

Because of this chaining, we cannot add a new item anywhere except at the first *head* position of the list.
This can be done with the `::` operator like this:

`let moreNumbers = 1 :: numbers`

Now, `moreNumbers` will hold the values `[ 1; 5; 2; 7 ]`.
Note that the value of `numbers` is unchanged, it is still `[ 5; 2; 7 ]`.
This is because `numbers` is actually a reference to the chain item holding the `5` value.
Going through a list means that we take the current value of a chain item, then go to the next chain item,
take its value and so on, until the last real chain item just links to an empty list end without a value.

## Mapping lists

There is a module named `List` provided by the standard F# library (`FSharp.Core`) that contains a
number of helper functions to work with lists.

```fsharp
let square x = x * x
OneToFive |> List.map square // evaluates to [ 1; 4; 9; 16; 25 ]
```

From the example it should be clear what `List.map` does: it applies a function on all elements of a list
and composes a new list from the results.
Remember, lists are immutable, we have guarantee that the original `OneToFive` value is unchanged.

If we take a look at the tooltip of `List.map` it says: `val map: mapping:('T -> 'U) -> list:'T list -> 'U list`.
This is a more complex function signature than we have seen before but we can break it down.
First parameter to `List.map` is `mapping:('T -> 'U)`, so it expects a function that takes a value of some type 
and returns another of some (not necessarily the same) type.
We call `'T` and `'U` type parameters, and any function that has them in their signature is a *generic function*.
Being generic adds a great deal of flexibility to their usage, for example now we are using an `int -> int` mapper
function to transform an `int list` into another `int list` but we can also use it on lists of any other type.

Still, as before, F# type inference can figure out all of the types involved by itself, but if we want,
we can specify the type parameters ourselves:

```fsharp
OneToFive |> List.map<int, int> square // works the same
```

The parameter to `List.map` is a `'T list`.
So we could write `List.map square OneToFive` and it gives us an `'U list`, which is now an `int list`
because `'U` was already set to `int` by using the `square` function as the mapping parameter.

Many standard F# functions are set up in a way, that they are taking the value that they are transforming
as the last parameter, so using the pipe operator provides a nicely readable way of applying it.

## Anonymous functions

In the sample above, we defined a `square` function, just to pass it as a mapping parameter to `List.map`.
Often our code could be cleaner if we just have expressions in place instead of defining them with a `let`
on its own line.
Now comes the most fun part of F#: we can define functions in place with the `fun` keyword.

```fsharp
OneToFive |> List.map (fun x -> x * x)
```

As a simple rule, if you have a function defined with a `let`, if you replace the keyword with `fun`,
remove the name of the function, and replace the `=` with `->`, then you have an *anonymous function*.
It is also called a *lambda* from their original mathematical notation.

Let's see a sample using multiple lambdas, `List` functions and piping:

```fsharp
OneToFive
|> List.map (fun x -> x * x)
|> List.filter (fun x -> x > 5)
|> List.sum // evaluates to 50
```

Now the advantage of pipes are really apparent, we have a piece of code that is nice to read from top to bottom:

* we have a list of numbers from one to five
* we make a new list with their squares
* then we make a new list that keeps only the values that are bigger then 5 and drops the rest
* then we sum all the numbers together 

The other big advantage of this structure is that we can select part of the code quickly to evaluate in F# interactive.
For example the first three lines evaluate to `[9; 16; 25]` so we can check where are sum came from.

let square x = x * x // defining a function
// note that square has type inferred to be `int -> int`
// we now have a named function that we can use in place of the anonymous function (lambda)

## Simplifying lambdas

Using our `add` function from the last lesson (an alias of `+` operator):

```fsharp
OneToFive |> List.map (fun x -> add 10 x) // evaluates to [11; 12; 13; 14; 15]
```

We have seen before that `add 10 x` can be also written as `(add 10) x`, so we could have
`fun x -> add 10 x` written as `fun x -> (add 10) x`.

We are defining an anonymous function here that is doing nothing else than passing its parameter to an inner function.
So actually our lambda does the exact same thing as the inner function and we can simplify our code.

```fsharp
OneToFive |> List.map (add 10) // same as above
```

Again, from the original mathematical naming, this simplification is called an `eta-reduction` and
the resulting expression is said to be in *point-free style*.
(What we have as `->` in F# code, is a point in the mathematical notation.)

## Folding

Another common operation with lists is going through the elements, and using each element in some ongoing computation.
Now we would like to get the product of our numbers (multiply them all together).
We have already seen that there is a build-in function for summing all the elements, but there is no such one for product.
This is where `List.fold` helps:

```fsharp
OneToFive |> List.fold (fun state item -> state * item) 1 // evaluates to 120
```

`List.fold` takes a `folder:'State -> 'T -> 'State` function as its first parameter.
The first type parameter is named `'State` to tell us that this is the type of our state value: something that contains
the current value of our computation as we go through elements of the list one by one.
The second parameter of `List.fold` is a `state:'State`, the initial state we are starting from.
We use `1` here, because we will multiply numbers together and `1` is the identity element of multiplication.

What `List.fold` does is to spare us from writing a loop used usually in imperative programming.
It handles a changing value internally, each of our results returned from our lambda serves as the next `state` input,
but we can have this without using any mutable variables.

We finish with some simplification: the operator `*` can be used like a standard two-parameter function by
using parentheses around it:

```fsharp
OneToFive |> List.fold (fun state item -> (*) state item) 1
```

And now we can use eta-reduction on both of our lambda parameters:

```fsharp
OneToFive |> List.fold (*) 1
```

What we have here is pretty readable on first sight: we are folding through the given list using multiplication,
starting from 1.

## Summary
F# provides the `list` type as a way of dealing with a list of values in the functional way:
processing the items by passing named or anonymous functions to `List` helper functions
instead of having to loop through elements ourselves.