using System;

namespace Kata.Potter
{
    public class Cart
    {
        private readonly double BOOK_PRICE = 8.0;
        private readonly int BOOKS_NUM_IN_SERIES = 5;
        private readonly double[] DISCOUNT = new double[] { 1, 1, 0.95, 0.9, 0.8, 0.75 };

        private int[] _books;
        private int[] bookCategory;

        public void Add(int[] books)
        {
            BookValidation(books);
            _books = books;
        }

        private void BookValidation(int[] books)
        {
            foreach (int eachBook in books)
            {
                if (eachBook >= 5 || eachBook < 0)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public double Checkout()
        {
            ClassifyBook();
            double prices = 0;
            double fullSeries = 0;
            while (true)
            {
                int checkoutBook = GetCheckoutBook();
                if (checkoutBook == 0)
                {
                    break;
                }
                else if (checkoutBook == 3 && fullSeries > 0)
                {
                    prices += 2 * CalculatePrices(4);
                    fullSeries--;
                }
                else if (checkoutBook == BOOKS_NUM_IN_SERIES)
                {
                    fullSeries++;
                }
                else
                {
                    prices += CalculatePrices(checkoutBook);
                }
            }

            if (fullSeries > 0)
            {
                prices += fullSeries * CalculatePrices(BOOKS_NUM_IN_SERIES);
            }
            return prices;
        }

        private int GetCheckoutBook()
        {
            int checkoutBook = 0;
            for (int i = 0; i < BOOKS_NUM_IN_SERIES; i++)
            {
                if (bookCategory[i] > 0)
                {
                    checkoutBook++;
                    bookCategory[i]--;
                }
            }

            return checkoutBook;
        }

        private double CalculatePrices(int numberOfBook)
        {
            return numberOfBook * BOOK_PRICE * DISCOUNT[numberOfBook];
        }

        private void ClassifyBook()
        {
            bookCategory = new int[BOOKS_NUM_IN_SERIES];
            foreach (int eachBook in _books)
            {
                bookCategory[eachBook]++;
            }
        }
    }
}
