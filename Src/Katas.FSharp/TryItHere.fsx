// See why F# at http://fsharpforfunandprofit.com/why-use-fsharp/

#load "MarsKata.fs"
open Katas.FSharp.Mars

// Try your kata here using F# interactive window


let roverAtMars = landAt 10 10 North

// fail
landAt 200 200 North |> ignore