using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.CodeWar
{
    public class StockList
    {
        public string Summary(string[] stockQuantity, string[] categories)
        {

            if (stockQuantity.Length == 0 || categories.Length == 0)
            {
                return string.Empty;
            }

            IDictionary<string, int> stockTable = CreateStockTable(categories);

            foreach (string eachStock in stockQuantity)
            {
                string[] stockParts = eachStock.Split(" ");
                string stockCategory = stockParts[0].Substring(0, 1);
                int quantity = Convert.ToInt32(stockParts[1]);
                if (stockTable.ContainsKey(stockCategory))
                {
                    stockTable[stockCategory] += quantity;
                }
            }

            string summary = string.Join(" - ",
                stockTable.Select(x => string.Format("({0} : {1})", x.Key, x.Value)).ToArray());
            return summary;
        }

        private IDictionary<string, int> CreateStockTable(string[] categories)
        {
            IDictionary<string, int> stockTable = new Dictionary<string, int>();
            foreach (string eachCategory in categories)
            {
                if (!stockTable.ContainsKey(eachCategory))
                {
                    stockTable.Add(eachCategory, 0);
                }
            }

            return stockTable;
        }

        private string SummaryByFunc(string[] stockQuantity, string[] categories)
        {
            return string.Join(" - ",
                categories.Select(x => string.Format("({0} : {1})", x,
                    stockQuantity.Where(s => x.Equals(s.Substring(0, 1)))
                                 .Sum(s => Convert.ToInt16(s.Split(' ')[1]))
                    )
                )
            );
        }
    }
}
