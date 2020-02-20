using NUnit.Framework;

namespace Secure_Calculator_Technical_Challenge_Tests
{
    public class CalculatorDivisionTests
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
            var sum = Calculator.Divide(1, 1);
            Assert.AreEqual(sum, 1);
        }

        [Test]
        public void FiveAndTwoShouldBeTwoAndAHalf()
        {
            var sum = Calculator.Divide(5, 2);
            Assert.AreEqual(sum, 2.5);
        }

        [Test]
        public void MinusThreeAndOneShouldBeMinusThree()
        {
            var sum = Calculator.Divide(-3, 1);
            Assert.AreEqual(sum, -3);
        }

        [Test]
        public void OneAndMinusThreeShouldBeMinusOneThrid()
        {
            var sum = Calculator.Divide(1, -3);
            Assert.That(sum, Is.EqualTo(1 / 3).Within(15));
        }

        [Test]
        public void MinusThreeAndMinusThreeShouldBeOne()
        {
            var sum = Calculator.Divide(-3, -3);
            Assert.AreEqual(sum, 1) ;
        }

        [Test]
        public void ZeroAndZeroShouldNotANumber()
        {
            var sum = Calculator.Divide(0, 0);
            Assert.IsTrue(double.IsNaN(sum));
        }

        public void OneAndZeroShouldBeInfinity()
        {
            var sum = Calculator.Divide(1, 0);
            Assert.IsTrue(double.IsInfinity(sum));
        }
    }
}