/// This is the Mars Rover kata. See: http://craftsmanship.sv.cmu.edu/katas/mars-rover-kata
namespace Katas.FSharp.MarsRoverKata

open System
open Spatial

module Rover =

    type Rover = {Position:Position;OnPlanet:Planet}

    type Command = 
            | MoveRover of Move 
            | TurnRover of Turn


    let LandOn planet (position:Position) =
        { Rover.Position = {position with At = around planet position.At}
          OnPlanet = planet }
    
    let move (how:Move) by rover =
        
        let {At = at; Facing = facing} = rover.Position
        let delta (move:Move) = function
            | North -> {X = 0; Y = by * int move}
            | South -> {X = 0; Y = - by * int move}
            | East -> {X = by * int move; Y = 0}
            | West -> {X = - by * int move; Y = 0}

        let {X = dx; Y = dy} = delta how facing
        
        // TODO: check obstacles here

        let arroundPlanet = around rover.OnPlanet
        let newPosition = {Position.At = arroundPlanet {X = at.X + dx; Y = at.Y + dy}; Position.Facing = facing}
       
        {rover with Position = newPosition}


    let turn (direction:Turn) rover : Rover =
        
        let {At = at; Facing = facing} = rover.Position
        let toLeft = function
            | North -> West 
            | East -> North
            | South -> East
            | West -> South
        
        let toRight = function
            | North -> East 
            | East -> South
            | South -> West
            | West -> North

        let newDirection = function
            | Left -> toLeft
            | Right -> toRight

        { rover with 
            Position = {rover.Position with 
                            Facing = newDirection direction facing}}
    

    let Send (commands:string) rover = 
        let rec sendAux rover = function
            | MoveRover m ::rest   -> sendAux (rover |> move m 1) rest
            | TurnRover dir ::rest -> sendAux (rover |> turn dir) rest
            | [] -> rover

        commands
        |> Seq.map (function 
                    | 'f' | 'F' -> MoveRover Move.Forward
                    | 'b' | 'B' -> MoveRover Move.Backward
                    | 'l' | 'L' -> TurnRover Turn.Left
                    | 'r' | 'R' -> TurnRover Turn.Right
                    | x  -> failwith "I don't understand '%s' command" x)
        |> Seq.toList
        |> sendAux rover

        
//    let GoForward = move Move.Forward 1
//    let GoBackward = move Move.Backward 1
//    let TurnLeft = turn Turn.Left
//    let TurnRight = turn Turn.Right


