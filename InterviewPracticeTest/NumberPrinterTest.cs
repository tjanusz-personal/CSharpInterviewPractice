using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewPractice;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPracticeTest
{
    [TestClass]
    public class NumberPrinterTest
    {
        private NumberPrinter printer;

        [TestInitialize]
        public void setup()
        {
            printer = new NumberPrinter();
        }

        [TestMethod]
        public void GetNumbersUsingWhereReturnsOnlyNumbersFromString()
        {
            String actual = printer.GetNumbersUsingWhere("Hello12This3");
            Assert.AreEqual("123", actual);
        }

        [TestMethod]
        public void GetNumbersUsingForEachLoopReturnsOnlyNumbersFromString()
        {
            String actual = printer.GetNumbersUsingForEachLoop("Hello12This3");
            Assert.AreEqual("123", actual);
        }

        [TestMethod]
        public void GetNumbersUsingForLoopReturnsOnlyNumbersFromString()
        {
            String actual = printer.GetNumbersUsingForLoop("Hello12This3");
            Assert.AreEqual("123", actual);
        }

        [TestMethod]
        public void GetNumbersUsingLinqReturnsOnlyNumbersFromString()
        {
            String actual = printer.GetNumbersUsingLinq("Hello12This3");
            Assert.AreEqual("123", actual);
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithMatchingWordsRegardlessOfCase()
        {
            int actual = printer.CountWordsInString("Hello", "Hello Hello Helll HELLO To You");
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithNoMatchingWords()
        {
            int actual = printer.CountWordsInString("HelloX", "Hello Hello Helll To You");
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void CountWordsInStringReturnsCorrectCountWithSingleString()
        {
            int actual = printer.CountWordsInString("Hello", "HelloHelloHelllToYou");
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void SortWordsAlphabeticallyCorrectlyWorks()
        {
            String sortedResult = printer.SortWordsAlphabetically("AAA DDD CCC BBB");
            Assert.AreEqual("AAA BBB CCC DDD", sortedResult);
        }

        [TestMethod]
        public void SentanceContainsWordsReturnsCorrectResults()
        {
            string[] wordsToFind = { "AAA", "CCC" };
            Boolean result = printer.SentanceContainsWords("AAA BBB CCC. AAA BBB DDD.", wordsToFind);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntersectOnTwoEnumerablesExamples()
        {
            string[] someWords = { "AAA", "CCC" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsInCommon = someWords.Intersect(moreWords);
            Assert.AreEqual(1, stringsInCommon.Count());
            Assert.IsTrue(stringsInCommon.Any());
            Assert.AreEqual("AAA", stringsInCommon.First());

            string[] someWords2 = { "AAA", "CCC", "DDD", "AAA" };
            stringsInCommon = someWords2.Intersect(moreWords);
            Assert.AreEqual(2, stringsInCommon.Count());
            string[] matchedArray = stringsInCommon.ToArray();
            CollectionAssert.AreEqual(moreWords, matchedArray);
        }

        [TestMethod]
        public void ExceptOnTwoEnumerablesExamples()
        {
            string[] someWords = { "AAA", "CCC", "DDD", "EEE" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsNotInCommon = someWords.Except(moreWords);
            Assert.AreEqual(2, stringsNotInCommon.Count());
            Assert.IsTrue(stringsNotInCommon.Any());
            Assert.AreEqual("CCC", stringsNotInCommon.First());
        }

    }
}
