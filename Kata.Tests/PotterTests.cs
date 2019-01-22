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
        public void CanCreateCart()
        {
            cart = new Cart();
            Assert.NotNull(cart);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreateCart();
        }

        [Test]
        public void CanAddAndCheckout()
        {
            AddBooksAndAssertPrices(new int[] { 0 }, 8);
        }

        [TestCase(new int[] { 0 }, 8)]
        [TestCase(new int[] { 1, 1 }, 16)]
        [TestCase(new int[] { 2, 2, 2 }, 24)]
        [TestCase(new int[] { 3, 3, 3, 3 }, 32)]
        [TestCase(new int[] { 4, 4, 4, 4, 4 }, 40)]
        public void GivenBookStack_WhenCheckout_ThenReturnPrices(int[] books, double expected)
        {
            AddBooksAndAssertPrices(books, expected);
        }

        private void AddBooksAndAssertPrices(int[] books, double expected)
        {
            cart.Add(books);
            double prices = cart.Checkout();
            Assert.AreEqual(expected, prices);
        }

        [TestCase(new int[] { 0, 1 }, 15.2)]
        [TestCase(new int[] { 1, 2, 3 }, 21.6)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 25.6)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 30)]
        public void GivenSingleDiscount_WhenCheckout_ThenReturnDiscountPrices(int[] books, double expected)
        {
            AddBooksAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1 }, 23.2)]
        [TestCase(new int[] { 0, 0, 1, 1 }, 30.4)]
        [TestCase(new int[] { 0, 0, 1, 2, 2, 3 }, 40.8)]
        [TestCase(new int[] { 0, 1, 1, 2, 3, 4 }, 38)]
        public void GivenMutipleDiscount_WhenCheckout_ThenReturnDiscountPrices(int[] books, double expected)
        {
            AddBooksAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }, 51.2)]
        [TestCase(new int[] {0, 0, 0, 0, 0,
                                1, 1, 1, 1, 1,
                                2, 2, 2, 2,
                                3, 3, 3, 3, 3,
                                4, 4, 4, 4 }, 141.2)]
        public void GivenSpecialDiscount_WhenCheckout_ThenReturnDiscountPrices(int[] books, double expected)
        {
            AddBooksAndAssertPrices(books, expected);
        }

        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { 5 })]
        public void GivenNotSeriesBook_WhenAdd_ThenThrowInvalidOperationException(int[] books)
        {
            Assert.Throws<InvalidOperationException>(() => cart.Add(books));
        }

        [TestCase(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }, 51.2)]
        [TestCase(new int[] {0, 0, 0, 0, 0,
                                1, 1, 1, 1, 1,
                                2, 2, 2, 2,
                                3, 3, 3, 3, 3,
                                4, 4, 4, 4 }, 141.2)]
        public void GivenSpecialDiscount_WhenCheckoutTwice_ThenReturnTheSameDiscountPrices(int[] books, double expected)
        {
            AddBooksAndAssertPrices(books, expected);
            double prices = cart.Checkout();
            Assert.AreEqual(expected, prices);
        }
    }
}
