using Kata.FizBuz;
using NSubstitute;
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

        [TestCase(2)]
        [TestCase(23)]
        [TestCase(37)]
        [TestCase(83)]
        public void GivenNumber_ThenReturnNumberString(int number)
        {
            string result = game.Given(number);
            Assert.AreEqual(Convert.ToString(number), result);
        }

        [TestCase(3)]
        [TestCase(69)]
        [TestCase(21)]
        [TestCase(12)]
        public void GivenNumberDivisibleBy3_ThenReturnFizz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("Fizz", result);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(35)]
        public void GivenNumberDivisibleBy5_ThenReturnBuzz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("Buzz", result);
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(60)]
        [TestCase(90)]
        public void GivenNumberDivisibleBy3And5_ThenReturnFizzBuzz(int number)
        {
            string result = game.Given(number);
            StringAssert.AreEqualIgnoringCase("FizzBuzz", result);
        }

        [Test]
        public void GivenNumber_ThenParseByNumberConverter()
        {
            INumberConverter numberConverter = Substitute.For<INumberConverter>();
            game = new FizzBuzz(numberConverter);

            game.Given(2);

            numberConverter.Received().Parse(Arg.Is(2));
        }
    }
}
