namespace Katas.FSharp

// http://craftsmanship.sv.cmu.edu/katas/prime-factors-kata
module Numbers =

    let rec PrimeFactors = function
        | n when n < 1 -> failwith "number should be positive"
        | n when n = 1 -> []
        | n -> 
            //TODO:
            []

