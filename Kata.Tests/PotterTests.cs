using Kata.Potter;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class PotterTests
    {
        private Cart cart;

        [Test]
        public void CanCreate()
        {
            cart = new Cart();
            Assert.NotNull(cart);
        }
        
        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanAddAndCheckoutCart()
        {
            AddCartAndAssertPrices(new int[] { 0 }, 8);
        }

        [TestCase(new int[] { 0 }, 8)]
        [TestCase(new int[] { 1, 1 }, 16)]
        [TestCase(new int[] { 2, 2, 2 }, 24)]
        [TestCase(new int[] { 3, 3, 3, 3 }, 32)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 40)]
        public void AddTheSameKindBooks_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        private void AddCartAndAssertPrices(int[] books, double expected)
        {
            cart.Add(books);

            double prices = cart.Checkout();

            Assert.AreEqual(expected, prices);
        }

        [TestCase(new int[] { 0, 1 }, 15.2)]
        [TestCase(new int[] { 1, 2, 3 }, 21.6)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 25.6)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 30)]
        public void AddSingleDiscountBooks_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1 }, 23.2)]
        [TestCase(new int[] { 0, 0, 1, 1 }, 30.4)]
        [TestCase(new int[] { 0, 0, 1, 2, 2, 3 }, 40.8)]
        [TestCase(new int[] { 0, 1, 1, 2, 3, 4 }, 38)]
        public void AddMultipleDiscountBooks_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }, 51.2)]
        [TestCase(new int[] {
                                    0, 0, 0, 0, 0,
                                    1, 1, 1, 1, 1,
                                    2, 2, 2, 2,
                                    3, 3, 3, 3, 3,
                                    4, 4, 4, 4 }, 141.2)]
        public void AddSpecialDiscountBooks_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [Test]
        public void AddSpeicialDiscoutBooks_WhenCheckoutTwice_ThenReturnImmutablePrices()
        {
            int[] books = new int[] { 0, 0, 1, 1, 2, 2, 3, 4 };
            AddCartAndAssertPrices(books, 51.2);

            double prices = cart.Checkout();

            Assert.AreEqual(51.2, prices);
        }

        [TestCase(new int[] { -1, 3 })]
        [TestCase(new int[] { 0, 5 })]
        public void AddBookNotInSeries_ThenThrowArgumentOutOfRangException(int[] books)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => cart.Add(books));
        }

        [TestCase(new int[] { -1, 3 })]
        public void AddBookNotInSeries_WhenCheckout_ThenReturnZeroPrices(int[] books)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => cart.Add(books));

            double prices = cart.Checkout();

            Assert.AreEqual(0, prices);
        }

        [Test]
        public void AddBookNotInSeriesAfterNormalExecution_WhenCheckout_ThenReturnZeroPrices()
        {
            AddCartAndAssertPrices(new int[] { 0 }, 8);

            Assert.Throws<ArgumentOutOfRangeException>(() => cart.Add(new int[] { -1, 3 }));

            double prices = cart.Checkout();

            Assert.AreEqual(0, prices);
        }
    }
}
