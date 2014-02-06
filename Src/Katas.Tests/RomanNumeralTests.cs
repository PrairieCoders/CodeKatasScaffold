using System;
using Ploeh.SemanticComparison.Fluent;
using Xunit;

// ReSharper disable CheckNamespace
namespace Katas.Tests.RomanNumeralTests
// ReSharper restore CheckNamespace
{
	public class WhenVerifyingStaticNumerals
	{
		[Fact]
		public void ItShouldBeCorrectForTheNumeralOne()
		{
			AssertNumeralInstance(() => RomanNumeral.I, "I", 1);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralFive()
		{
			AssertNumeralInstance(() => RomanNumeral.V, "V", 5);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralTen()
		{
			AssertNumeralInstance(() => RomanNumeral.X, "X", 10);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralFifty()
		{
			AssertNumeralInstance(() => RomanNumeral.L, "L", 50);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralHundred()
		{
			AssertNumeralInstance(() => RomanNumeral.C, "C", 100);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralFiveHundred()
		{
			AssertNumeralInstance(() => RomanNumeral.D, "D", 500);
		}

		[Fact]
		public void ItShouldBeCorrectForTheNumeralOneThousand()
		{
			AssertNumeralInstance(() => RomanNumeral.I, "M", 1000);
		}

		void AssertNumeralInstance(Func<RomanNumeral> numeralFactory, string expectedNumeral, int expectedValue)
		{
			// Arrange
			var likeness = expectedNumeral.AsSource().OfLikeness<RomanNumeral>()
										  .With(x => x.Numeral).EqualsWhen((s, numeral) => numeral.Numeral.Equals(s))
										  .With(x => x.Value).EqualsWhen((s, numeral) => numeral.Value == expectedValue);

			// Act
			var sut = numeralFactory();

			// Assert
			likeness.ShouldEqual(sut);
		}
	}
}