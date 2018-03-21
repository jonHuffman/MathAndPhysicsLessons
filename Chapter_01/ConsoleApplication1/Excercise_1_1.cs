using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
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
        public static void ConvertBase(int[] number, BaseSystem frombase, BaseSystem toBase)
        {

        }

        /// <summary>
        /// Converts a number from any base system to Decimal.
        /// </summary>
        /// <param name="number">Digits should be ordered in the array from most to least significant. 724 would be [ 7, 2, 4]</param>
        /// <returns>A list containing the digits of the number sorted from most to least significant.</returns>
        private static List<int> ToDecimal(int[] number, BaseSystem frombase)
        {
            // To ease the storage, number will be stored least to most
            List<int> convertedNumber = new List<int>();

            // Reverse for ease of calculation
            Array.Reverse(number);

            // Base ^ Index x Digit = DecimalOfDigit
            for(int i = 0; i < number.Length; i++)
            {
                // WHAT about overflowing an int for large numbers?
                int decimalValue = (int)frombase ^ i * number[i];
                decimalValue
            }

            convertedNumber.Reverse();
            return convertedNumber;
        }
    }
}
