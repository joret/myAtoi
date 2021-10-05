using System;
using System.Text;

namespace MyAtoi
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Console.Out.WriteLine($"Max:{int.MaxValue} Min:{int.MinValue}");
            var atoi = program.MyAtoi("20000000000000000000");
            Console.WriteLine($"Number:{atoi}");
        }

        public int MyAtoi(string input)
        {
            var trimmed = input.Trim();

            if (trimmed.Length == 0)
            {
                return 0;
            }

            var isNegative = IsNegative(trimmed[0]);
            var explicitSignal = HasExplicitSignal(trimmed[0]);
            var noSignal = RemoveSignal(explicitSignal, trimmed);

            if (noSignal.Length == 0 || !IsDigit(noSignal[0]))
            {
                return 0;
            }

            var digits = FilterDigitsOnly(noSignal);
            if (digits.Length == 0)
            {
                return 0;
            }

            Console.WriteLine($"Digits:{digits}");

            var digitWithout0 = RemoveLeading0(digits);
            Console.WriteLine($"Digits no trail zero:{digitWithout0}");


            var moreDigitsThan32 = digitWithout0.Length > 12 ? true : false;
            if (moreDigitsThan32)
            {
                if (isNegative == -1)
                {
                    return int.MinValue;
                }
                else
                {
                    return int.MaxValue;
                }
            }

            var numberLong = Convert.ToInt64(digitWithout0) * isNegative;

            if (numberLong > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (numberLong < int.MinValue)
            {
                return int.MinValue;
            }

            return Convert.ToInt32(numberLong);

        }

        private string RemoveLeading0(string digits)
        {
            var digitPosition = digits.Length - 1;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != '0')
                {
                    digitPosition = i > 0 ? i - 1 : 0;
                    break;
                }
            }

            Console.WriteLine($"zero position:{digitPosition}");
            return digits.Substring(digitPosition);
        }

        private string FilterDigitsOnly(string noSignal)
        {
            var digitFound = false;
            var digits = new StringBuilder();
            foreach (var character in noSignal)
            {
                if (IsDigit(character))
                {
                    digits.Append(character);
                    digitFound = true;
                }
                else if (digitFound)
                {
                    break;
                }
            }

            return digits.ToString();
        }

        private string RemoveSignal(bool explicitSignal, string input)
        {
            if (explicitSignal)
            {
                return input.Substring(1);
            }

            return input;
        }

        private bool IsDigit(char character)
        {
            var ascii = (byte)character;
            if (ascii >= 48 && ascii <= 57)
            {
                return true;
            }

            return false;
        }

        private bool HasExplicitSignal(char firstChar)
        {
            if (firstChar == '+' || firstChar == '-')
            {
                return true;
            }
            return false;
        }

        private int IsNegative(char signal)
        {
            if (signal == '-')
            {
                return -1;
            }

            return 1;
        }
    }
}
