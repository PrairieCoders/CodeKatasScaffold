using System;
using Xunit;
using Xunit.Extensions;
using Should;

namespace Katas.Tests
{
	public class BowlingGameTests
	{

		[Theory]
		[InlineData("00000000000000000000", 0)]
		[InlineData("11111111111111111111", 20)]
		[InlineData("1/111111111111111111", 29)]
		[InlineData("XXXXXXXXXXXX", 300)]
		[InlineData("9-9-9-9-9-9-9-9-9-9-", 90)]
		[InlineData("5/5/5/5/5/5/5/5/5/5/5", 150)]
		public void ItHasToPass(string scores, int expected)
		{
			// arrange
			var sut = new BowlingGame();

			// act 
			int actual = sut.CalculateTotal(scores);

			actual.ShouldEqual(expected, "scores: " + scores);

		}


	}
}
