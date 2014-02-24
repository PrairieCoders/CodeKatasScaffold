using System;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Katas.Tests
{
    
	public class StringCalculatorTests
	{
        [TestFixture]
        public class WhenAdding
        {
            [TestFixture]
            public class AndNoNumbersArePassedIn
            {
                [Test]
                public void ItShouldReturnZeroWhenNoNumbersArePassedIn()
                {
                    // arrange
                    var fixture = new Fixture();

                    var sut = fixture.Create<StringCalculator>();

                    // act
                    var result = sut.Add("");

                    // assert
                    Assert.AreEqual(0, result);

                }
            }

            [TestFixture]
            public class AndOnlyOneNumberIsPassedIn
            {
                [Test]
                public void ItShouldReturnThatNumber()
                {
                    // arrange
                    var fixture = new Fixture();

                    const string number = "5";
                    var sut = fixture.Create<StringCalculator>();
                    
                    // act
                    var result = sut.Add(number);

                    // assert
                    Assert.AreEqual(int.Parse(number), result);
                }
            }

            [TestFixture]
            public class AndTwoNumbersArePassedIn
            {
                [Test]
                public void ItShouldReturnTheSumOfTheTwoNumbers()
                {
                    // arrange
                    var fixture = new Fixture();

                    const string numbers = "5\n4";
                    var sut = fixture.Create<StringCalculator>();

                    // act
                    var result = sut.Add(numbers);

                    // assert
                    Assert.AreEqual(5+4, result);
                }
            }

            [TestFixture]
            public class AndAnUnknownAmountOfNumbersArePassedIn
            {
                [TestCase("1\n2\n3", 6)]
                [TestCase("1\n2\n3\n4", 10)]
                [TestCase("1\n2\n3\n4\n5", 15)]
                [TestCase("1\n2\n3\n4\n5\n6", 21)]
                public void ItShouldReturnTheSumOfAllTheNumbers(string numbers, int expectedResult)
                {
                    // arrange
                    var fixture = new Fixture();

                    var sut = fixture.Create<StringCalculator>();

                    // act
                    var result = sut.Add(numbers);

                    // assert
                    Assert.AreEqual(expectedResult, result);
                }
            }

            [TestFixture]
            public class AndNewLineIsUsedBetweenNumbersInsteadOfCommas
            {
                [TestCase("1\n2\n3", 6)]
                public void ItShouldHandleItAndReturnTheSum(string numbers, int expectedResult)
                {
                    // arrange
                    var fixture = new Fixture();

                    var sut = fixture.Create<StringCalculator>();

                    // act
                    var result = sut.Add(numbers);

                    // assert
                    Assert.AreEqual(expectedResult, result);
                }
            }

            [TestCase("//;\n1;2", 3)]
            [TestCase("//p\n3p3p4", 10)]
            public void ItShouldBeAbleToChangeTheDelimiter(string numbers, int expectedResult)
            {
                // arrange
                var fixture = new Fixture();

                var sut = fixture.Create<StringCalculator>();

                // act
                var result = sut.Add(numbers);

                // assert
                Assert.AreEqual(expectedResult, result);
            }

            [TestFixture]
            public class AndNegativeNumbersArePassedIn
            {
                [Test]
                public void ItShouldThrowANegativesNotAllowedExceptionWithTheNegativeNumbersInTheMessage()
                {
                    // arrange
                    var fixture = new Fixture();
                    const string numbers = "2\n-1";
                    var sut = fixture.Create<StringCalculator>();

                    // act and assert
                    Assert.Throws(Is.TypeOf<NegativesNotAllowedException>()
                                    .And.Message.Contains("-1")
                                    .And.Not.Message.Contains("2"), 
                                    () => sut.Add(numbers));

                    
                }
            }
        }
	}
}
