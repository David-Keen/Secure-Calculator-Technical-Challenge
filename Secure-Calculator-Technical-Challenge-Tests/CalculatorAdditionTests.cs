using NUnit.Framework;

namespace Secure_Calculator_Technical_Challenge_Tests
{
    public class CalculatorAdditionTests
    {
        Calculator_Application.Services.Calculator.ICalculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new Calculator_Application.Services.Calculator.BasicCalculator();
        }

        [Test]
        public void OneAndOneShouldBeTwo()
        {
            var sum = Calculator.Add(1, 1);
            Assert.AreEqual(sum, 2);
        }

        [Test]
        public void TwoAndThreeShouldBeFive()
        {
            var sum = Calculator.Add(2, 3);
            Assert.AreEqual(sum, 5);
        }

        [Test]
        public void MinusThreeAndOneShouldBeMinusTwo()
        {
            var sum = Calculator.Add(-3, 1);
            Assert.AreEqual(sum, -2);
        }

        [Test]
        public void OneAndMinusThreeShouldBeMinusTwo()
        {
            var sum = Calculator.Add(1, -3);
            Assert.AreEqual(sum, -2);
        }

        [Test]
        public void MinusThreeAndMinusThreeShouldBeMinusSix()
        {
            var sum = Calculator.Add(-3, -3);
            Assert.AreEqual(sum, -6) ;
        }

        [Test]
        public void ZeroAndZeroShouldBeZero()
        {
            var sum = Calculator.Add(0, 0);
            Assert.AreEqual(sum, 0);
        }
    }
}