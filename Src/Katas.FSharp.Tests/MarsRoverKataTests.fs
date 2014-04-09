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

    //TODO: use fscheck: count number of f's and b's ...


    [<Theory>]
    [<InlineData(0,0,"f", 0,1)>]
    [<InlineData(0,0,"ff", 0,2)>]
    [<InlineData(10,10,"ffbb", 10,10)>]
    let ``When sending a command, rover moves to the correct coordinates``
        (initX:int, initY:int, commands:string, expectedX:int, expectedY:int) =
            
            let initialCoords = {X = initX; Y = initY}
            let rover = {rover with Position = { rover.Position with At = initialCoords}}
            let expectedCoords = {X = expectedX; Y = expectedY}
            
            verify <@  (rover |> Send commands).Position.At = expectedCoords @>
   

    [<Theory>]
    [<InlineData(0,0,"r")>]
    [<InlineData(10,10,"lrlrl")>]
    let ``When sending turn commands only the rover's coordinates should stay the same``
        (initX:int, initY:int, commands:string) =
        
            let initialCoords = {X = initX; Y = initY}
            let rover = {rover with Position = { rover.Position with At = initialCoords}}
            let expectedCoords = initialCoords

            verify <@ (rover |> Send commands).Position.At = expectedCoords @>

                
