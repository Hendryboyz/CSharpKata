using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class FibProductTests
    {
        private FibProduct algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new FibProduct();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        [Timeout(1000)]
        public void BuildFibnacci()
        {
            int count = 1000;
            ulong[] fibSequence = new ulong[count + 1];
            ulong number = algorithm.BuildFibnacci(count, fibSequence);
            number.Should().BeGreaterThan(0);
            Console.WriteLine(number);
            Console.WriteLine(string.Join(", ", fibSequence));
        }

        [Test]
        public void CanProductFib()
        {
            ulong[] result = algorithm.ProductFib(1);
            result.Should().Equal(new long[] { 1, 1, 1 });
        }

        [TestCase(4895, new ulong[] { 55, 89, 1 })]
        [TestCase(714, new ulong[] { 21, 34, 1 })]
        public void GivenProductCase_WhenProductFib_ThenReturnFibNumAndTrue(
            int product, ulong[] expected)
        {
            ulong[] result = algorithm.ProductFib(Convert.ToUInt64(product));
            Console.WriteLine(string.Join(",", result));
            result.Should().Equal(expected);
        }

        [TestCase(800, new ulong[] { 34, 55, 0 })]
        public void GivenNotProductCase_WhenProductFib_ThenReturnFibNumAndTrue(
            int product, ulong[] expected)
        {
            ulong[] result = algorithm.ProductFib(Convert.ToUInt64(product));
            Console.WriteLine(string.Join(",", result));
            result.Should().Equal(expected);
        }
    }
}
