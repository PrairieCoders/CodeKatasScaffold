namespace Katas.FSharp

module RomanCalculator =

    
    [<Literal>]
    let tokens = "IVXLCDM"

    type Roman = Roman of string
    
    let add (a:Roman) (b:Roman) = 
        Roman "I"

// requirements:
    // order: M, D, C, L, 
    // max one for: V, L, D
    // max four repetitions for: I, X, C, M
    
    // substitutions:
    // a) IIII=>IV,
    // b) VIIII=>IX,
    // c) XXXX=>XL,
    // d) LXXXX=>XC,
    // e) CCCC=>CD,
    // f) DCCCC=>CM

    // samples:
        // 1066 = MLXVI,
        // 207 = CCVII,
        // 2014 = MMXIV
        // III + II = IIIII
    // 2014 = MMXIV before reduction:
    // MMXIIII

    // process:
    //  1) enlarge arguments, e.g.: MMXIV becomes MMXIIII
    //  2) concatenate tokens
    //  3) sort (higher first)
    //  4) reduce (somehow)
    //
    // sample: XLIV + XXIX  = LXXIII (44 + 29 = 73)
    //  1. enlarge: XXXXIIII + XXVIIII
    //  2. concatenate: XXXXIIIIXXVIIII
    //  3. sort: XXXXXXVIIIIIIII
    //  4. reduce: one level rule at the time (reducing from left to right, higher rule first)
    //      - rule "c": XXXXXXVIIIIIIII -> XLXXVIIIIIIII
    //      - rule "b": XLXXVIIIIIIII -> XLXXIXIIII
    //      - rule "a": XLXXIXIIII -> XLXXIXIV      <- this is 73 but not really correct form, hmm
            