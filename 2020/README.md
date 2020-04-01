# Course: Functional Web Development in F#

## University of Dunaújváros, Hungary

### Instructors

* Adam Granicz (@granicz), [IntelliFactory](https://intellifactory.com)
* Andras Janko (@andrasjanko), [IntelliFactory](https://intellifactory.com)

### Course and study material

* Syme, D., Granicz. A., Cisternino A. (2017). *[Expert F# 4.0](https://www.apress.com/gp/book/9781484207413)*. 4th Edition. Apress. ISBN 978-1-4842-0741-3.
* [F# language reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
* [Tour of F#](https://docs.microsoft.com/en-us/dotnet/fsharp/tour)
* [The WebSharper documentation](http://developers.websharper.com/)

* Setting up your F# environment
    * Installation - https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/install-fsharp

    * Visual Studio Code - https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode

    * Visual Studio - https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-visual-studio

    * F# with .NET CLI - https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line

* [Version control](https://en.wikipedia.org/wiki/Version_control) in general
    * [git learning resources](https://try.github.io/)

    * [git handbook](https://guides.github.com/introduction/git-handbook/)

### Evaluation

 * Ways to earn a grade:

   * Home work - 100 points<br />
   * Project work - 150 points<br />
   * Extra credit - TBA

 * 5 - 225+ points
 * 4 - 200+ points
 * 3 - 175+ points
 * 2 - 150+ points
 * Fail - below 150 points

### Assignments

* [Assignment #1](assignment-01.md) - due date: Apr 7, 2020.
  * Numbers, sequences/lists, mapping/filtering/folding, records, discriminated unions, functions/recursion + extra credit
  
### Course schedule

* Feb 21, 2020 - Instructor: Adam Granicz

    * Chapter 2, Chapter 3 - Functional programming
        * Your first F# program - analyzing a string for duplicate words
        * Using F# Interactive (FSI/fsi)
        * Bindings - using `let`, left-hand-side (LHS) is a pattern
        * **Values and immutability**
        * **Types and signatures**
        * **Type inference and type annotations**
        * **Functions calls**
        * Scope
        * Dot-notation
        * Tuples
        * Values and objects
        * Opening namespaces and modules - `open`
        * Values, methods, properties

    * MSDN - F# reference
        * Basic types - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types
        
        * **Unit type** -https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type

        * **Tuples** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples

        * **Records** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records

        * **Options** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/options

        * **Values, immutability** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/values/
        
        * Type inference and automatic generalization - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/type-inference
        

* Feb 28, 2020 - Instructor: Adam Granicz
    * Chapter 3 - Functional programming
        * Basic types and their literals (`bool`, `int`, `float`, `double`, `string`, `unit`)
        * Arithmetic operators, using type annotations to drive overload selection
        * Converting values
        * Basic comparison (`=`, `<>`, `<`, `<=`, `>`, `>=`, `min`, `max`)
        * Strings and their characters
        * **Conditionals**
        * **Recursive functions**
        * **Lists**, **Arrays**
        * **Options**
        * **Pattern matching**
        * **Function values, function composition, first-class functions**

    * MSDN - F# reference
        * **Discriminated unions** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions

        * **Active patterns** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns

        * **Namespaces, nested namespaces** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/namespaces

        * **Modules, nested modules** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/modules

        * **Functions, anonymous functions, currying, higher-order functions**
            * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/, 
            * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/lambda-expressions-the-fun-keyword
            * Recurive, and mutually recursive functions - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword

* Mar 6, 2020 - Instructor: Andras Janko
* Mar 13, 2020 - Instructor: Adam Granicz
    * Chapter 4 - Imperative programming
        * **Mutable records**
        * **Mutable let-bindings**
        * **Reference cells**
        * **Arrays, slicing**
        * **.NET collections - lazy vs eager**
        * **Sequences**

    * Chapter 5
        * Exploring some simple type definitions
        * **Understanding generics**
        * Making things generic
        * Reference and value types

    * MSDN - F# reference
        * **Copy and update record expressions** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/copy-and-update-record-expressions

        * **Arrays** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/arrays

        * **Exception handling** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/exception-handling/

        * **F# collection types** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/fsharp-collection-types

        * **Sequences** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences

        * **Slices** - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/slices

* Mar 20, 2020 - Instructor: Adam Granicz

    * WebSharper basics, project templates, getting started
        * Installation - https://websharper.com/downloads

    * Sitelets, requests, content - http://developers.websharper.com/docs/v4.x/fs/sitelets

* Mar 27, 2020 - Instructor: Adam Granicz
    * Chapter 2
        * Documenting code - `(* ... *)` and `///` XMLDoc comments
        * Using OO libraries
        * Fetching web pages
        * Getting and using Nuget packages
        * Accessing external data with `FSharp.Data`
        * Starting a web server and serving data

    * Chapter 3
        * Recursive functions - examples: `fib`, `fact`, etc.

    * MSDN - F# reference
        * Using XML documentation - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/xml-documentation

    * Visual F# Team Blog
        * Tail calls in F# - https://devblogs.microsoft.com/fsharpteam/tail-calls-in-f/
        
        * Understanding tail recursion - https://docs.microsoft.com/en-us/archive/blogs/chrsmith/understanding-tail-recursion

* Apr 3, 2020 - Instructor: Adam Granicz
* Apr 10, 2020 - Instructor: Adam Granicz
* Apr 17, 2020 - Instructor: Adam Granicz
* Apr 24, 2020 - Instructor: Adam Granicz
* May 1, 2020 - No class
* May 8, 2020 - Instructor: Adam Granicz
