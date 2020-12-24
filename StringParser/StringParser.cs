using System;
using System.Linq;
using System.Text;

namespace StringParser
{
    public static class StringParser
    {
        public static int ToInt(this string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (str.ContainsOnlyDigits() || (str.Length > 1 && str.StartsWith("-") && str.Substring(1).ContainsOnlyDigits()))
            {
                str = str.Trim();
                bool isNegative = (str[0] == '-');
                if (isNegative)
                {
                    str = str.Substring(1);
                }
                int result = 0;
                int power = str.Length - 1;

                foreach (char c in str)
                {
                    try
                    {
                        checked
                        {
                            {
                                for (var j = 0; j <= power; j++)
                                {
                                    result += (c - 48) * (int)Math.Pow(10, power);
                                    power--;
                                }
                            }
                        }
                    }
                    catch (OverflowException e)
                    {
                        throw new OverflowException("The input value was too big or too smal for int.", e);
                    }
                }

                return (isNegative) ? -result : result;
            }
            else
            {
                throw new ArgumentException("Input string with digits only");
            }

        }

        public static bool ContainsOnlyDigits(this string str)
        {
            return str.All(s => char.IsDigit(s));
        }
    }

}
