module Katas.FSharp.Tests.SpatialTests

open System
open Xunit
open Xunit.Extensions

open Katas.FSharp.MarsRoverKata.Spatial

let planet = {
    Name = "test planet"
    Size = 50
    Obstacles = [Rock {X = 10; Y = 5}
                 Rock {X = 15; Y = 2}] }

[<Theory>]
[<InlineData(1,2, false)>]
[<InlineData(10,5, true)>]
[<InlineData(15,2, true)>]
let ``It correctly determines obstacle at given coordinates``
    ( x:int, y:int, expected:bool ) =

    verify <@ planet |> isObstacleAt  {X = x; Y = y} = expected @>

