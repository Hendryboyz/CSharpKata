using System;

namespace Kata.Potter
{
    public class Cart
    {
        private readonly double BOOK_PRICES = 8;
        private readonly double[] DISCOUNT = new double[] { 1, 1, 0.95, 0.9, 0.8, 0.75 };
        private readonly int BOOK_NUM_IN_SERIES = 5;
        private int[] _books;
        private int[] _bookCategory;

        public void Add(int[] books)
        {
            foreach (int eachBook in books)
            {
                if (eachBook < 0 || eachBook >= BOOK_NUM_IN_SERIES)
                {
                    throw new InvalidOperationException();
                }
            }
            _books = books;
        }

        public double Checkout()
        {
            if (_books is null)
            {
                return 0;
            }
            ClassifyBooks();
            double prices = 0;
            int fullSeries = 0;
            while (true)
            {
                int checkoutBooks = GetCheckoutBooks();
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
            return numOfBooks * BOOK_PRICES * DISCOUNT[numOfBooks];
        }

        private void ClassifyBooks()
        {
            _bookCategory = new int[BOOK_NUM_IN_SERIES];
            foreach (int eachBook in _books)
            {
                _bookCategory[eachBook]++;
            }
        }

        private int GetCheckoutBooks()
        {
            int checkoutBooks = 0;
            for (int i = 0; i < BOOK_NUM_IN_SERIES; i++)
            {
                if (_bookCategory[i] > 0)
                {
                    _bookCategory[i]--;
                    checkoutBooks++;
                }
            }

            return checkoutBooks;
        }
    }
}
