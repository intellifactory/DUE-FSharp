# Project #1 - An F# Web Application, due date: Apr 26 EOD.

What to turn in: the URL of a public GitHub/GitLab/Bitbucket repository that contains:
 
 * your source files - in the `src` folder. You should add comments for each code block (types, functions, etc.) 
 * a `README.md` that describes your project, with screenshots, and provides step-by-step instructions on building it.
 
## Project #1 *(25 points)* - A web calculator

Develop a single-page application (SPA) that implements a simple web calculator. It should support:

* Single digits (`0`-`9`)
* Addition (`+`)
* Subtraction (`-`)
* Multiplication (`*`)
* Division (`/`)
* All-Clear (`AC`) for clearing the register and all its state
* Clear (`C`) for clearing the last number entered
* Result (`=`) for displaying the result of an operation entered
* Negation (`+/-`) for negating the current number entered

Operations are registered/executed when entered, so to calculate `1+2*3`, one would enter it as `2*3+1`.

Below is a fuller example: `(1+3)*5=20`:

| Button pushed | Displayed |
| ------------- |:---------:|
| (`1`) | 1 |
| (`+`) | 1 |
| (`3`) | 3 |
| (`*`) | 4 |
| (`5`) | 5 |
| (`=`) | 20 |

Extra credit:

 * Division by zero should yield the error message `E`. *(+10 points)*
 * Implement `sin` and `cos`. *(+10 points)*
 * Implement `1/x`. *(+5 points)*
 * Elaborate UI design/layout. *(up to +10 points)*

## Project #2 (50 points) - A book database

Implement a book database as a WebSharper client-server application that allows users to:

 * Enter and store books by providing their title, author, and year published.
 * Search books by part of their title, part of their author name, or exact year published (using one query).
 * Display all their stored books.

Storage should be implemented as a server-side in-memory store (list, map, etc.).

Extra credit:

 * Switching storage to a server-side database (MS SQL). *(+15 points)*
 * Implementing user registration (username and password) and logging in/out. *(+15 points)*
 * Uploading a book cover image for each book and displaying thumbnails. *(+15 points)*
 * Displaying books with a pager. *(+5 points)*
 * Elaborate UI design. *(up to +10 points)*

## Project #3 (50 points) -

Implement a weight tracker application as a WebSharper client-server application that allows users to:

 * Enter and store their weight on a given day.
 * Display all stored measurements as a Day/(Loss or Gain)/Weight table.
 * Display a line chart for all measurements (X-axis: date, Y-axis: weight).

Storage should be implemented as a server-side in-memory store (list, map, etc.), and charting should be done with [WebSharper.Charting](https://github.com/dotnet-websharper/charting).

Extra credit:

 * Switching storage to a server-side database (MS SQL). *(+15 points)*
 * Implementing user registration (username and password) and logging in/out. *(+15 points)*
 * Binding and using another/custom JS charting library. *(up to +20 points, depending on the library and its binding)*, OR inlining calls to such library. *(+10 points)*
 * Elaborate UI design. *(up to +10 points)*
