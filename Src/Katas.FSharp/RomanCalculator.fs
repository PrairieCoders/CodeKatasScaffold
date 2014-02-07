namespace Katas.FSharp

module RomanCalculator =

    
    [<Literal>]
    let tokens = "IVXLCDM" // "MDCLXVI" 

    type Roman = Roman of string
    
    let add (a:Roman) (b:Roman) = 
        Roman "I"

// requirements:
    // order: M, D, C, L, 
    // max one for: V, L, D
    // max three repetitions for: I, X, C, M
    
    // reduction rules:
    // a) IIII=>IV,
    // b) VIIII=>IX,
    // c) XXXX=>XL,
    // d) LXXXX=>XC,
    // e) CCCC=>CD,
    // f) DCCCC=>CM
    // i.e.:
    //    (4x odd token -> 1x odd and next) 
    //    (1x even and 4x odd token -> 1x the odd and next of the even) 
    // 

    // additional reduction rules:
    // g-i) IIIII -> V, XXXXX -> L, CCCCC -> D
    // j-l) VV -> X, LL -> C, DD -> M
    // i.e.:
    //    4x odd -> 1x next odd
    //    2x even

    // samples:
        // XLIV + XXIX = LXXIII
        // XXVIII + LXVI = XCIV

    // process:
    //  1) expand arguments, e.g.: MMXIV becomes MMXIIII
    //  2) concatenate tokens
    //  3) sort (higher first)
    //  4) reduce (left to right, until nothing to reduce)
    //
    // sample: XLIV + XXIX  = LXXIII (44 + 29 = 73)
    //  1. expand: XXXXIIII + XXVIIII
    //  2. concatenate: XXXXIIIIXXVIIII
    //  3. sort: XXXXXXVIIIIIIII
    //  4. reduce: one level rule at the time (reducing from left to right, higher rule first)
            