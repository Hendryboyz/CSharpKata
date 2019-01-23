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
        public void CanAddAndCheckout()
        {
            AddCartAndAssertPrices(new int[] { 0 }, 8);
        }

        [TestCase(new int[] { 0 }, 8)]
        [TestCase(new int[] { 1, 1 }, 16)]
        [TestCase(new int[] { 2, 2, 2 }, 24)]
        [TestCase(new int[] { 3, 3, 3, 3 }, 32)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 40)]
        public void AddTheSameBooks_WhenCheckout_ThenReturnPrices(int[] books, double expected)
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
        [TestCase(new int[] { 0, 1, 2 }, 21.6)]
        [TestCase(new int[] { 0, 1, 2, 3 }, 25.6)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 30)]
        public void AddBasicDiscount_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1 }, 23.2)]
        [TestCase(new int[] { 0, 0, 1, 1 }, 30.4)]
        [TestCase(new int[] { 0, 0, 1, 2, 2, 3 }, 40.8)]
        [TestCase(new int[] { 0, 1, 1, 2, 3, 4 }, 38)]
        public void AddMultipleDiscount_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }, 51.2)]
        [TestCase(new int[] {0, 0, 0, 0, 0,
                            1, 1, 1, 1, 1,
                            2, 2, 2, 2,
                            3, 3, 3, 3, 3,
                            4, 4, 4, 4 }, 141.2)]
        public void AddSpecialDiscount_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddCartAndAssertPrices(books, expected);
        }

        [Test]
        public void AddFullSeriesDiscount_WhenCheckoutTwice_ThenPricesIsImmutable()
        {
            AddCartAndAssertPrices(new int[] { 0, 1, 2, 3, 4 }, 30);
            double prices = cart.Checkout();
            Assert.AreEqual(30, prices);
        }

        [TestCase(new int[] { 0, -1 })]
        [TestCase(new int[] { 1, 5 })]
        public void AddNotInSeriesBook_ThenReturnInvalidOperationException(int[] books)
        {
            Assert.Throws<InvalidOperationException>(() => cart.Add(books));
        }
    }
}
