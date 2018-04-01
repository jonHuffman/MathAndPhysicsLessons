using System;
using System.Collections.Generic;

namespace Chapter_01
{
    //----------------------------------------------
    // References
    //  - http://mathonweb.com/help_ebook/html/expolog_4.htm
    public class Excercise_1_1
    {
        public enum BaseSystem
        {
            // These values will be cast back to integers for calculations so the
            // values are important
            Binary = 2,
            Ternary = 3,
            Quaternary = 4,
            Quinary = 5,
            Senary = 6,
            Septenary = 7,
            Octal = 8,
            Nonary = 9,
            Decimal = 10,
            Undecimal = 11,
            Duodecimal = 12,
            Tridecimal = 13,
            Tetradecimal = 14,
            Pentadecimal = 15,
            Hexadecimal = 16
        }

        /// <summary>
        /// Takes a number represented as an array of digits and converts it from one Base system to another.
        /// </summary>
        /// <param name="number">Digits should be ordered in the array from most to least significant. 724 would be [ 7, 2, 4] </param>
        /// <remarks>This function can support any base system supported by <see cref="BaseSystem"/>, we assume that all Base systems above decimal make use of A-F characters</remarks>
        public static string ConvertBase(string number, BaseSystem frombase, BaseSystem toBase)
        {
            string convertedValue = "";
            int decimalValue;

            char firstCharacter = number[0];
            bool isNegative = firstCharacter.Equals('-');

            if (isNegative)
            {
                number = number.Remove(0, 1);
            } 

            if (BaseToDecimal(number, frombase, out decimalValue))
            {
                DecimalToBase(decimalValue, toBase, ref convertedValue);
            }

            if(isNegative)
            {
                convertedValue = string.Format("-{0}", convertedValue);
            }

            return convertedValue;
        }

        /// <summary>
        /// Converts a positive number from any base system to Decimal.
        /// </summary>
        /// <param name="number">Digits should be ordered in the array from most to least significant. 724 would be [ 7, 2, 4]</param>
        /// <returns>True if conversion was successful</returns>
        /// <remarks>This function can support any base system supported by <see cref="BaseSystem"/>, we assume that all Base systems above decimal make use of A-F characters</remarks>
        public static bool BaseToDecimal(string number, BaseSystem frombase, out int convertedValue)
        {
            convertedValue = 0;

            // Reverse for ease of calculation, index corresponds to digit position in number
            char[] splitNumber = number.ToCharArray();
            Array.Reverse(splitNumber);

            // Confirm that we won't immediately overflow the int
            int mostSignificantDigit = Parse(splitNumber[splitNumber.Length - 1], frombase);
            int largestSupportedIndex = (int)(Math.Log10(int.MaxValue / mostSignificantDigit) / Math.Log10((int)frombase));

            if (splitNumber.Length - 1 > largestSupportedIndex)
            {
                return false;
            }

            // Digit x Base ^ Index = DecimalOfDigit
            for (int i = splitNumber.Length - 1; i >= 0; i--)
            {
                // WHAT about overflowing an int for large numbers?
                int decimalNumber = Parse(splitNumber[i], frombase) * (int)Math.Pow((int)frombase, i);

                if (decimalNumber > int.MaxValue - convertedValue)
                {
                    return false;
                }

                convertedValue += decimalNumber;
            }

            return true;
        }

        /// <summary>
        /// Recurcively converts a positive number from decimal to another base system
        /// </summary>
        /// <param name="number">The number to convert</param>
        /// <param name="toBase">The base system to convert it to</param>
        /// <param name="convertedValue">The converted value</param>
        /// <remarks>This function can support any base system supported by <see cref="BaseSystem"/>, we assume that all Base systems above decimal make use of A-F characters</remarks>
        public static void DecimalToBase(int number, BaseSystem toBase, ref string convertedValue)
        {
            number = Math.Abs(number);

            if(number < (int)toBase)
            {
                convertedValue += ConvertToBaseString(number, toBase);
                return;
            }

            int remainder = number % (int)toBase;
            DecimalToBase((number - remainder) / (int)toBase, toBase, ref convertedValue);
            convertedValue += ConvertToBaseString(remainder, toBase);
        }

        private static int Parse(char number, BaseSystem baseSystem)
        {
            int value = (int)char.GetNumericValue(number);
            if (value >= 0 && value <= 9)
            {
                return value;
            }
            else
            {
                switch (number)
                {
                    case 'A':
                    case 'a':
                        return 10;
                    case 'B':
                    case 'b':
                        return 11;
                    case 'C':
                    case 'c':
                        return 12;
                    case 'D':
                    case 'd':
                        return 13;
                    case 'E':
                    case 'e':
                        return 14;
                    case 'F':
                    case 'f':
                        return 15;
                    default:
                        throw new NotSupportedException(string.Format("Character {0} is not supported by this conversion tool.", number));
                }
            }
        }

        private static string ConvertToBaseString(int number, BaseSystem baseSystem)
        {
            if(number < 0)
            {
                number = Math.Abs(number);
            }

            if (number <= 9)
            {
                return number.ToString();
            }
            else
            {
                switch (number)
                {
                    case 10:
                        return "A";
                    case 11:
                        return "B";
                    case 12:
                        return "C";
                    case 13:
                        return "D";
                    case 14:
                        return "E";
                    case 15:
                        return "F";
                    default:
                        throw new NotSupportedException(string.Format("Number {0} is not supported by this conversion tool.", number));
                }
            }
        }

        private static double NthRoot(double number, int power)
        {
            return Math.Pow(number, 1.0 / power);
        }
    }
}
