namespace Katas.FSharp.Tests

open System
open Xunit
open Xunit.Extensions



module MarsRoverTests =


    open Katas.FSharp.MarsRoverKata.Rover
    open Katas.FSharp.MarsRoverKata.Spatial
    
    let planet = {Name = "Planet"; Size = 100}
    let position = {At = { X = 0; Y = 0}; Facing = North}
    let rover = {Rover.Position = position; OnPlanet = planet}

    let toDirection = function
        | "N" -> North
        | "E" -> East
        | "S" -> South
        | "W" -> West
        | _ -> failwith "not supported direction"

    [<Theory>]
    [<InlineData(0,0,"N","f", 0,1,"N")>]
    [<InlineData(10,10,"N","flb", 11,11,"W")>]
    [<InlineData(0,0,"W","ffrbb", 98,98,"N")>]
    [<InlineData(10,10,"S", "lrlr", 10, 10, "S")>]
    let ``When sending a command, rover moves to the correct position``
        (initX:int, initY:int, initDir:string, commands:string, expectedX:int, expectedY:int, expectedDir:string) =
            
            let initialPosition = {At = {X = initX; Y = initY}; Facing = toDirection initDir}
            let rover = {rover with Position = initialPosition}
            let expectedPosition = {At = {X = expectedX; Y = expectedY}; Facing = toDirection expectedDir}
            
            verify <@  (rover |> Send commands).Position = expectedPosition @>

