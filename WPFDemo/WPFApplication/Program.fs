// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.Windows
open System.Collections.ObjectModel
open System.ComponentModel
open System.Windows.Input

type Name =
    {
        FirstName : string
        LastName : string
    }

type MyViewModel() =
    let mutable firstName = ""
    let mutable lastName = ""
    let changed = Event<_, _>()
    let names = ObservableCollection<Name>() 
    let canExecuteAddChanged = Event<_, _>()

    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member x.PropertyChanged = changed.Publish      

    member this.NotifyChange p =
        changed.Trigger(this, PropertyChangedEventArgs(p))
        canExecuteAddChanged.Trigger(this, EventArgs())

    member this.FirstName 
        with get () = firstName 
        and set v =
            firstName <- v
            this.NotifyChange "FirstName"

    member this.LastName
        with get () = lastName 
        and set v = 
            lastName <- v 
            this.NotifyChange "LastName"

    member this.Names = names

    member this.Add =
        { new ICommand with
              member x.CanExecute(_) =
                not (String.IsNullOrWhiteSpace firstName || 
                    String.IsNullOrWhiteSpace lastName)  
              [<CLIEvent>]
              member x.CanExecuteChanged = 
                canExecuteAddChanged.Publish
              member x.Execute(_) =
                this.Names.Add(
                    {
                        FirstName = this.FirstName
                        LastName = this.LastName
                    }    
                )
                this.FirstName <- ""
                this.LastName <- ""
        }

[<EntryPoint; STAThread>]
let main argv = 
    
    let vm = MyViewModel()

    let window = WpfLibrary.MainWindow()
    window.DataContext <- vm
    Application().Run(window)
