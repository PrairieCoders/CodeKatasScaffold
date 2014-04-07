namespace Katas.FSharp.MarsRoverKata

module Spatial =
    
    type Position = { At : Coordinates; Facing : Direction }
    and Coordinates = {X : int ; Y : int}
    and Direction = North | South | East | West
    
    type Move = Forward = 1 | Backward = -1
    type Turn = Right | Left

    type Planet = {Name: string; Size:int (*; Obstacles: Obstacle list*)}
    and Obstacle = 
        | Rock of Coordinates

    
    let around planet coordinates =
                { X = coordinates.X % planet.Size;
                  Y = coordinates.Y % planet.Size}