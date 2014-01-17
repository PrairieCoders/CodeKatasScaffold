// bowling kata, ref: http://codingdojo.org/cgi-bin/wiki.pl?KataBowling
#if INTERACTIVE
#r "../../packages/xunit.1.9.2/lib/net20/xunit.dll"
#r "../../packages/FsUnit.xUnit.1.2.2.1/Lib/Net40/FsUnit.Xunit.dll"
#r "../../packages/xunit.extensions.1.9.2/lib/net20/xunit.extensions.dll"
#endif

namespace BowlingGame

open System
open Xunit
open Xunit.Extensions
open FsUnit.Xunit


type Score = 
    | Strike
    | Spare
    | Miss
    | Hit of int

type Frame = Score * Score

type BowlingGame() = 


    let toScore = function
        | 'x' | 'X' -> Strike
        | '/' -> Spare
        | '-' | '0' -> Miss
        | x -> Hit (Int32.Parse (x.ToString()))

    let toPoints = function
        | Strike -> 10
        | Spare -> 10
        | Miss -> 0//| Na -> 0
        | Hit x -> x

    let rec calculate total = function
        | Strike::b::c::tail -> calculate ( (**total +**) toPoints Strike + toPoints b + toPoints c) (b::c::tail)
        | Strike::Strike::[] -> total // strike bonus 
        | a::Spare::c::[] -> total + toPoints Spare + toPoints c // spare bonus
        | a::Spare::c::tail -> calculate (total + toPoints Spare + toPoints c) (c::tail)
        | a::b::c::tail -> calculate (total + toPoints a) (b::c::tail)
        | a::b::[] -> total + toPoints a + toPoints b
        | [a] -> total + toPoints a
        | [] -> total

    let error = "given scores data is not correct"
    let rec validate = function
        | Strike::Spare::tail -> Some(error)
        | Spare::Spare::tail -> Some(error)
        | _::Spare::[] -> Some(error)
        | h::tail -> validate tail
        | [] -> None

    member this.CalculateTotal scoresChars : int =
        let scores = Seq.map (fun sc -> toScore sc) scoresChars |> Seq.toList
        match validate scores with
        | None -> calculate 0 scores
        | Some(error) -> failwith error


// f# unit test frameworks: http://stackoverflow.com/questions/1989487/f-development-and-unit-testing
type ``When calculating total game score``() = 

    [<Theory>]
    [<InlineData("00000000000000000000", 0)>]
    [<InlineData("11111111111111111111", 20)>]
    [<InlineData("1/111111111111111111", 29)>] // 10 + 1 + 18
    [<InlineData("XXXXXXXXXXXX", 300)>]
    [<InlineData("9-9-9-9-9-9-9-9-9-9-", 90)>]
    [<InlineData("5/5/5/5/5/5/5/5/5/5/5", 150)>]
    member x.``It should return correct result``(gameLine:string, expectedScore:int) =
        
        BowlingGame().CalculateTotal gameLine 
        |> should equal expectedScore
     