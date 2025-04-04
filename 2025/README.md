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

* Ways to earn a grade:
  * Mid-term project - 50 points
  * End-of-term project - 100 points
  * Extra credit - max 39 points
* Grade 5 - 135+ points
* Grade 4 - 120+ points
* Grade 3 - 105+ points
* Grade 2 - 90+ points
* Fail - below 90 points


### Projects

During the course of the semester, you will work on two projects of your choosing, helping you explore F# according to your own interests:

1. Project Alpha (50 points, due date: **Apr 25, 2024**). You should aim for 300+ LOC (F#), not counting boiler-plate/comments, and templates/configuration.

2. [Project Omega](project-omega.md) (100 points, due date: **last Sunday of the semester**).


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
> TBD
>


### Course sandbox

You can find the code walkthroughs in the course sandbox repositories:

* [DUE-FSharp-SPASandbox-2025](https://github.com/intellifactory/DUE-FSharp-SPASandbox-2025) - a single-page application (SPA)

> If you encounter NuGet errors about missing `WebSharper.*` packages, make sure you have the WebSharper developer NuGet feed configured on your system. [See instructions.](https://docs.websharper.com/basics/nuget/#configuring-the-websharper-developer-feed)


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

  * Embedding TryWebSharper snippets in your own apps
  * WebSharper.UI templating
    * Understanding the difference between `FromDocument` and `Inline` for the client-side templating behavior
  * [WebSharper.Forms](https://github.com/dotnet-websharper/forms) - reactive web forms 
  * [WebSharper.Charting](https://github.com/dotnet-websharper/forms) - charting and visualization
</details>

<details>
  <summary>Apr 4, 2025</summary>

  * client->server calls (RPC)
  * TBD
</details>
