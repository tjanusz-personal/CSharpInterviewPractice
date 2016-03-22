using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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

        private void runGetStringValueScenario(List<int> numbersToVerify, String valueToAssert)
        {
            numbersToVerify.ForEach(x =>
            {
                Assert.AreEqual(buzz.GetStringValue(x), valueToAssert);
            });

        }

        [TestMethod]
        public void TestGetStringValueReturnsFizzBuzzValuesCorrectly2()
        {
            List<int> numbersDivisibleBy5And3 = Enumerable.Range(1, 100).Where(x => (x % 3) == 0 && (x % 5) == 0).ToList();
            Assert.AreEqual(6, numbersDivisibleBy5And3.Count);
            runGetStringValueScenario(numbersDivisibleBy5And3, "FizzBuzz");
        }

        [TestMethod]
        public void TestGetStringValueReturnsFizzCorrectly()
        {
            List<int> numbersDivisibleBy3Only = Enumerable.Range(1, 100).Where(x => (x % 3) == 0 && (x % 5) != 0).ToList();
            Assert.AreEqual(27, numbersDivisibleBy3Only.Count);
            runGetStringValueScenario(numbersDivisibleBy3Only, "Fizz");
        }

        [TestMethod]
        public void TestGetStringReturnsBuzzCorrectly()
        {
            List<int> numbersDivisibleBy5Only = Enumerable.Range(1, 100).Where(x => (x % 5) == 0 && (x % 3) != 0).ToList();
            Assert.AreEqual(14, numbersDivisibleBy5Only.Count);
            runGetStringValueScenario(numbersDivisibleBy5Only, "Buzz");
        }

        [TestMethod]
        public void TestGetStringReturnsNonFizzBuzzNumbersCorrectly()
        {
            List<int> numbersNotDivisibleBy5Or3 = Enumerable.Range(1, 100).Where(x => (x % 5) != 0 && (x % 3) != 0).ToList();
            Assert.AreEqual(53, numbersNotDivisibleBy5Or3.Count);
            numbersNotDivisibleBy5Or3.ForEach(x =>
            {
                Assert.AreEqual(x.ToString(), buzz.GetStringValue(x));
            });
        }
    }
}
