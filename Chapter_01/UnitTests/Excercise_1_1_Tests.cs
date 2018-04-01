using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter_01;

namespace UnitTests
{
    [TestClass]
    public class Excercise_1_1_Tests
    {
        const string BinaryValue = "100011001001000001010001";
        const string TernaryValue = "122100000110122";
        const string QuaternaryValue = "203021001101";
        const string QuinaryValue = "4324240420";
        const string SenaryValue = "525240025";
        const string SeptenaryValue = "141205046";
        const string OctalValue = "43110121";
        const string NonaryValue = "18300418";
        const string DecimalValue = "9211985";
        const string UndecimalValue = "5222112";
        const string DuodecimalValue = "3103015";
        const string TridecimalValue = "1BA6CA3";
        const string TetradecimalValue = "131B1CD";
        const string PentadecimalValue = "C1E725";
        const string HexadecimalValue = "8C9051";

        [TestMethod]
        public void ToDecimalConversionTest()
        {
            int convertedValue;
            Assert.IsTrue(Excercise_1_1.BaseToDecimal(BinaryValue, Excercise_1_1.BaseSystem.Binary, out convertedValue));
            Assert.AreEqual(DecimalValue, convertedValue.ToString());
        }

        [TestMethod]
        public void DecimalConversionOverflowTest()
        {
            int convertedValue;

            // 1111111111111111111111111111111 == int.MaxValue
            Assert.IsTrue(Excercise_1_1.BaseToDecimal("1111111111111111111111111111111", Excercise_1_1.BaseSystem.Binary, out convertedValue));
            // 8001869F == 2147583647 which exceeds int.MaxValue by 500000
            Assert.IsFalse(Excercise_1_1.BaseToDecimal("8001869F", Excercise_1_1.BaseSystem.Hexadecimal, out convertedValue));
        }

        [TestMethod]
        public void DecimalToBaseConversionTest()
        {
            const int inputValue = 724;

            string convertedValue = "";
            Excercise_1_1.DecimalToBase(inputValue, Excercise_1_1.BaseSystem.Hexadecimal, ref convertedValue);
            // 724 = 2D4 in Hex
            Assert.AreEqual("2D4", convertedValue);

            convertedValue = "";
            Excercise_1_1.DecimalToBase(inputValue, Excercise_1_1.BaseSystem.Binary, ref convertedValue);
            // 724 = 1011010100 in Binary
            Assert.AreEqual("1011010100", convertedValue);
        }

