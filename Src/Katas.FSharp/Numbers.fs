namespace Katas.FSharp

// http://craftsmanship.sv.cmu.edu/katas/prime-factors-kata
module Numbers =

    open System

    let Divides div num = num % div = 0

    /// the least divisor starting from given threshold
    let rec LeastDivisorFrom threshold = function
        | num when Divides threshold num -> threshold
        | num when pown threshold 2 > num -> num
        | num -> LeastDivisorFrom (threshold+1) num

    let rec PrimeFactors = function
        | n when n < 1 -> failwith "number should be positive"
        | n when n = 1 -> []
        | n -> 
            let ld = LeastDivisorFrom 2 n
            ld :: PrimeFactors (n / ld)

