using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Katas.Tests
{
    public class RomanCalculatorTests
    {
        [TestFixture]
        public class WhenAdding
        {
            [TestCase("XX", "II", "XXII")]
            [TestCase("XIV", "LX", "LXXIV")]
            [TestCase("II", "II", "IV")]
            [TestCase("XX", "XX", "XL")]
            [TestCase("CC", "CC", "CD")]
            [TestCase("V", "V", "X")]
            [TestCase("L", "L", "C")]
            [TestCase("D", "D", "M")]
            [TestCase("IV", "I", "V")]
            [TestCase("XII", "IV", "XVI")]
            [TestCase("IX", "IV", "XIII")]
            public void ItShouldAddTheRomanNumerals(string num1, string num2, string expectedResult)
            {
                // arrange
                var sut = new RomanCalculator();

                // act
                var actualResult = sut.Add(num1, num2);

                // assert
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestFixture]
        public class WhenComparingRomanNumeral
        {

            [TestCase("M", "II", true)]
            [TestCase("M", "MI", false)]
            [TestCase("X", "XX", false)]
            [TestCase("L", "D", false)]
            [TestCase("CC", "LXIII", true)]
            [TestCase("DIX", "DIV", true)]
            [TestCase("MMMCCCXXXIII", "MMMCCCXXXII", true)]
            public void ItShouldReturnTheCorrectResultsForGreaterThan(string num1, string num2, bool expectedResult)
            {
                // arrange
                var rom1 = new RomanNumeral(num1);
                var rom2 = new RomanNumeral(num2);

                // act
                var actualResult = rom1 > rom2;

                // assert
                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestCase("M", "M", true)]
            public void ItShouldReturnTheCorrectResultsForLessThan(RomanNumeral num1, RomanNumeral num2, bool expectedResult)
            {

            }
        }
    }
}
