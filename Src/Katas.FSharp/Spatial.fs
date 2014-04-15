namespace Katas.FSharp.MarsRoverKata

module Spatial =
    
    type Position = { At : Coordinates; Facing : Direction }
    and Coordinates = {X : int ; Y : int}
    and Direction = North | South | East | West
    
    type Move = Forward = 1 | Backward = -1
    type Turn = Right | Left

    type Planet = {Name: string; Size:int; Obstacles: Obstacle list}
    and Obstacle = 
        | Rock of Coordinates

    let around planet coordinates =
        let aroundSingle coord size = 
            (if coord < 0 then size else 0) + coord % size
        { X = aroundSingle coordinates.X planet.Size;
          Y = aroundSingle coordinates.Y planet.Size}

    let isObstacleAt coordinates planet =
            planet.Obstacles 
                |> Seq.map (function | Rock c -> c)
                |> Seq.exists ((=) coordinates)