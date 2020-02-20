using NUnit.Framework;

namespace Secure_Calculator_Technical_Challenge_Tests
{
    public class CalculatorMultiplicationTests
    {
        Secure_Calculator_Technical_Challenge.Calculator.ICalculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new Secure_Calculator_Technical_Challenge.Calculator.BasicCalculator();
        }

        [Test]
        public void OneAndOneShouldBeOne()
        {
            var sum = Calculator.Multiply(1, 1);
            Assert.AreEqual(sum, 1);
        }

        [Test]
        public void FiveAndTwoShouldBeTen()
        {
            var sum = Calculator.Multiply(5, 2);
            Assert.AreEqual(sum, 10);
        }

        [Test]
        public void MinusThreeAndOneShouldBeMinusThree()
        {
            var sum = Calculator.Multiply(-3, 1);
            Assert.AreEqual(sum, -3);
        }

        [Test]
        public void OneAndMinusThreeShouldBeMinusThree()
        {
            var sum = Calculator.Multiply(1, -3);
            Assert.AreEqual(sum, -3);
        }

        [Test]
        public void MinusThreeAndMinusThreeShouldBeNine()
        {
            var sum = Calculator.Multiply(-3, -3);
            Assert.AreEqual(sum, 9) ;
        }

        [Test]
        public void ZeroAndZeroShouldBeZero()
        {
            var sum = Calculator.Multiply(0, 0);
            Assert.AreEqual(sum, 0);
        }
    }
}