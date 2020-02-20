using NUnit.Framework;
using Secure_Calculator_Technical_Challenge;

namespace Secure_Calculator_Technical_Challenge_Tests
{
    public class CalculatorAdditionTests
    {
        Secure_Calculator_Technical_Challenge.Calculator.BasicCalculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new Secure_Calculator_Technical_Challenge.Calculator.BasicCalculator();
        }

        [Test]
        public void OneAndOneShouldBeTwo()
        {
            var sum = Calculator.Add(1, 1);
            Assert.AreEqual(sum, 2);
        }

        public void TwoAndThreeShouldBeFive()
        {
            var sum = Calculator.Add(2, 3);
            Assert.AreEqual(sum, 5);
        }

        public void MinusThreeAndOneShouldBeMinusTwo()
        {
            var sum = Calculator.Add(-3, 1);
            Assert.AreEqual(sum, 1);
        }

        public void OneAndMinusThreeShouldBeMinusTwo()
        {
            var sum = Calculator.Add(1, -3);
            Assert.AreEqual(sum, -2);
        }

        public void MinusThreeAndMinusThreeShouldBeMinusSix()
        {
            var sum = Calculator.Add(-3, -3);
            Assert.AreEqual(sum, -6) ;
        }

        public void ZeroAndZeroShouldBeZero()
        {
            var sum = Calculator.Add(0, 0);
            Assert.AreEqual(sum, 0);
        }
    }
}