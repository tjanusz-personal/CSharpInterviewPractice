using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InterviewPracticeTest
{
    [TestClass]
    public class TwoSumTest
    {
        private TwoSum twoSum;

        [TestInitialize]
        public void Setup()
        {
            twoSum = new TwoSum();
        }

        [TestMethod]
        public void FindTwoSumFindsFirstMatchingPair()
        {
            List<int> numbers = new List<int>() { 1, 3, 5, 7, 9};
            Tuple<int,int> actualValue = twoSum.FindTwoSum(numbers, 12);
            Tuple<int,int> expectedTuple = new Tuple<int,int>(3,9);
            Assert.AreEqual(actualValue, expectedTuple);
        }

        [TestMethod]
        public void FindTwoSumReturnsNullWhenNoMatches()
        {
            List<int> numbers = new List<int>() { 1, 3, 5, 7, 9 };
            Tuple<int, int> actualValue = twoSum.FindTwoSum(numbers, 21);
            Assert.IsNull(actualValue);
        }

        [TestMethod]
        public void FindTwoSumReturnsNullOnEmptyList()
        {
            List<int> numbers = new List<int>();
            Assert.IsNull(twoSum.FindTwoSum(numbers, 12));
        }

        [TestMethod]
        public void FindTwoSumGreedyFindsFirstMatchingPair()
        {
            List<int> numbers = new List<int>() { 1, 3, 5, 7, 9 };
            Tuple<int, int> actualValue = twoSum.FindTwoSumGreedy(numbers, 12);
            Tuple<int, int> expectedTuple = new Tuple<int, int>(3, 9);
            Assert.AreEqual(actualValue, expectedTuple);
        }

        [TestMethod]
        public void FindTwoSumGreedyFindsFirstMatchingPairWhenLastIsMatch()
        {
            List<int> numbers = new List<int>() { 1, 9, 6, 7, 3 };
            Tuple<int, int> actualValue = twoSum.FindTwoSumGreedy(numbers, 12);
            Tuple<int, int> expectedTuple = new Tuple<int, int>(9, 3);
            Assert.AreEqual(actualValue, expectedTuple);
        }

        [TestMethod]
        public void FindTwoSumGreedyReturnsNullWhenNoMatches()
        {
            List<int> numbers = new List<int>() { 1, 3, 5, 7, 9 };
            Tuple<int, int> actualValue = twoSum.FindTwoSumGreedy(numbers, 21);
            Assert.IsNull(actualValue);
        }

        [TestMethod]
        public void FindTwoSumGreedyReturnsNullOnEmptyList()
        {
            List<int> numbers = new List<int>();
            Assert.IsNull(twoSum.FindTwoSumGreedy(numbers, 12));
        }

    }
}
