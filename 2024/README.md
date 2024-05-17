# Course: Introduction to functional programming in F\#

## University of Dunaújváros, Hungary

### Instructor

* Adam Granicz (adam@intellifactory.com, [GitHub:granicz](https://github.com/granicz), [Twitter:@granicz](https://twitter.com/granicz)), [IntelliFactory](https://intellifactory.com)

### Course and study material

* [F# language reference](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/)
* [Tour of F#](https://docs.microsoft.com/en-us/dotnet/fsharp/tour)
* Syme, D., Granicz. A., Cisternino A. (2017). *[Expert F# 4.0](https://www.apress.com/gp/book/9781484207413)*. 4th Edition. Apress. ISBN 978-1-4842-0741-3.
* Setting up your F# environment
  * [Installation](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/install-fsharp)
    * [Visual Studio Code](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode)
    * [Visual Studio](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-visual-studio)
    * [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
    * [TortoiseGit](https://tortoisegit.org/)
  * [F# with .NET CLI](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line)
* Formats and tools
  * [Mastering Markdown](https://guides.github.com/features/mastering-markdown/)
  * [Version control](https://en.wikipedia.org/wiki/Version_control) in general
    * [git learning resources](https://try.github.io/)
    * [git handbook](https://guides.github.com/introduction/git-handbook/)
* Web programming
  * [Web Programming with F\#](https://fsharp.org/guides/web/)
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

* [Assignment #1](assignment-01.md) - (40 points, due date: **Mar 29, 2024**).
  * Numbers, sequences/lists, mapping/filtering/folding, discriminated unions, functions/recursion
* [Assignment #2](assignment-02.md) - (30 points, due date: **May 17, 2024**).
  * Basic concepts for building web applications with WebSharper
* Assignment #3 - (30 points) - TBD

### Project work

During the course of the semester, you will work on and complete two larger projects.

1. Mid-term project (50 points, due date: **Apr 26, 2024**). You should aim for 200+ LOC, not counting boiler-plate and templates/configuration.

2. Personal project (100 points, due date: **last Sunday of the semester**) - this is a project you can pick for youself, and it is meant to help you explore F# more fully at your own pace and according to your own interest.

> #### Guidelines for projects
> Projects can be native, mobile, or web applications. For both the mid-term and end-of-semester projects, you should:
> * Use a public repository (hosted on GitHub or any other host), and send its URL via email.
> * Have a `README.md` in the root of your repository describing your project, its motivation, and how to build/run it.
>
> The README should contain 1) screenshot(s) of your application and 2) a try-live link (for web and mobile apps).
>
> For the try-live link, if your app is client-only, use the repository's `gh-pages` to host it, and add a build action that deploys each commit to it. For an example of such build action, see [IntelliLogo's `ghpages.yml`](https://github.com/granicz/IntelliLogo/blob/master/.github/workflows/ghpages.yml), and adapt it to your needs. If your app needs a server-side (for data access, etc.), you should set up auto-deployment to a suitable free host (Azure websites, etc.).
>
> If each project was awarded a grade on its own, it would be as follows:
>
> * Grade `1` (fail). The project fails to compile, has no or incomplete README, doesn't have a try-live link, or has been fully or largely copied from elsewhere.
> * Grade `2`. The project idea is unoriginal (it adds little value over an existing project) or has insufficient content.
> * Grade `3`. The project idea is unoriginal but the implementation makes significant additions, or it centers on a new idea with missing functionality or incomplete features.
> * Grade `4`. The project implements an original idea, and presents a well-rounded, standalone contribution that has good practical value.
> * Grade `5` (outstanding). The project solves a real-life problem for a larger audience, and it does so with a polished user interface (UI) and user experience (UX).
>
>#### Setting up auto-deployment of your projects
>
> See [this page](github-pages.md) for instructions.
>
### Course sandbox

You can find the code walkthroughs in the course sandbox repositories:

* [DUE-FSharp-Sandbox-2024](https://github.com/intellifactory/DUE-FSharp-Sandbox-2024) - a client-server application
* [DUE-FSharp-SPASandbox-2024](https://github.com/intellifactory/DUE-FSharp-SPASandbox-2024) - a single-page application (SPA)

> If you encounter NuGet errors about missing `WebSharper.*` packages, make sure you have the WebSharper developer NuGet feed configured on your system. [See instructions.](https://docs.websharper.com/basics/nuget/#configuring-the-websharper-developer-feed)

### Course schedule

<details>
  <summary>Mar 1, 2024 (online)</summary>
  
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
</details>

<details>
  <summary>Mar 8, 2024 (online)</summary>
  
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
</details>

<details>
  <summary>Mar 15, 2024 - National holiday, no class</summary>
</details>

<details>
  <summary>Mar 22, 2024 (online)</summary>

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
</details>

<details>
  <summary>Mar 29, 2024 - National holiday, no class</summary>
</details>

<details>
  <summary>Apr 5, 2024 (online)</summary>
  
  >Be sure to follow along the course Sandbox repository (see above)

  * [Asynchronous computations](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/async-expressions)
  * Installing [WebSharper project templates](https://docs.websharper.com/basics/templates/)
  * Sitelets - [doc](https://developers.websharper.com/docs/v4.x/fs/sitelets)
    * Routing via endpoint type annotations, endpoint modifiers (`EndPoint`, `Json`, `FormData`)
    * Returning various content types (Text, Json, HTML, error codes, custom responses)
    * Implementing microservices (POST/GET)
  * Client-side programming with WebSharper.UI - [doc](https://developers.websharper.com/docs/v4.x/fs/ui)
    * Reactive variables and views
    * Templating
    * Calling RPCs
  * Example application: [IntelliLogo](https://github.com/granicz/IntelliLogo)
</details>

<details>
  <summary>Apr 12, 2024 (online)</summary>

  * WebSharper.UI templating - see the Sandbox
    * Simple web form to collect user data
    * Client->Server calls (RPC)
</details>

<details>
  <summary>Apr 19, 2024 (online)</summary>

  * WebSharper.UI templating
    * Understanding the difference between `FromDocument` and `Inline` for the client-side templating behavior
  * [WebSharper.Forms](https://github.com/dotnet-websharper/forms) - see the Sandbox
  * [WebSharper.Charting](https://github.com/dotnet-websharper/forms) - see the Sandbox
  * [Active patterns](https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns)
    * Single-case - used for value conversion
    * Multi-case - used for subdiving into a closed set of "shapes"
    * Partial - used to deal with only a partial set of input values -> must return an option 
    * Parameterized partial - using an argument to drive how the returned value is computed 
</details>

<details>
  <summary>Apr 26, 2024 (online)</summary>

  * Adding popups in your WebSharper applications
    * See relevant bits around `LoseChangesReason` in [this commit](https://github.com/granicz/IntelliLogo/commit/7ea5f371f25af8f052a5539e8bf43b4fbb020b40#diff-3ad230a2befab3e4a4dd12f56a1de08f3d4db0345f4c8c1bcb0a81d296d2c534R176)
  * Quick overview of libraries available for data access
  * Hands-on: Plotting functions - see [commit](https://github.com/intellifactory/DUE-FSharp-Sandbox-2024/commit/a98948555b1b7ee638afe81a25f2f61784c4ef1d)
    * WebSharper.Forms to collect data
    * Parsing math formulas with active patterns
    * Evaluating an AST to compute values of formulas
    * Drawing lines on HTML5 Canvas
</details>

<details>
  <summary>May 3, 2024 (online)</summary>

  * Working with the WebSharper SPA template (`websharper-spa`)
    * Converting sitelets to SPAs - see [SPA Sandbox](https://github.com/intellifactory/DUE-FSharp-SPASandbox-2024) for structuring SPAs
    * Switching "pages" in an SPA using client-side routing
    * Setting up auto-deploy with GitHub Actions - see [sample script](https://github.com/intellifactory/DUE-FSharp-SPASandbox-2024/blob/master/.github/workflows/ghpages.yml)
</details>

<details open>
  <summary>May 10, 2024 (online)</summary>

  * Looking at several student projects and issues
</details>

May 17, 2024 (online) - TBD

May 24, 2024 (online) - TBD
