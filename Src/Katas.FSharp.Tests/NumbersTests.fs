module Katas.FSharp.Tests.NumbersTests


open NUnit.Framework
open FsCheck
open Katas.FSharp.Numbers

let isNaturalNumber i = i >= 1


[<Test>]
let ``PrimeFactors property-based tests``() =

    let ``Product of results equals input value`` i = PrimeFactors i |> Seq.reduce (*)
    
    let property i = isNaturalNumber i ==> ``Product of results equals input value``
    Check.QuickThrowOnFailure property
    
