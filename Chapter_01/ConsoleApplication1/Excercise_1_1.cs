using System;
using System.Collections.Generic;

namespace ConsoleApplication1
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
        public static void ConvertBase(string number, BaseSystem frombase, BaseSystem toBase)
        {
            int decimalValue = ToDecimal(number, frombase);
        }

        /// <summary>
        /// Converts a number from any base system to Decimal.
        /// </summary>
        /// <param name="number">Digits should be ordered in the array from most to least significant. 724 would be [ 7, 2, 4]</param>
        /// <returns>The number converted to decimal</returns>
        /// <remarks>This function can support any base system supported by <see cref="BaseSystem"/>, we assume that all Base systems above decimal make use of A-F characters</remarks>
        private static int ToDecimal(string number, BaseSystem frombase)
        {
            // Reverse for ease of calculation
            char[] splitNumber = number.ToCharArray();
            Array.Reverse(splitNumber);

            // Confirm that we won't immediately overflow the int
            int mostSignificantDigit = Parse(splitNumber[splitNumber.Length - 1], frombase);
            int largestSupportedIndex = (int)(Math.Log10(int.MaxValue / mostSignificantDigit) / Math.Log10((int)frombase));

            if (splitNumber.Length - 1 > largestSupportedIndex)
            {
                throw new OverflowException(string.Format("A {0} number with the most significant digit being {1} cannot have more than {2} digits. You have {3} digits.",
                    frombase,
                    mostSignificantDigit,
                    largestSupportedIndex + 1,
                    splitNumber.Length));
            }

            // Digit x Base ^ Index = DecimalOfDigit
            int decimalConversion = 0;
            for (int i = splitNumber.Length - 1; i >= 0; i--)
            {
                // WHAT about overflowing an int for large numbers?
                int decimalNumber = Parse(splitNumber[i], frombase) * (int)Math.Pow((int)frombase, i);

                if (decimalNumber > int.MaxValue - decimalConversion)
                {
                    throw new OverflowException("The number has overflowed the integer during decimal conversion.");
                }

                decimalConversion += decimalNumber;
            }

            return decimalConversion;
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

        private static double NthRoot(double number, int power)
        {
            return Math.Pow(number, 1.0 / power);
        }
    }
}
