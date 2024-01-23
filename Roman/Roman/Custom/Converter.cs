using System;
using System.Text;

namespace Roman
{
	public class Converter
	{
		public Converter ()
		{
			
		}
		
		public string NumberToRoman(int number)
        {
            if (number == 0) return "N";

			int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            
            StringBuilder result = new StringBuilder();

            
            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

            return result.ToString();
        }
		
		public int RomanToNumber(string number)
        {
            var CurrentChar = "";
            var NextChar = "";
            var CurrentValue = 0;
            var NextValue = 0;
            var FinalValue = 0;
            for (var i = 0; i < number.Length; i++)
            {
                CurrentChar = number.Substring(i, 1);
                CurrentValue = GetValue(Convert.ToChar(CurrentChar));
                if (CurrentValue == -1)
                {
                    return -1;
                }
                if (i + 1 < number.Length)
                {
                    NextChar = number.Substring(i+1, 1);
                }
                else
                {
                    NextChar = "!";
                }
                NextValue = GetValue(Convert.ToChar(NextChar));
                if (NextValue > CurrentValue)
                {
                    FinalValue += NextValue - CurrentValue;
                    i++;
                }
                else
                {
                    FinalValue += CurrentValue;
                }
            }

            return FinalValue;
        }
		
		
		public int GetValue(char MyChar)
        {
            var result = -1;

            switch (MyChar)
            {
                case 'M':
                    {
                        result = 1000;
                        break;
                    }
                case 'D':
                    {
                        result = 500;
                        break;
                    }
                case 'C':
                    {
                        result = 100;
                        break;
                    }
                case 'L':
                    {
                        result = 50;
                        break;
                    }
                case 'X':
                    {
                        result = 10;
                        break;
                    }
                case 'V':
                    {
                        result = 5;
                        break;
                    }
                case 'I':
                    {
                        result = 1;
                        break;
                    }
            }
            return result;
        }
	}
}

