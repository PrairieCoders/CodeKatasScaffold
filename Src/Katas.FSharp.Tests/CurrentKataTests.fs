namespace Katas.FSharp.Tests

open System
open Xunit
open Xunit.Extensions

module CurrentKataTests =

//TODO: install the "xUnit runner..." VS extension to run xUnit tests in Visual Studio test runner.

    [<Theory>]
    [<InlineData("70150")>]
    let MyFunctionCallReturnsCorrectResults(data:string) =
        let actual = Int32.TryParse data
        let expected = true, 70150
        verify <@  actual = expected @>
        