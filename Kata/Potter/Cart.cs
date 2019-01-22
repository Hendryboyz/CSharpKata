using System;

namespace Kata.Potter
{
    // http://codingdojo.org/kata/Potter/
    public class Cart
    {
        private readonly int NUM_BOOK_IN_SERIES = 5;
        private readonly double BOOK_PRICE = 8.0;
        private readonly double[] DISCOUNT = new double[] { 1, 1, 0.95, 0.9, 0.8, 0.75 };
        private int fullSeries;
        private int[] _books;
        private int[] bookSeries = new int[5];

        public void Add(int[] books)
        {
            _books = books;
            BookValidation();
        }

        private void BookValidation()
        {
            foreach (var eachBook in _books)
            {
                bool isSeriesBook = eachBook >= NUM_BOOK_IN_SERIES || eachBook < 0;
                if (isSeriesBook)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public double Checkout()
        {
            ClassifyBooks();
            fullSeries = 0;
            double prices = 0;
            while (true)
            {
                int checkingoutBooks = ExtractDifferentBooks();
                if (checkingoutBooks == 0)
                {
                    break;
                }
                else if (checkingoutBooks == NUM_BOOK_IN_SERIES)
                {
                    fullSeries++;
                }
                else if (checkingoutBooks == 3 && fullSeries > 0)
                {
                    prices += 2 * GetPrices(4);
                    fullSeries--;
                }
                else
                {
                    prices += GetPrices(checkingoutBooks);
                }
            }

            if (fullSeries > 0)
            {
                prices += fullSeries * GetPrices(NUM_BOOK_IN_SERIES);
            }
            return prices;
        }

        private void ClassifyBooks()
        {
            foreach (int eachBook in _books)
            {
                bookSeries[eachBook]++;
            }
        }

        private double GetPrices(int numberOfBooks)
        {
            return numberOfBooks * BOOK_PRICE * DISCOUNT[numberOfBooks];
        }

        private int ExtractDifferentBooks()
        {
            int checkingoutBooks = 0;
            for (int i = 0; i < NUM_BOOK_IN_SERIES; i++)
            {
                if (bookSeries[i] > 0)
                {
                    bookSeries[i]--;
                    checkingoutBooks++;
                }
            }
            return checkingoutBooks;
        }
    }
}