        [TestMethod]
        public void NegativeConversionTest()
        {
            string NegativeTernaryValue      = string.Format("-{0}", TernaryValue);
            string NegativeQuinaryValue      = string.Format("-{0}", QuinaryValue);
            string NegativeSenaryValue       = string.Format("-{0}", SenaryValue);
            string NegativeOctalValue        = string.Format("-{0}", OctalValue);
            string NegativeUndecimalValue    = string.Format("-{0}", UndecimalValue);
            string NegativePentadecimalValue = string.Format("-{0}", PentadecimalValue);

            Assert.AreEqual(NegativeTernaryValue,       Excercise_1_1.ConvertBase(NegativePentadecimalValue,    Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(NegativeQuinaryValue, Excercise_1_1.ConvertBase(NegativeSenaryValue, Excercise_1_1.BaseSystem.Senary, Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(NegativeTernaryValue, Excercise_1_1.ConvertBase(NegativeOctalValue, Excercise_1_1.BaseSystem.Octal, Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(NegativeOctalValue, Excercise_1_1.ConvertBase(NegativeUndecimalValue, Excercise_1_1.BaseSystem.Undecimal, Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(NegativeTernaryValue, Excercise_1_1.ConvertBase(NegativeUndecimalValue, Excercise_1_1.BaseSystem.Undecimal, Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(NegativePentadecimalValue, Excercise_1_1.ConvertBase(NegativeOctalValue, Excercise_1_1.BaseSystem.Octal, Excercise_1_1.BaseSystem.Pentadecimal));
        }

        [TestMethod]
        public void BinaryConversionTest()
        {
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Binary));
            Assert.AreEqual(BinaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Binary));
        }

        [TestMethod]
        public void TernaryConversionTest()
        {
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Ternary));
            Assert.AreEqual(TernaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Ternary));
        }
        
        [TestMethod]
        public void QuaternaryConversionTest()
        {
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Quaternary));
            Assert.AreEqual(QuaternaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Quaternary));
        }

        [TestMethod]
        public void QuinaryConversionTest()
        {
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Quinary));
            Assert.AreEqual(QuinaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Quinary));
        }

        [TestMethod]
        public void SenaryConversionTest()
        {
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Senary));
            Assert.AreEqual(SenaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Senary));
        }

        [TestMethod]
        public void SeptenaryConversionTest()
        {
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Septenary));
            Assert.AreEqual(SeptenaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Septenary));
        }

        [TestMethod]
        public void OctalConversionTest()
        {
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Octal));
            Assert.AreEqual(OctalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Octal));
        }

        [TestMethod]
        public void NonaryConversionTest()
        {
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Nonary));
            Assert.AreEqual(NonaryValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Nonary));
        }

        [TestMethod]
        public void DecimalConversionTest()
        {
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Decimal));
            Assert.AreEqual(DecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Decimal));
        }

        [TestMethod]
        public void UndecimalConversionTest()
        {
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Undecimal));
            Assert.AreEqual(UndecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Undecimal));
        }

        [TestMethod]
        public void DuodecimalConversionTest()
        {
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Duodecimal));
            Assert.AreEqual(DuodecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Duodecimal));
        }

        [TestMethod]
        public void TridecimalConversionTest()
        {
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Tridecimal));
            Assert.AreEqual(TridecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Tridecimal));
        }

        [TestMethod]
        public void TetradecimalConversionTest()
        {
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Tetradecimal));
            Assert.AreEqual(TetradecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Tetradecimal));
        }

        [TestMethod]
        public void PentadecimalConversionTest()
        {
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Pentadecimal));
            Assert.AreEqual(PentadecimalValue, Excercise_1_1.ConvertBase(HexadecimalValue,    Excercise_1_1.BaseSystem.Hexadecimal,   Excercise_1_1.BaseSystem.Pentadecimal));
        }

        [TestMethod]
        public void HexadecimalConversionTest()
        {
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(BinaryValue,         Excercise_1_1.BaseSystem.Binary,        Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(TernaryValue,        Excercise_1_1.BaseSystem.Ternary,       Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(QuaternaryValue,     Excercise_1_1.BaseSystem.Quaternary,    Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(QuinaryValue,        Excercise_1_1.BaseSystem.Quinary,       Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(SenaryValue,         Excercise_1_1.BaseSystem.Senary,        Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(SeptenaryValue,      Excercise_1_1.BaseSystem.Septenary,     Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(OctalValue,          Excercise_1_1.BaseSystem.Octal,         Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(NonaryValue,         Excercise_1_1.BaseSystem.Nonary,        Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(DecimalValue,        Excercise_1_1.BaseSystem.Decimal,       Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(UndecimalValue,      Excercise_1_1.BaseSystem.Undecimal,     Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(DuodecimalValue,     Excercise_1_1.BaseSystem.Duodecimal,    Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(TridecimalValue,     Excercise_1_1.BaseSystem.Tridecimal,    Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(TetradecimalValue,   Excercise_1_1.BaseSystem.Tetradecimal,  Excercise_1_1.BaseSystem.Hexadecimal));
            Assert.AreEqual(HexadecimalValue, Excercise_1_1.ConvertBase(PentadecimalValue,   Excercise_1_1.BaseSystem.Pentadecimal,  Excercise_1_1.BaseSystem.Hexadecimal));
        }
    }
}
