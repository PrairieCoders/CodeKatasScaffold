using System;
using System.Linq;

namespace Katas
{
	/// <summary>
	/// My implementation of the Bowling Kata, ref="http://codingdojo.org/cgi-bin/wiki.pl?KataBowling",
	/// </summary>
	public class BowlingGame
	{

		public int CalculateTotal(string gameLine)
		{
			return
				gameLine
					.Reverse()
					.Aggregate((IRoll)new NullRoll(), (next, r) => new Roll(r, next))
					.GetTotal();
		}

		interface IRoll
		{
			IRoll Next { get; }
			int Points { get; }
			int GetTotal();
			bool IsStrike { get; }
			bool IsSpare { get; }
			bool IsHit { get; }
		}

		class Roll : IRoll
		{
			private readonly char _roll;
			public IRoll Next { get; private set; }
			public int Points { get { return ToPoints(_roll); } }
			public bool IsStrike { get { return _roll == 'X'; } }
			public bool IsSpare { get { return _roll == '/'; } }
			public bool IsHit { get { return Char.IsDigit(_roll); } }

			public Roll(char roll, IRoll next = null)
			{
				_roll = roll;
				Next = next ?? new NullRoll();
			}

			private static int ToPoints(char c)
			{
				return c == '-' ? 0 :
				c == 'X' || c == 'X' || c == '/' ? 10 :
				c - '0';
			}

			int GetPoints()
			{
				if (IsHit && Next.IsSpare)
					return 0;
				if (IsStrike && (IsEmpty(Next) || IsEmpty(Next.Next)))
					return 0;
				if (IsSpare)
					return Points + (IsEmpty(Next.Next) ? 0 : Next.Points);
				if (IsStrike)
					return Points + Next.Points + Next.Next.Points;

				return Points;
			}

			private static bool IsEmpty(IRoll next)
			{
				return !(next.IsHit || next.IsSpare || next.IsStrike);
			}

			public int GetTotal()
			{
				return GetPoints() + Next.GetTotal();
			}
		}

		class NullRoll : IRoll
		{
			public IRoll Next { get { return new NullRoll(); } }
			public int Points { get { return 0; } }
			public int GetTotal() { return 0; }
			public bool IsStrike { get { return false; } }
			public bool IsSpare { get { return false; } }
			public bool IsHit { get { return false; } }
		}
	}

}

