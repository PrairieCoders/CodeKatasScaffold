module Katas.FSharp.Tests.NumbersTests

open NUnit.Framework
open FsCheck
open Katas.FSharp.Numbers


[<Test>]
let ``PrimeFactors tests``() =

    let ``product of results equals input value`` i = PrimeFactors i |> Seq.fold (*) 1
    
    let property (PositiveInt i) =  
            (i > 1)
                ==> ``product of results equals input value`` i
    Check.QuickThrowOnFailure property

