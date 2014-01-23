using System;
using Katas;
using Machine.Specifications;
using Ploeh.AutoFixture;
using System.Linq;
using FluentAssertions;

namespace Kata.Specs
{
	public abstract class StringCalculatorSpecs
	{
		protected static IFixture fixture;
		protected static StringCalculator calculator;
		protected static int result;

		// The Establish delegate is the "Arrange" part of the spec class. 
		// The establish will only run once, so your assertions should not mutate any state or you may be in trouble.
		Establish context = () =>
			{
				fixture = new Fixture();
				calculator = new StringCalculator();
			};
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_is_empty : StringCalculatorSpecs
	{
		// The Because delegate is the "Act" part of the spec class. 
		// It should be the single action for this context, the only part that mutates state, against which all of the assertions can be made. 
		Because of = () => result = calculator.Add("");

		// The It delegate is the "Assert" part of the spec class. It may appear one or more times in your spec class. 
		// Each statement should contain a single assertion, so that the intent and failure reporting is crystal clear.
		It should_return_0 = () => result.ShouldEqual(0);
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_has_only_one_number : StringCalculatorSpecs
	{
		Establish context = () =>
			{
				expected = fixture.Create<int>();

				numberString = expected.ToString();
			};

		Because of = () => result = calculator.Add(numberString);

		It should_return_the_input_number = () => result.ShouldEqual(expected);

		static string numberString;
		static int expected;
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_has_two_numbers : StringCalculatorSpecs
	{
		Establish context = () =>
			{
				var generator = fixture.Create<Generator<int>>();

				var numbers = generator.Take(2).ToArray();
				expected = numbers.Sum();

				numberString = string.Join(",", numbers);
			};

		Because of = () => result = calculator.Add(numberString);

		It should_return_the_sum_of_the_input_numbers = () => result.ShouldEqual(expected);

		static string numberString;
		static int expected;
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_has_any_amount_of_numbers : StringCalculatorSpecs
	{
		Establish context = () =>
			{
				var amountOfNumbers = fixture.Create<int>();
				var generator = fixture.Create<Generator<int>>();

				var numbers = generator.Take(amountOfNumbers).ToArray();
				expected = numbers.Sum();

				numberString = string.Join(",", numbers);
		};

		Because of = () => result = calculator.Add(numberString);

		It should_return_the_sum_of_the_input_numbers = () => result.ShouldEqual(expected);

		static string numberString;
		static int expected;
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_uses_newline_delimiters : StringCalculatorSpecs
	{
		Establish context = () =>
		{
			var amountOfNumbers = fixture.Create<int>();
			var generator = fixture.Create<Generator<int>>();

			var numbers = generator.Take(amountOfNumbers).ToArray();
			expected = numbers.Sum();

			numberString = string.Join("\n", numbers);
		};

		Because of = () => result = calculator.Add(numberString);

		It should_return_the_sum_of_the_input_numbers = () => result.ShouldEqual(expected);

		static string numberString;
		static int expected;
	}

	[Subject(typeof(StringCalculator), "Adding numbers")]
	public class When_adding_a_string_of_numbers_that_uses_a_custom_delimiter : StringCalculatorSpecs
	{
		Establish context = () =>
		{
			var amountOfNumbers = fixture.Create<int>();
			var intGenerator = fixture.Create<Generator<int>>();
			var charGenerator = fixture.Create<Generator<char>>();

			var numbers = intGenerator.Take(amountOfNumbers).ToArray();
			expected = numbers.Sum();

			var customDelimiter = Convert.ToString(charGenerator.First(x => !char.IsDigit(x) && x != '/' && x!= '\n'));
			var delimiterChangeTag = string.Format("//{0}\n", customDelimiter);

			var joinedNumbers = string.Join(customDelimiter, numbers);

			numberString = string.Format("{0}{1}", delimiterChangeTag, joinedNumbers);
		};

		Because of = () => result = calculator.Add(numberString);

		It should_return_the_sum_of_the_input_numbers = () => result.ShouldEqual(expected);

		static string numberString;
		static int expected;
	}

//	[Subject(typeof(StringCalculator), "Adding numbers")]
//	public class When_adding_a_string_of_numbers_that_contains_a_negative_number : StringCalculatorSpecs
//	{
//		Establish context = () =>
//		{
//			var amountOfNumbers = fixture.Create<int>();
//			var intGenerator = fixture.Create<Generator<int>>();
//
//			var numbers = intGenerator.Take(amountOfNumbers).Select(x => -x).ToArray();
//
//			numberString = string.Join("\n", numbers);
//		};
//
//		Because of = () => caughtException = Catch.Exception(() => calculator.Add(numberString));
//
//		It should_fail = () => caughtException.ShouldBeOfType<Exception>();
//		It should_have_a_specific_reason = () => caughtException.ShouldContainErrorMessage("negatives not allowed");
////		It should_contain_a_list_of_offending_numbers = () => nume
//
//		static string numberString;
//		static Exception caughtException;
//	}
}