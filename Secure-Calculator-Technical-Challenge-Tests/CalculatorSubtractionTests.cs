using NUnit.Framework;

namespace Secure_Calculator_Technical_Challenge_Tests
{
    public class CalculatorSubtractionTests
    {
        SecureCalculator.ICalculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new SecureCalculator.BasicCalculator();
        }

        [Test]
        public void OneAndOneShouldBeZero()
        {
            var sum = Calculator.Subtract(1, 1);
            Assert.AreEqual(sum, 0);
        }

        [Test]
        public void FiveAndTwoShouldBeThree()
        {
            var sum = Calculator.Subtract(5, 2);
            Assert.AreEqual(sum, 3);
        }

        [Test]
        public void MinusThreeAndOneShouldBeMinusFour()
        {
            var sum = Calculator.Subtract(-3, 1);
            Assert.AreEqual(sum, -4);
        }

        [Test]
        public void OneAndMinusThreeShouldBeFour()
        {
            var sum = Calculator.Subtract(1, -3);
            Assert.AreEqual(sum, 4);
        }

        [Test]
        public void MinusThreeAndMinusThreeShouldBeZero()
        {
            var sum = Calculator.Subtract(-3, -3);
            Assert.AreEqual(sum, 0) ;
        }

        [Test]
        public void ZeroAndZeroShouldBeZero()
        {
            var sum = Calculator.Subtract(0, 0);
            Assert.AreEqual(sum, 0);
        }
    }
}