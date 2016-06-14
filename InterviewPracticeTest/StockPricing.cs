using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewPracticeTest
{
    class StockPricingHistory
    {

        public int DetermineMaxProfit(List<int> stockPricesYesterday)
        {
            if (stockPricesYesterday == null || stockPricesYesterday.Count < 2)
            {
                return 0;
            }
            
            int minPrice = stockPricesYesterday.First();
            int maxProfit = Math.Max(0, stockPricesYesterday.ElementAt(1) - minPrice);
            int iCount = 0;
            foreach (int price in stockPricesYesterday)
            {
                if (iCount == 0)
                {
                    iCount++;
                    continue;
                }
                int currProfit = price - minPrice;
                maxProfit = Math.Max(currProfit, maxProfit);
                minPrice = Math.Min(price, minPrice);
            }
            return maxProfit;
        }

        public List<int> ProductNotIncludingIndex(List<int> numbersToMultiply)
        {
            List<int> result = new List<int>();
            if (numbersToMultiply == null)
            {
                return result;
            }
            foreach (int number in numbersToMultiply) 
            {
                int finalTotal = numbersToMultiply.Except(new List<int>() { number })
                    .Aggregate((total, next) => next * total);
                result.Add(finalTotal);
            }
            return result;
        }

        public int CountCharsInString(String stringToTest)
        {
            return stringToTest.Where(x => Char.IsLetter(x)).Count();
        }

        public String ReverseWordsInString(String sentanceToReverse)
        {
            string[] sourceWords = sentanceToReverse.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return String.Join(" ", sourceWords.Reverse());
        }

        public int SumTwoLargestValues(List<int> intValueList)
        {
            if (intValueList == null || intValueList.Count < 2)
            {
                return 0;
            }
            int maxValue = intValueList.Max();
            int count = intValueList.Count(x => x == maxValue);
            if (count >= 2) return maxValue + maxValue;
            int maxValue2 = intValueList.Except(new List<int>() { maxValue}).Max();
            return maxValue + maxValue2;
        }
    }
}
