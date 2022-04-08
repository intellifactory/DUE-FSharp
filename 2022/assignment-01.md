# Assignment #1 - due date: Apr 10, 2022

What to turn in: a single `.fsx` script that contains your solutions to all exercises. Be sure to add comments with the exercise numbers and any other details you think will help evaluating your code.

## Numbers, sequences/lists, mapping, filtering, folding *(15 points)*

1) Write a function that determines whether a number is even or odd. Example: `IsEven 12` -> `true`. *(1 point)*

2) Filter a list of numbers to find all even ones. Example: `FindEvenNumbers [1 .. 10]` -> `[2; 4; 6; 8; 10]`. *(1 point)*

3) Calculate the sum of the first 100 even numbers. *(1 point)*

4) Find the difference between the sum of the squares of all even and odd numbers between 1 and 100. *(2 points)*

5) Write a function that computes every other character in a string. Example: `"Hello"` -> `["H"; "l"; "o"]`. *(2 points)*

6) Use the Sieve of Erathostenes to find all prime numbers from 2 to a given number. Example: `FindAllPrimesUpTo 10` -> `[2; 3; 5; 7]` *(3 points)*

7) Compute the sum of the differences between consequtive prime numbers smaller than a given number. Example: `SumPrimeDifferencesUpTo 1000` -> some number. *(2 points)*

8) Write a function to find the nth prime number. Example: `FindNthPrime 50` -> `...` *(3 points)*

## Records *(10 points)*

Given the following type to represent people and a list of such people as (`people: Person list`):

```fsharp
type Person =
    {
        FirstName: string
        LastName: string
        Age: int
    }
```

9) Find the sum of all people's ages. *(1 point)*

10) Find all people above a given age. Example: `FindPeopleAbove 50 people` -> `[...]`. *(1 points)*

11) Compute the average age in a given list of people. Example: `FindAverageAge people` -> `45.3`. *(1 points)*

12) Compute a new people list with first and last names interchanged. *(2 points)*

13) Implement a "marriage name change" algorithm that takes a list of (old last name, new last name) pairs and returns a new people list. Example: `ApplyMarriage [("Smith", "Johnson"); ("Williams", "Jones")] people` -> `[...]`. *(3 points)*

14) Extend the original `Person` type with a gender and enhance `ApplyMarriage` to only rename females. *(2 points)*

## Discriminated unions *(10 points)*

Given the original `Person` record in the previous group of exercises, and the following `Employee` type to represent employee hierarchies (a team leader manages a team of people, a manager manages a list of teams) in an imaginary software company:

```fsharp
type Employee =
    | Developer of Person
    | TeamLeader of Person * Person list
    | Manager of Person * Person list list

let org : Employee list = ...
```
> You may need to use `Set` or `Map`. These allow you to represent collections with unique elements, and key-value stores, respectively.

15) Find the person who manages the largest single team. Example: `FindPersonWithLargestTeam org` -> `...`. *(2 points)*

16) Find those team leaders or managers that have people older than themselves in their teams. Signature: `FindLeadersWithOlderTeamMembers: Employee list -> Employee list`. *(3 points)*

17) Modify `FindLeadersWithOlderTeamMembers` to implement `FindLeadersWithTeamMembersOlderThan: int -> Employee list -> Employee list`. *(2 points)*

18) Find all people who are in multiple teams. Example: `FindPeopleInMultipleTeams org` -> `[...]`. *(3 points)*

## Functions, recursion *(5 points)*

19) Write a tail recursive `fib` function. *(2 points)*

20) Explain why we prefer tail recursive functions to non-tail recursive ones. *(3 points)*

## Extra credit *(7 points)*

Given the following type to represent basic arithmetic expressions with variables:

```fsharp
type Expr =
    | Var of string
    | Number of float
    | Sum of Expr * Expr
    | Diff of Expr * Expr
    | Mult of Expr * Expr
    | Div of Expr * Expr
```

* Implement an evaluator function. Signature: `Eval: env:Map<string, float> -> Expr -> float`. *(2 points)*

* Implement a function that substitutes the values of given variables into an expression. Signature: `Subst: (string, float) list -> Expr -> Expr`. *(2 points)*

* Implement a renderer for expressions that correctly account for operator precedence (so it uses parentheses where necessary). Signature: `PrettyPrint: Expr -> string`. *(3 points)*

## More extra credit *(8 points)*

* Implement queues and stacks as a new data type. Be sure to read up on defining classes with members.
