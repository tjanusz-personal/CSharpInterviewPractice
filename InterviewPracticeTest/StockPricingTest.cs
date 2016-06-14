using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InterviewPracticeTest
{
    [TestClass]
    public class StockPricingHistoryTest
    {
        private StockPricingHistory pricer;
        
        [TestInitialize]
        public void Setup()
        {
            pricer = new StockPricingHistory();
        }

        [TestMethod]
        public void DetermineMaxProfitReturnsBestSaleValue()
        {
            List<int> stockPricesYesterday = new List<int>() { 10, 7, 5, 8, 11, 9 };
            int maxProfit = pricer.DetermineMaxProfit(stockPricesYesterday);
            Assert.AreEqual(6, maxProfit);
        }

        [TestMethod]
        public void DetermineMaxProfitReturns0IfPriceFellAllDay()
        {
            List<int> stockPricesYesterday = new List<int>() { 10, 9, 8, 7, 6, 5 };
            int maxProfit = pricer.DetermineMaxProfit(stockPricesYesterday);
            Assert.AreEqual(0, maxProfit);
        }

        [TestMethod]
        public void DetermineMaxProfitReturns0IfPriceStayedSameAllDay()
        {
            List<int> stockPricesYesterday = new List<int>() { 10, 10, 10, 10, 10, 10 };
            int maxProfit = pricer.DetermineMaxProfit(stockPricesYesterday);
            Assert.AreEqual(0, maxProfit);
        }

        [TestMethod]
        public void DetermineMaxProfitReturnsZeroForEmptyList()
        {
            int maxProfit = pricer.DetermineMaxProfit(new List<int>());
            Assert.AreEqual(0, maxProfit);
        }

        [TestMethod]
        public void ProductNotIncludingIndexReturnsCorrectList()
        {
            List<int> listOfInts = new List<int>() {1,7,3,4};
            List<int> expectedInts = new List<int>() { 84, 12, 28, 21 };
            CollectionAssert.AreEqual(expectedInts, pricer.ProductNotIncludingIndex(listOfInts));
        }

        [TestMethod]
        public void ProductNotIncludingIndexWithZerosReturnsCorrectList()
        {
            List<int> listOfInts = new List<int>() { 1, 7, 3, 4, 0 };
            List<int> expectedInts = new List<int>() { 0, 0, 0, 0, 84 };
            CollectionAssert.AreEqual(expectedInts, pricer.ProductNotIncludingIndex(listOfInts));
        }

        [TestMethod]
        public void CountCharsInStringReturnsCorrectCountForMixedStringWord()
        {
            Assert.AreEqual(7, pricer.CountCharsInString("H3ll0 W0rld"));
        }

        [TestMethod]
        public void CountCharsInStringReturnsCorrectCountForStringNoChars()
        {
            Assert.AreEqual(0, pricer.CountCharsInString(" 30 0"));
        }

        [TestMethod]
        public void ReverseWordsInStringCorrectlyReversesWordsBasedOnSpaceDelimiter()
        {
            String testString = "These are the days of our lives";
            String expectedString = "lives our of days the are These";
            Assert.AreEqual(expectedString, pricer.ReverseWordsInString(testString));
        }

        [TestMethod]
        public void ReverseWordsInStringCorrectlyReversesWordsWithExtraSpacesInIt()
        {
            String testString = " These are the  days of  our lives ";
            String expectedString = "lives our of days the are These";
            Assert.AreEqual(expectedString, pricer.ReverseWordsInString(testString));
        }

        [TestMethod]
        public void SumTwoLargestValuesWithDifferentValuesReturnsCorrectSum()
        {
            List<int> values = new List<int>() { 2, 3, 5, 9, 12 };
            Assert.AreEqual(21, pricer.SumTwoLargestValues(values));
        }

        [TestMethod]
        public void SumTwoLargestValuesWithSameValueReturnsCorrectSum()
        {
            List<int> values = new List<int>() { 2, 3, 5, 12, 12 };
            Assert.AreEqual(24, pricer.SumTwoLargestValues(values));
        }

    }


}
