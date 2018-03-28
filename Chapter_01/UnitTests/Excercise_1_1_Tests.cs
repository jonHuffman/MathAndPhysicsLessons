using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chapter_01;

namespace UnitTests
{
    [TestClass]
    public class Excercise_1_1_Tests
    {
        [TestMethod]
        public void DecimalConversionTest()
        {
            const int expectedValue = 179;
            int convertedValue;
            Assert.IsTrue(Excercise_1_1.ToDecimal("10110011", Excercise_1_1.BaseSystem.Binary, out convertedValue));
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void DecimalConversionOverflowTest()
        {
            // 8001869F == 2147583647 which exceeds int.MaxValue by 500000
            int convertedValue;
            Assert.IsFalse(Excercise_1_1.ToDecimal("8001869F", Excercise_1_1.BaseSystem.Hexadecimal, out convertedValue));
        }
    }
}
