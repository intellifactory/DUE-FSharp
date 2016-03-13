// we will download a book as a single string
open System
open System.Net

let dowloadTextAsync (url: string) =
    use client = new WebClient()
    client.AsyncDownloadString (Uri url)

let book = 
    dowloadTextAsync "http://www.gutenberg.org/cache/epub/1661/pg1661.txt"
    |> Async.RunSynchronously

// the text needs some cleaning, we are splitting it into
// paragraphs and replace line breaks with spaces
let allParagraphs =
    book.Split([| "\n\r" |], StringSplitOptions.None)
    |> Array.map (fun s -> s.Trim().Replace("\r\n", " "))

let startIndex =
    allParagraphs |> Array.findIndex (fun s -> s.StartsWith "THE ADVENTURES") 

let endIndex =
    allParagraphs |> Array.findIndex (fun s -> s.StartsWith "End of the Project") 

// now, this is only the book without the extra copyright infos
let paragraphs = allParagraphs.[startIndex .. endIndex - 1]

// Exercises:
// 1a how many paragraphs contain the name "Sherlock"
// 1b and "Watson"
// 1c and both?

// straightforward:
let sherlockOccurs1 =
    paragraphs
    |> Array.filter (fun s -> s.Contains "Sherlock")
    |> Array.length

// a more efficient solution: sum up 1 for each paragraph
// we do not create a temporary array here
let sherlockOccurs2 =
    paragraphs
    |> Array.sumBy (fun s -> if s.Contains "Sherlock" then 1 else 0)

// doing it with a higher-order function helper:

// Exercise: return that for how many elements of `array`, `f x` is true
let trueForHowMany (f: 'T -> bool) (array: 'T[]) : int =
    array |> Array.sumBy (fun s -> if f s then 1 else 0)  

// Exercise: returns true if `s` contains all elements of `l` as substring
let containsAll (l: string list) (s: string) =
    l |> List.forall s.Contains 

// now using these helper function:
let sherlockOccurs =
    paragraphs |> trueForHowMany (containsAll [ "Sherlock" ])    

let watsonOccurs =
    paragraphs |> trueForHowMany (containsAll [ "Watson" ])

let bothOccur =
    paragraphs |> trueForHowMany (containsAll [ "Sherlock"; "Watson" ])

// get a single array of all the words
// we remove punctuation from both sides and empty entries
let words =
    paragraphs 
    |> Seq.collect (fun p -> p.Split(' '))
    |> Seq.map (fun s -> s.Trim('.', '?', '-', ',', ';', ':', '!', '"'))
    |> Seq.filter (fun s -> s <> "")
    |> Array.ofSeq   

// doing a word statistic
words
|> Array.countBy (fun s -> s.ToLower())

// exercises: sort it. 1. by alphabet 2. by number of occurrence

// do countby on the length of words

// which 5-letter word is the most common? second most common?
