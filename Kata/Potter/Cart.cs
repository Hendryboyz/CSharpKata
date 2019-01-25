using System;

namespace Kata.Potter
{
    public class Cart
    {
        private readonly double[] DISCOUNT = new double[] { 1, 1, 0.95, 0.9, 0.8, 0.75 };
        private readonly int BOOK_NUM_IN_SERIES = 5;
        private readonly int BOOK_PRICES = 8;

        private int[] _books;

        public void Add(int[] books)
        {
            ValidateArgument(books);
            _books = books;
        }

        private void ValidateArgument(int[] books)
        {
            foreach (int eachBook in books)
            {
                bool bookInSeries = eachBook >= 0 && eachBook < BOOK_NUM_IN_SERIES;
                if (!bookInSeries)
                {
                    _books = null;
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double Checkout()
        {
            if (_books is null)
            {
                return 0;
            }

            int[] bookStacks = ClassifyBooks();

            double prices = 0;
            int fullSeries = 0;
            while (true)
            {
                int checkoutBooks = GetCheckoutBooks(bookStacks);
                if (checkoutBooks == 0)
                {
                    break;
                }
                else if (checkoutBooks == BOOK_NUM_IN_SERIES)
                {
                    fullSeries++;
                }
                else if (checkoutBooks == 3 && fullSeries > 0)
                {
                    fullSeries--;
                    prices += 2 * CalculatePrices(4);
                }
                else
                {
                    prices += CalculatePrices(checkoutBooks);
                }
            }

            if (fullSeries > 0)
            {
                prices += fullSeries * CalculatePrices(BOOK_NUM_IN_SERIES);
            }

            return prices;
        }

        private double CalculatePrices(int numOfBooks)
        {
            return BOOK_PRICES * numOfBooks * DISCOUNT[numOfBooks];
        }

        private int GetCheckoutBooks(int[] bookStacks)
        {
            int checkoutBooks = 0;
            for (int i = 0; i < BOOK_NUM_IN_SERIES; i++)
            {
                if (bookStacks[i] > 0)
                {
                    bookStacks[i]--;
                    checkoutBooks++;
                }
            }
            return checkoutBooks;
        }

        private int[] ClassifyBooks()
        {
            int[] bookStacks = new int[BOOK_NUM_IN_SERIES];
            foreach (int eachBook in _books)
            {
                bookStacks[eachBook]++;
            }
            return bookStacks;
        }
    }
}
