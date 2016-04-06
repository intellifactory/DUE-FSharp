
#r "System.Xml.Linq.dll"
// Requires downloading the FSharp.Data NuGet package
#r "../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"

// a sample xml
let [<Literal>] xml = """<?xml version="1.0"?>
<catalog>
   <book id="bk101">
      <author>Gambardella, Matthew</author>
      <title>XML Developer's Guide</title>
      <genre>Computer</genre>
      <price>44.95</price>
      <publish_date>2000-10-01</publish_date>
      <description>An in-depth look at creating applications 
      with XML.</description>
   </book>
   <book id="bk102">
      <author>Ralls, Kim</author>
      <title>Midnight Rain</title>
      <genre>Fantasy</genre>
      <price>5.95</price>
      <publish_date>2000-12-16</publish_date>
      <description>A former architect battles corporate zombies, 
      an evil sorceress, and her own childhood to become queen 
      of the world.</description>
   </book>
   <book id="bk103">
      <author>Corets, Eva</author>
      <title>Maeve Ascendant</title>
      <genre>Fantasy</genre>
      <price>5.95</price>
      <publish_date>2000-11-17</publish_date>
      <description>After the collapse of a nanotechnology 
      society in England, the young survivors lay the 
      foundation for a new society.</description>
   </book>
   <book id="bk104">
      <author>Corets, Eva</author>
      <title>Oberon's Legacy</title>
      <genre>Fantasy</genre>
      <price>5.95</price>
      <publish_date>2001-03-10</publish_date>
      <description>In post-apocalypse England, the mysterious 
      agent known only as Oberon helps to create a new life 
      for the inhabitants of London. Sequel to Maeve 
      Ascendant.</description>
   </book>
   <book id="bk105">
      <author>Corets, Eva</author>
      <title>The Sundered Grail</title>
      <genre>Fantasy</genre>
      <price>5.95</price>
      <publish_date>2001-09-10</publish_date>
      <description>The two daughters of Maeve, half-sisters, 
      battle one another for control of England. Sequel to 
      Oberon's Legacy.</description>
   </book>
   <book id="bk106">
      <author>Randall, Cynthia</author>
      <title>Lover Birds</title>
      <genre>Romance</genre>
      <price>4.95</price>
      <publish_date>2000-09-02</publish_date>
      <description>When Carla meets Paul at an ornithology 
      conference, tempers fly as feathers get ruffled.</description>
   </book>
   <book id="bk107">
      <author>Thurman, Paula</author>
      <title>Splish Splash</title>
      <genre>Romance</genre>
      <price>4.95</price>
      <publish_date>2000-11-02</publish_date>
      <description>A deep sea diver finds true love twenty 
      thousand leagues beneath the sea.</description>
   </book>
   <book id="bk108">
      <author>Knorr, Stefan</author>
      <title>Creepy Crawlies</title>
      <genre>Horror</genre>
      <price>4.95</price>
      <publish_date>2000-12-06</publish_date>
      <description>An anthology of horror stories about roaches,
      centipedes, scorpions  and other insects.</description>
   </book>
   <book id="bk109">
      <author>Kress, Peter</author>
      <title>Paradox Lost</title>
      <genre>Science Fiction</genre>
      <price>6.95</price>
      <publish_date>2000-11-02</publish_date>
      <description>After an inadvertant trip through a Heisenberg
      Uncertainty Device, James Salway discovers the problems 
      of being quantum.</description>
   </book>
   <book id="bk110">
      <author>O'Brien, Tim</author>
      <title>Microsoft .NET: The Programming Bible</title>
      <genre>Computer</genre>
      <price>36.95</price>
      <publish_date>2000-12-09</publish_date>
      <description>Microsoft's .NET initiative is explored in 
      detail in this deep programmer's reference.</description>
   </book>
   <book id="bk111">
      <author>O'Brien, Tim</author>
      <title>MSXML3: A Comprehensive Guide</title>
      <genre>Computer</genre>
      <price>36.95</price>
      <publish_date>2000-12-01</publish_date>
      <description>The Microsoft MSXML3 parser is covered in 
      detail, with attention to XML DOM interfaces, XSLT processing, 
      SAX and more.</description>
   </book>
   <book id="bk112">
      <author>Galos, Mike</author>
      <title>Visual Studio 7: A Comprehensive Guide</title>
      <genre>Computer</genre>
      <price>49.95</price>
      <publish_date>2001-04-16</publish_date>
      <description>Microsoft Visual Studio 7 is explored in depth,
      looking at how Visual Basic, Visual C++, C#, and ASP+ are 
      integrated into a comprehensive development 
      environment.</description>
   </book>
</catalog>"""

// using the XML type provider, passing it a sample xml
type BooksXml = FSharp.Data.XmlProvider<xml>

BooksXml.Parse(xml) // we can parse another xml which has the same structure

let catalog = BooksXml.GetSample()

catalog.Books |> Array.minBy (fun b -> b.PublishDate)

// World Bank type provider has a default root type
// The subtypes are still generated at compile time
// (and while writing the code, for code completion and checking)
let wb = FSharp.Data.WorldBankData.GetDataContext()

// Extract Hungarian total population by year
let hunPopTotal = wb.Countries.Hungary.Indicators.``Population, total``
hunPopTotal.Years |> Seq.map (fun y -> y, int hunPopTotal.[y]) |> Array.ofSeq

// exercise: which was the 10 most populated countries in the world
// in year 2010? (where data exists) 

let population =
    wb.Regions.World.Countries
    |> Seq.map (fun c -> c.Name, int c.Indicators.``Population, total``.[2010])
    |> Seq.sortByDescending snd
    |> Seq.take 10
    |> Array.ofSeq

// as a query computation expression
// whenever the data source object allows, queries do not run
// locally, but are encoded in some way as defined by the
// data source object (for example to an SQL string or REST API call)
// so filtering and other operations happen at the remote data source
let populationQ =
    query {
        for c in wb.Regions.World.Countries do
        let pop2010 = int c.Indicators.``Population, total``.[2010]
        sortByDescending pop2010
        take 10
        select (c.Name, pop2010)
    }
    |> Array.ofSeq

// full list of available operations:
// https://msdn.microsoft.com/en-us/library/hh225374.aspx

// homework:
// experiment and find anything you think is interesting in World Bank data
// by query or Seq operations

let lifeExpectancy =
    wb.Regions.World.Countries |> Seq.map (fun c -> c.Name, c.Indicators.``Life expectancy at birth, total (years)``.[2015])
    |> Seq.sortByDescending snd
    |> Seq.take 10
    |> Array.ofSeq

// exercise:
// Which country has increased "CO2 emissions (metric tons per capita)" with the largest 
// percentage from 1980 to 2010 (among those which has both data available)
let firstExercise =
    query {
        for c in wb.Regions.World.Countries do
        let data1980 = float c.Indicators.``CO2 emissions (metric tons per capita)``.[1980]
        let data2010 = float c.Indicators.``CO2 emissions (metric tons per capita)``.[2010]
        where (data1980 > 0. && data1980 > 0.) // to filter out `nan` values
        let increaseRatio = data2010/data1980
        sortByDescending increaseRatio
        select (c.Name, increaseRatio)
        head
    }
