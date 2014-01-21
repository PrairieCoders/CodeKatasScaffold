using Katas;
using Machine.Specifications;

namespace Kata.Specs
{
	public abstract class StringCalculatorSpecs
	{
		protected static StringCalculator calculator;
		protected static int result;

		// The Establish delegate is the "Arrange" part of the spec class. 
		// The establish will only run once, so your assertions should not mutate any state or you may be in trouble.
		Establish context = () => calculator = new StringCalculator();
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
		Establish context = () => inputNumbers = "99";

		Because of = () => result = calculator.Add(inputNumbers);

		It should_return_the_number = () => result.ShouldEqual(int.Parse(inputNumbers));

		static string inputNumbers;
	}

//	[Subject(typeof(StringCalculator), "Adding numbers")]
//	public class When_adding_a_string_of_numbers_that_has_two_numbers : StringCalculatorSpecs
//	{
//		Establish context = () => inputNumbers = "99";
//
//		Because of = () => result = calculator.Add(inputNumbers);
//
//		It should_return_the_number = () => result.ShouldEqual(int.Parse(inputNumbers));
//
//		static string inputNumbers;
//	}
}