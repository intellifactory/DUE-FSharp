
let a = 1 + 1 // this value is immutable, it cannot be changed
a <- 3 // this is an error, does not compile

let mutable b = 1 + 1 // defining a variable needs the `mutable` keyword
b <- 3 // setting a new value to `b`

[ 1 .. 10 ] |> List.map (fun x -> x * x) // generating a  list of the first ten sqare numbers by mapping
List.map (fun x -> x * x) [ 1 .. 10 ] // this is equivalent: the pipe operator passes last argument around

// piping shows its strength when you chain multiple operations:
[ 1 .. 10 ]
|> List.map (fun x -> x * x)
|> List.filter (fun x -> x > 5)
|> List.sum
// it allows more readable code than using nested parentheses:
List.sum (
    List.filter (fun x -> x > 5) 
        (List.map (fun x -> x * x) [ 1 .. 10 ]))

let square x = x * x // defining a function
// note that square has type inferred to be `int -> int`
// we now have a named function that we can use in place of the anonymous function (lambda)
 
[ 1 .. 10 ] |> List.map square

let add x y = x + y // a function with two argument separated by space
// this is called a curried function - named after Haskell Curry, not the spice :)
// not that it has inferred type `int -> int -> int`

add 1 3 // this yields the value 3, as expected

add 1 // this is a function!
// remember, `add` was typed `int -> int -> int`, supplying it a single `int` creates an `int -> int`

// so insted of
[ 1 .. 10 ] |> List.map (fun x -> add 1 x)
// you can write 
[ 1 .. 10 ] |> List.map (add 1)
// this is called "eta-reduction" mathematically
// `(fun x -> f x)` is equivalent to just `f`
// in place of `f` you can have any expression that is free of `x` (not using `x`)

let t = 3, "hi" // this is a tuple, typed int * string
// a tuple is multiple values of any type stored/named together

let l = [ "hi"; "hello" ] // this is a list of two elements
// note that we use the semicolon instead of comma
// this is typed list<string>
// a list is a singly linked chain of elements of the same type
 
List.head l // the head of a list is its first element 

List.tail l // the tail of a list is a list of all but the first element 

let l1 = ["hello"]

"hi" :: l1 // `::` is the `cons` operator, adds a head to an existing list
"hey" :: l1 // this has the same tail as the previous one, just a different head
// lists are immutable (elements cannot be changed)
// so this makes sharing tails safe

// calculate a factorial of 5 by folding a list
[ 1 .. 5 ] |> List.fold (fun state item -> state * item) 1

// the operator `*` can be used as a function by using parentheses
[ 1 .. 5 ] |> List.fold (fun state item -> (*) state item) 1

// note that we can do eta-reduction here:
[ 1 .. 5 ] |> List.fold (*) 1
// this code is nice to read:
// make a list of 1 to 5, fold over it by multiplication, starting from 1
