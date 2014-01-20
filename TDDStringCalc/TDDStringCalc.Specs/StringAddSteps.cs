using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TDDStringCalc.Specs
{
    [Binding]
    public class StringAddSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Binding]
        public class StepDefinitions
        {
            private Calculator _calculator;
            private string _addString;
            private int _result;

            [Given(@"A calculator")]
            public void GivenACalculator()
            {
                _calculator = new Calculator();
                Assert.IsNotNull(_calculator);
            }

            [Given(@"A string containing one number")]
            public void GivenAStringContainingOneNumber()
            {
                _addString = " 3 ";
            }

            [Then(@"The result should be an integer equal to the input string")]
            public void ThenTheResultShouldBeAnIntegerEqualToTheInputString()
            {
                int result;
                int.TryParse(_addString, out result);
                Assert.AreEqual(result, _result);
                
            }

            [When(@"I press add")]
            public void WhenIPressAdd()
            {
                _result = _calculator.Add(_addString);
            }

            [Given(@"A string containing two numbers")]
            public void GivenAStringContainingTwoNumbers()
            {
                _addString = "1, 2";
            }

            [Then(@"The result should be an integer equal to the sum of the two inputs")]
            public void ThenTheResultShouldBeAnIntegerEqualToTheSumOfTheTwoInputs()
            {
                var inArray = _addString.Split(',');
                int result = int.Parse(inArray[0]) + int.Parse(inArray[1]);
                Assert.AreEqual(result, _result);
            }

            [Given(@"An empty string")]
            public void GivenAnEmptyString()
            {
                _addString = String.Empty;
            }

            [Then(@"The result should be (.*)")]
            public void ThenTheResultShouldBe(int p0)
            {
                Assert.AreEqual(p0, _result);
            }
        }
    }
}
