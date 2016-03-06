// module declaration
// use modules to hold related functions
module List =
    let filterPositive l = l |> List.filter (fun x -> x > 0)

// modules can have the same name as another module, and functions from both are available
// here we "extend" the List module this way
[-1; 1] |> List.filterPositive

// type alias
type L<'a> = list<'a>

// using a type alias
let x : int L = [2]

// class definition
type Counter() =
    inherit obj() // this is unnecessary, done by default
    // class-level value
    let mutable n = 0

    member this.Next() =
        n <- n + 1
        n

    // overriding a System.Object method
    override this.ToString() =
        "counter:" + string n

let counter1 = new Counter() // new is optional
counter1.Next()

counter1.ToString()

// exercise: do this with functional style without classes

// solution:
let createCounter() =
    // hidden value, captured by the returned function
    let mutable n = 0

    // a function can be seen as a "small object", 
    // doing one thing: it can be called
    fun() ->
        n <- n + 1
        n

// first call creates the counter function
let counter2 = createCounter()
// using the counter function
counter2()
counter2()
counter2()

// a class with 2 methods
type CounterWithReset() =
    let mutable n = 0

    member this.Next() =
        n <- n + 1
        n

    member this.Reset() =
        n <- 0

// Exercise: write this functionally. Return 2 functions

// solution
let createCounterWithReset() =
    let mutable n = 0

    fun() ->
        n <- n + 1
        n
    ,
    fun() ->
        n <- 0

let counter3, reset3 = createCounterWithReset()
counter3()
reset3()
counter3()

// this is what F# compiler does for us:
let createCounterWithRef() =
    // captured variables are translated to reference cells
    let n = ref 0

    fun() ->
        n := !n + 1 // ! gets, := sets the value of a ref cell
        !n

// Algebraic expression with numbers, variables named as a single character 
// and the four basic arithmetic operations
type Expr =
    | Num of float
    | Var of char
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

// a small expression represented with our Expr type
Add(Num 1., Num 1.)

// we can define custom operators to make writing Expr values easier
let (^+) a b = Add (a, b) // define an infix operator
let (^*) a b = Mul (a, b) 
Num 1. ^+ Num 1.

let (!^) a = Num a // define a prefix operator, prefix operators must start with ~ or !
!^1. ^+ !^1.

// a printer function
let rec printExpr expr =
    match expr with
    | Num n -> string n 
    | Var x -> string x 
    | Add (a, b) -> sprintf "(%s + %s)" (printExpr a) (printExpr b)
    | Sub (a, b) -> sprintf "(%s - %s)" (printExpr a) (printExpr b)
    | Mul (a, b) -> sprintf "(%s * %s)" (printExpr a) (printExpr b)
    | Div (a, b) -> sprintf "(%s / %s)" (printExpr a) (printExpr b)

// test it
printExpr (!^1. ^+ !^1.)

// Exercise: write an evaluator function, not handling variables

// Solution:
let rec eval expr =
    match expr with
    | Num n -> n
    | Var x -> failwith "eval does not support variables" 
    | Add (a, b) -> eval a + eval b
    | Sub (a, b) -> eval a - eval b
    | Mul (a, b) -> eval a * eval b
    | Div (a, b) -> eval a / eval b

// test it
eval (!^1. ^+ !^1.)

// Exercise: return a new expression where every occurrence of `var`
// is replaced to `Num value`

// Solution:
let rec substitute (var: char) (value: float) expr =
    // we need to substitute recursively, always with the same var and value
    let sub = substitute var value
    match expr with
    | Num _ -> expr
    | Var x -> if x = var then Num value else expr 
    | Add (a, b) -> Add (sub a, sub b) 
    | Sub (a, b) -> Sub (sub a, sub b)
    | Mul (a, b) -> Mul (sub a, sub b)
    | Div (a, b) -> Div (sub a, sub b)

// test it
(!^1. ^+ Var 'x') |> substitute 'x' 2. |> eval

// Exercise: differentiate on variable `var`
// Homework: finish this
let rec diff (var: char) expr =
    let d = diff var
    match expr with
    | Num _ -> Num 0.
    | Var x -> if x = var then Num 1. else Num 0.
    | Add (a, b) -> Add (d a, d b)
    | Sub ...
    | Mul (a, b) -> (d a ^* b) ^+ (a ^* d b)

// Extra exercise: write some simplification rules
// add recursivity
let rec simplify expr =
    match expr with
    | Add (Num a, Num b) -> Num (a + b)
    | Add (a, Num 0.) | Add (Num 0., a) -> a 
    // ... you can come up with more simplification rules
    // test it if you have something
    | _ -> expr