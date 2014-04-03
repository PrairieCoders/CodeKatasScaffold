namespace Katas.FSharp

/// This is the Mars Rover kata. See: http://craftsmanship.sv.cmu.edu/katas/mars-rover-kata
module Mars =

    type Coordinates = {X:int;Y:int}
    and Direction = North | South | East | West
    and Position = {At:Coordinates;Facing:Direction} //Position of Coordinates * Direction
    and Rover = Rover of Position

    let marsPlanetSize = {X = 100; Y = 100}
    
    let landAt x y direction =
        match x,y with
        | x,y when x < marsPlanetSize.X && y < marsPlanetSize.Y
            -> Rover {At = {X = x; Y = y}; Facing = direction}
        | _ -> failwith "Kaboom! Sorry, your rover smashed into the planet. Mission failed." //TODO: Error type

