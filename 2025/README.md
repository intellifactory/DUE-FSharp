# Course: Introduction to functional programming in F\#

## University of Dunaújváros, Hungary

### Instructor

* Adam Granicz (adam@intellifactory.com, [GitHub:granicz](https://github.com/granicz), [Twitter:@granicz](https://twitter.com/granicz)), [IntelliFactory](https://intellifactory.com)

### Course and study material

* Syme, D., Granicz. A., Cisternino A. (2017). *[Expert F# 4.0](https://www.apress.com/gp/book/9781484207413)*. 4th Edition. Apress. ISBN 978-1-4842-0741-3.
* [F# language reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
* [Installing F#](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/install-fsharp) - [vscode](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode), [Visual Studio](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-visual-studio)
* [Tour of F#](https://docs.microsoft.com/en-us/dotnet/fsharp/tour)
* [F# with .NET CLI](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line)
* [Web programming with F\#](https://fsharp.org/guides/web/) - [WebSharper](https://websharper.com/)
* [markdown](https://guides.github.com/features/mastering-markdown/)
* [Source/version control](https://en.wikipedia.org/wiki/Version_control) - [git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git), [resources](https://try.github.io/), [handbook](https://guides.github.com/introduction/git-handbook/), [TortoiseGit](https://tortoisegit.org/)

### Evaluation

TDB

### Course sandbox

TBD

### Course schedule

> ### How to join online
> [Use this link](https://meet.google.com/dhq-jkrn-jyd), or if that stream is full, use [this link](https://meet.google.com/cef-izpu-jwa). (These links remain the same during the semester.)

<details>
  <summary>Feb 21, 2025</summary>
  
  * Functional programming
    * Using F# Interactive (FSI/fsi)
    * Values and immutability
    * Bindings
    * Scoping
    * Basic types (`bool`, `int`, `float`, `double`, `string`, `char`, `unit`)
    * Tuples, Lists, Arrays, Options
    * Discriminated unions
    * Type signatures
    * Type inference and type annotations
    * Function definitions, calls, composition
    * First-class functions, higher-order functions
    * Recursive functions
    * Opening namespaces and modules - `open`
    * Conditionals
    * Pattern matching
  
    * Resources:
      * [Basic types](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/basic-types)
      * [**Unit type**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type)
      * [**Tuples**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples)
      * [**Records**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records)
      * [**Options**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/options)
      * [**Values, immutability**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/values/)
      * [Type inference and automatic generalization](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/type-inference)
      * [**Discriminated unions**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions)
      * [**Active patterns**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns)
      * [**Namespaces, nested namespaces**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/namespaces)
      * [**Modules, nested modules**](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/modules)
      * **Functions, anonymous functions, currying, higher-order functions**
        * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/, 
        * https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/lambda-expressions-the-fun-keyword
        * Recurive, and mutually recursive functions - https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword
  
</details>

<details>
  <summary>Feb 28, 2025</summary>

  * Recap
  * Functional Programming
    * Piping values (`|>`)
    * Composing functions (`>>`, `<<`)
    * Hands-on collections and their operations - `List`, `Array`, `Set`, `Map`, `Seq`
      * iterating, mapping, folding
      * other core operations
    * Hands-on patterns and pattern matching
    * Hands-on active patterns - conversion, partition, recognition/filter
</details>

<details>
  <summary>Mar 7, 2025</summary>

  * Installing [WebSharper project templates](https://docs.websharper.com/basics/templates/)
  * Sitelets - [doc](https://developers.websharper.com/docs/v4.x/fs/sitelets)
    * Routing via endpoint type annotations, endpoint modifiers (`EndPoint`, `Json`, `FormData`)
    * Returning various content types (Text, Json, HTML, error codes, custom responses)
    * Implementing microservices (POST/GET)

</details>

<details>
  <summary>Mar 14, 2025</summary>

  * [Active patterns](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns)
    * Single-case - used for value conversion
    * Multi-case - used for subdiving into a closed set of "shapes"
    * Partial - used to deal with only a partial set of input values -> must return an option 
    * Parameterized partial - using an argument to drive how the returned value is computed
  * Client-side programming with WebSharper.UI - [doc](https://developers.websharper.com/docs/v4.x/fs/ui)
    * Reactive variables and views

</details>

<details>
  <summary>Mar 21, 2025</summary>

  * [Asynchronous computations](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/async-expressions)
  * WebSharper.UI templating - replacing in-code HTML combinators with templates
  * Simple web form to collect user data

</details>

<details>
  <summary>Mar 28, 2025</summary>

  * client->server calls (RPC)
  * WebSharper.UI templating
    * Understanding the difference between `FromDocument` and `Inline` for the client-side templating behavior
  * [WebSharper.Forms](https://github.com/dotnet-websharper/forms) - see the Sandbox
  * [WebSharper.Charting](https://github.com/dotnet-websharper/forms) - see the Sandbox
</details>
