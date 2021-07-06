module App

open Browser.Dom
open Fetch
open Thoth.Fetch

// Mutable variable to count the number of times we clicked the button
let mutable count = 0

// Get a reference to our button and cast the Element to an HTMLButtonElement
let myButton =
    document.querySelector (".my-button") :?> Browser.Types.HTMLButtonElement

// Register our listener
myButton.onclick <-
    fun _ ->
        count <- count + 1
        myButton.innerText <- sprintf "You clicked: %i time(s)!" count

let getMessageButton =
    document.querySelector (".get-data") :?> Browser.Types.HTMLButtonElement

getMessageButton.onclick <-
    fun _ ->
        promise {
            let! message =
                Fetch.get ("/api/GetMessage?name=FSharp", headers = [ HttpRequestHeaders.Accept "application/json" ])

            let p = document.getElementById ("message")

            p.innerText <- message
        }
