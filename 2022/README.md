# Course: Introduction to functional programming in F\#

## University of Dunaújváros, Hungary

### Instructor

* Adam Granicz ([GitHub:granicz](https://github.com/granicz), [Twitter:@granicz](https://twitter.com/granicz)), [IntelliFactory](https://intellifactory.com)

### Course and study material

* [F# language reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
* [Tour of F#](https://docs.microsoft.com/en-us/dotnet/fsharp/tour)
* Syme, D., Granicz. A., Cisternino A. (2017). *[Expert F# 4.0](https://www.apress.com/gp/book/9781484207413)*. 4th Edition. Apress. ISBN 978-1-4842-0741-3.
* Setting up your F# environment
  * [Installation](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/install-fsharp)
    * [Visual Studio Code](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode)
    * [Visual Studio](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-visual-studio)
  * [F# with .NET CLI](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line)
* Formats and tools
  * [Mastering Markdown](https://guides.github.com/features/mastering-markdown/)
  * [Version control](https://en.wikipedia.org/wiki/Version_control) in general
    * [git learning resources](https://try.github.io/)
    * [git handbook](https://guides.github.com/introduction/git-handbook/)
* Web programming
  * [The WebSharper documentation](http://developers.websharper.com/)

### Evaluation

* Ways to earn a grade:
  * Homework (3x) - 100 points
  * Project work (1+1) - 150 points
  * Extra credit
* Grade 5 - 225+ points
* Grade 4 - 200+ points
* Grade 3 - 175+ points
* Grade 2 - 150+ points
* Fail - below 150 points

### Assignments

* [Assignment #1](assignment-01.md) - (30 points, due date: **Apr 10, 2022**).
  * Numbers, sequences/lists, mapping/filtering/folding, records, discriminated unions, functions/recursion
* Assignment #2 - (30 points) - TBD
* Assignment #3 - (40 points) - TBD

### Project work

During the course of the semester, you will work on and complete two larger projects.

1. [Mid-term project](project-01.md) (50 points, due date: **Apr 24, 2022**). A web project meant to help you dig deeper into web programming with F#. You can implement more than one project to earn extra credit.

2. Personal project (100 points, due date: **last Sunday of the semester**) - this is a project you can pick for youself, and it is meant to help you explore F# more fully at your own pace and according to your own interest.

### Course schedule

* Feb 18, 2022 (in-class)

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
      * [Basic types](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types)
      * [**Unit type**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type)
      * [**Tuples**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples)
      * [**Records**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records)
      * [**Options**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/options)
      * [**Values, immutability**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/values/)
      * [Type inference and automatic generalization](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/type-inference)

* Feb 25, 2022 (in-class)
  * Expert F# 4 - Chapter 3 - Functional programming
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
      * [**Discriminated unions**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions)
      * [**Active patterns**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns)
      * [**Namespaces, nested namespaces**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/namespaces)
      * [**Modules, nested modules**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/modules)
      * **Functions, anonymous functions, currying, higher-order functions**
        * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/, 
        * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/lambda-expressions-the-fun-keyword
        * Recurive, and mutually recursive functions - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword

* Mar 4, 2022 - **cancelled**
* Mar 11, 2022 (online) - [video](https://www.facebook.com/granicz.adam/videos/648381906409172)
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
      * [**Copy and update record expressions**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/copy-and-update-record-expressions)
      * [**Arrays**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/arrays)
      * [**Exception handling**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/exception-handling/)
      * [**F# collection types**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/fsharp-collection-types)
      * [**Sequences**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences)
      * [**Slices**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/slices)

* Mar 18, 2022 (online) - [video](https://www.facebook.com/granicz.adam/videos/5257780810933586)
  * WebSharper basics, project templates, getting started
    * [Installation](https://websharper.com/downloads)
    * [Sitelets, requests, content](https://developers.websharper.com/docs/v4.x/fs/sitelets)

* Mar 25, 2022 - [video](https://www.facebook.com/granicz.adam/videos/3243498595872041)

* Apr 1, 2022 (online) - [video](https://www.facebook.com/granicz.adam/videos/1120076285504497)
* Apr 8, 2020
* Apr 15, 2020
* Apr 22, 2020
* Apr 29, 2020
* May 6, 2020
