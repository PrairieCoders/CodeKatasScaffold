using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBDD
{
    public class BowlingGame
    {
        private const int MaxRolls = 21;

        private readonly char[] _rolls = new char[MaxRolls];
        private int _currentRoll;

        public BowlingGame()
        {
            
        }

        public void Roll(char roll)
        {
            _rolls[_currentRoll] = roll;
            _currentRoll++;
        }

        

        public int GetScore()
        {
            var scoreStack = new Stack<int>();
            for (var i = 0; i < MaxRolls; i++)
            {
                var roll = _rolls[i];
                if (Char.IsDigit(roll))
                {
                    scoreStack.Push(GetIntValue(roll));
                    continue;
                }
                if (roll == '-')
                {
                    scoreStack.Push(GetIntValue(roll));
                    continue;
                }
                if (roll == '/')
                {
                    scoreStack.Pop();
                    scoreStack.Push(GetIntValue(roll));
                    scoreStack.Push(GetIntValue(_rolls[i+1]));
                    continue;
                }
                if (roll == 'x' || roll == 'X')
                {
                    scoreStack.Push(GetIntValue(roll));
                    scoreStack.Push(GetIntValue(_rolls[i+1]));
                    scoreStack.Push(GetIntValue(_rolls[i+2]));
                    continue;
                }
                if (roll == default(char))
                {
                    break;
                }
                throw new ArgumentException("Invalid roll.");
            }

            var total = 0;
            while (scoreStack.Any())
                total += scoreStack.Pop();

            return total;
        }

        private int GetIntValue(char charValue)
        {
            if (Char.IsDigit(charValue))
            {
                var temp = Char.GetNumericValue(charValue);
                var val = Convert.ToInt32(temp);
                return val;
            }
            if (charValue == '-')
                return 0;
            if (charValue == '/')
                return 10;
            if (charValue == 'x' || charValue == 'X')
                return 10;
            if (charValue == default(char))
                return 0;

            throw new ArgumentException("Invalid roll character");
        }
    }

   
}
