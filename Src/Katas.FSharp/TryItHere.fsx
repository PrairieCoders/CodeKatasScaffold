// See why F# at http://fsharpforfunandprofit.com/why-use-fsharp/

#load "Spatial.fs"
#load "Rover.fs"
open Katas.FSharp.MarsRoverKata.Spatial
open Katas.FSharp.MarsRoverKata.Rover

// Try your kata here using F# interactive window


let mars = {Planet.Name = "Mars" ; Size = 200}
let initialPosition = {
    Position.At = {X = 10; Y = 10}
    Facing = North }

let roverOnMars = LandOn mars initialPosition

roverOnMars
    |> move Move.Forward 1
//    |> turn
    |> move Move.Backward 1
    |> move Move.Forward 1
//    |> turn //
