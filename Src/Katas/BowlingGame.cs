using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas
{
	/// <summary>
	/// Implementation of the Bowling Kata, ref="http://codingdojo.org/cgi-bin/wiki.pl?KataBowling",
	/// HOW? : 
	///		- visitor pattern ?,
	///		- monoids and map-reduce?
	/// </summary>
	public class BowlingGame
	{
		public int CalculateTotal(string gameLog)
		{

			gameLog
				.Select( c => c == 'X' ? new []{'X','_'} : new[]{'X'})
				// add dummy frame for strike (X)
				.SelectMany( @throw => )

				.Zip(gameLog.Skip(1), (f,s) => new Frame {First})

			return 0;
		}
	}

	class Frame
	{
		public Score FirstThrow { get; private set; }
		public Score SecondThrow { get; private set; }

		protected Frame(char firstThrow, char secondThrow)
		{
			FirstThrow = Score.Create(firstThrow);
			SecondThrow = Score.Create(secondThrow);
		}
	}

	abstract class Score
	{
		readonly char _throw;

		private Score(char @throw)
		{
			_throw = @throw;
		}

		public Throw Throw { get; set; }

		public static Score Create(char @throw)
		{
			return ToThrow(@throw);
		}

		static Score ToThrow(char @throw)
		{
			switch (@throw)
			{
				case 'X':
					return new Strike();
				case '/':
					return new Spare();
			}
			return __;
		}
	}

	class Spare : Score
	{
	}

	class Strike : Score
	{
	}


	enum Throw
	{
		Strike,
		Spare,
		Hit,
		Miss,
		//None
	}
}
