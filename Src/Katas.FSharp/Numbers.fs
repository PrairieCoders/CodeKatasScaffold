namespace Katas.FSharp

// http://craftsmanship.sv.cmu.edu/katas/prime-factors-kata
module Numbers =

    open System
    
    let rec lcd a b =
        raise (NotImplementedException())
        0

    let rec PrimeFactors = function
        | n when n < 1 -> failwith "number should be positive"
        | n when n = 1 -> []
        | n -> 
            let ld = lcd 2 n
            ld :: PrimeFactors (n / ld)

