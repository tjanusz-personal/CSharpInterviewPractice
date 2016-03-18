using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Collections.Generic;
using System.Collections;

namespace InterviewPracticeTest
{
    [TestClass]
    public class FizzBuzzTest
    {
        private FizBuzz buzz;

        [TestInitialize]
        public void setup()
        {
            buzz = new FizBuzz();
        }

        [TestMethod]
        public void TestGetNumberReturnsFizzBuzzCorrectly()
        {
            List<int> multiplesOfThree = new List<int> { 15, 30, 45, 60, 75, 90 };
            multiplesOfThree.ForEach(x =>
            {
                Assert.AreEqual(buzz.getNumber(x), "FizzBuzz");
            });
        }

        [TestMethod]
        public void TestGetNumberReturnsFizzCorrectly()
        {
            List<int> multiplesOfThree = new List<int> { 3, 6, 9, 12, 18, 21, 24, 27, 33, 36, 39, 42, 48, 51 };
            multiplesOfThree.ForEach( x => {
                Assert.AreEqual(buzz.getNumber(x), "Fizz");
            });
        }

        [TestMethod]
        public void TestGetNumberReturnsBuzzCorrectly()
        {
            List<int> multiplesOfFive = new List<int> { 5, 10, 20, 25, 35, 40, 50, 55, 65, 70, 80, 85, 95 };
            multiplesOfFive.ForEach(x =>
            {
                Assert.AreEqual(buzz.getNumber(x), "Buzz");
            });
        }

        [TestMethod]
        public void TestGetNumberReturnsNonFizzBuzzNumbersCorrectly()
        {
            List<int> multiplesOfFive = new List<int> { 0, 1, 2, 4, 7, 8, 11, 13, 14, 16, 17, 19, 22 };
            multiplesOfFive.ForEach(x =>
            {
                Assert.AreEqual(x.ToString(), buzz.getNumber(x));
            });
        }
    }
}
