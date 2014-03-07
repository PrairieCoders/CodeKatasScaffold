// See why F# at http://fsharpforfunandprofit.com/why-use-fsharp/

#load "Numbers.fs"
open Katas.FSharp.Numbers

Divides 3 6

LeastDivisorFrom 11 150

[for i in 1..35 -> (i, LeastDivisorFrom i 150)]

PrimeFactors 150
