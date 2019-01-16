using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz game;

        [Test]
        public void CanCreate()
        {
            game = new FizzBuzz();
            Assert.NotNull(game);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [TestCase(1)]
        [TestCase(7)]
        [TestCase(11)]
        [TestCase(97)]
        public void GivenNumber_ThenReturnNumber(int number)
        {
            string result = game.Given(number);
            Assert.AreEqual(Convert.ToString(number), result);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(21)]
        public void GivenNumberDivisibleBy3_ThenReturnFizz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("Fizz", result);
        }

        [TestCase(5)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(10)]
        public void GivenNumberDivisibleBy5_ThenReturnBuzz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("Buzz", result);
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        [TestCase(90)]
        public void GivenNumberDivisibleBy3And5_ThenReturnFizzBuzz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("FizzBuzz", result);
        }
    }
}
